using Nox.Solution;
using Nox.Types;

namespace Nox.Factories
{
    public abstract class NoxTypeFactoryBase<T> : INoxTypeFactory<T> where T : INoxType
    {
        public NoxTypeFactoryBase(NoxSolution solution)
        {
            Solution = solution;
        }

        public NoxSolution Solution { get; }

        public virtual T? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value)
        {
            var attributeDefinition = entityDefinition.GetAttributeByName(propertyName);

            return CreateNoxType(attributeDefinition, value);
        }

        public abstract T? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value);
    }
}
