using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Extensions;
using Nox.Integration.Services;
using Nox.Solution;

namespace Nox.Integration.EtlTests;

public class CoreTests
{
    [Fact (Skip = "This test can only be run locally if you have a loal sql server instance and have created the CountrySource database using ./files/Create_CoutrySource.sql")] 
    public async Task Can_Execute_an_integration()
    {
        var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());
        var logger = loggerFactory.CreateLogger<INoxIntegrationContext>();
        
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
                    DateColumns = new List<string>
                    {
                        "CreateDate",
                        "EditDate"
                    }
                },
                SourceAdapterType = IntegrationSourceAdapterType.DatabaseQuery,
                DataConnectionName = "CountrySource",
                QueryOptions = new IntegrationSourceQueryOptions
                {
                    Query = "SELECT CountryId AS Id, Name, Population, CreateDate, EditDate FROM CountryMaster",
                    MinimumExpectedRecords = 1
                }
            },
            Target = new IntegrationTarget
            {
                Name = "TestTarget",
                Description = "Integration target for testing.",
                TargetAdapterType = IntegrationTargetAdapterType.DatabaseTable,
                DataConnectionName = "EtlSample",
                TableOptions = new IntegrationTargetTableOptions
                {
                    TableName = "Country",
                    Watermark = new IntegrationTargetWatermark
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
            }
        };

        var solution = new NoxSolution
        {
            Application = new Application
            {
                Integrations = new List<Solution.Integration> { definition }
            },
            Infrastructure = new Infrastructure
            {
                Dependencies = new Dependencies
                {
                    DataConnections = dataConnections
                }
            }
        };

        var integration = new NoxIntegration(logger, definition)
            .WithReceiveAdapter(definition.Source, dataConnections)
            .WithSendAdapter(definition.Target, dataConnections);

        var context = new NoxIntegrationContext(logger, solution);
        context.AddIntegration(integration);
        var result = await context.ExecuteIntegrationAsync("EtlTest");
        Assert.True(result);
    }

    [Fact (Skip = "This test can only be run locally if you have a loal sql server instance and have created the CountrySource database using ./files/Create_CoutrySource.sql")]    
    public async Task Can_Execute_an_Integration_From_Yaml_Definition()
    {
        var services = new ServiceCollection();
        services.AddLogging(configure =>
        {
            configure.AddConsole();
        });

        var solution = new NoxSolutionBuilder()
            .WithFile("./files/test_integration.solution.nox.yaml")
            .Build();
        services.AddSingleton<NoxSolution>(solution);
        services.AddNoxIntegrations();
        var provider = services.BuildServiceProvider();
        var context = provider.GetRequiredService<INoxIntegrationContext>();
        var result = await context.ExecuteIntegrationAsync("SqlToSqlIntegration");
        Assert.True(result);
    }
}