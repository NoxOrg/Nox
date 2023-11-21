using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Extensions;
using Nox.Integration.Services;
using Nox.Solution;

namespace Nox.Integration.EtlTests;

public class CustomTransformTests
{
#if DEBUG
    [Fact]
#else
    [Fact (Skip = "This test can only be run locally if you have a loal sql server instance and have created the CountrySource database using ./files/Create_CoutrySource.sql")]
#endif 
    public async Task Can_Execute_an_integration_using_custom_transform()
    {
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<INoxIntegrationContext>();
        
        var dataConnections = new List<DataConnection>
        {
            new()
            {
                Name = "CountrySource",
                Provider = DataConnectionProvider.SqlServer,
                User = "sa",
                Password = "Developer*123",
                Port = 1433,
                ServerUri = "localhost",
                Options = "pooling=false;encrypt=false"
            },
            new()
            {
                Name = "EtlSample",
                Provider = DataConnectionProvider.SqlServer,
                User = "sa",
                Password = "Developer*123",
                Port = 1433,
                ServerUri = "localhost",
                Options = "pooling=false;encrypt=false"
            }
        };

        var definition = new Solution.Integration
        {
            Name = "EtlCustomTransformTest",
            Description = "This is a custom transform test Integration",
            MergeType = IntegrationMergeType.MergeNew,
            TransformationType = IntegrationTransformType.CustomTransform,
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

        var integration = new NoxIntegration(logger, definition)
            .WithReceiveAdapter(new IntegrationSource
            {
                Name = "TestSource",
                Description = "Integration Source for testing",
                SourceAdapterType = IntegrationSourceAdapterType.DatabaseQuery,
                QueryOptions = new IntegrationSourceQueryOptions
                {
                    Query = "SELECT Id, Name, Population, CreateDate, EditDate FROM CountryMaster",
                    MinimumExpectedRecords = 10
                },
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
                TargetAdapterType = IntegrationTargetAdapterType.DatabaseTable,
                TableOptions = new IntegrationTargetTableOptions
                {
                    TableName = "Country"
                },
                DataConnectionName = "EtlSample"
            }, dataConnections);

        var context = new NoxIntegrationContext(logger, new NoxSolution());
        context.AddIntegration(integration);
        var result = await context.ExecuteIntegrationAsync("EtlCustomTransformTest");
        Assert.True(result);
    }
}