using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeWeightFactory : NoxTypeFactoryBase<Weight>
    {
        public NoxTypeWeightFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Weight? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }

            return Weight.From(value, simpleTypeDefinition.WeightTypeOptions ?? new WeightTypeOptions());
        }        
    }
}