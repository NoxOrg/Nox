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

public partial class CurrencyCreateDto : CurrencyCreateDtoBase
{

}

/// <summary>
/// Currency and related data.
/// </summary>
public abstract class CurrencyCreateDtoBase : IEntityDto<DomainNamespace.Currency>
{
    /// <summary>
    /// Currency unique identifier (Required).
    /// </summary>
    [Required(ErrorMessage = "Id is required")]
    public System.String Id { get; set; } = default!;
    /// <summary>
    /// Currency's name (Optional).
    /// </summary>
    public virtual System.String? Name { get; set; }
    /// <summary>
    /// Currency's symbol (Optional).
    /// </summary>
    public virtual System.String? Symbol { get; set; }

    /// <summary>
    /// Currency List of store licenses where this currency is a default one OneOrMany StoreLicenses
    /// </summary>
    public virtual List<System.Int64> StoreLicenseDefaultId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<StoreLicenseCreateDto> StoreLicenseDefault { get; set; } = new();

    /// <summary>
    /// Currency List of store licenses that were sold in this currency OneOrMany StoreLicenses
    /// </summary>
    public virtual List<System.Int64> StoreLicenseSoldInId { get; set; } = new();
    
    [System.Text.Json.Serialization.JsonIgnore]
    public virtual List<StoreLicenseCreateDto> StoreLicenseSoldIn { get; set; } = new();
}