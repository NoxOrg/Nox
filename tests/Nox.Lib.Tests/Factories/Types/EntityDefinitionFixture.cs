using Moq;
using Nox.Solution;
using Nox.Types;

namespace Nox.Lib.Tests.Factories.Types
{
    public class EntityDefinitionFixture
    {
        public EntityDefinitionFixture(Mock<Entity> entityDefinition, string propertyName)
        {


            entityDefinition.Setup(e => e.Attributes).Returns(new[] {
                new NoxSimpleTypeDefinition() {
                    Name = propertyName }
            });

            EntityDefinition = entityDefinition.Object;
            PropertyName = propertyName;
        }

        public Entity EntityDefinition { get; }
        public string PropertyName { get; }
    }
}
