// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// StoreOwnerCreated integration event.
/// </summary>
internal record StoreOwnerCreated(StoreOwnerDto StoreOwner) :  IIntegrationEvent;