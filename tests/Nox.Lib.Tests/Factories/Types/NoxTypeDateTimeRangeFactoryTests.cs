using FluentAssertions;
using Nox.Factories.Types;
using Nox.Lib.Tests.FixtureConfig;
using Nox.Solution;

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
}