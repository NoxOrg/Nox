using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeNuidFactory : NoxTypeFactoryBase<Nuid>
    {
        public NoxTypeNuidFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Nuid? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }

            return Nuid.From(value, simpleTypeDefinition.NuidTypeOptions ?? new NuidTypeOptions());
        }
    }
}
