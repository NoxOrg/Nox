using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeDistanceFactory : NoxTypeFactoryBase<Distance>
    {
        public NoxTypeDistanceFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Distance? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            
            return Distance.From(value, simpleTypeDefinition.DistanceTypeOptions ?? new DistanceTypeOptions());
        }
    }
}
