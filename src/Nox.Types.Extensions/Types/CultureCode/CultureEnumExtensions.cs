using Nox.Reference;
using Nox.Types.Abstractions.Extensions;

namespace Nox.Types.Extensions;

/// <summary>
/// Provides extension methods for the <see cref="Culture"/> enum.
/// </summary>
public static class CultureEnumExtensions
{
    /// <summary>
    /// Gets the reference culture corresponding to the specified culture enum.
    /// </summary>
    /// <param name="culture">The culture.</param>
    /// <returns>The reference culture.</returns>
    public static Nox.Reference.Culture GetReferenceCulture(this Culture culture)
        => World.Cultures.Get(culture.ToDisplayName())!;
}