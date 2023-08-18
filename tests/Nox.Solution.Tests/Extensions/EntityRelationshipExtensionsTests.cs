using Moq;
using Nox.Solution.Tests.FixtureConfig;
using Nox.Solution.Extensions;
using FluentAssertions;

namespace Nox.Solution.Tests.Extensions
{
    public class EntityRelationshipExtensionsTests
    {
        /// <summary>
        /// * To Many relation does not have a foreign key on the Entity with Many
        /// </summary>
        [Theory, InlineAutoMoqData(EntityRelationshipType.OneOrMany)]
        public void ShouldGenerateForeignKeyOnThisSide_ToMany_ShouldNot(EntityRelationshipType relationshipType, Mock<EntityRelationship> relationship, Mock<EntityRelationship> relatedRelationship)
        {
            // Arrange            
            relationship.Setup(r => r.Relationship).Returns(relationshipType);
            relationship.Setup(r => r.Related.EntityRelationship).Returns(relatedRelationship.Object);            

            // Act
            bool shouldGenerateForeignOnThisSide = relationship.Object.ShouldGenerateForeignKeyOnThisSide();

            // Assert
            shouldGenerateForeignOnThisSide.Should().BeFalse();

        }
    }
}
