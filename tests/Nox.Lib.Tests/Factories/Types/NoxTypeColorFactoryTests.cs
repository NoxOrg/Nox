using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;

namespace Nox.Lib.Tests.Factories.Types;

public class NoxTypeColorFactoryTests
{

    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        NoxTypeColorFactory sut = new NoxTypeColorFactory(noxSolution);
        var value = "#ABCDEF";

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        entity.Should().NotBeNull();
        entity!.ToHex().Should().Be(value);
    }
}