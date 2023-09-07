// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ClientApi.Application.Dto;

/// <summary>
/// Store owners.
/// </summary>
public partial class StoreOwnerUpdateDto
{
    /// <summary>
    /// Owner Name (Required).
    /// </summary>
    [Required(ErrorMessage = "Name is required")]
    
    public System.String Name { get; set; } = default!;
    /// <summary>
    /// Vat Number (Optional).
    /// </summary>
    public VatNumberDto? VatNumber { get; set; }
    /// <summary>
    /// Street Address (Optional).
    /// </summary>
    public StreetAddressDto? StreetAddress { get; set; }
}