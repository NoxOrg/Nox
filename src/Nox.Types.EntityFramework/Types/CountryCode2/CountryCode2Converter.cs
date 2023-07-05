using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
///   Class for two-letter country codes (ISO alpha-2).
/// </summary>
public class CountryCode2Converter : ValueConverter<CountryCode2, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CountryCode2Converter" /> class.
    /// </summary>
    public CountryCode2Converter() : base(countryCode2 => countryCode2.Value, countryCode2Value => CountryCode2.From(countryCode2Value)) { }
}