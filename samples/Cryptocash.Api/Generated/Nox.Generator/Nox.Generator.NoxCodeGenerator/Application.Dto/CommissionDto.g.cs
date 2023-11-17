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


using DomainNamespace = Cryptocash.Domain;

namespace Cryptocash.Application.Dto;

public record CommissionKeyDto(System.Int64 keyId);

/// <summary>
/// Update Commission
/// Exchange commission rate and amount.
/// </summary>
public partial class CommissionDto : CommissionDtoBase
{

}

/// <summary>
/// Exchange commission rate and amount.
/// </summary>
public abstract class CommissionDtoBase : EntityDtoBase, IEntityDto<DomainNamespace.Commission>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        ExecuteActionAndCollectValidationExceptions("Rate", () => DomainNamespace.CommissionMetadata.CreateRate(this.Rate), result);
    
        ExecuteActionAndCollectValidationExceptions("EffectiveAt", () => DomainNamespace.CommissionMetadata.CreateEffectiveAt(this.EffectiveAt), result);
    

        return result;
    }
    #endregion

    /// <summary>
    /// Commission unique identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Commission rate     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.Single Rate { get; set; } = default!;

    /// <summary>
    /// Exchange rate conversion amount     
    /// </summary>
    /// <remarks>Required.</remarks>    
    public System.DateTimeOffset EffectiveAt { get; set; } = default!;

    /// <summary>
    /// Commission fees for ZeroOrOne Countries
    /// </summary>
    //EF maps ForeignKey Automatically
    public System.String? CountryId { get; set; } = default!;
    public virtual CountryDto? Country { get; set; } = null!;

    /// <summary>
    /// Commission fees for ZeroOrMany Bookings
    /// </summary>
    public virtual List<BookingDto> Bookings { get; set; } = new();
    [System.Text.Json.Serialization.JsonIgnore]
    public System.DateTime? DeletedAtUtc { get; set; }

    [JsonPropertyName("@odata.etag")]
    public System.Guid Etag { get; init; }
}