using Nox.Application;

namespace ClientApi.Application.IntegrationEvents.StoreOwner
{
    [IntegrationEventType("created", nameof(ClientApi.Domain.StoreOwner))]
    internal record UnknowStoreOwnerCreated(string StoreOwnerId): IIntegrationEvent;
}
