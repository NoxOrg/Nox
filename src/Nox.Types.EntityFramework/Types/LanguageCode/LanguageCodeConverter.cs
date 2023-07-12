using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
///  Class for two-letter language codes (ISO 639-1).
/// </summary>
public class LanguageCodeConverter : ValueConverter<LanguageCode, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LanguageCodeConverter" /> class.
    /// </summary>
    public LanguageCodeConverter() : base(languageCode => languageCode.Value, languageCodeValue => LanguageCode.From(languageCodeValue))
    {
    }
}