// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Messaging;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// StoreOwnerCreated integration event.
/// </summary>
[IntegrationEventType("Created", nameof(StoreOwner))]
internal record StoreOwnerCreated(StoreOwnerDto StoreOwner) :  IIntegrationEvent;