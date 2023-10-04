// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;

using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// CountryCreated integration event.
/// </summary>
internal record CountryCreated(CountryDto Country) :  IIntegrationEvent;