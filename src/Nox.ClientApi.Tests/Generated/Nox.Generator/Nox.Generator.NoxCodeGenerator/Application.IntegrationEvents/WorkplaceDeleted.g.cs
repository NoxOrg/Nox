// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// WorkplaceDeleted integration event.
/// </summary>
[IntegrationEventType("deleted", nameof(ClientApi.Domain.Workplace))]
internal record WorkplaceDeleted(WorkplaceDto Workplace) :  IIntegrationEvent;