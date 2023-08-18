using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types;

/// <summary>
/// The nox type year factory.
/// </summary>
public class NoxTypeYearFactory : NoxTypeFactoryBase<Year>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NoxTypeYearFactory"/> class.
    /// </summary>
    /// <param name="solution">The solution.</param>
    public NoxTypeYearFactory(NoxSolution solution) : base(solution)
    {
    }

    /// <inheritdoc />>
    public override Year? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        => value is null ? null :Year.From(value, simpleTypeDefinition.YearTypeOptions ?? new YearTypeOptions());
}
