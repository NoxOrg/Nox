using System.Dynamic;
using ETLBox;
using ETLBox.DataFlow;
using Microsoft.Data.SqlClient;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Adapters.SqlServer;
using Nox.Solution;

namespace Nox.Integration.Adapters;

public static class DatabaseTargetHelpers
{
    internal static object? CreateDatabaseTargetAdapter(Type targetType, string integrationName, IntegrationTargetTableOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.SqlServer:
                return CreateSqlServerTableAdapter(targetType, integrationName, options, dataConnectionDefinition);
            default:
                throw new NotImplementedException($"{dataConnectionDefinition.Provider.ToString()} target adapter for integration {integrationName} has not been implemented");
        }
    }
    
    private static object? CreateSqlServerTableAdapter(Type targetType, string integrationName, IntegrationTargetTableOptions options, DataConnection dataConnectionDefinition)
    {
        var csb = new SqlConnectionStringBuilder(dataConnectionDefinition.Options)
        {
            DataSource = $"{dataConnectionDefinition.ServerUri},{dataConnectionDefinition.Port ?? 1433}",
            UserID = dataConnectionDefinition.User,
            Password = dataConnectionDefinition.Password,
            InitialCatalog = dataConnectionDefinition.Name,
            ApplicationName = integrationName
        };
        var adapterType = typeof(SqlServerTargetAdapter<>).MakeGenericType(targetType);
        return Activator.CreateInstance(adapterType, csb.ConnectionString, options.SchemaName, null, options.TableName);
    }
    
    public static CustomDestination<ExpandoObject> LinkToDatabaseTable(this IDataFlowSource<ExpandoObject> source, INoxDatabaseTargetAdapter TargetAdapter, List<string>? idColumns, List<string>? dateColumns)
    {
        var tableTarget = TargetAdapter.TableTarget!;
        if (idColumns != null && idColumns.Any())
        {
            var mergeIdColumns = idColumns.Select(idColumn => new IdColumn { IdPropertyName = idColumn }).ToList();
            tableTarget.IdColumns = mergeIdColumns;    
        }

        if (dateColumns != null && dateColumns.Any())
        {
            var mergeDateColumns = dateColumns.Select(dateColumn => new CompareColumn { ComparePropertyName = dateColumn }).ToList();
            tableTarget.CompareColumns = mergeDateColumns;
        }

        source.LinkTo(tableTarget);
        var result = new CustomDestination<ExpandoObject>();
        tableTarget.LinkTo(result);
        return result;
    }
}