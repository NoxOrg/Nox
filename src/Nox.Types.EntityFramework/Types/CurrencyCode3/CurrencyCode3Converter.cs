using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework;

/// <summary>
/// Class for three-letters currency code (ISO 4217).
/// </summary>
public class CurrencyCode3Converter : ValueConverter<CurrencyCode3, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CurrencyCode3Converter" /> class.
    /// </summary>
    public CurrencyCode3Converter() : base(currencyCode3 => currencyCode3.Value, currencyCode3Value => CurrencyCode3.From(currencyCode3Value)) { }
}