using Nox.Reference;

namespace Nox.Types.Extensions;

/// <summary>
/// Class containing extension methods for the <see cref="Language"/> class.
/// </summary>
public static class LanguageExtensions
{
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