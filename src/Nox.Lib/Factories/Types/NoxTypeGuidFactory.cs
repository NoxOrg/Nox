using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeGuidFactory : NoxTypeFactoryBase<Nox.Types.Guid>
    {
        public NoxTypeGuidFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Nox.Types.Guid? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            return Nox.Types.Guid.From(value);
        }
    }
}