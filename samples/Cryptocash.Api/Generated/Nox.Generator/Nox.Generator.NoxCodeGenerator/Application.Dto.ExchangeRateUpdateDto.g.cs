// Generated

#nullable enable

using Nox.Abstractions;
using Nox.Types;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CryptocashApi.Application.Dto;

/// <summary>
/// Exchange rate and related data.
/// </summary>
public partial class ExchangeRateUpdateDto
{
    //TODO Add owned Entities and update odata endpoints
    /// <summary>
    /// The exchange rate conversion amount (Required).
    /// </summary>
    [Required(ErrorMessage = "EffectiveRate is required")]
    
    public System.Int32 EffectiveRate { get; set; } = default!;
    /// <summary>
    /// The exchange rate conversion amount (Required).
    /// </summary>
    [Required(ErrorMessage = "EffectiveAt is required")]
    
    public System.DateTimeOffset EffectiveAt { get; set; } = default!;

    /// <summary>
    /// ExchangeRate The currency exchanged from ExactlyOne Currencies
    /// </summary>
    [Required(ErrorMessage = "CurrencyFrom is required")]
    public System.String CurrencyId { get; set; } = default!;
}