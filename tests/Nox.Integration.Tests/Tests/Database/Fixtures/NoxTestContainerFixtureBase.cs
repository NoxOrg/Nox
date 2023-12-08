using DotNet.Testcontainers.Containers;

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
}