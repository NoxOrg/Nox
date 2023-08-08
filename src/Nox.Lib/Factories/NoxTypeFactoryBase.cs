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

        public abstract T? CreateNoxType(Entity entityDefinition, string propertyName, dynamic? value);

        protected static NoxSimpleTypeDefinition GetAttributeDefinition(Entity entityDefinition, string propertyName)
        {
            return entityDefinition.Attributes!.Single(attribute => attribute.Name == propertyName);
        }
    }
}
