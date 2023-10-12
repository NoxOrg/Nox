// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;

using MediatR;

using Nox.Application.Dto;
using Nox.Types;
using Nox.Domain;
using Nox.Extensions;
using System.Text.Json.Serialization;
using Cryptocash.Domain;
using ExchangeRateEntity = Cryptocash.Domain.ExchangeRate;

namespace Cryptocash.Application.Dto;

public record ExchangeRateKeyDto(System.Int64 keyId);

public partial class ExchangeRateDto : ExchangeRateDtoBase
{

}

/// <summary>
/// Exchange rate and related data.
/// </summary>
public abstract class ExchangeRateDtoBase : EntityDtoBase, IEntityDto<ExchangeRateEntity>
{

    #region Validation
    public virtual IReadOnlyDictionary<string, IEnumerable<string>> Validate()
    {
        var result = new Dictionary<string, IEnumerable<string>>();
    
        ExecuteActionAndCollectValidationExceptions("EffectiveRate", () => Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveRate(this.EffectiveRate), result);
    
        ExecuteActionAndCollectValidationExceptions("EffectiveAt", () => Cryptocash.Domain.ExchangeRateMetadata.CreateEffectiveAt(this.EffectiveAt), result);
    

        return result;
    }
    #endregion

    /// <summary>
    /// Exchange rate unique identifier (Required).
    /// </summary>
    public System.Int64 Id { get; set; } = default!;

    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    public System.Int32 EffectiveRate { get; set; } = default!;

    /// <summary>
    /// Exchange rate conversion amount (Required).
    /// </summary>
    public System.DateTimeOffset EffectiveAt { get; set; } = default!;
}