using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeDayOfWeekFactory : NoxTypeFactoryBase<Nox.Types.DayOfWeek>
    {
        public NoxTypeDayOfWeekFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Nox.Types.DayOfWeek? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            return Nox.Types.DayOfWeek.From(value);
        }
    }
}