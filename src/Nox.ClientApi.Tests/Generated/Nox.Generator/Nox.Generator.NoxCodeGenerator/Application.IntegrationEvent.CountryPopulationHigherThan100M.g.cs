// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application;
using Nox.Types;

namespace ClientApi.Application.IntegrationEvents;

/// <summary>
/// Country Population Updated with Population Higher then 100M.
/// </summary>
public partial class CountryPopulationHigherThan100M : IIntegrationEvent
{
    public Nox.Types.CountryCode2? Code { get; set; } = null!;

    public Nox.Types.Text? Name { get; set; } = null!;

    public Nox.Types.Number? Population { get; set; } = null!;
}
