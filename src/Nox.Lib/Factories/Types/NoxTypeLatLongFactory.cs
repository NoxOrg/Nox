using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeLatLongFactory : NoxTypeFactoryBase<LatLong>
    {
        public NoxTypeLatLongFactory(NoxSolution solution) : base(solution)
        {
        }
        public override LatLong? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            return LatLong.From(value.Latitude, value.Longitude);
        }
    }
}