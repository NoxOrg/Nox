// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Store owners.
/// </summary>
public partial class StoreOwnerUpdateDto : StoreOwnerUpdateDtoBase
{

}

/// <summary>
/// Patch entity StoreOwner: Store owners.
/// </summary>
/// <remarks>Registered in OData for Delta feature. It is not suppose to extend this, extend update Dto instead</remarks>
public partial class StoreOwnerPatchDto: { { className} }
{

}

/// <summary>
/// Store owners
/// </summary>
public partial class StoreOwnerUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.StoreOwner>
{
    /// <summary>
    /// Owner Name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Temporary Owner Name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TemporaryOwnerName is required")]
    
    public virtual System.String TemporaryOwnerName { get; set; } = default!;
    /// <summary>
    /// Vat Number     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual VatNumberDto? VatNumber { get; set; }
    /// <summary>
    /// Street Address     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual StreetAddressDto? StreetAddress { get; set; }
    /// <summary>
    /// Owner Greeting     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual TranslatedTextDto? LocalGreeting { get; set; }
    /// <summary>
    /// Notes     
    /// </summary>
    /// <remarks>Optional.</remarks>
    public virtual System.String? Notes { get; set; }
}