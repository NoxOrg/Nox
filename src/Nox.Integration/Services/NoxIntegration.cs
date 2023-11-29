using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Elastic.Apm.Api;
using ETLBox;
using ETLBox.DataFlow;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Abstractions.Adapters;
using Nox.Integration.Constants;
using Nox.Integration.Exceptions;
using Nox.Integration.Extensions.Send;
using Nox.Solution;
using Nox.Solution.Extensions;

namespace Nox.Integration.Services;

internal sealed class NoxIntegration: INoxIntegration
{
    private readonly ILogger _logger;
    private readonly INoxIntegrationDbContextFactory _dbContextFactory;
    
    public string Name { get; }
    public string? Description { get; }
    public IntegrationSchedule? Schedule { get; }
    public IntegrationMergeType MergeType { get; }
    
    public IntegrationTransformType TransformType { get; }
    public INoxReceiveAdapter? ReceiveAdapter { get; set; }
    public INoxSendAdapter? SendAdapter { get; set; }
    public List<string>? TargetIdColumns { get; private set; } = null;
    public List<string>? TargetDateColumns { get; private set; } = null;

    public List<string>? SourceFilterColumns { get; set; }

    public NoxIntegration(ILogger logger, Solution.Integration definition, INoxIntegrationDbContextFactory dbContextFactory)
    {
        _logger = logger;
        _dbContextFactory = dbContextFactory;
        Name = definition.Name;
        Schedule = definition.Schedule;
        Description = definition.Description;
        MergeType = definition.MergeType;
        TransformType = definition.TransformationType;
        AddSourceFilterColumns(definition.Source);
        AddTargetWatermark(definition.Target);
    }
    
    public async Task ExecuteAsync(ITransaction apmTransaction, INoxCustomTransformHandler? handler = null)
    {
        var lastMergeStates = await GetMergeStates();
        switch (MergeType)
        {
            case IntegrationMergeType.MergeNew:
                await apmTransaction.CaptureSpan("MergeNew", ApiConstants.ActionExec, async () => await ExecuteMergeNew(handler));
                break;
            case IntegrationMergeType.AddNew:
                await apmTransaction.CaptureSpan("AddNew", ApiConstants.ActionExec, async() => await ExecuteAddNew(handler));
                break;
        }
    }

    private async Task ExecuteMergeNew(INoxCustomTransformHandler? handler)
    {
        var source = ReceiveAdapter!.DataFlowSource;
        //todo: filter source using merge state


        IDataFlowSource<ExpandoObject>? transformSource = null;
        
        if (TransformType == IntegrationTransformType.CustomTransform)
        {
            if (handler == null) throw new NoxIntegrationException("Cannot execute custom transform, handler not registered.");
            var rowTransform = new RowTransformation<ExpandoObject, ExpandoObject>(sourceRecord => handler.Invoke(sourceRecord));
            transformSource =  source.LinkTo(rowTransform);
        }
        
        CustomDestination? postProcessDestination;
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

        var unChanged = 0;
        var inserts = 0;
        var updates = 0;

        postProcessDestination.WriteAction = (row, _) =>
        {
            var record = (IDictionary<string, object?>)row;
            if ((ChangeAction)record["ChangeAction"]! == ChangeAction.Insert)
            {
                inserts++;
                //Fire events
                //if(entityCreatedMsg is not null) SendChangeEvent(loader, row, entityCreatedMsg, NoxEventSource.EtlMerge);
                //Update merge state
                //UpdateMergeStates(lastMergeDateTimeStampInfo, record);
            }
            else if ((ChangeAction)record["ChangeAction"]! == ChangeAction.Update)
            {
                updates++;
                //Fire events
                //if (entityUpdatedMsg is not null) SendChangeEvent(loader, row, entityUpdatedMsg, NoxEventSource.EtlMerge);
                //Update merge state
                //UpdateMergeStates(lastMergeDateTimeStampInfo, record);
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
            _logger.LogCritical("Failed to run Merge for integration: {integrationName}", Name);
            _logger.LogError("{message}", ex.Message);
            throw;
        }  

        //Log analytics
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
            foreach (var filterColumn in SourceFilterColumns)
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
        
        return result;
    }

    private async Task<DateTime> GetLastMergeTimestamp(NoxIntegrationDbContext dbContext, string filterName)
    {
        var result = IntegrationContextConstants.MinSqlMergeData;
        var timestamp = await dbContext.MergeStates!.FirstOrDefaultAsync(ts =>
            ts.Integration!.Equals(Name, StringComparison.OrdinalIgnoreCase) &&
            ts.Property!.Equals(filterName, StringComparison.OrdinalIgnoreCase));
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
            ts.Integration!.Equals(Name, StringComparison.OrdinalIgnoreCase) &&
            ts.Property!.Equals(IntegrationContextConstants.DefaultFilterProperty));
        if (timestamp != null) dbContext.MergeStates!.Remove(timestamp);
    }

    private async Task RemoveDefaultMergeTimestamp(NoxIntegrationDbContext dbContext)
    {
        var timestamps = await dbContext.MergeStates!.Where(ts =>
            ts.Integration!.Equals(Name, StringComparison.OrdinalIgnoreCase) &&
            !ts.Property!.Equals(IntegrationContextConstants.DefaultFilterProperty)).ToListAsync();
        if (timestamps.Any())
        {
            dbContext.MergeStates!.RemoveRange(timestamps);
        }
    }
    
}