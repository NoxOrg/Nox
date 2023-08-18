using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;
using Nox.Types;

namespace Nox.Lib.Tests.Factories.Types;

public class NoxTypeYearFactoryTests
{
    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        NoxTypeYearFactory sut = new NoxTypeYearFactory(noxSolution);
        ushort value = 1945;

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        entity.Should().NotBeNull();
        entity!.Value.Should().Be(value);
    }



    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_WithLessThanMinDate_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var sut = new NoxTypeYearFactory(noxSolution);
        ushort value = 1857;

        // Act
        var action = () => sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[]
            {
                new ValidationFailure("Value", "Could not create a Nox Year type as value 1857 is less than the minimum specified value of 1900")
            });
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_WithGreaterThanMaxDate_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var sut = new NoxTypeYearFactory(noxSolution);
        ushort value = 3120;

        // Act
        var action = () => sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[]
            {
                new ValidationFailure("Value", "Could not create a Nox Year type a value 3120 is greater than the maximum specified value of 3000")
            });
    }
}
