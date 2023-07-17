using System.Dynamic;
using ETLBox.DataFlow;
using ETLBox.DataFlow.Connectors;
using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Exceptions;
using Nox.Integration.Store;
using Nox.Solution;

namespace Nox.Integration.Executor;

public class EntityExecutor
{
    private readonly ILogger _logger;
    private readonly string _name;
    private readonly IStoreService _storeService;
    private readonly IntegrationSourceWatermark _watermark;
    private readonly IIntegrationSource _source;
    private readonly IIntegrationTarget _target;
    private readonly Entity _entity;
    
    public EntityExecutor(
        ILogger logger,
        string name,
        IStoreService storeService,
        IntegrationSourceWatermark watermark,
        IIntegrationSource source,
        IIntegrationTarget target,
        Entity entity)
    {
        _logger = logger;
        _name = name;
        _storeService = storeService;
        _watermark = watermark;
        _source = source;
        _target = target;
        _entity = entity;
    }
    
    public async Task ExecuteAsync()
    {
        try
        {
            var lastMergeDateTimeStampInfo = await _storeService.GetAllLastMergeDateTimeStampsAsync(_name, _watermark, _entity);
            var targetColumns =
                Array.Empty<string>()
                .Concat(_entity.Keys!
                    .Select(k => k.Name))
                .Concat(_entity.Attributes!
                    .Select(a => a.Name))
                //.Concat(entity.RelatedParents.Select(p => p + "Id"))
                .ToArray();
            var destination = CreateEntityDestinationDestination();
            _source.DataFlowSource().LinkTo(destination);
            var postProcessDestination = new CustomDestination();

            // Store analytics
        
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
                    unchanged++;
                }
            };

            destination.LinkTo(postProcessDestination);

            try
            {
                await Network.ExecuteAsync((DataFlowExecutableSource<ExpandoObject>)_source);
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Failed to run Merge for Entity {entity}", _entity.Name);
                _logger.LogError("{message}", ex.Message);
                throw;
            }

            _storeService.LogMergeAnalytics(inserts, updates, unchanged, lastMergeDateTimeStampInfo);
        }
        catch (Exception ex)
        {
            _logger.LogCritical(ex, ExceptionResources.ExecutorExecutionError, _name);
            throw new NoxIntegrationException(string.Format(ExceptionResources.ExecutorExecutionError, _name), ex);
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
}