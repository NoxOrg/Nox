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
/// Store owners
/// </summary>
public partial class StoreOwnerUpdateDtoBase: EntityDtoBase, IEntityDto<DomainNamespace.StoreOwner>
{
    /// <summary>
    /// Owner Name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Temporary Owner Name 
    /// <remarks>Required.</remarks>    
    /// </summary>
    [Required(ErrorMessage = "TemporaryOwnerName is required")]
    
    public virtual System.String TemporaryOwnerName { get; set; } = default!;
    /// <summary>
    /// Vat Number 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual VatNumberDto? VatNumber { get; set; }
    /// <summary>
    /// Street Address 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual StreetAddressDto? StreetAddress { get; set; }
    /// <summary>
    /// Owner Greeting 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual TranslatedTextDto? LocalGreeting { get; set; }
    /// <summary>
    /// Notes 
    /// <remarks>Optional.</remarks>    
    /// </summary>
    public virtual System.String? Notes { get; set; }
}