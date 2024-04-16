// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Infrastructure.Messaging;
using DomainNamespace = ClientApi.Domain;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// UserContactSelectionCreated integration event.
/// </summary>
[IntegrationEventType("created", nameof(DomainNamespace.UserContactSelection))]
internal record UserContactSelectionCreated(UserContactSelectionDto UserContactSelection) :  IIntegrationEvent;