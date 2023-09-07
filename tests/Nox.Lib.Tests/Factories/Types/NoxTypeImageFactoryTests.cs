using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;

namespace Nox.Lib.Tests.Factories.Types;

public record ImageDto(string Url, string PrettyName, int SizeInBytes);
public class NoxTypeImageFactoryTests
{
    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        NoxTypeImageFactory sut = new NoxTypeImageFactory(noxSolution);
        var value = new ImageDto("https://example.com/image.jpg", "Image1", 100);

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        entity.Should().NotBeNull();
        entity!.Url.Should().Be(value.Url);
        entity.PrettyName.Should().Be(value.PrettyName);
        entity.SizeInBytes.Should().Be(value.SizeInBytes);
    }
}