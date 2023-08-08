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

        public override User? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            if (value == null)
            {
                return null;
            }

            NoxSimpleTypeDefinition attributeDefinition = GetAttributeDefinition(entityDefinition, propertyName);

            return User.From(value, attributeDefinition.UserTypeOptions ?? new UserTypeOptions());
        }
    }
}
