using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types;
/// <summary>
/// The nox type date time schedule factory.
/// </summary>

public class NoxTypeDateTimeScheduleFactory : NoxTypeFactoryBase<DateTimeSchedule>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NoxTypeDateTimeScheduleFactory"/> class.
    /// </summary>
    /// <param name="solution">The solution.</param>
    public NoxTypeDateTimeScheduleFactory(NoxSolution solution) : base(solution)
    {
    }

    /// <inheritdoc />
    public override DateTimeSchedule? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        => value is null ? null : DateTimeSchedule.From(value);
}
