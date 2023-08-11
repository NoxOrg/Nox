using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypePercentageFactory : NoxTypeFactoryBase<Percentage>
    {
        public NoxTypePercentageFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Percentage? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }

            return Percentage.From(value, simpleTypeDefinition.PercentageTypeOptions ?? new PercentageTypeOptions());
        }        
    }
}