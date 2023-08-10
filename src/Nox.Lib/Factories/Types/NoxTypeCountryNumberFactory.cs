using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeCountryNumberFactory : NoxTypeFactoryBase<CountryNumber>
    {
        public NoxTypeCountryNumberFactory(NoxSolution solution) : base(solution)
        {
        }

        public override CountryNumber? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            return CountryNumber.From(value);
        }
    }
}