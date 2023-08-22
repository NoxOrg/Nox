using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeDatabaseNumberFactory : NoxTypeFactoryBase<DatabaseNumber>
    {
        public NoxTypeDatabaseNumberFactory(NoxSolution solution) : base(solution)
        {
        }
     
        public override DatabaseNumber? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            return DatabaseNumber.FromDatabase(value);
        }
    }
}