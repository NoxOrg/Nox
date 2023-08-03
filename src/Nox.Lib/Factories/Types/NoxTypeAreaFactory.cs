using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeAreaFactory : NoxTypeFactoryBase<Area>
    {
        public NoxTypeAreaFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Area? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            if(value == null)
            {
                return null;
            }
            var attributeDefinition = entityDefinition.Attributes!.Single(attribute => attribute.Name == propertyName);

            return Area.From(value, attributeDefinition.AreaTypeOptions ?? new AreaTypeOptions());
        }
    }
}
