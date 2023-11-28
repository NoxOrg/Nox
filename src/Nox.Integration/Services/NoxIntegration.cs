using System.Dynamic;
using ETLBox;
using ETLBox.DataFlow;
using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Abstractions.Adapters;
using Nox.Integration.Exceptions;
using Nox.Integration.Extensions.Send;

namespace Nox.Integration.Services;

internal sealed class NoxIntegration: INoxIntegration
{
    private readonly ILogger _logger;
    
    public string Name { get; }
    public string? Description { get; }
    public IntegrationMergeType MergeType { get; }
    
    public IntegrationTransformType TransformType { get; }
    public INoxReceiveAdapter? ReceiveAdapter { get; set; }
    public INoxSendAdapter? SendAdapter { get; set; }
    public List<string>? IdColumns { get; } = null;
    public List<string>? DateColumns { get; } = null;

    public NoxIntegration(ILogger logger, Solution.Integration definition)
    {
        _logger = logger;
        Name = definition.Name;
        Description = definition.Description;
        MergeType = definition.MergeType;
        TransformType = definition.TransformationType;

        if (definition.Target.TableOptions?.Watermark == null) return;
        
        var watermark = definition.Target.TableOptions.Watermark;
        if (watermark.SequentialKeyColumns != null && watermark.SequentialKeyColumns.Any())
        {
            IdColumns = new List<string>();
            foreach (var keyColumn in watermark.SequentialKeyColumns)
            {
                IdColumns.Add(keyColumn);
            }
        }
        if (watermark.DateColumns != null && watermark.DateColumns.Any())
        {
            DateColumns = new List<string>();
            foreach (var dateColumn in watermark.DateColumns)
            {
                DateColumns.Add(dateColumn);
            }
        }
    }
    
    public async Task<bool> ExecuteAsync(INoxCustomTransformHandler? handler = null)
    {
        var result = false;

        switch (MergeType)
        {
            case IntegrationMergeType.MergeNew:
                result = await ExecuteMergeNew(handler);
                break;
            case IntegrationMergeType.AddNew:
                result = await ExecuteAddNew(handler);
                break;
        }

        return result;
    }

    private async Task<bool> ExecuteMergeNew(INoxCustomTransformHandler? handler)
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
                    postProcessDestination = transformSource.LinkToDatabaseTable((INoxDatabaseSendAdapter)SendAdapter, IdColumns, DateColumns);    
                }
                else
                {
                    postProcessDestination = source.LinkToDatabaseTable((INoxDatabaseSendAdapter)SendAdapter, IdColumns, DateColumns);    
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

        return true;

    }

    private Task<bool> ExecuteAddNew(INoxCustomTransformHandler? handler)
    {
        return Task.FromResult(true);
    }
}