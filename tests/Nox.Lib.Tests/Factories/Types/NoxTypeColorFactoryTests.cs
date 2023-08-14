using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;

namespace Nox.Lib.Tests.Factories.Types;

public class NoxTypeColorFactoryTests
{
    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_WithArray_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        NoxTypeColorFactory sut = new NoxTypeColorFactory(noxSolution);
        var value = new byte[] { 1, 2, 3, 4 };

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        entity.Should().NotBeNull();
        entity!.Value.Should().BeEquivalentTo(value);
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_WithColor_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        NoxTypeColorFactory sut = new NoxTypeColorFactory(noxSolution);
        var value = System.Drawing.Color.Lavender;

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        entity.Should().NotBeNull();
        entity!.Value.Should().BeEquivalentTo(new byte[] { value.A, value.R, value.G, value.B });
    }
}