// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Presentation.Api.OData;

/// <summary>
/// Stores.
/// </summary>
public partial class StoreDto
{
    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public String Name { get; set; } =default!;
    /// <summary>
    /// Physical Money in the Physical Store (Required).
    /// </summary>
    public Decimal PhysicalMoney { get; set; } =default!;
}