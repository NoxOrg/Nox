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
                instance.SendAdapter = CreateSqlServerSendAdapter(options, dataConnectionDefinition);
                break;
        }

        return instance;
    }
    
    internal static SqlServerSendAdapter CreateSqlServerSendAdapter(IntegrationTargetDatabaseOptions options, DataConnection dataConnectionDefinition)
    {
        var adapter = new SqlServerSendAdapter(options.StoredProcedure);
        //todo create the connection manager here
        return adapter;
    }
}