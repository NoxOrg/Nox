// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ClientApi.Domain;

using StoreOwnerEntity = ClientApi.Domain.StoreOwner;
namespace ClientApi.Application.Dto;

/// <summary>
/// Store owners.
/// </summary>
public partial class StoreOwnerUpdateDto : IEntityDto<StoreOwnerEntity>
{
    /// <summary>
    /// Owner Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Temporary Owner Name (Required).
    /// </summary>
    [Required(ErrorMessage = "TemporaryOwnerName is required")]
    
    public System.String TemporaryOwnerName { get; set; } = default!;
    /// <summary>
    /// Vat Number (Optional).
    /// </summary>
    public VatNumberDto? VatNumber { get; set; }
    /// <summary>
    /// Street Address (Optional).
    /// </summary>
    public StreetAddressDto? StreetAddress { get; set; }
    /// <summary>
    /// Owner Greeting (Optional).
    /// </summary>
    public TranslatedTextDto? LocalGreeting { get; set; }
    /// <summary>
    /// Notes (Optional).
    /// </summary>
    public System.String? Notes { get; set; }
}