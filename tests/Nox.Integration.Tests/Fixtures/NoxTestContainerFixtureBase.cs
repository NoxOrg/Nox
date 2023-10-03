using DotNet.Testcontainers.Containers;
using Microsoft.EntityFrameworkCore;

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

    protected abstract DbContextOptions<TDbContext> CreateDbOptions<TDbContext>(string connectionString)
        where TDbContext : DbContext;

    protected abstract string GetConnectionString(TContainer container);

    protected override DbContextOptions<TDbContext> CreateDbOptions<TDbContext>()
    {
        var connectionString = GetConnectionString(_container);
        return CreateDbOptions<TDbContext>(connectionString);
    }
}