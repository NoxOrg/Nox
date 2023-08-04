using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeCountryCode3Factory : NoxTypeFactoryBase<CountryCode3>
    {
        public NoxTypeCountryCode3Factory(NoxSolution solution) : base(solution)
        {
        }

        public override CountryCode3? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            return CountryCode3.From(value);
        }
    }
}