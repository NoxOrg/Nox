using System.Reflection;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Exceptions;
using Nox.Integration.Extensions.Receive;
using Nox.Integration.Extensions.Send;
using Nox.Solution;
using Nox.Types;

namespace Nox.Integration.Extensions;

public static class IntegrationContextExtensions
{
    internal static INoxIntegration WithReceiveAdapter(this INoxIntegration instance, IntegrationSource sourceDefinition, IReadOnlyList<DataConnection>? dataConnections)
    {
        var dataConnection = dataConnections!.FirstOrDefault(dc => dc.Name == sourceDefinition.DataConnectionName);
        switch (sourceDefinition.SourceAdapterType)
        {
            case IntegrationSourceAdapterType.DatabaseQuery:
                instance.WithDatabaseReceiveAdapter(sourceDefinition.QueryOptions!, dataConnection!);
                break;
            case IntegrationSourceAdapterType.File:
                instance.WithFileReceiveAdapter(sourceDefinition.FileOptions!, dataConnection!);
                break;
        }

        return instance;
    }
    
    internal static INoxIntegration WithSendAdapter(this INoxIntegration instance, IntegrationTarget targetDefinition, IReadOnlyList<DataConnection>? dataConnections)
    {
        switch (targetDefinition.TargetAdapterType)
        {
            case IntegrationTargetAdapterType.DatabaseTable:
                var dataConnection = dataConnections!.FirstOrDefault(dc => dc.Name == targetDefinition.DataConnectionName);
                instance.WithDatabaseTableSendAdapter(targetDefinition.TableOptions!, dataConnection!);
                break;
        }
        return instance;
    }

    internal static INoxIntegration WithSchedule(this INoxIntegration instance, IntegrationSchedule schedule)
    {
        //todo add the integration to the hangfire job scheduler.
        return instance;
    }

    internal static INoxIntegration WithTargetDto(this INoxIntegration instance, IntegrationTarget targetDefinition, Nox.Solution.Domain? domainDefinition)
    {
        if (targetDefinition.TableOptions == null) return instance;
        if (domainDefinition == null) return instance;
        
        var tableName = targetDefinition.TableOptions.TableName;
        
        //Find the entity from the table name
        var entity = domainDefinition.Entities.FirstOrDefault(e => e.Persistence.TableName!.Equals(tableName, StringComparison.OrdinalIgnoreCase));
        if (entity != null)
        {
            var dtoType = Assembly.GetEntryAssembly()!.GetTypes().FirstOrDefault(t => t.IsClass && t.Name.Equals($"{entity.Name}Dto"));
            if (dtoType != null) instance.DtoType = dtoType;
        }
        
        return instance;
    }
}