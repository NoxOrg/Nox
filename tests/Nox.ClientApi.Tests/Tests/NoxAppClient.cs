using MassTransit.Testing;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ClientApi.Tests;

public class NoxAppClient
{
    private readonly WebApplicationFactory<StartupFixture> _factory;

    public NoxAppClient(WebApplicationFactory<StartupFixture> factory)
    {
        _factory = factory;
    }
    public ITestHarness GetTestHarness()
    {
        return _factory.Services.GetTestHarness();
    }

    public void ResetDataContext()
    {
        using var scope = _factory.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<Infrastructure.Persistence.AppDbContext>();
        dbContext.Database.EnsureDeleted();
        dbContext.Database.EnsureCreated();
    }
    public HttpClient CreateClient()
    {
        return _factory.CreateClient();
    }

    internal Infrastructure.Persistence.AppDbContext GetDbContext() => _factory.Services.GetRequiredService<Infrastructure.Persistence.AppDbContext>();
}
