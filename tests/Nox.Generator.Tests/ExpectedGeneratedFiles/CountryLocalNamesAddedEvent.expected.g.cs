// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Types;

using System.Collections.Generic;

using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.IntegrationEvents;

/// <summary>
/// An integration event raised when new local names are added to a country.
/// </summary>
public partial class CountryLocalNamesAddedEvent : IIntegrationEvent
{
    public IEnumerable<CountryLocalNameInfo> CountryLocalNameInfos { get; set; } = default!;
}

public class CountryLocalNameInfo
{
    /// <summary>
    /// The identifier of the country. The Iso alpha 2 code.
    /// </summary>
    public System.String? CountryId { get; set; }

    /// <summary>
    /// The new name of the country.
    /// </summary>
    public System.String? CountryLocalName { get; set; }
}
