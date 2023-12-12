// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

/// <summary>
/// Landlord related data.
/// </summary>
public partial class LandLordCreateDto : LandLordCreateDtoBase
{

}

/// <summary>
/// Landlord related data.
/// </summary>
public abstract class LandLordCreateDtoBase : IEntityDto<DomainNamespace.LandLord>
{/// <summary>
    /// Landlord unique identifier     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public System.Guid? Id { get; set; }
    /// <summary>
    /// Landlord name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String? Name { get; set; }
    /// <summary>
    /// Landlord's street address     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Address is required")]
    
    public virtual StreetAddressDto? Address { get; set; }

    /// <summary>
    /// LandLord leases an area to house ZeroOrMany VendingMachines
    /// </summary>
    public virtual List<System.Guid> VendingMachinesId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<VendingMachineCreateDto> VendingMachines { get; set; } = new();
}