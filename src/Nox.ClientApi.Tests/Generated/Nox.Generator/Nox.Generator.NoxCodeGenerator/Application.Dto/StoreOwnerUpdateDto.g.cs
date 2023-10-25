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
public partial class StoreOwnerUpdateDto : IEntityDto<DomainNamespace.StoreOwner>
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