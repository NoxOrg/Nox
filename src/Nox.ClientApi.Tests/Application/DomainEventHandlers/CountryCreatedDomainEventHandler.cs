using ClientApi.Domain;
using MediatR;
using Nox.Types;

namespace ClientApi.Application.DomainEventHandlers;

/// <summary>
/// This is an example of a domain event handler. Probably we will generate domain event handlers in the future.
/// Handles the domain event when a new country is created.
/// </summary>
internal class CountryCreatedDomainEventHandler : INotificationHandler<CountryCreated>
{
    /// <summary>
    /// Handles the domain event asynchronously.
    /// </summary>
    /// <param name="notification">The <see cref="CountryCreated"/> notification.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Handle(CountryCreated notification, CancellationToken cancellationToken)
    {
        // Modify the country name to be in uppercase invariant form.
        notification.Country.Name = Text.From(notification.Country.Name.Value.ToUpperInvariant());

        // Perform any additional handling if necessary.

        // Return a completed task to indicate completion.
        await Task.CompletedTask;
    }
}
