using Divergic.Logging.Xunit;
using FluentAssertions.Common;
using MassTransit;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Nox;
using Nox.Types.EntityFramework.Abstractions;
using Xunit.Abstractions;

namespace ClientApi.Tests;

public class NoxTestApplicationFactory : WebApplicationFactory<StartupFixture>
{
    private readonly NoxTestContainerService _containerService;
    private readonly ITestOutputHelper _testOutput;
    private readonly DatabaseServerProvider _dbProviderKind;
    private readonly bool _enableMessaging;

    public NoxTestApplicationFactory(
        NoxTestContainerService containerService,
        ITestOutputHelper testOutput,
        Nox.DatabaseServerProvider dbProviderKind,
        bool enableMessaging)
    {
        _testOutput = testOutput;
        _dbProviderKind = dbProviderKind;
        _enableMessaging = enableMessaging;
        _containerService = containerService;
    }

    protected override IWebHostBuilder? CreateWebHostBuilder()
    {
        var host = WebHost.CreateDefaultBuilder(null!)
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
                
                if(_enableMessaging)
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