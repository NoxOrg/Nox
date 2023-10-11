// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Messaging;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// WorkplaceDeleted integration event.
/// </summary>
[IntegrationEventType("deleted", nameof(Workplace))]
internal record WorkplaceDeleted(WorkplaceDto Workplace) :  IIntegrationEvent;