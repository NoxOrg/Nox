using Nox.Reference;

namespace Nox.Types.Extensions;

/// <summary>
/// Class containing extension methods for the <see cref="Language"/> class.
/// </summary>
public static class LanguageExtensions
{
    /// <summary>
    /// Retrieves the reference language code for the specified <paramref name="language"/>.
    /// </summary>
    /// <param name="language">The <see cref="Language"/> object.</param>
    /// <returns>The reference language code as a <see cref="LanguageCode"/> object.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="language"/> or <paramref name="language"/>'s Iso_639_1 value is null.</exception>
    public static LanguageCode GetReferenceLanguageCode(this Language language)
    {
        if (language.Iso_639_1 is not null)
        {
            return LanguageCode.From(language.Iso_639_1);
        }

        throw new ArgumentNullException(nameof(language), "Language.Iso_639_1 is null");
    }
}