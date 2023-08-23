using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types;

public class NoxTypeInternetDomainFactory : NoxTypeFactoryBase<InternetDomain>
{
    public NoxTypeInternetDomainFactory(NoxSolution solution) : base(solution)
    {
    }

    public override InternetDomain? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
    {
        if (value == null)
        {
            return null;
        }

        return InternetDomain.From(value);
    }
}