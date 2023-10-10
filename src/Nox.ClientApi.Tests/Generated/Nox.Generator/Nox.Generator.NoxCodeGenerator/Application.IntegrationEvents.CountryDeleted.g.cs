// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Messaging;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// CountryDeleted integration event.
/// </summary>
[IntegrationEventType("deleted", nameof(Country))]
internal record CountryDeleted(CountryDto Country) :  IIntegrationEvent;