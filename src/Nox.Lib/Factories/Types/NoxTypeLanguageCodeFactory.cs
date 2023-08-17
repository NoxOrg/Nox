using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types;

/// <summary>
/// The nox type language code factory.
/// </summary>
public class NoxTypeLanguageCodeFactory : NoxTypeFactoryBase<LanguageCode>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NoxTypeLanguageCodeFactory"/> class.
    /// </summary>
    /// <param name="solution">The solution.</param>
    public NoxTypeLanguageCodeFactory(NoxSolution solution) : base(solution)
    {
    }

    /// <inheritdoc />
    public override LanguageCode? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        => value is null ? null : LanguageCode.From(value);
}
