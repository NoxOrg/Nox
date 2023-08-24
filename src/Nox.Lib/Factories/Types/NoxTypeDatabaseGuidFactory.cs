using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeDatabaseGuidFactory : NoxTypeFactoryBase<DatabaseGuid>
    {
        public NoxTypeDatabaseGuidFactory(NoxSolution solution) : base(solution)
        {
        }

        public override DatabaseGuid? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }
            return DatabaseGuid.FromDatabase(value);
        }
    }
}