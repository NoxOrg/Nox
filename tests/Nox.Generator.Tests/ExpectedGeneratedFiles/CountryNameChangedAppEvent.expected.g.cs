// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Types;
using Nox.Infrastructure.Messaging;


using SampleWebApp.Application.Dto;

namespace SampleWebApp.Application.IntegrationEvents;

/// <summary>
/// An application event raised when the name of a country changes.
/// </summary>
[IntegrationEventType("countryNameChangedAppEvent", "country")]
public partial class CountryNameChangedAppEvent : IIntegrationEvent
{
    /// <summary>
    /// The identifier of the country. The Iso alpha 2 code.
    /// </summary>
    public System.String? CountryId { get; set; }

    /// <summary>
    /// The new name of the country.
    /// </summary>
    public System.String? CountryName { get; set; }
}