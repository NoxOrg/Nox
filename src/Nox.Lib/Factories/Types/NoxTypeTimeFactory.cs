using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeTimeFactory : NoxTypeFactoryBase<Time>
    {
        public NoxTypeTimeFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Time? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }

            NoxSimpleTypeDefinition attributeDefinition = GetAttributeDefinition(entityDefinition, propertyName);

            return Time.From(value, attributeDefinition.TimeTypeOptions ?? new TimeTypeOptions());
        }        
    }
}