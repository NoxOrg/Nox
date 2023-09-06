// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;

using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record StoreOwnerKeyDto(System.String keyId);

/// <summary>
/// Store owners.
/// </summary>
public partial class StoreOwnerDto
{

    /// <summary>
    ///  (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Owner Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Vat Number (Optional).
    /// </summary>
    public VatNumberDto? VatNumber { get; set; }

    /// <summary>
    /// Street Address (Optional).
    /// </summary>
    public StreetAddressDto? StreetAddress { get; set; }

    /// <summary>
    /// StoreOwner Set of stores that this owner owns ZeroOrMany Stores
    /// </summary>
    public virtual List<StoreDto> Stores { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }    
}