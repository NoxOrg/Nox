using System.Dynamic;
using Elastic.Apm.Api;
using ETLBox;
using ETLBox.DataFlow;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions.Constants;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;
using Nox.Integration.Exceptions;
using Nox.Integration.Extensions;
using Nox.Integration.Extensions.Send;
using Nox.Solution;

namespace Nox.Integration.Services;

internal sealed class NoxIntegration: INoxIntegration
{
    private readonly ILogger _logger;
    private readonly INoxIntegrationDbContextFactory _dbContextFactory;
    private IntegrationMergeStates? _mergeStates;
    private readonly IPublisher _publisher;
    private readonly EtlExecuteCompletedEvent? _completedEvent;
    private readonly EtlRecordCreatedEvent<IEtlEventDto>? _createdEvent;
    private readonly EtlRecordUpdatedEvent<IEtlEventDto>? _updatedEvent;
    
    public string Name { get; }
    public string? Description { get; }
    public IntegrationSchedule? Schedule { get; }
    public IntegrationMergeType MergeType { get; }
    
    public IntegrationTransformType TransformType { get; }
    public INoxReceiveAdapter? ReceiveAdapter { get; set; }
    public INoxSendAdapter? SendAdapter { get; set; }
    
    public Type? DtoType { get; set; }
    public List<string>? TargetIdColumns { get; private set; } = null;
    public List<string>? TargetDateColumns { get; private set; } = null;

    public List<string>? SourceFilterColumns { get; set; }

    public NoxIntegration(
        ILogger logger, 
        Solution.Integration definition, 
        INoxIntegrationDbContextFactory dbContextFactory, 
        IPublisher publisher,
        EtlRecordCreatedEvent<IEtlEventDto>? createdEvent,
        EtlRecordUpdatedEvent<IEtlEventDto>? updatedEvent,
        EtlExecuteCompletedEvent? completedEvent)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
        _publisher = publisher;
        Name = definition.Name;
        Schedule = definition.Schedule;
        Description = definition.Description;
        MergeType = definition.MergeType;
        TransformType = definition.TransformationType;
        AddSourceFilterColumns(definition.Source);
        AddTargetWatermark(definition.Target);
        _createdEvent = createdEvent;
        _updatedEvent = updatedEvent;
        _completedEvent = completedEvent;
    }
    
    public async Task ExecuteAsync(ITransaction apmTransaction, INoxCustomTransformHandler? handler = null)
    {
        try
        {
            _mergeStates = await GetMergeStates();
            if (SourceFilterColumns != null && SourceFilterColumns.Any())
            {
                ReceiveAdapter!.ApplyFilter(SourceFilterColumns, _mergeStates);
            }

            switch (MergeType)
            {
                case IntegrationMergeType.MergeNew:
                    await apmTransaction.CaptureSpan(MergeType.ToString(), ApiConstants.ActionExec, async () => await ExecuteMergeNew(handler));
                    break;
                case IntegrationMergeType.AddNew:
                    await apmTransaction.CaptureSpan(MergeType.ToString(), ApiConstants.ActionExec, async () => await ExecuteAddNew(handler));
                    break;
            }

            await SetLastMergeStates();
            _logger.LogInformation("{0}. Component {1}. Action {2}. Status {3}.", Name, "NoxIntegration", MergeType.ToString(), "success");
        }
        catch (Exception ex)
        {
            _logger.LogError("{0}. Component {1}. Action {2}. Status {3}. Error {4}", Name, "NoxIntegration", MergeType.ToString(), "error", ex.ToString());
        }
    }

    private async Task ExecuteMergeNew(INoxCustomTransformHandler? handler)
    {
        var unChanged = 0;
        var inserts = 0;
        var updates = 0;

        var source = ReceiveAdapter!.DataFlowSource;

        IDataFlowSource<ExpandoObject>? transformSource = null;

        if (TransformType == IntegrationTransformType.CustomTransform)
        {
            if (handler == null) throw new NoxIntegrationException("Cannot execute custom transform, handler not registered.");
            var rowTransform = new RowTransformation<ExpandoObject, ExpandoObject>(sourceRecord => handler.Invoke(sourceRecord));
            transformSource = source.LinkTo(rowTransform);
        }
        
        var postProcessDestination = new CustomDestination();
        switch (SendAdapter!.AdapterType)
        {
            case IntegrationTargetAdapterType.DatabaseTable:
                if (transformSource != null)
                {
                    postProcessDestination = transformSource.LinkToDatabaseTable((INoxDatabaseSendAdapter)SendAdapter, TargetIdColumns, TargetDateColumns);
                }
                else
                {
                    postProcessDestination = source.LinkToDatabaseTable((INoxDatabaseSendAdapter)SendAdapter, TargetIdColumns, TargetDateColumns);
                }

                break;
            default:
                throw new NotImplementedException($"Send adapter type: {Enum.GetName(SendAdapter!.AdapterType)} has not been implemented!");
        }

        postProcessDestination.WriteAction = (row, _) =>
        {
            var record = (IDictionary<string, object?>)row;
            if ((ChangeAction)record["ChangeAction"]! == ChangeAction.Insert)
            {
                inserts++;
                SendCreatedEvent(record).ConfigureAwait(false);
                UpdateMergeStates(record);
            }
            else if ((ChangeAction)record["ChangeAction"]! == ChangeAction.Update)
            {
                updates++;
                SendUpdatedEvent(record).ConfigureAwait(false);
                UpdateMergeStates(record);
            }
            else if ((ChangeAction)record["ChangeAction"]! == ChangeAction.Exists)
            {
                unChanged++;
            }
        };

        try
        {
            await Network.ExecuteAsync(source);
        }
        catch (Exception ex)
        {
            _logger.LogCritical("Failed to execute MergeNew for integration: {integrationName}", Name);
            _logger.LogError("{message}", ex.Message);
            throw;
        }

        await SendExecuteCompletedEvent(inserts, updates, unChanged);
        LogMergeAnalytics(inserts, updates, unChanged);
    }

    private Task ExecuteAddNew(INoxCustomTransformHandler? handler)
    {
        return Task.CompletedTask;
    }

    private void AddSourceFilterColumns(IntegrationSource source)
    {
        if (source.Watermark == null) return;
        var watermark = source.Watermark;
        if (watermark.DateColumns != null && watermark.DateColumns.Any())
        {
            SourceFilterColumns = new List<string>();
            foreach (var filterColumn in watermark.DateColumns)
            {
                SourceFilterColumns.Add(filterColumn);
            }
        }
    }

    private void AddTargetWatermark(IntegrationTarget target)
    {
        if (target.TableOptions?.Watermark == null) return;
        
        var watermark = target.TableOptions.Watermark;
        if (watermark.SequentialKeyColumns != null && watermark.SequentialKeyColumns.Any())
        {
            TargetIdColumns = new List<string>();
            foreach (var keyColumn in watermark.SequentialKeyColumns)
            {
                TargetIdColumns.Add(keyColumn);
            }
        }
        if (watermark.DateColumns != null && watermark.DateColumns.Any())
        {
            TargetDateColumns = new List<string>();
            foreach (var dateColumn in watermark.DateColumns)
            {
                TargetDateColumns.Add(dateColumn);
            }
        }
    }

    private async Task<IntegrationMergeStates> GetMergeStates()
    {
        var result = new IntegrationMergeStates();
        var dbContext = _dbContextFactory.CreateContext();
        
        var addedFilterColumn = false;

        if (SourceFilterColumns != null && SourceFilterColumns.Any())
        {
            addedFilterColumn = true;
            
            foreach(var filterColumn in SourceFilterColumns)
            {
                var lastMergeTimestamp = await GetLastMergeTimestamp(dbContext, filterColumn);
                result[filterColumn] = new IntegrationMergeState
                {
                    Integration = Name,
                    Property = filterColumn,
                    LastDateLoadedUtc = lastMergeTimestamp
                };
            }   
        }

        if (!addedFilterColumn)
        {
            var lastMergeTimestamp = await GetLastMergeTimestamp(dbContext, IntegrationContextConstants.DefaultFilterProperty);
            result[IntegrationContextConstants.DefaultFilterProperty] = new IntegrationMergeState
            {
                Integration = Name,
                Property = IntegrationContextConstants.DefaultFilterProperty,
                LastDateLoadedUtc = lastMergeTimestamp
            };
            await RemoveNonDefaultMergeTimestamps(dbContext);
        }
        else
        {
            await RemoveDefaultMergeTimestamp(dbContext);
        }

        await dbContext.SaveChangesAsync();
        return result;
    }

    private async Task<DateTime> GetLastMergeTimestamp(NoxIntegrationDbContext dbContext, string filterName)
    {
        var result = IntegrationContextConstants.MinSqlMergeDate;
        var timestamp = await dbContext.MergeStates!.FirstOrDefaultAsync(ts =>
            ts.Integration!.Equals(Name) &&
            ts.Property!.Equals(filterName));
        if (timestamp != null)
        {
            result = timestamp.LastDateLoadedUtc;
        }
        else
        {
            timestamp = new IntegrationMergeState
            {
                Integration = Name,
                Property = filterName,
                LastDateLoadedUtc = result,
                IsUpdated = true
            };
            await dbContext.MergeStates!.AddAsync(timestamp);
        }
        return result;
    }

    private async Task RemoveNonDefaultMergeTimestamps(NoxIntegrationDbContext dbContext)
    {
        var timestamp = await dbContext.MergeStates!.FirstOrDefaultAsync(ts =>
            ts.Integration!.Equals(Name) &&
            !ts.Property!.Equals(IntegrationContextConstants.DefaultFilterProperty));
        if (timestamp != null) dbContext.MergeStates!.Remove(timestamp);
    }

    private async Task RemoveDefaultMergeTimestamp(NoxIntegrationDbContext dbContext)
    {
        var timestamps = await dbContext.MergeStates!.Where(ts =>
            ts.Integration!.Equals(Name) &&
            ts.Property!.Equals(IntegrationContextConstants.DefaultFilterProperty)).ToListAsync();
        if (timestamps.Any())
        {
            dbContext.MergeStates!.RemoveRange(timestamps);
        }
    }

    private void UpdateMergeStates(IDictionary<string, object?> record)
    {
        if (_mergeStates == null) return;
        foreach (var filterColumn in _mergeStates.Keys)
        {
            if (record.TryGetValue(filterColumn, out var filterColumnValue))
            {
                if (filterColumnValue == null) continue;
                
                if (DateTime.TryParse(filterColumnValue.ToString(), out var fieldValue))
                {
                    if (fieldValue > _mergeStates[filterColumn].LastDateLoadedUtc)
                    {
                        var changeEntry = _mergeStates[filterColumn];
                        changeEntry.LastDateLoadedUtc = fieldValue;
                        changeEntry.IsUpdated = true;
                        _mergeStates[filterColumn] = changeEntry;
                    }
                }
            }
            else
            {
                if (record.TryGetValue("ChangeDate", out var changeDate))
                {
                    if (changeDate == null) continue;
                    
                    if (DateTime.TryParse(changeDate.ToString(), out var changeDateValue))
                    {
                        var changeEntry = _mergeStates[IntegrationContextConstants.DefaultFilterProperty];
                        changeEntry.LastDateLoadedUtc = changeDateValue.ToUniversalTime();
                        changeEntry.IsUpdated = true;
                        _mergeStates[IntegrationContextConstants.DefaultFilterProperty] = changeEntry;    
                    }
                }
            }
        }
    }

    private async Task SetLastMergeStates()
    {
        if (_mergeStates == null) return;
        
        var dbContext = _dbContextFactory.CreateContext();
        foreach (var (filterColumn, mergeState) in _mergeStates)
        {
            if (mergeState.IsUpdated)
            {
                await SetLastMergeState(dbContext, filterColumn, mergeState.LastDateLoadedUtc);
            }
        }

        await dbContext.SaveChangesAsync();
    }

    private async Task SetLastMergeState(NoxIntegrationDbContext dbContext, string propertyName, DateTime lastMergeDateTime)
    {
        var timestamp = await dbContext.MergeStates!.SingleAsync(ts =>
            ts.Integration!.Equals(Name) &&
            ts.Property!.Equals(propertyName));
        timestamp.LastDateLoadedUtc = lastMergeDateTime;
    }

    private void LogMergeAnalytics(int inserts, int updates, int unChanged, bool logUpdates = true)
    {
        var lastTimestamp = IntegrationContextConstants.MinSqlMergeDate;

        if (_mergeStates != null)
        {
            var loadDates = _mergeStates
                .Values
                .Select(v => v.LastDateLoadedUtc)
                .ToList();

            if (loadDates.Any())
            {
                lastTimestamp = loadDates.Max();
            }
        }

        if ((inserts == 0 && updates == 0) || (inserts == 0 && logUpdates == false))
        {
            if (unChanged > 0)
            {
                _logger.LogInformation("{0}. Component {1}. Action {2}. Documents {3}. last merge at {4}", Name, "NoxIntegration", "nochanges", unChanged, lastTimestamp);
            }
            else
            {
                _logger.LogInformation("{0}. Component {1}. Action {2}. Documents {3}. last merge at {4}", Name, "NoxIntegration", "nochanges", 0, lastTimestamp);
            }

            return;
        }

        if (_mergeStates != null)
        {
            var changes = _mergeStates
                .Values
                .Where(ms => ms.IsUpdated)
                .Select(ms => ms.LastDateLoadedUtc)
                .ToList();
            if (changes.Any())
            {
                lastTimestamp = changes.Max();
            }
            
            _logger.LogInformation("{0}. Component {1}. Action {2}. Documents {3}. last merge at {4}", Name, "NoxIntegration", "insert", inserts, lastTimestamp);
            _logger.LogInformation("{0}. Component {1}. Action {2}. Documents {3}. last merge at {4}", Name, "NoxIntegration", "update", updates, lastTimestamp);
        }
    }
    
    private async Task SendCreatedEvent(IDictionary<string, object?> record)
    {
        if (_createdEvent == null) return;
        _createdEvent.SetDto(record.ResolvePayload(_createdEvent));
        await _publisher.Publish(_createdEvent);
    }

    private async Task SendUpdatedEvent(IDictionary<string, object?> record)
    {
        if (_updatedEvent == null) return;
        _updatedEvent.SetDto(record.ResolvePayload(_updatedEvent));
        await _publisher.Publish(_updatedEvent);
    }
    
    private async Task SendExecuteCompletedEvent(int inserts, int updates, int unChanged)
    {
        if (_completedEvent == null) return;
        _completedEvent.SetDto(new EtlExecuteCompletedDto
        {
            Inserts = inserts,
            Updates = updates,
            Unchanged = unChanged
        });
        await _publisher.Publish(_completedEvent);
    }

}