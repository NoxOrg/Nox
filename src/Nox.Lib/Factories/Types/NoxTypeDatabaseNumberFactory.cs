using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeDatabaseNumberFactory : NoxTypeFactoryBase<Nox.Types.DatabaseNumber>
    {
        public NoxTypeDatabaseNumberFactory(NoxSolution solution) : base(solution)
        {
        }
     
        public override Nox.Types.DatabaseNumber? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            return Nox.Types.DatabaseNumber.FromDatabase(value);
        }
    }
}