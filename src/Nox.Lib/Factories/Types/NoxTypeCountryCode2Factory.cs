using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{

    public class NoxTypeCountryCode2Factory : NoxTypeFactoryBase<CountryCode2>
    {
        public NoxTypeCountryCode2Factory(NoxSolution solution) : base(solution)
        {
        }

        public override CountryCode2? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            return CountryCode2.From(value); ;
        }
    }
}