// Generated

#nullable enable
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using Nox.Abstractions;
using Nox.Application.Dto;
using Nox.Domain;
using Nox.Extensions;
using Nox.Types;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

/// <summary>
/// Store owners.
/// </summary>
public partial class StoreOwnerCreateDto : IEntityCreateDto <StoreOwner>
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