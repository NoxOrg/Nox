using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeWeightFactory : NoxTypeFactoryBase<Weight>
    {
        public NoxTypeWeightFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Weight? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }

            NoxSimpleTypeDefinition attributeDefinition = GetAttributeDefinition(entityDefinition, propertyName);

            return Weight.From(value, attributeDefinition.WeightTypeOptions ?? new WeightTypeOptions());
        }        
    }
}