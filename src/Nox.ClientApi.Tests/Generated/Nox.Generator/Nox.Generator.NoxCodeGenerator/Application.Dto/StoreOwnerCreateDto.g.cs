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

public partial class StoreOwnerCreateDto : StoreOwnerCreateDtoBase
{

}

/// <summary>
/// Store owners.
/// </summary>
public abstract class StoreOwnerCreateDtoBase : IEntityDto<DomainNamespace.StoreOwner>
{
    /// <summary>
    ///  (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    /// Owner Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public virtual System.String Name { get; set; } = default!;
    /// <summary>
    /// Temporary Owner Name (Required).
    /// </summary>
    [Required(ErrorMessage = "TemporaryOwnerName is required")]
    
    public virtual System.String TemporaryOwnerName { get; set; } = default!;
    /// <summary>
    /// Vat Number (Optional).
    /// </summary>
    public virtual VatNumberDto? VatNumber { get; set; }
    /// <summary>
    /// Street Address (Optional).
    /// </summary>
    public virtual StreetAddressDto? StreetAddress { get; set; }
    /// <summary>
    /// Owner Greeting (Optional).
    /// </summary>
    public virtual TranslatedTextDto? LocalGreeting { get; set; }
    /// <summary>
    /// Notes (Optional).
    /// </summary>
    public virtual System.String? Notes { get; set; }

    /// <summary>
    /// StoreOwner Set of stores that this owner owns ZeroOrMany Stores
    /// </summary>
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<StoreCreateDto> Stores { get; set; } = new();
}