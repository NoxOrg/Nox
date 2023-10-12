// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// CountryDeleted integration event.
/// </summary>
internal record CountryDeleted(CountryDto Country) :  IIntegrationEvent;