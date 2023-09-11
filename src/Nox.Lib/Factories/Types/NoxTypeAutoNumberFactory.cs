using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeAutoNumberFactory : NoxTypeFactoryBase<AutoNumber>
    {
        public NoxTypeAutoNumberFactory(NoxSolution solution) : base(solution)
        {
        }
     
        public override AutoNumber? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            return AutoNumber.FromDatabase(value);
        }
    }
}