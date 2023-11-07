// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


using DomainNamespace = ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record CurrencyKeyDto(System.String keyId);

public partial class CurrencyDto : CurrencyDtoBase
{

}

/// <summary>
/// Currency and related data.
/// </summary>
public abstract class CurrencyDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.Currency>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        if (this.Name is not null)
            ExecuteActionAndCollectValidationExceptions("Name", () => DomainNamespace.CurrencyMetadata.CreateName(this.Name.NonNullValue<System.String>()), result);
        if (this.Symbol is not null)
            ExecuteActionAndCollectValidationExceptions("Symbol", () => DomainNamespace.CurrencyMetadata.CreateSymbol(this.Symbol.NonNullValue<System.String>()), result);

        return result;
    }
    #endregion

    /// <summary>
    /// Currency unique identifier (Required).
    /// </summary>
    public System.String Id { get; set; } = default!;

    /// <summary>
    /// Currency's name (Optional).
    /// </summary>
    public System.String? Name { get; set; }

    /// <summary>
    /// Currency's symbol (Optional).
    /// </summary>
    public System.String? Symbol { get; set; }

    /// <summary>
    /// Currency List of store licenses where this currency is a default one OneOrMany StoreLicenses
    /// </summary>
    public virtual List<StoreLicenseDto> StoreLicenseDefault { get; set; } = new();

    /// <summary>
    /// Currency List of store licenses that were sold in this currency OneOrMany StoreLicenses
    /// </summary>
    public virtual List<StoreLicenseDto> StoreLicenseSoldIn { get; set; } = new();
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}