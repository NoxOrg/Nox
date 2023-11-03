using Nox.Integration.Extensions;
using Nox.Integration.Services;
using Nox.Solution;

namespace Nox.Integration.Tests;

public class IntegrationTests
{
    public async Task Can_Execute_an_integration()
    {
        var dataConnections = new List<DataConnection>();
        dataConnections.Add(new DataConnection
        {
            Name = "SourceDatabase",
            Provider = DataConnectionProvider.SqlServer,
            User = "sa",
            Password = "Developer*123",
            Port = 1433,
            ServerUri = "localhost"
        });
        dataConnections.Add(new DataConnection
        {
            Name = "TargetDatabase",
            Provider = DataConnectionProvider.SqlServer,
            User = "sa",
            Password = "Developer*123",
            Port = 1433,
            ServerUri = "localhost"
        });

        var integration = new NoxIntegration("EtlTest", "This is a test Integration", IntegrationMergeType.MergeNew)
            .WithReceiveAdapter(new IntegrationSource
            {
                Name = "TestSource",
                Description = "Integration Source for testing",
                QueryOptions = new IntegrationSourceQueryOptions
                {
                    Query = "SELECT * FROM SourceTable",
                    MinimumExpectedRecords = 10
                },
                SourceSourceAdapterType = IntegrationSourceAdapterType.DatabaseQuery,
                DataConnectionName = "SourceDataConnection",
                Watermark = new IntegrationSourceWatermark
                {
                    DateColumns = new[]
                    {
                        "CreateDate",
                        "EditDate"
                    }
                }
            }, dataConnections)
            .WithSendAdapter(new IntegrationTarget
            {
                Name = "TestTarget",
                Description = "Integration target for testing.",
                StoredProcedureOptions = new IntegrationTargetStoredProcedureOptions
                {
                    StoredProcedure = "up_Insert_Target",
                    SchemaName = "dbo"
                },
                DataConnectionName = "TargetDatabase",
                TargetAdapterType = IntegrationTargetAdapterType.StoredProcedure
            }, dataConnections);

        var context = new NoxIntegrationContext(new Solution.Solution());
        context.AddIntegration(integration);
        var result = await context.ExecuteIntegrationAsync("EtlTest");
        Assert.True(result);
    }
}