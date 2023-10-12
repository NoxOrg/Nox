// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// WorkplaceDeleted integration event.
/// </summary>
internal record WorkplaceDeleted(WorkplaceDto Workplace) :  IIntegrationEvent;