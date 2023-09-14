using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Nox.Types.EntityFramework.Abstractions;

namespace ClientApi.Tests;

public class NoxTestApplicationFactory : WebApplicationFactory<StartupFixture>
{
    public NoxTestContainerService _containerService = default!;

    public void UseContainer(NoxTestContainerService containerService)
    {
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
                services.AddScoped<INoxDatabaseProvider>(sp =>
                {
                    var configurations = sp.GetServices<INoxTypeDatabaseConfigurator>();
                    return _containerService.GetDatabaseProvider(configurations);
                });
            });
        return host;
    }

}
