using Nox.Solution;
using Nox.TypeOptions;
using Nox.Types;

namespace Nox.Factories.Types
{
    public class NoxTypeUserFactory : NoxTypeFactoryBase<User>
    {
        public NoxTypeUserFactory(NoxSolution solution) : base(solution)
        {
        }

        public override User? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }

            return User.From(value, simpleTypeDefinition.UserTypeOptions ?? new UserTypeOptions());
        }
    }
}
