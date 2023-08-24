using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;
using Nox.Types;

namespace Nox.Lib.Tests.Factories.Types;

public class NoxTypeCurrencyNumberFactoryTests
{
    [Theory, AutoMoqData]
    public void CreateCurrencyNumberType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        NoxTypeCurrencyNumberFactory factory = new NoxTypeCurrencyNumberFactory(noxSolution);
        short value = 710;

        // Act
        var entity = factory.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        entity.Should().NotBeNull();
        entity!.Value.Should().Be(value);
    }
    
    [Theory, AutoMoqData]
    public void CreateCurrencyNumberType_FromDto_WithLessInvalidValue_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var factory = new NoxTypeCurrencyNumberFactory(noxSolution);
        short value = 1857;

        // Act
        var action = () => factory.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[]
            {
                new ValidationFailure("Value", $"Could not create a Nox CurrencyNumber type with unsupported value '{value}'.")
            });
    }
    
}