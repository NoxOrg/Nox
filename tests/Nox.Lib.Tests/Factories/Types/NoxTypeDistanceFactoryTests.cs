using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;

namespace Nox.Lib.Tests.Factories.Types
{
    public class NoxTypeDistanceFactoryTests
    {
        [Theory, AutoMoqData]
        public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
        {
            // Arrange
            NoxTypeDistanceFactory sut = new NoxTypeDistanceFactory(noxSolution);
            var value = 7.5;

            // Act
            var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

            // Assert
            entity.Should().NotBeNull();
            entity!.Value.Should().Be(value);
        }
    }
}