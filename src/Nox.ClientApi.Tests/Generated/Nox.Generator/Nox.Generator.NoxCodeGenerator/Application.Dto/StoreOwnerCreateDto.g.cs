// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Store owners.
/// </summary>
public partial class StoreOwnerCreateDto : StoreOwnerCreateDtoBase
{

}

/// <summary>
/// Store owners.
/// </summary>
public abstract class StoreOwnerCreateDtoBase : IEntityDto<DomainNamespace.StoreOwner>
{
    /// <summary>
    ///     
    /// </summary>
    /// <remarks>Required.</remarks>    
    [Required(ErrorMessage = "Id is required")]
    public System.String? Id { get; set; }
    /// <summary>
    /// Owner Name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String? Name { get; set; }
    /// <summary>
    /// Temporary Owner Name     
    /// </summary>
    /// <remarks>Required</remarks>
    [Required(ErrorMessage = "TemporaryOwnerName is required")]
    
    public virtual System.String? TemporaryOwnerName { get; set; }
    /// <summary>
    /// Vat Number     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual VatNumberDto? VatNumber { get; set; }
    /// <summary>
    /// Street Address     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual StreetAddressDto? StreetAddress { get; set; }
    /// <summary>
    /// Owner Greeting     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual TranslatedTextDto? LocalGreeting { get; set; }
    /// <summary>
    /// Notes     
    /// </summary>
    /// <remarks>Optional</remarks>
    public virtual System.String? Notes { get; set; }

    /// <summary>
    /// StoreOwner Set of stores that this owner owns OneOrMany Stores
    /// </summary>
    public virtual List<System.Guid> StoresId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<StoreCreateDto> Stores { get; set; } = new();
}