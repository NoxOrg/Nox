using Divergic.Logging.Xunit;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Nox.Types.EntityFramework.Abstractions;
using Xunit.Abstractions;

namespace ClientApi.Tests;

public class NoxTestApplicationFactory : WebApplicationFactory<StartupFixture>
{
    private readonly NoxTestContainerService _containerService;
    private readonly ITestOutputHelper _testOutput;

    public NoxTestApplicationFactory(NoxTestContainerService containerService, ITestOutputHelper testOutput)
    {
        _testOutput = testOutput;
        _containerService = containerService;
    }

    protected override IWebHostBuilder? CreateWebHostBuilder()
    {
        var host = WebHost.CreateDefaultBuilder(null!)
            .UseStartup<StartupFixture>()
            .ConfigureTestServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(INoxDatabaseProvider));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }
                services.AddScoped(sp =>
                {
                    var configurations = sp.GetServices<INoxTypeDatabaseConfigurator>();
                    return _containerService.GetDatabaseProvider(configurations);
                });
            })
            .ConfigureLogging(opts => opts.AddXunit(_testOutput, new LoggingConfig
            {
                LogLevel = LogLevel.Error
            }));

        return host;
    }
}