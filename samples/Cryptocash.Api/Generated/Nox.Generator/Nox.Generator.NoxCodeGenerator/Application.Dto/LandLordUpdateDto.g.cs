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
public partial class LandLordUpdateDto : IEntityDto<DomainNamespace.LandLord>
{
    /// <summary>
    /// Landlord name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Landlord's street address (Required).
    /// </summary>
    [Required(ErrorMessage = "Address is required")]
    
    public StreetAddressDto Address { get; set; } = default!;

    /// <summary>
    /// LandLord leases an area to house ZeroOrMany VendingMachines
    /// </summary>
    public List<System.Guid> ContractedAreasForVendingMachinesId { get; set; } = new();
}