using Divergic.Logging.Xunit;
using MassTransit;
using MassTransit.Testing;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Nox.Types.EntityFramework.Abstractions;
using ClientApi.Infrastructure.Persistence;
using Xunit.Abstractions;

namespace ClientApi.Tests;

public class NoxTestApplicationFactory : WebApplicationFactory<StartupFixture>
{
    private readonly ITestOutputHelper _testOutput;
    private readonly NoxTestContainerService _containerService;
    private readonly bool _enableMessaging;
    private readonly string Environment = Environments.Production;

    public NoxTestApplicationFactory(
        ITestOutputHelper testOutput,
        NoxTestContainerService containerService,
        bool enableMessaging,
        string? environment = null)
    {
        _testOutput = testOutput;
        _containerService = containerService;
        _enableMessaging = enableMessaging;

        if (environment != null)
        {
            Environment = environment;
        }
    }

    public ITestHarness GetTestHarness()
    {
        return Services.GetTestHarness();
    }

    public void ResetDataContext()
    {
        var dbContext = Services.GetRequiredService<ClientApiDbContext>();
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }
    
    internal ClientApiDbContext GetDbContext() => Services.GetRequiredService<ClientApiDbContext>();

    protected override IWebHostBuilder? CreateWebHostBuilder()
    {
        var host = WebHost.CreateDefaultBuilder(null!)
            .UseEnvironment(Environment)
            .UseStartup<StartupFixture>()
            // this extension makes it sure that our lambda will run after the Startup.ConfigureServices()
            // method has been executed.
            .ConfigureTestServices(services =>
            {
                //Override Db Provider and set container connection string
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(INoxDatabaseProvider));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }
                services.AddSingleton(sp =>
                {
                    var configurations = sp.GetServices<INoxTypeDatabaseConfigurator>();
                    return _containerService.GetDatabaseProvider(configurations);
                });

                if (_enableMessaging)
                    services.AddMassTransitTestHarness();

                //TODO Override NoxSolution with _dbProviderKind
            })
            .ConfigureLogging(opts => opts.AddXunit(_testOutput, new LoggingConfig
            {
                LogLevel = LogLevel.Error
            }));

        return host;
    }
}