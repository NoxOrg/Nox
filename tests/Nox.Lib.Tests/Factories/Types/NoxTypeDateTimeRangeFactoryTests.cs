using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;
using Nox.Types;
using DateTime = System.DateTime;

namespace Nox.Lib.Tests.Factories.Types;

public record DateTimeRangeDto(DateTimeOffset Start, DateTimeOffset End);
public class NoxTypeDateTimeRangeFactoryTests
{
    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        NoxTypeDateTimeRangeFactory sut = new NoxTypeDateTimeRangeFactory(noxSolution);
        var start = new DateTimeOffset(DateTime.UtcNow);
        var end = start.AddDays(1);
        var value = new DateTimeRangeDto(start, end);

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        entity.Should().NotBeNull();
        entity!.Start.Should().Be(start);
        entity.End.Should().Be(end);
    }


    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_WhenValueIsNull_IsValid(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var sut = new NoxTypeDateTimeRangeFactory(noxSolution);

        // Act
        var entity = sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, null);

        // Assert
        entity.Should().BeNull();
    }

    [Theory, AutoMoqData]
    public void CreateNoxType_FromDto_WhenValueIsInvalid_ThrowsException(NoxSolution noxSolution, EntityDefinitionFixture fixture)
    {
        // Arrange
        var sut = new NoxTypeDateTimeRangeFactory(noxSolution);
        var datetime = DateTimeOffset.Parse("2023-05-01T00:00:00+01:00");
        var value = new DateTimeRangeDto(datetime.AddHours(1), datetime);

        // Act
        var action = () => sut.CreateNoxType(fixture.EntityDefinition, fixture.PropertyName, value);

        // Assert
        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox DateTimeRange type with Start value 05/01/2023 01:00:00 +01:00 and End value 05/01/2023 00:00:00 +01:00 as start of the time range must be the same or before the end of the time range.") });
    }
}