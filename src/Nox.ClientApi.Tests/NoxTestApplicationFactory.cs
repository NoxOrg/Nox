using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc.Testing;

namespace Nox.ClientApi.Tests;

public class NoxTestApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
{
    protected override IWebHostBuilder? CreateWebHostBuilder()
    {
        var host = WebHost.CreateDefaultBuilder(null!)
            .UseStartup<TStartup>();
        return host;
    }
}