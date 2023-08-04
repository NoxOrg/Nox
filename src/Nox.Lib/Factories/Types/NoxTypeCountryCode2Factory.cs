using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{

    public class NoxTypeCountryCode2Factory : NoxTypeFactoryBase<CountryCode2>
    {
        public NoxTypeCountryCode2Factory(NoxSolution solution) : base(solution)
        {
        }

        public override CountryCode2? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            return CountryCode3.From(value);
        }
    }
}