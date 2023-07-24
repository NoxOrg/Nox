using FluentAssertions;
using System.Globalization;

namespace Nox.Types.Tests.Types;

public class DateTimeScheduleTests
{
    [Fact]
    public void From_WithValidStartAndEnd_ReturnsValue()
    {
        var start = System.DateTime.UtcNow;
        var end = start.AddDays(1);

        var dateTimeRange = DateTimeSchedule.From(start, end);

        Assert.Equal(start, dateTimeRange.StartDate);
        Assert.Equal(end, dateTimeRange.EndDate);
        Assert.Equal((start, end), dateTimeRange.Value);
    }

    [Fact]
    public void From_WithSameStartAndEnd_ReturnsValue()
    {
        var start = System.DateTime.UtcNow;
        var end = start;

        var dateTimeRange = DateTimeSchedule.From(start, end);

        Assert.Equal(start, dateTimeRange.StartDate);
        Assert.Equal(end, dateTimeRange.EndDate);
        Assert.Equal((start, end), dateTimeRange.Value);
    }

    [Fact]
    public void From_WithInvalidDates_ThrowsValidationException()
    {
        var start = new System.DateTime(2023, 05, 01);
        var end = new System.DateTime(2023, 04, 01);
        Action comparison = () => DateTimeSchedule.From(start, end);

        comparison.Should().Throw<TypeValidationException>();

    }

    [Fact]
    public void Equality_WithSameStartAndEnd_ShouldBeEquivalent()
    {
        var start = new System.DateTime(2020, 5, 1);
        var end = new System.DateTime(2020, 8, 1);

        var dateTimeSchedule1 = DateTimeSchedule.From(start, end);
        var dateTimeSchedule2 = DateTimeSchedule.From(start, end);

        dateTimeSchedule1.Equals(dateTimeSchedule2).Should().BeTrue();
    }

    [Fact]
    public void GetNextScheduledDate_ThrowsException_DefaultOptions()
    {
        var start = new System.DateTime(2020, 5, 1);
        var end = new System.DateTime(2020, 8, 1);

        var dateTimeSchedule1 = DateTimeSchedule.From(start, end);

        Action comparison = () => dateTimeSchedule1.GetNextScheduledDate();
        comparison.Should().Throw<TypeValidationException>();
    }

    [Fact]
    public void GetNextScheduledDate_ReturnsValue_Minutely()
    {
        var start = new System.DateTime(2020, 5, 1);
        var end = new System.DateTime(2020, 8, 1);
        var options = new DateTimeScheduleTypeOptions() { Frequency = Frequency.Minutely, FrequencyValue = 10 };

        var dateTimeSchedule1 = DateTimeSchedule.From(start, end, options);
        var dateTimeSchedule2 = dateTimeSchedule1.GetNextScheduledDate();

        dateTimeSchedule1.StartDate.Should().Be(start);
        dateTimeSchedule1.EndDate.Should().Be(end);
        dateTimeSchedule2.StartDate.Day.Should().Be(1);
        dateTimeSchedule2.StartDate.Month.Should().Be(5);
        dateTimeSchedule2.StartDate.Minute.Should().Be(10);
        dateTimeSchedule2.EndDate.Should().Be(dateTimeSchedule1.EndDate);
    }

    [Fact]
    public void GetNextScheduledDate_ReturnsValue_Hourly()
    {
        var start = new System.DateTime(2020, 5, 1);
        var end = new System.DateTime(2020, 8, 1);
        var options = new DateTimeScheduleTypeOptions() { Frequency = Frequency.Hourly, FrequencyValue = 8 };

        var dateTimeSchedule1 = DateTimeSchedule.From(start, end, options);
        var dateTimeSchedule2 = dateTimeSchedule1.GetNextScheduledDate();

        dateTimeSchedule1.StartDate.Should().Be(start);
        dateTimeSchedule1.EndDate.Should().Be(end);
        dateTimeSchedule2.StartDate.Hour.Should().Be(8);
        dateTimeSchedule2.StartDate.Day.Should().Be(1);
        dateTimeSchedule2.StartDate.Month.Should().Be(5);
        dateTimeSchedule2.EndDate.Should().Be(dateTimeSchedule1.EndDate);
    }

    [Fact]
    public void GetNextScheduledDate_ReturnsValue_Weekly()
    {
        var start = new System.DateTime(2020, 5, 1);
        var end = new System.DateTime(2020, 8, 1);
        var options = new DateTimeScheduleTypeOptions() { Frequency = Frequency.Weekly, FrequencyValue = 2 };

        var dateTimeSchedule1 = DateTimeSchedule.From(start, end, options);
        var dateTimeSchedule2 = dateTimeSchedule1.GetNextScheduledDate();

        dateTimeSchedule1.StartDate.Should().Be(start);
        dateTimeSchedule1.EndDate.Should().Be(end);
        dateTimeSchedule2.StartDate.Day.Should().Be(15);
        dateTimeSchedule1.StartDate.Month.Should().Be(5);
        dateTimeSchedule2.StartDate.Month.Should().Be(5);
        dateTimeSchedule2.EndDate.Should().Be(dateTimeSchedule1.EndDate);
    }

    [Fact]
    public void GetNextScheduledDate_ReturnsValue_Monthly()
    {
        var start = new System.DateTime(2020, 5, 1);
        var end = new System.DateTime(2020, 8, 1);
        var options = new DateTimeScheduleTypeOptions() { Frequency = Frequency.Monthly, FrequencyValue = 3 };

        var dateTimeSchedule1 = DateTimeSchedule.From(start, end, options);
        var dateTimeSchedule2 = dateTimeSchedule1.GetNextScheduledDate();

        dateTimeSchedule1.StartDate.Should().Be(start);
        dateTimeSchedule1.EndDate.Should().Be(end);
        dateTimeSchedule2.StartDate.Day.Should().Be(1);
        dateTimeSchedule2.StartDate.Month.Should().Be(8);
        dateTimeSchedule2.EndDate.Should().Be(dateTimeSchedule1.EndDate);
    }

    [Fact]
    public void GetNextScheduledDate_ReturnsValue_Yearly()
    {
        var start = new System.DateTime(2020, 5, 1);
        var end = new System.DateTime(2025, 8, 1);
        var options = new DateTimeScheduleTypeOptions() { Frequency = Frequency.Yearly, FrequencyValue = 3 };

        var dateTimeSchedule1 = DateTimeSchedule.From(start, end, options);
        var dateTimeSchedule2 = dateTimeSchedule1.GetNextScheduledDate();

        dateTimeSchedule1.StartDate.Should().Be(start);
        dateTimeSchedule1.EndDate.Should().Be(end);
        dateTimeSchedule2.StartDate.Day.Should().Be(1);
        dateTimeSchedule2.StartDate.Month.Should().Be(5);
        dateTimeSchedule2.StartDate.Year.Should().Be(2023);
        dateTimeSchedule2.EndDate.Should().Be(dateTimeSchedule1.EndDate);
    }

    [Fact]
    public void GetNextScheduledDate_ThrowsException_Yearly()
    {
        var start = new System.DateTime(2020, 5, 1);
        var end = new System.DateTime(2022, 8, 1);
        var options = new DateTimeScheduleTypeOptions() { Frequency = Frequency.Yearly, FrequencyValue = 3 };

        var dateTimeSchedule1 = DateTimeSchedule.From(start, end, options);

        Action comparison = () => dateTimeSchedule1.GetNextScheduledDate();
        comparison.Should().Throw<TypeValidationException>();
    }

    [Fact]
    public void GetAllOccurrences_ReturnsValues_Yearly()
    {
        var start = new System.DateTime(2020, 5, 1);
        var end = new System.DateTime(2025, 8, 1);
        var options = new DateTimeScheduleTypeOptions() { Frequency = Frequency.Yearly, FrequencyValue = 1 };

        var dateTimeSchedule1 = DateTimeSchedule.From(start, end, options);
        var dateTimeSchedule2 = dateTimeSchedule1.GetAllOccurrences();

        dateTimeSchedule1.StartDate.Should().Be(start);
        dateTimeSchedule1.EndDate.Should().Be(end);
        dateTimeSchedule2.Count.Should().Be(6);
    }

    [Fact]
    public void GetAllOccurrences_OneOccurence_Minutely()
    {
        var start = new System.DateTime(2020, 5, 1);
        var end = new System.DateTime(2020, 5, 1);
        var options = new DateTimeScheduleTypeOptions() { Frequency = Frequency.Minutely, FrequencyValue = 10 };

        var dateTimeSchedule1 = DateTimeSchedule.From(start, end, options);
        var dateTimeSchedule2 = dateTimeSchedule1.GetAllOccurrences();

        dateTimeSchedule1.StartDate.Should().Be(start);
        dateTimeSchedule1.EndDate.Should().Be(end);
        dateTimeSchedule2.Count.Should().Be(1);
    }

    [Fact]
    public void GetAllOccurrences_OneOccurence_DefaultOptions()
    {
        var start = new System.DateTime(2020, 5, 1);
        var end = new System.DateTime(2023, 5, 1);

        var dateTimeSchedule1 = DateTimeSchedule.From(start, end);
        var dateTimeSchedule2 = dateTimeSchedule1.GetAllOccurrences();

        dateTimeSchedule1.StartDate.Should().Be(start);
        dateTimeSchedule1.EndDate.Should().Be(end);
        dateTimeSchedule2.Count.Should().Be(1);
    }
}