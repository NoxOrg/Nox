using Nox.Solution;
using Nox.Types;

namespace Nox.Factories
{
    public abstract class NoxTypeFactoryBase<T> : INoxTypeFactory<T> where T : INoxType
    {
        protected NoxTypeFactoryBase(NoxSolution solution)
        {
            Solution = solution;
        }

        public NoxSolution Solution { get; }

        public virtual T? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            NoxSimpleTypeDefinition? definition;
            entityDefinition.TryGetKeyByName(propertyName, out definition);
            if (definition == null)
            {
                entityDefinition.TryGetAttributeByName(propertyName, out definition);
            }
            if (definition == null)
            {
                entityDefinition.TryGetRelationshipByName(Solution, propertyName, out definition);
            }

            return CreateNoxType(definition, value);
        }

        public abstract T? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value);
    }
}
