using System.Reflection;
using Microsoft.Data.SqlClient;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Solution;

namespace Nox.Integration.Adapters;

public static class AdapterExtensions
{
    internal static INoxIntegration WithSourceAdapter(this INoxIntegration instance, string integrationName, IntegrationSource sourceDefinition, IReadOnlyList<DataConnection>? dataConnections)
    {
        var dataConnection = dataConnections!.FirstOrDefault(dc => dc.Name == sourceDefinition.DataConnectionName);
        switch (sourceDefinition.SourceAdapterType)
        {
            case IntegrationSourceAdapterType.DatabaseQuery:
                instance.WithDatabaseSourceAdapter(integrationName, sourceDefinition.QueryOptions!, dataConnection!);
                break;
            case IntegrationSourceAdapterType.File:
                instance.WithFileSourceAdapter(integrationName, sourceDefinition.FileOptions!, dataConnection!);
                break;
        }
        return instance;
    }

    internal static INoxIntegration WithTargetAdapter(this INoxIntegration instance, string integrationName, IntegrationTarget targetDefinition, IReadOnlyList<DataConnection>? dataConnections)
    {
        var dataConnection = dataConnections!.FirstOrDefault(dc => dc.Name == targetDefinition.DataConnectionName);
        switch (targetDefinition.TargetAdapterType)
        {
            case IntegrationTargetAdapterType.DatabaseTable:
                instance.WithDatabaseTableTargetAdapter(targetDefinition.TableOptions!, dataConnection!);
                break;
        }

        return instance;
    }
    
    internal static INoxIntegration WithSchedule<TSource, TTarget>(this INoxIntegration instance, IntegrationSchedule schedule)
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