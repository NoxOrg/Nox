using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeVolumeFactory : NoxTypeFactoryBase<Volume>
    {
        public NoxTypeVolumeFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Volume? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }

            NoxSimpleTypeDefinition attributeDefinition = GetAttributeDefinition(entityDefinition, propertyName);

            return Volume.From(value, attributeDefinition.VolumeTypeOptions ?? new VolumeTypeOptions());
        }        
    }
}