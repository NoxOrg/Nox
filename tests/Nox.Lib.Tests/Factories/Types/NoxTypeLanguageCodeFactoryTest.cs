using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;
using Nox.Types;

namespace Nox.Lib.Tests.Factories.Types;

public class NoxTypeLanguageCodeFactoryTest
{
    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange            
        var sut = new NoxTypeLanguageCodeFactory(noxSolution);
        string languageCode = "ur";

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, languageCode);

        // Assert
        entity.Should().NotBeNull();
        entity!.Value.Should().Be(languageCode);
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromNull_ReturnsNull(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange            
        var sut = new NoxTypeLanguageCodeFactory(noxSolution);

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, null);

        // Assert
        entity.Should().BeNull();
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_ForInvalidCode_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange            
        var sut = new NoxTypeLanguageCodeFactory(noxSolution);
        var value = "urd";

        // Act
        var action = () => sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[]
            {
                new ValidationFailure("Value", $"Could not create a Nox LanguageCode type with unsupported value '{value}'.")
            });
    }
}
