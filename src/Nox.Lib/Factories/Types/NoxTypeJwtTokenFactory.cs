using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types;
/// <summary>
/// The nox type jwt token factory.
/// </summary>

public class NoxTypeJwtTokenFactory : NoxTypeFactoryBase<JwtToken>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NoxTypeJwtTokenFactory"/> class.
    /// </summary>
    /// <param name="solution">The solution.</param>
    public NoxTypeJwtTokenFactory(NoxSolution solution) : base(solution)
    {
    }

    /// <inheritdoc />
    public override JwtToken? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        => value is null ? null : JwtToken.From(value!);
}
