// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

namespace ClientApi.Application.Dto;



/// <summary>
/// Stores.
/// </summary>
public partial class StorePartialUpdateDto : StorePartialUpdateDtoBase
{

}

/// <summary>
/// Stores
/// </summary>
public partial class StorePartialUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Store Name
    /// </summary>
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Street Address
    /// </summary>
    public virtual StreetAddressDto Address { get; set; } = default!;
    /// <summary>
    /// Location
    /// </summary>
    public virtual LatLongDto Location { get; set; } = default!;
    /// <summary>
    /// Opening day
    /// </summary>
    public virtual System.DateTimeOffset? OpeningDay { get; set; }
    /// <summary>
    /// Store Status
    /// </summary>
    public virtual System.Int32? Status { get; set; }
}