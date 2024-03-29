﻿// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Types;
using Nox.Infrastructure.Messaging;


using ClientApi.Application.Dto;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// Country Population Updated with Population Higher then 100M.
/// </summary>
[IntegrationEventType("countryPopulationHigherThan100M", "country")]
public partial class CountryPopulationHigherThan100M : IIntegrationEvent
{
    public System.String? Name { get; set; }

    public System.Int32? Population { get; set; }

    public MoneyDto? CountryDebt { get; set; }
}