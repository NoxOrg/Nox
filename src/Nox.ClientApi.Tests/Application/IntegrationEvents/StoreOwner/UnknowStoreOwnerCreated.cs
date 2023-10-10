using Nox.Application;

namespace ClientApi.Application.IntegrationEvents.StoreOwner
{
    internal record UnknowStoreOwnerCreated(string StoreOwnerId): IIntegrationEvent;
    
}
