// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Types;
using Nox.Messaging;


using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.IntegrationEvents;

/// <summary>
/// An integration event raised when multiple currencies are added.
/// </summary>
[IntegrationEventType("countryCurrenciesAddedEvent", "country")]
public partial class CountryCurrenciesAddedEvent : IIntegrationEvent
{
    public CurrencyInfo[] CurrencyInfos { get; set; } = default!;
}

public class CurrencyInfo
{
    /// <summary>
    /// The identifier of the country. The Iso alpha 2 code.
    /// </summary>
    public System.String? CountryId { get; set; }

    /// <summary>
    /// The identifier of the currency.
    /// </summary>
    public System.String? CurrencyId { get; set; }
}
