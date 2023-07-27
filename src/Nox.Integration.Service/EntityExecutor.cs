using System.Dynamic;
using ETLBox.Connection;
using ETLBox.DataFlow;
using ETLBox.DataFlow.Connectors;
using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Exceptions;
using Nox.Integration.Store;
using Nox.Solution;
using Nox.Types;

namespace Nox.Integration.Service;

public class EntityExecutor: ExecutorBase
{
    private readonly ILogger _logger;
    private readonly Solution.Integration _definition;
    private readonly IStoreService _storeService;
    private readonly IIntegrationSource _source;
    private readonly IIntegrationTarget _target;
    private readonly Entity _entity;
    
    public EntityExecutor(
        ILogger logger,
        Solution.Integration definition,
        IStoreService storeService,
        IIntegrationSource source,
        IIntegrationTarget target,
        Entity entity): base(definition)
    {
        _logger = logger;
        _storeService = storeService;
        _definition = definition;
        _source = source;
        _target = target;
        _entity = entity;
    }
    
    public async Task ExecuteAsync()
    {
        try
        {
            var targetColumns = GetEntityAttributeNames();
            var integrationId = await _storeService.ConfigureIntegrationAsync(_definition, targetColumns);
            var lastMergeDateTimeStampInfo = await _storeService.GetLastMergeStateAsync(integrationId);
            
            var destination = CreateEntityDestinationDestination();

            destination.MergeProperties.IdColumns = targetColumns.Where(k => k.IsKey).Select(k => new IdColumn { IdPropertyName = k.Name }).ToArray();
            foreach (var dateColumn in lastMergeDateTimeStampInfo)
            {
                if (targetColumns.Any(c => !c.IsKey && c.Name.Equals(dateColumn.Value.Property, StringComparison.OrdinalIgnoreCase)))
                {
                    if (destination.MergeProperties.CompareColumns == null) destination.MergeProperties.CompareColumns = new List<CompareColumn>();
                    destination.MergeProperties.CompareColumns.Add(new CompareColumn
                    {
                        ComparePropertyName = dateColumn.Value.Property
                    });
                }
            }

            var dataSource = _source.DataFlowSource();
            
            //Include all transformations
            IncludeTransformation(dataSource);
            
            dataSource.LinkTo(destination);
            var postProcessDestination = new CustomDestination();

            int inserts = 0, updates = 0, unchanged = 0;

            // Get events to fire, if any

            //TODO implement messaging
            // INoxEvent? entityCreatedMsg = null, entityUpdatedMsg = null;
            // if (loader.Messaging != null && loader.Messaging.Any())
            // {
            //     entityCreatedMsg = _messages.FindEventImplementation(entity.Name, NoxEventType.Created);
            //     entityUpdatedMsg = _messages.FindEventImplementation(entity.Name, NoxEventType.Updated);
            // }

            postProcessDestination.WriteAction = (row, _) =>
            {
                var record = (IDictionary<string, object?>)row;

                if ((ChangeAction)record["ChangeAction"]! == ChangeAction.Insert)
                {
                    inserts++;
                    //TODO implement messaging
                    //if(entityCreatedMsg is not null) SendChangeEvent(loader, row, entityCreatedMsg, NoxEventSource.EtlMerge);
                    _storeService.UpdateMergeStates(lastMergeDateTimeStampInfo, record);
                }
                else if ((ChangeAction)record["ChangeAction"]! == ChangeAction.Update)
                {
                    updates++;
                    //TODO implement messaging
                    //if (entityUpdatedMsg is not null) SendChangeEvent(loader, row, entityUpdatedMsg, NoxEventSource.EtlMerge);
                    _storeService.UpdateMergeStates(lastMergeDateTimeStampInfo, record);
                }
                else if ((ChangeAction)record["ChangeAction"]! == ChangeAction.Exists)
                {
                    _storeService.UpdateMergeStates(lastMergeDateTimeStampInfo, record);
                    unchanged++;
                }
            };

            destination.LinkTo(postProcessDestination);

            try
            {
                await Network.ExecuteAsync((DataFlowExecutableSource<ExpandoObject>)dataSource);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Failed to run Merge for Entity {entity}", _entity.Name);
                _logger.LogError("{message}", ex.Message);
                throw;
            }

            await _storeService.SetLastMergeState(integrationId, lastMergeDateTimeStampInfo);
            await _storeService.LogMergeAnalytics( integrationId, inserts, updates, unchanged, lastMergeDateTimeStampInfo);
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, ExceptionResources.ExecutorExecutionError, _definition.Name);
            throw new NoxIntegrationException(string.Format(ExceptionResources.ExecutorExecutionError, _definition.Name), ex);
        }
    }

    private DbMerge CreateEntityDestinationDestination()
    {
        return new DbMerge(_target.ConnectionManager, _target.ToTableNameForSql(_entity.Persistence!.TableName!, _entity.Persistence.Schema))
        {
            CacheMode = ETLBox.DataFlow.Transformations.CacheMode.Partial,
            MergeMode = MergeMode.InsertsAndUpdates
        };
    }

    private IReadOnlyList<EntityAttribute> GetEntityAttributeNames()
    {
        var result = new List<EntityAttribute>();
        result.AddRange(_entity.Keys!.Select(k => new EntityAttribute{Name = k.Name, IsKey = true}));
        if (_entity.Attributes != null) result.AddRange(_entity.Attributes.Select(a => new EntityAttribute{Name = a.Name, IsKey = false}));
        return result;
    }
}