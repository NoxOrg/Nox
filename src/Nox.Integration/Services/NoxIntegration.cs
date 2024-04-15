using System.Dynamic;
using System.Reflection;
using Elastic.Apm.Api;
using ETLBox;
using ETLBox.DataFlow;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions.Constants;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;
using Nox.Integration.Adapters;
using Nox.Integration.Extensions;
using Nox.Integration.Helpers;
using Nox.Solution;

namespace Nox.Integration.Services;

internal sealed class NoxIntegration<TSource, TTarget>: INoxIntegration<TSource, TTarget>
    
{
    private readonly ILogger _logger;
    private readonly INoxIntegrationDbContextFactory _dbContextFactory;
    private IntegrationMergeStates? _mergeStates;
    private readonly IPublisher _publisher;
    private readonly INoxSourceAdapter<TSource> _sourceAdapter;
    private readonly INoxTargetAdapter<TTarget> _targetAdapter;
    
    private readonly EtlExecuteCompletedEvent? _completedEvent;
    private readonly EtlRecordCreatedEvent<IEtlEventDto>? _createdEvent;
    private readonly EtlRecordUpdatedEvent<IEtlEventDto>? _updatedEvent;
    
    public string Name { get; }
    public string? Description { get; }
    public IntegrationSchedule? Schedule { get; }
    public IntegrationMergeType MergeType { get; }
    
    public IntegrationTransformType TransformType { get; }
    
    public Type? DtoType { get; set; }
    public List<string>? TargetIdColumns { get; private set; } = null;
    public List<string>? TargetDateColumns { get; private set; } = null;

    public List<string>? SourceFilterColumns { get; set; }

    public NoxIntegration(
        ILogger logger, 
        Solution.Integration definition, 
        INoxIntegrationDbContextFactory dbContextFactory, 
        IPublisher publisher,
        INoxSourceAdapter<TSource> sourceAdapter,
        INoxTargetAdapter<TTarget> targetAdapter,
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
        TransformType = definition.Transformation.Type;
        _sourceAdapter = sourceAdapter;
        _targetAdapter = targetAdapter;
        AddSourceFilterColumns(definition.Source);
        AddTargetWatermark(definition.Target);
        _createdEvent = createdEvent;
        _updatedEvent = updatedEvent;
        _completedEvent = completedEvent;
    }
    
    public async Task ExecuteAsync(ITransaction apmTransaction, INoxTransform<TSource, TTarget>? transform)
    {
        try
        {
            _mergeStates = await GetMergeStates();
            if (SourceFilterColumns != null && SourceFilterColumns.Any())
            {
                _sourceAdapter.ApplyFilter(SourceFilterColumns, _mergeStates);
            }

            await apmTransaction.CaptureSpan(MergeType.ToString(), ApiConstants.ActionExec, async () => await ExecuteInternal(transform));

            await SetLastMergeStates();
            _logger.LogInformation("{0}. Component {1}. Action {2}. Status {3}.", Name, "NoxIntegration", MergeType.ToString(), "success");
        }
        catch (Exception ex)
        {
            _logger.LogError("{0}. Component {1}. Action {2}. Status {3}. Error {4}", Name, "NoxIntegration", MergeType.ToString(), "error", ex.ToString());
            throw;
        }
    }

    //Execute with no transform
    private async Task ExecuteInternal(INoxTransform<TSource, TTarget>? transform)
    {
        try
        {
            var source = _sourceAdapter.DataFlowSource;
            switch (_targetAdapter.AdapterType)
            {
                case IntegrationTargetAdapterType.DatabaseTable:
                    var dbAdapter = (INoxDatabaseTargetAdapter<TTarget>)_targetAdapter;
                    var tableTarget = dbAdapter.TableTarget!
                        .WithMergeFields(TargetIdColumns, TargetDateColumns);
                    var metricsTarget = dbAdapter.MetricsTarget;
                    dbAdapter.OnInsert += TargetAdapterOnInsert;
                    dbAdapter.OnUpdate += TargetAdapterOnUpdate;

                    if (transform == null)
                    {
                        var dynamicSource = source as IDataFlowExecutableSource<ExpandoObject>;
                        var dynamicTarget = tableTarget as IDataFlowDestination<ExpandoObject>;
                        var dynamicMetrics = metricsTarget as CustomDestination<ExpandoObject>;
                        dynamicSource!
                            .LinkTo(dynamicTarget)
                            .LinkTo(dynamicMetrics);
                        await Network.ExecuteAsync(dynamicSource);
                    }
                    else
                    {
                        var rowTransform = new RowTransformation<TSource, TTarget>(record => transform.Invoke(record));
                        source
                            .LinkTo<TTarget>(rowTransform)
                            .LinkTo<TTarget>(tableTarget)
                            .LinkTo(metricsTarget);
                        await Network.ExecuteAsync(source);
                    }

                    break;
                default:
                    throw new NotImplementedException($"Target adapter type: {Enum.GetName(_targetAdapter.AdapterType)} has not been implemented!");
            }

            await PostExecuteAction(_targetAdapter.Metrics);
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, "Failed to execute integration: {integrationName}", Name);
            _logger.LogError("{message}", ex.Message);
            throw;
        }
    }
    
    private void TargetAdapterOnInsert(object sender, MetricsEventArgs args)
    {
        TargetCreatedEvent(args.DataRecord).ConfigureAwait(false);
        UpdateMergeStates(args.DataRecord);
    }
    
    private void TargetAdapterOnUpdate(object sender, MetricsEventArgs args)
    {
        TargetUpdatedEvent(args.DataRecord).ConfigureAwait(false);
        UpdateMergeStates(args.DataRecord);
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
                result[filterColumn] = new MergeState
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
            result[IntegrationContextConstants.DefaultFilterProperty] = new MergeState
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
            timestamp = new MergeState
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

    private void UpdateMergeStates(TTarget record)
    {
        if (_mergeStates == null) return;
        var recordProperties = record!.GetType().GetProperties();
        
        foreach (var dateColumn in _mergeStates.Keys)
        {
            if (ObjectHelpers.TryGetDateTimePropertyValue(record, dateColumn, recordProperties, out var mergeDate))
            {
                if (mergeDate != null && mergeDate > _mergeStates[dateColumn].LastDateLoadedUtc)
                {
                    var changeEntry = _mergeStates[dateColumn];
                    changeEntry.LastDateLoadedUtc = mergeDate.Value;
                    changeEntry.IsUpdated = true;
                    _mergeStates[dateColumn] = changeEntry;
                }
            }
            else
            {
                if (ObjectHelpers.TryGetDateTimePropertyValue(record, "ChangeDate", recordProperties, out var changeDate))
                {
                    var changeEntry = _mergeStates[IntegrationContextConstants.DefaultFilterProperty];
                    changeEntry.LastDateLoadedUtc = changeDate!.Value.ToUniversalTime();
                    changeEntry.IsUpdated = true;
                    _mergeStates[IntegrationContextConstants.DefaultFilterProperty] = changeEntry;    
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

    private async Task PostExecuteAction(TargetAdapterMetrics metrics, bool logUpdates = true)
    {
        const string component = "NoxIntegration";
        
        if (_completedEvent != null)
        {
            _completedEvent.SetDto(new EtlExecuteCompletedDto
            {
                Inserts = metrics.Inserts,
                Updates = metrics.Updates,
                Unchanged = metrics.Unchanged
            });
            await _publisher.Publish(_completedEvent);
        }

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

        if ((metrics.Inserts == 0 && metrics.Updates == 0) || (metrics.Inserts == 0 && !logUpdates))
        {
            if (metrics.Unchanged > 0)
            {
                _logger.LogInformation("{name}. Component {component}. Action {action}. Documents {documents}. last merge at {timestamp}", Name, component, "nochanges", metrics.Unchanged, lastTimestamp);
            }
            else
            {
                _logger.LogInformation("{name}. Component {component}. Action {action}. Documents {documents}. last merge at {timestamp}", Name, component, "nochanges", 0, lastTimestamp);
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
            
            _logger.LogInformation("{name}. Component {component}. Action {action}. Documents {documents}. last merge at {timestamp}", Name, component, "insert", metrics.Inserts, lastTimestamp);
            _logger.LogInformation("{name}. Component {component}. Action {action}. Documents {documents}. last merge at {timestamp}", Name, component, "update", metrics.Updates, lastTimestamp);
        }
    }
    
    private async Task TargetCreatedEvent(TTarget record)
    {
        if (_createdEvent == null) return;
        _createdEvent.SetDto(record.ResolvePayload(_createdEvent));
        await _publisher.Publish(_createdEvent);
    }

    private async Task TargetUpdatedEvent(TTarget record)
    {
        if (_updatedEvent == null) return;
        _updatedEvent.SetDto(record.ResolvePayload(_updatedEvent));
        await _publisher.Publish(_updatedEvent);
    }

}