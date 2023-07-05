using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
///   Class for three-letter country codes (ISO alpha-3).
/// </summary>
public class CountryCode3Converter : ValueConverter<CountryCode3,string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CountryCode3Converter" /> class.
    /// </summary>
    public CountryCode3Converter() : base (countryCode3 => countryCode3.Value, countryCode3Value => CountryCode3.From(countryCode3Value)) { }
}