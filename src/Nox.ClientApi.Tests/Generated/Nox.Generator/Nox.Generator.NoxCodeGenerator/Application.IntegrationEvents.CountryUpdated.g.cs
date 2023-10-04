// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// CountryUpdated integration event.
/// </summary>
internal record CountryUpdated(CountryDto Country) :  IIntegrationEvent;