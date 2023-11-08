using Microsoft.Extensions.Logging;
using Nox.Integration.Extensions;
using Nox.Integration.Services;
using Nox.Solution;

namespace Nox.Integration.Tests;

public class IntegrationTests
{
#if DEBUG
    [Fact]
#else
    [Fact (Skip = "This test can only be run locally if you have a loal sql server instance and have created the CountrySource database using ./files/Create_CoutrySource.sql")]
#endif 
    public async Task Can_Execute_an_integration()
    {
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        
        var dataConnections = new List<DataConnection>();
        dataConnections.Add(new DataConnection
        {
            Name = "CountrySource",
            Provider = DataConnectionProvider.SqlServer,
            User = "sa",
            Password = "Developer*123",
            Port = 1433,
            ServerUri = "localhost",
            Options = "pooling=false;encrypt=false"
        });
        dataConnections.Add(new DataConnection
        {
            Name = "EtlSample",
            Provider = DataConnectionProvider.SqlServer,
            User = "sa",
            Password = "Developer*123",
            Port = 1433,
            ServerUri = "localhost",
            Options = "pooling=false;encrypt=false"
        });

        var definition = new Solution.Integration
        {
            Name = "EtlTest",
            Description = "This is a test Integration",
            MergeType = IntegrationMergeType.MergeNew,
            Source = new IntegrationSource
            {
                Watermark = new IntegrationSourceWatermark
                {
                    SequentialKeyColumns = new List<string>
                    {
                        "Id"
                    },
                    DateColumns = new List<string>
                    {
                        "CreateDate",
                        "EditDate"
                    }
                }
            }
        };

        var integration = new NoxIntegration(loggerFactory, definition)
            .WithReceiveAdapter(new IntegrationSource
            {
                Name = "TestSource",
                Description = "Integration Source for testing",
                QueryOptions = new IntegrationSourceQueryOptions
                {
                    Query = "SELECT Id, Name, Population, CreateDate, EditDate FROM CountryMaster",
                    MinimumExpectedRecords = 10
                },
                SourceAdapterType = IntegrationSourceAdapterType.DatabaseQuery,
                DataConnectionName = "CountrySource",
                Watermark = new IntegrationSourceWatermark
                {
                    SequentialKeyColumns = new []
                    {
                        "Id"
                    },
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
                    TableName = "Country"
                },
                DataConnectionName = "EtlSample",
                TargetAdapterType = IntegrationTargetAdapterType.DatabaseTable
            }, dataConnections);

        var context = new NoxIntegrationContext(loggerFactory, new Solution.Solution());
        context.AddIntegration(integration);
        var result = await context.ExecuteIntegrationAsync("EtlTest");
        Assert.True(result);
    }
}