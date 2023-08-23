using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;
using Nox.Types;

namespace Nox.Lib.Tests.Factories.Types;

public class NoxTypeMonthFactoryTests
{
    [Theory, AutoMoqData]
    public void CreateMonthType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        NoxTypeMonthFactory factory = new(noxSolution);
        byte value = 7;

        // Act
        var entity = factory.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        entity.Should().NotBeNull();
        entity!.Value.Should().Be(value);
    }
    
    [Theory, AutoMoqData]
    public void CreateMonthType_FromDto_WithLessThanMinDate_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var factory = new NoxTypeMonthFactory(noxSolution);
        byte value = 0;

        // Act
        var action = () => factory.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        action.Should().Throw<TypeValidationException>()
            .And.Errors.First().ErrorMessage.Should().Be( $"Could not create a Nox Month type with unsupported value '{value}'. The value must be between 1 and 12.");
    }
    
    [Theory, AutoMoqData]
    public void CreateMonthType_FromDto_WithGreaterThanMaxDate_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var factory = new NoxTypeMonthFactory(noxSolution);
        byte value = 13;

        // Act
        var action = () => factory.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        action.Should().Throw<TypeValidationException>()
            .And.Errors.First().ErrorMessage.Should().Be( $"Could not create a Nox Month type with unsupported value '{value}'. The value must be between 1 and 12.");
    }
    
}