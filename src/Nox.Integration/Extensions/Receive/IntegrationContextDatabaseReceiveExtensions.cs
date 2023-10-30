using Nox.Integration.Abstractions;
using Nox.Integration.Adapters;
using Nox.Solution;

namespace Nox.Integration.Extensions.Receive;

public static class IntegrationContextDatabaseReceiveExtensions
{
    internal static INoxIntegration WithDatabaseReceiveAdapter(this INoxIntegration instance, IntegrationSourceDatabaseOptions options, DataConnection dataConnectionDefinition)
    {
        switch (dataConnectionDefinition.Provider)
        {
            case DataConnectionProvider.SqlServer:
                instance.ReceiveAdapter = CreateSqlServerReceiveAdapter(options, dataConnectionDefinition);
                break;
        }
        return instance;
    }

    internal static SqlServerReceiveAdapter CreateSqlServerReceiveAdapter(IntegrationSourceDatabaseOptions options, DataConnection dataConnectionDefinition)
    {
        var adapter = new SqlServerReceiveAdapter(options.Query, options.MinimumExpectedRecords!.Value);
        //todo create the connection manager here
        return adapter;
    }
}