using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types;

public class NoxTypeJsonFactory : NoxTypeFactoryBase<Json>
{
    public NoxTypeJsonFactory(NoxSolution solution) : base(solution)
    {
    }

    public override Json? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
    {
        if (value == null)
        {
            return null;
        }

        return Json.From(value, simpleTypeDefinition.JsonTypeOptions ?? new JsonTypeOptions());
    }
}