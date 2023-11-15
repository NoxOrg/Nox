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

        var integration = new NoxIntegration("EtlTest", "This is a test Integration")
            .WithReceiveAdapter(new IntegrationSource
            {
                Name = "TestSource",
                Description = "Integration Source for testing",
                DatabaseOptions = new IntegrationSourceDatabaseOptions
                {
                    Query = "SELECT * FROM SourceTable",
                    MinimumExpectedRecords = 10
                },
                SourceAdapterType = IntegrationAdapterType.Database,
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
                DatabaseOptions = new IntegrationTargetDatabaseOptions
                {
                    StoredProcedure = "up_Insert_Target"
                },
                DataConnectionName = "TargetDatabase",
                TargetAdapterType = IntegrationAdapterType.Database
            }, dataConnections);

        var context = new NoxIntegrationContext(new Solution.NoxSolution());
        context.AddIntegration(integration);
        var result = await context.ExecuteIntegrationAsync("EtlTest");
        Assert.True(result);
    }
}