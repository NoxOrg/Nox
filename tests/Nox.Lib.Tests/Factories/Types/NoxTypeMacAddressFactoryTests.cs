using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;

namespace Nox.Lib.Tests.Factories.Types
{
    public class NoxTypeMacAddressFactoryTests
    {
        [Theory, AutoMoqData]
        public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
        {
            // Arrange
            NoxTypeMacAddressFactory sut = new NoxTypeMacAddressFactory(noxSolution);
            var value = "AA:11:22:33:44:55";

            // Act
            var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

            // Assert
            entity.Should().NotBeNull();
            entity!.ToString(Nox.Types.MacAddressFormat.ByteGroupWithColon).Should().Be(value);
        }
    }
}