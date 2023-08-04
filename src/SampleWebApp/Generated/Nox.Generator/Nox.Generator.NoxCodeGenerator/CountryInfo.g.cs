// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Application.DataTransferObjects;

/// <summary>
/// .
/// </summary>
public partial class CountryInfo : IDynamicDto
{
    /// <summary>
    /// The country's Id (Optional).
    /// </summary>
    public CountryCode2? CountryId { get; set; } = null!;
    /// <summary>
    /// The country name (Optional).
    /// </summary>
    public Text? CountryName { get; set; } = null!;
}