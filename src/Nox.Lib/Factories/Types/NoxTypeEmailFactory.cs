using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeEmailFactory : NoxTypeFactoryBase<Email>
    {
        public NoxTypeEmailFactory(NoxSolution solution) : base(solution)
        {
        }

        public override Email? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            return Email.From(value);
        }
    }
}