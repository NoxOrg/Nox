// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// CountryCreated integration event.
/// </summary>
[IntegrationEventType("created", nameof(ClientApi.Domain.Country))]
internal record CountryCreated(CountryDto Country) :  IIntegrationEvent;