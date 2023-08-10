using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeBooleanFactory : NoxTypeFactoryBase<Nox.Types.Boolean>
    {
        public NoxTypeBooleanFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Nox.Types.Boolean? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            return Nox.Types.Boolean.From(value);
        }
    }
}