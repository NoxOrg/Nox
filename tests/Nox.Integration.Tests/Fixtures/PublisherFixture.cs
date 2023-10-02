using MediatR;

namespace Nox.Integration.Tests.Fixtures;

public class PublisherFixture : IPublisher
{
    public Task Publish(object notification, CancellationToken cancellationToken = default)
    {
        // Ignore
        return Task.CompletedTask;
    }

    public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default) where TNotification : INotification
    {
        // Ignore
        return Task.CompletedTask;
    }
}