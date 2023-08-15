using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeMacAddressFactory : NoxTypeFactoryBase<MacAddress>
    {
        public NoxTypeMacAddressFactory(NoxSolution solution) : base(solution)
        {
        }

        public override MacAddress? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            return MacAddress.From(value);
        }
    }
}