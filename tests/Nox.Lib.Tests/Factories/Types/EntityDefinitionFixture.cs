using Moq;
using Nox.Solution;
using Nox.Types;

namespace Nox.Lib.Tests.Factories.Types
{
    public class EntityDefinitionFixture
    {
        public EntityDefinitionFixture(Mock<NoxSolution> noxSolution,Mock<Entity> entityDefinition, string propertyName)
        {
            var propertyDefinition = new NoxSimpleTypeDefinition()
            {
                Name = propertyName
            };

            entityDefinition.Setup(e => e.Attributes).Returns(new[] {propertyDefinition});

            entityDefinition.Setup(e => e.GetAttributeByName(It.IsAny<string>())).Returns(propertyDefinition);
            entityDefinition.Setup(e => e.IsKey(It.IsAny<string>())).Returns(false);

            EntityDefinition = entityDefinition.Object;
            NoxSolution = noxSolution;
            PropertyName = propertyName;
        }

        public Entity EntityDefinition { get; }
        public Mock<NoxSolution> NoxSolution { get; }
        public string PropertyName { get; }
    }
}
