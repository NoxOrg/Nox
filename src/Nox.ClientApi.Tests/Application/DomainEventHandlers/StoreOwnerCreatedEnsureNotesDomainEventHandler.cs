using MediatR;
using Nox.Types;

namespace ClientApi.Application.DomainEventHandlers;

internal class StoreOwnerCreatedEnsureNotesDomainEventHandler : INotificationHandler<ClientApi.Domain.StoreOwnerCreated>
{
    public Task Handle(ClientApi.Domain.StoreOwnerCreated notification, CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(notification.StoreOwner.Notes?.Value))
        {
            notification.StoreOwner.Notes = Text.From("Store owner created at " + System.DateTime.Now.ToString("yyyy-MM-dd)"));
        }
        return Task.CompletedTask;
    }
}