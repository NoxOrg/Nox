// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Application.Dto; 

/// <summary>
/// Stores.
/// </summary>
public partial class StoreCreateDto
{
    /// <summary>
    /// Store Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Store address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Store location coordinates (Required).
    /// </summary>
    public LatLongDto LatLong { get; set; } = default!;
    /// <summary>
    /// Store phone number (Required).
    /// </summary>
    public System.String Phone { get; set; } = default!;
}