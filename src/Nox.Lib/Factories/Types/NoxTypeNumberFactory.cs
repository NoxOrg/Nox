using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeNumberFactory : NoxTypeFactoryBase<Number>
    {
        public NoxTypeNumberFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Number? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            return Number.From(value, simpleTypeDefinition.NumberTypeOptions ?? new NumberTypeOptions());
        }
    }
}