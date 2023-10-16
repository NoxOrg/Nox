// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Infrastructure.Messaging;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// CountryDeleted integration event.
/// </summary>
[IntegrationEventType("deleted", nameof(ClientApi.Domain.Country))]
internal record CountryDeleted(CountryDto Country) :  IIntegrationEvent;