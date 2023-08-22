using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types;

/// <summary>
/// The nox type date time duration factory.
/// </summary>
public class NoxTypeDateTimeDurationFactory : NoxTypeFactoryBase<Nox.Types.DateTimeDuration>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NoxTypeDateTimeDurationFactory"/> class.
    /// </summary>
    /// <param name="solution">The solution.</param>
    public NoxTypeDateTimeDurationFactory(NoxSolution solution) : base(solution)
    {
    }

    /// <summary>
    /// Creates the nox type.
    /// </summary>
    /// <param name="simpleTypeDefinition">The simple type definition.</param>
    /// <param name="value">The value.</param>
    /// <returns>A DateTimeDuration? .</returns>
  
    public override DateTimeDuration? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
    {
        if (value == null)
        {
            return null;
        }
        return DateTimeDuration.From(value, simpleTypeDefinition.DateTimeDurationTypeOptions ?? new DateTimeDurationTypeOptions());
    }
}
