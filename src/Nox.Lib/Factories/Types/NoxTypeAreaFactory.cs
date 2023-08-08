using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeAreaFactory : NoxTypeFactoryBase<Area>
    {
        public NoxTypeAreaFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Area? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }

            return Area.From(value, simpleTypeDefinition.AreaTypeOptions ?? new AreaTypeOptions());
        }
    }
}
