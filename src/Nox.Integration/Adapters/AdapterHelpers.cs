using System.Reflection;
using ETLBox;
using ETLBox.DataFlow;
using Microsoft.Data.SqlClient;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;
using Nox.Integration.Adapters.Message;
using Nox.Integration.Extensions;
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
                return DatabaseSourceHelpers.CreateDatabaseQuerySourceAdapter(sourceType, integrationName, sourceDefinition.QueryOptions!, dataConnection!);
            case IntegrationSourceAdapterType.File:
                return FileSourceHelpers.CreateFileSourceAdapter(sourceType, integrationName, sourceDefinition.FileOptions!, dataConnection!);
            case IntegrationSourceAdapterType.DatabaseProcedure:
                return DatabaseSourceHelpers.CreateDatabaseProcedureSourceAdapter(sourceType, integrationName, sourceDefinition.ProcedureOptions!, dataConnection!);
        }

        throw new NotImplementedException($"{sourceDefinition.SourceAdapterType.ToString()} source adapter for integration {integrationName} has not been implemented");
    }

    internal static object? CreateTargetAdapter(
        Type targetType, 
        Solution.Integration definition, 
        IReadOnlyList<DataConnection>? dataConnections)
    {
        var dataConnection = dataConnections!.FirstOrDefault(dc => dc.Name == definition.Target.DataConnectionName);
        switch (definition.Target.TargetAdapterType)
        {
            case IntegrationTargetAdapterType.DatabaseTable:
                return DatabaseTargetHelpers.CreateDatabaseTargetAdapter(targetType, definition.Name, definition.Target.TableOptions!, dataConnection!, definition.MergeType.ToEtlBoxMergeMode());
            case IntegrationTargetAdapterType.MessageBroker:
                return MessageTargetHelpers.CreateMessageBrokerTargetAdapter(targetType, definition.Name, definition.Target.MessageBrokerOptions!, dataConnection!);
        }

        //Code should never reach this
        throw new NotImplementedException();
    }
    
    internal static INoxIntegration<TSource, TTarget> WithSchedule<TSource, TTarget>(this INoxIntegration<TSource, TTarget> instance, IntegrationSchedule schedule)
        where TSource : class 
        where TTarget : class
    {
        //Add the integration to the hangfire job scheduler.
        return instance;
    }

    internal static INoxIntegration<TSource, TTarget> WithTargetDto<TSource, TTarget>(this INoxIntegration<TSource, TTarget> instance, IntegrationTarget targetDefinition, Nox.Solution.Domain? domainDefinition)
        where TSource : class 
        where TTarget : class
    {
        if (targetDefinition.TableOptions == null) return instance;
        if (domainDefinition == null) return instance;
        
        var tableName = targetDefinition.TableOptions.TableName;
        
        //Find the entity from the table name
        var entity = domainDefinition.Entities.FirstOrDefault(e => e.Persistence.TableName!.Equals(tableName, StringComparison.OrdinalIgnoreCase));
        if (entity != null)
        {
            var dtoType = Array.Find(Assembly.GetEntryAssembly()!.GetTypes(), t => t.IsClass && t.Name.Equals($"{entity.Name}Dto"));
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