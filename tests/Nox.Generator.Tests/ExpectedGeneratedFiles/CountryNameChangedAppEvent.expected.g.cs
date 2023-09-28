// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Types;

namespace SampleWebApp.Application.IntegrationEvents;

/// <summary>
/// An application event raised when the name of a country changes.
/// </summary>
public partial class CountryNameChangedAppEvent : IIntegrationEvent
{ 
    /// <summary>
    /// The identifier of the country. The Iso alpha 2 code.
    /// </summary>
    public Nox.Types.CountryCode2? CountryId { get; set; } = null!;
 
    /// <summary>
    /// The new name of the country.
    /// </summary>
    public Nox.Types.Text? CountryName { get; set; } = null!;
}
