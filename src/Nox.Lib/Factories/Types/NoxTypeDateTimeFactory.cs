using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types;

/// <summary>
/// The nox type date time factory.
/// </summary>
public class NoxTypeDateTimeFactory : NoxTypeFactoryBase<Nox.Types.DateTime>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NoxTypeDateTimeFactory"/> class.
    /// </summary>
    /// <param name="solution">The solution.</param>
    public NoxTypeDateTimeFactory(NoxSolution solution) : base(solution)
    {
    }

    /// <summary>
    /// Creates the nox type.
    /// </summary>
    /// <param name="simpleTypeDefinition">The simple type definition.</param>
    /// <param name="value">The value.</param>
    /// <returns>A Nox.Types.DateTime? .</returns>
    public override Nox.Types.DateTime? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        => value is null ? null : Nox.Types.DateTime.From(value!, simpleTypeDefinition.DateTimeTypeOptions ?? new DateTimeTypeOptions());
}
