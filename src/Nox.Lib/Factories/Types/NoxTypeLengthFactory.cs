using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeLengthFactory : NoxTypeFactoryBase<Length>
    {
        public NoxTypeLengthFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Length? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            
            return Length.From(value, simpleTypeDefinition.LengthTypeOptions ?? new LengthTypeOptions());
        }
    }
}
