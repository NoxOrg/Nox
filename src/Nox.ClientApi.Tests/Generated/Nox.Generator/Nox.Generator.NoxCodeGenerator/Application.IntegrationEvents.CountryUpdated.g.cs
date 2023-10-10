// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Messaging;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// CountryUpdated integration event.
/// </summary>
[IntegrationEventType("Updated", nameof(Country))]
internal record CountryUpdated(CountryDto Country) :  IIntegrationEvent;