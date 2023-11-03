using Microsoft.Data.SqlClient;
using Nox.Integration.Abstractions;
using Nox.Integration.Adapters;
using Nox.Solution;

namespace Nox.Integration.Extensions.Send;

public static class IntegrationContextDatabaseSendExtensions
{
    public static INoxIntegration WithDatabaseSendAdapter(this INoxIntegration instance, IntegrationTargetDatabaseOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.SqlServer:
                instance.SendAdapter = CreateSqlServerSendAdapter(instance.Name, options, dataConnectionDefinition);
                break;
        }

        return instance;
    }
    
    internal static SqlServerSendAdapter CreateSqlServerSendAdapter(string integrationName, IntegrationTargetDatabaseOptions options, DataConnection dataConnectionDefinition)
    {
        var csb = new SqlConnectionStringBuilder(dataConnectionDefinition.Options)
        {
            DataSource = $"{dataConnectionDefinition.ServerUri},{dataConnectionDefinition.Port ?? 1433}",
            UserID = dataConnectionDefinition.User,
            Password = dataConnectionDefinition.Password,
            InitialCatalog = dataConnectionDefinition.Name,
            ApplicationName = integrationName
        };
        var adapter = new SqlServerSendAdapter(options.StoredProcedure, csb.ConnectionString);
        return adapter;
    }
}