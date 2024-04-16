// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;

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
public partial class StoreOwnerUpdateDtoBase: EntityDtoBase
{
    /// <summary>
    /// Owner Name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String? Name { get; set; }
    /// <summary>
    /// Temporary Owner Name     
    /// </summary>
    /// <remarks>Required.</remarks>
    [Required(ErrorMessage = "TemporaryOwnerName is required")]
    
    public virtual System.String? TemporaryOwnerName { get; set; }
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