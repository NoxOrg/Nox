using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;
using Nox.Types;

namespace Nox.Lib.Tests.Factories.Types;

public class NoxTypeDateTimeDurationFactoryTest
{

    [Theory, AutoMoqData]
    public void CreateNoxType_FromTicksDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var sut = new NoxTypeDateTimeDurationFactory(noxSolution);
        var value = 10000L;

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        entity.Should().NotBeNull();
        entity!.Value.Should().Be(value);
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromTimeSpanDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var sut = new NoxTypeDateTimeDurationFactory(noxSolution);
        var ticks = 10000L;
        var value = new TimeSpan(ticks);

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        entity.Should().NotBeNull();
        entity!.Value.Should().Be(ticks);
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromNullDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var sut = new NoxTypeDateTimeDurationFactory(noxSolution);

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, null);

        // Assert
        entity.Should().BeNull();
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_WhenValueIsLessThanMinValue_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var value = 500L;
        var sut = new NoxTypeDateTimeDurationFactory(noxSolution);

        var options = new DateTimeDurationTypeOptions() { MinDuration = 1000L, TimeUnit = TimeUnit.Millisecond };

        fixture.EntityDefinition.Attributes![0]!.DateTimeDurationTypeOptions = options;
        fixture.EntityDefinition.Attributes![0]!.Name = "DateTimeDurationTypeOptions";

        // Act
        var action = () => sut.CreateNoxType(fixture.EntityDefinition, "DateTimeDurationTypeOptions", value);

        // Assert
        action.Should().Throw<TypeValidationException>()
            .WithMessage("The Nox type validation failed with 1 error(s).")
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox DateTimeDuration type as value 00:00:00.0000500 is less than than the minimum specified value of 00:00:01") });
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_WhenValueIsGreaterThanMaxValue_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var value = 150000000L;
        var sut = new NoxTypeDateTimeDurationFactory(noxSolution);

        var options = new DateTimeDurationTypeOptions() { MaxDuration = 1000L, TimeUnit = TimeUnit.Millisecond };

        fixture.EntityDefinition.Attributes![0]!.DateTimeDurationTypeOptions = options;
        fixture.EntityDefinition.Attributes![0]!.Name = "DateTimeDurationTypeOptions";

        // Act
        var action = () => sut.CreateNoxType(fixture.EntityDefinition, "DateTimeDurationTypeOptions", value);

        // Assert
        action.Should().Throw<TypeValidationException>()
            .WithMessage("The Nox type validation failed with 1 error(s).")
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox DateTimeDuration type as value 00:00:15 is greater than than the maximum specified value of 00:00:01") });
    }
}