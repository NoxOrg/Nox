using ClientApi.Domain;
using MediatR;

namespace ClientApi.Application.DomainEventHandlers;

/// <summary>
/// This is an example of a domain event handler. Probably we will generate domain event handlers in the future.
/// Handles the domain event when a new country is created.
/// </summary>
internal class CountryCreatedDomainEventHandler : INotificationHandler<CountryCreated>
{
    private readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);
    
    /// <summary>
    /// How many times the handler was called.
    /// </summary>
    public static int HandledEventCount { get; private set; }=0;
    
    /// <summary>
    /// Handles the domain event asynchronously.
    /// </summary>
    /// <param name="notification">The <see cref="CountryCreated"/> notification.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Handle(CountryCreated notification, CancellationToken cancellationToken)
    {
        await _semaphoreSlim.WaitAsync(cancellationToken);
        HandledEventCount++;
        _semaphoreSlim.Release();
        // Perform any additional handling if necessary.

        // Return a completed task to indicate completion.
        await Task.CompletedTask;
    }
}
