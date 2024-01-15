using Nox.Reference;

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
        => World.Languages.GetByIso_639_1(languageCode.Value)!;


   
}