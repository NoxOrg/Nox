// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Infrastructure.Messaging;
using DomainNamespace = ClientApi.Domain;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// CountryUpdated integration event.
/// </summary>
[IntegrationEventType("updated", nameof(DomainNamespace.Country))]
internal record CountryUpdated(CountryDto Country) :  IIntegrationEvent;