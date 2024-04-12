using System.Reflection;
using ETLBox;
using ETLBox.DataFlow;
using Microsoft.Data.SqlClient;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Solution;

namespace Nox.Integration.Adapters;

public static class AdapterHelpers
{
    internal static object? CreateSourceAdapter(Type sourceType, string integrationName, IntegrationSource sourceDefinition, IReadOnlyList<DataConnection>? dataConnections)
    {
        var dataConnection = dataConnections!.FirstOrDefault(dc => dc.Name == sourceDefinition.DataConnectionName);
        switch (sourceDefinition.SourceAdapterType)
        {
            case IntegrationSourceAdapterType.DatabaseQuery:
                return DatabaseSourceHelpers.CreateDatabaseSourceAdapter(sourceType, integrationName, sourceDefinition.QueryOptions!, dataConnection!);
            case IntegrationSourceAdapterType.File:
                return FileSourceHelpers.CreateFileSourceAdapter(sourceType, integrationName, sourceDefinition.FileOptions!, dataConnection!);
        }

        throw new NotImplementedException($"{sourceDefinition.SourceAdapterType.ToString()} source adapter for integration {integrationName} has not been implemented");
    }

    internal static object? CreateTargetAdapter(Type targetType, string integrationName, IntegrationTarget targetDefinition, IReadOnlyList<DataConnection>? dataConnections)
    {
        var dataConnection = dataConnections!.FirstOrDefault(dc => dc.Name == targetDefinition.DataConnectionName);
        switch (targetDefinition.TargetAdapterType)
        {
            case IntegrationTargetAdapterType.DatabaseTable:
                return DatabaseTargetHelpers.CreateDatabaseTargetAdapter(targetType, integrationName, targetDefinition.TableOptions!, dataConnection!);
        }

        //Code should never reach this
        throw new NotImplementedException();
    }
    
    internal static INoxIntegration<TSource, TTarget> WithSchedule<TSource, TTarget>(this INoxIntegration<TSource, TTarget> instance, IntegrationSchedule schedule)
    {
        //todo add the integration to the hangfire job scheduler.
        return instance;
    }

    internal static INoxIntegration<TSource, TTarget> WithTargetDto<TSource, TTarget>(this INoxIntegration<TSource, TTarget> instance, IntegrationTarget targetDefinition, Nox.Solution.Domain? domainDefinition)
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
    
    internal static DbMerge<TTarget> WithMergeFields<TTarget>(this DbMerge<TTarget> target, List<string>? idColumns, List<string>? compareColumns)
    {
        if (idColumns != null && idColumns.Any())
        {
            var mergeIdColumns = idColumns.Select(idColumn => new IdColumn { IdPropertyName = idColumn }).ToList();
            target.IdColumns = mergeIdColumns;    
        }

        if (compareColumns != null && compareColumns.Any())
        {
            var mergeDateColumns = compareColumns.Select(dateColumn => new CompareColumn { ComparePropertyName = dateColumn }).ToList();
            target.CompareColumns = mergeDateColumns;
        }

        return target;
    }
}