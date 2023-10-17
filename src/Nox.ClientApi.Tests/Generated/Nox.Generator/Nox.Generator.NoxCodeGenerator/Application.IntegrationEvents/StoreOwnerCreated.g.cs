// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// StoreOwnerCreated integration event.
/// </summary>
[IntegrationEventType("created", nameof(ClientApi.Domain.StoreOwner))]
internal record StoreOwnerCreated(StoreOwnerDto StoreOwner) :  IIntegrationEvent;