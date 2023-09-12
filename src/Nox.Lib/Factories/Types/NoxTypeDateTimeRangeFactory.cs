using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types;

public class NoxTypeDateTimeRangeFactory : NoxTypeFactoryBase<DateTimeRange>
{
    public NoxTypeDateTimeRangeFactory(NoxSolution solution) : base(solution)
    {
    }

    public override DateTimeRange? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
    {
        if (value == null)
        {
            return null;
        }
        return DateTimeRange.From(value.Start, value.End, simpleTypeDefinition.DateTimeRangeTypeOptions ?? new DateTimeRangeTypeOptions());
    }
}