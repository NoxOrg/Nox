using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeLatLongFactory : NoxTypeFactoryBase<LatLong>
    {
        public NoxTypeLatLongFactory(NoxSolution solution) : base(solution)
        {
        }

        public override LatLong? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            var attributeDefinition = entityDefinition.Attributes!.Single(attribute => attribute.Name == propertyName);

            return LatLong.From(value.Latitude, value.Longitude);
        }
    }
}