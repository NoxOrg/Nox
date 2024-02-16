using Nox.Reference;
using Nox.Reference.Data.World;

namespace Nox.Types.Extensions;

/// <summary>
/// Provides extension methods for the LanguageCode
/// </summary>
public static class LanguageCodeExtensions
{
    /// <summary>
    /// Retrieves the reference language for a given language code.
    /// </summary>
    /// <param name="languageCode">The language code.</param>
    /// <returns>The reference language that corresponds to the given language code.</returns> 
    public static Language GetReferenceLanguage(this LanguageCode languageCode)
    {
        using var worldContext = new WorldContext();
        return worldContext.GetLanguagesQuery().GetByIso_639_1(languageCode.Value)!;
    }

    /// <summary>
    /// Retrieves the reference language code for the specified <paramref name="referenceLanguage"/>.
    /// </summary>
    /// <param name="referenceLanguage">The <see cref="Language"/> object.</param>
    /// <returns>The reference language code as a <see cref="LanguageCode"/> object.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="referenceLanguage"/> or <paramref name="referenceLanguage"/>'s Iso_639_1 value is null.</exception>
    public static LanguageCode GetLanguageCode(this Language referenceLanguage)
    {
        ArgumentNullException.ThrowIfNull(referenceLanguage);
        ArgumentNullException.ThrowIfNull(referenceLanguage.Iso_639_1);
        return LanguageCode.From(referenceLanguage.Iso_639_1);
    }
}