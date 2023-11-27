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
public partial class LandLordUpdateDto : LandLordUpdateDtoBase
{

}

/// <summary>
/// Patch entity LandLord: Landlord related data.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class LandLordPatchDto: { { className} }
{

}

/// <summary>
/// Landlord related data
/// </summary>
public partial class LandLordUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.LandLord>
{
    /// <summary>
    /// Landlord name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Landlord's street address     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Address is required")]
    
    public virtual StreetAddressDto Address { get; set; } = default!;
}