using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types;

public class NoxTypeIpAddressFactory : NoxTypeFactoryBase<IpAddress>
{
    public NoxTypeIpAddressFactory(NoxSolution solution) : base(solution)
    {
    }

    public override IpAddress? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
    {
        if (value == null)
        {
            return null;
        }
        return IpAddress.From(value);
    }
}