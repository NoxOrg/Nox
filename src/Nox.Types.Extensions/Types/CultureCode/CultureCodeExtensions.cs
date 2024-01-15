using Nox.Reference;

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
        => World.Cultures.Get(cultureCode.Value)!;
}