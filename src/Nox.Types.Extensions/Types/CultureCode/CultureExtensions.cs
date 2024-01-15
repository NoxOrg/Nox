namespace Nox.Types.Extensions;

/// <summary>
/// Extenstion class to provide additional methods for operating with cultures.
/// </summary>
public static class CultureExtensions
{
    /// <summary>
    /// Retrieves the reference culture corresponding to the given <see cref="Nox.Reference.Culture"/>.
    /// </summary>
    /// <param name="culture">The <see cref="Nox.Reference.Culture"/> to get the reference culture for.</param>
    /// <returns>The reference culture as a <see cref="CultureCode"/>.</returns>
    public static CultureCode GetReferenceCultureCode(this Nox.Reference.Culture culture)
        => CultureCode.From(culture.Name);
}