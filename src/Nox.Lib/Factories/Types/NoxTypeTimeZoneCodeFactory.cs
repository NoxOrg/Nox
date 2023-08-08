using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeTimeZoneCodeFactory : NoxTypeFactoryBase<TimeZoneCode>
    {
        public NoxTypeTimeZoneCodeFactory(NoxSolution solution) : base(solution)
        {
        }

        public override TimeZoneCode? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            return value == null ? null : TimeZoneCode.From(value);
        }
    }
}
