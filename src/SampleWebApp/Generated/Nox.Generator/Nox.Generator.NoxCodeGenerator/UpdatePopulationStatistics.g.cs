// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Application.DataTransferObjects;

/// <summary>
/// Instructs the service to collect updated population statistics.
/// </summary>
public partial class UpdatePopulationStatistics : IDynamicDto
{
    /// <summary>
    ///  (Optional).
    /// </summary>
    public CountryCode2? CountryCode { get; set; } = null!;
}