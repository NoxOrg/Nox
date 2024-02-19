using Nox.Reference;
using Nox.Reference.Data.World;
using Nox.Types.Abstractions.Extensions;

namespace Nox.Types.Extensions;

/// <summary>
/// Extension methods for <see cref="CultureCode"/> class.
/// </summary>
public static class CultureCodeExtensions
{
    /// <summary>
    /// Retrieves the reference culture associated with the given culture code.
    /// </summary>
    /// <param name="cultureCode">The culture code to retrieve the reference culture for.</param>
    /// <returns>The reference culture associated with the given culture code.</returns>
    public static Nox.Reference.Culture GetReferenceCulture(this CultureCode cultureCode)
    {
        using var worldContext = new WorldContext();
        return worldContext.GetCulturesQuery().Get(cultureCode.Value)!;
    }

    /// <summary>
    /// Gets the reference culture corresponding to the specified culture enum.
    /// </summary>
    /// <param name="culture">The culture.</param>
    /// <returns>The reference culture.</returns>
    public static Nox.Reference.Culture GetReferenceCulture(this Culture culture)
    {
        using var worldContext = new WorldContext();
        return worldContext.GetCulturesQuery().Get(culture.ToDisplayName())!;
    }

    /// <summary>
    /// Retrieves the reference culture corresponding to the given <see cref="Nox.Reference.Culture"/>.
    /// </summary>
    /// <param name="culture">The <see cref="Nox.Reference.Culture"/> to get the reference culture for.</param>
    /// <returns>The reference culture as a <see cref="CultureCode"/>.</returns>
    public static CultureCode GetCultureCode(this Nox.Reference.Culture culture)
        => CultureCode.From(culture.Name);
}