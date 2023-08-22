using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;
using Nox.Types;

namespace Nox.Lib.Tests.Factories.Types;

public class NoxTypeDateTimeScheduleFactoryTests
{
    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange            
        var sut = new NoxTypeDateTimeScheduleFactory(noxSolution);
        string value = "0 0 1-5/2,11,23 2-12/2,9,11 1-3,5,7 5,1,6 2020-2023/2,2000,1999";

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        entity.Should().NotBeNull();
        entity!.Value.Should().Be(value);
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromNull_ReturnsNull(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange            
        var sut = new NoxTypeDateTimeScheduleFactory(noxSolution);

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, null);

        // Assert
        entity.Should().BeNull();
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_ForInvalidCode_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange            
        var sut = new NoxTypeDateTimeScheduleFactory(noxSolution);
        var value = "66 55 2 */3 JAN-AUG *";

        // Act
        var action = () => sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[]
            {
                new ValidationFailure("Value", $"Could not create a Nox DateTimeSchedule type with value {value} because it is incorrect CronJob expression - seconds are incorrect.")
            });
    }
}
