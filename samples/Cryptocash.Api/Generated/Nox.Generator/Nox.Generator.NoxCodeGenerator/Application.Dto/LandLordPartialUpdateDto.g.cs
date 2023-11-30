// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;



/// <summary>
/// Landlord related data.
/// </summary>
public partial class LandLordPartialUpdateDto : LandLordPartialUpdateDtoBase
{

}

/// <summary>
/// Landlord related data
/// </summary>
public partial class LandLordPartialUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.LandLord>
{
    /// <summary>
    /// Landlord name
    /// </summary>
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Landlord's street address
    /// </summary>
    public virtual StreetAddressDto Address { get; set; } = default!;
}