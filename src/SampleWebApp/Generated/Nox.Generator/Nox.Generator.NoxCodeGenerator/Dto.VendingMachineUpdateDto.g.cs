// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;

namespace SampleWebApp.Application.Dto; 

/// <summary>
/// Vending machines.
/// </summary>
public partial class VendingMachineUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// Vending machine Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Vending machine's address (Required).
    /// </summary>
    public StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Vending machine' location coordinates (Required).
    /// </summary>
    public LatLongDto LatLong { get; set; } = default!;
    /// <summary>
    /// Vending machine's support number (Required).
    /// </summary>
    public System.String SupportNumber { get; set; } = default!;
}