using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeTimeFactory : NoxTypeFactoryBase<Time>
    {
        public NoxTypeTimeFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Time? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }

            return Time.From(value, simpleTypeDefinition.TimeTypeOptions ?? new TimeTypeOptions());
        }        
    }
}