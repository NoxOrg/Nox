using DotNet.Testcontainers.Containers;
using Microsoft.EntityFrameworkCore;
using TestWebApp.Infrastructure.Persistence;

namespace Nox.Integration.Tests.Fixtures;

public abstract class NoxTestContainerFixtureBase<TContainer> : NoxTestDataContextFixtureBase, IAsyncLifetime
    where TContainer : DockerContainer
{
    protected TContainer _container = default!;

    public Task InitializeAsync()
    {
        return _container.StartAsync();
    }

    public Task DisposeAsync()
    {
        return _container
            .DisposeAsync()
            .AsTask();
    }

    protected abstract DbContextOptions<TestWebAppDbContext> CreateDbOptions(string connectionString);

    protected abstract string GetConnectionString(TContainer container);

    protected override DbContextOptions<TestWebAppDbContext> CreateDbOptions()
    {
        var connectionString = GetConnectionString(_container);
        return CreateDbOptions(connectionString);
    }
}