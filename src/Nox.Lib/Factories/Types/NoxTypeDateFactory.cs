using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types;

public class NoxTypeDateFactory : NoxTypeFactoryBase<Date>
{
    public NoxTypeDateFactory(NoxSolution solution) : base(solution)
    {
    }

    public override Date? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
    {
        if (value == null)
        {
            return null;
        }
            
        return Date.From(value, simpleTypeDefinition.DateTypeOptions ?? new DateTypeOptions());
    }
}