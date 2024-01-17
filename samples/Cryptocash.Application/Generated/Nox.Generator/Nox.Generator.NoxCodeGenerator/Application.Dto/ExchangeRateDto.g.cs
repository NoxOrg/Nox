// Generated

#nullable enable

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;


namespace Cryptocash.Application.Dto;

public record ExchangeRateKeyDto(System.Int64 keyId);

/// <summary>
/// Update ExchangeRate
/// Exchange rate and related data.
/// </summary>
public partial class ExchangeRateDto : ExchangeRateDtoBase
{

}

/// <summary>
/// Exchange rate and related data.
/// </summary>
public abstract class ExchangeRateDtoBase : EntityDtoBase
{
    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        CollectValidationExceptions("EffectiveRate", () => ExchangeRateMetadata.CreateEffectiveRate(this.EffectiveRate), result);
    
        CollectValidationExceptions("EffectiveAt", () => ExchangeRateMetadata.CreateEffectiveAt(this.EffectiveAt), result);
    

        return result;
    }
    #endregion

    /// <summary>
    /// Exchange rate unique identifier
    /// </summary>    
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Exchange rate conversion amount     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.Int32 EffectiveRate { get; set; } = default!;

    /// <summary>
    /// Exchange rate conversion amount     
    /// </summary>
    /// <remarks>Required.</remarks>
    public System.DateTimeOffset EffectiveAt { get; set; } = default!;
}