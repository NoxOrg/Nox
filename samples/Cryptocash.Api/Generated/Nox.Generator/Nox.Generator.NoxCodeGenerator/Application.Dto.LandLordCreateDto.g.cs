// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using LandLordEntity = Cryptocash.Domain.LandLord;
using Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public partial class LandLordCreateDto : LandLordCreateDtoBase
{

}

/// <summary>
/// Landlord related data.
/// </summary>
public abstract class LandLordCreateDtoBase : IEntityDto<LandLordEntity>
{
    /// <summary>
    /// Landlord name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Landlord's street address (Required).
    /// </summary>
    [Required(ErrorMessage = "Address is required")]
    
    public virtual StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// LandLord leases an area to house ZeroOrMany VendingMachines
    /// </summary>
    
    [System.Text.Json.Serialization.JsonIgnore] 
    public virtual List<VendingMachineCreateDto> ContractedAreasForVendingMachines { get; set; } = new();
}