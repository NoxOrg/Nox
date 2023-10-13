// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using Cryptocash.Application.Dto;

namespace Cryptocash.Application.IntegrationEvents;

/// <summary>
/// LandLordCreated integration event.
/// </summary>
[IntegrationEventType("created", nameof(LandLord))]
internal record LandLordCreated(LandLordDto LandLord) :  IIntegrationEvent;