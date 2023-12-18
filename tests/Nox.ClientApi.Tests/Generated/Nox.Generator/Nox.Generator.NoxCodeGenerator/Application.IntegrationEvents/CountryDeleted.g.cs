// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Infrastructure.Messaging;
using DomainNamespace = ClientApi.Domain;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// CountryDeleted integration event.
/// </summary>
[IntegrationEventType("deleted", nameof(DomainNamespace.Country))]
internal record CountryDeleted(CountryDto Country) :  IIntegrationEvent;