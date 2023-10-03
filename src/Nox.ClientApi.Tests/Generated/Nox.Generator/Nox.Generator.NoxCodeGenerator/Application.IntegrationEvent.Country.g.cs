// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// Country created integration event.
/// </summary>
internal record CountryCreated(CountryDto Country) :  IIntegrationEvent;

/// <summary>
/// Country updated integration event.
/// </summary>
internal record CountryUpdated(CountryDto Country) : IIntegrationEvent;

/// <summary>
/// Country deleted integration event.
/// </summary>
internal record CountryDeleted(CountryDto Country) : IIntegrationEvent;
