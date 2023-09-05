// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using ClientApi.Domain;

namespace ClientApi.Application.Dto;

public record CountryKeyDto(System.Int64 keyId);

/// <summary>
/// Country Entity.
/// </summary>
public partial class CountryDto
{

    /// <summary>
    /// The unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// The Country Name (Required).
    /// </summary>
    public System.String Name { get; set; } = default!;

    /// <summary>
    /// Population (Optional).
    /// </summary>
    public System.Int32? Population { get; set; }

    /// <summary>
    /// The Money (Optional).
    /// </summary>
    public MoneyDto? CountryDebt { get; set; }

    /// <summary>
    /// The Formula (Optional).
    /// </summary>
    public System.String? ShortDescription { get; set; }

    /// <summary>
    /// Country is also know as ZeroOrMany CountryLocalNames
    /// </summary>
    public virtual List<CountryLocalNameDto> CountryLocalNames { get; set; } = new();
    public System.DateTime? DeletedAtUtc { get; set; }
    [JsonPropertyName("@odata.etag")]
    [JsonProperty("@odata.etag")]
    public System.Guid Etag { get; set; }
}