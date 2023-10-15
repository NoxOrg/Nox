// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// CountryUpdated integration event.
/// </summary>
[IntegrationEventType("updated", nameof(Country))]
internal record CountryUpdated(CountryDto Country) :  IIntegrationEvent;