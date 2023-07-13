using FluentAssertions;

using System.Globalization;

namespace Nox.Types.Tests.Types;

public class DateTimeDurationTests
{
    [Fact]
    public void From_WithTimeSpanInput_ReturnsValue()
    {
        var timeSpan = new TimeSpan(1, 2, 3, 4, 5);

        var dateTimeDuration = DateTimeDuration.From(timeSpan);

        dateTimeDuration.Value.Days.Should().Be(1);
        dateTimeDuration.Value.Hours.Should().Be(2);
        dateTimeDuration.Value.Minutes.Should().Be(3);
        dateTimeDuration.Value.Seconds.Should().Be(4);
        dateTimeDuration.Value.Milliseconds.Should().Be(5);
        dateTimeDuration.Value.TotalMilliseconds.Should().Be(5 + 4000 + (3 * 60 * 1000) + (2 * 60 * 60 * 1000) + (1 * 24 * 60 * 60 * 1000));
    }

    [Fact]
    public void From_WithNegativeTimeSpanInput_ReturnsAbsoluteValue()
    {
        var timeSpan = new TimeSpan(1, 2, 3, 4, 5);

        var dateTimeDuration = DateTimeDuration.From(-timeSpan);

        dateTimeDuration.Value.Days.Should().Be(1);
        dateTimeDuration.Value.Hours.Should().Be(2);
        dateTimeDuration.Value.Minutes.Should().Be(3);
        dateTimeDuration.Value.Seconds.Should().Be(4);
        dateTimeDuration.Value.Milliseconds.Should().Be(5);
        dateTimeDuration.Value.TotalMilliseconds.Should().Be(5 + 4000 + (3 * 60 * 1000) + (2 * 60 * 60 * 1000) + (1 * 24 * 60 * 60 * 1000));
    }

    [Fact]
    public void From_WithHoursDaysMinutesSecondsMillisecondsParameters_ReturnsAbsoluteValue()
    {
        var dateTimeDuration = DateTimeDuration.From(1, 2, 3, 4, 5);

        dateTimeDuration.Value.Days.Should().Be(1);
        dateTimeDuration.Value.Hours.Should().Be(2);
        dateTimeDuration.Value.Minutes.Should().Be(3);
        dateTimeDuration.Value.Seconds.Should().Be(4);
        dateTimeDuration.Value.Milliseconds.Should().Be(5);
    }

    [Fact]
    public void From_WithDaysHoursMinutesSecondsParameters_ReturnsAbsoluteValue()
    {
        var dateTimeDuration = DateTimeDuration.From(1, 2, 3, 4);

        dateTimeDuration.Value.Days.Should().Be(1);
        dateTimeDuration.Value.Hours.Should().Be(2);
        dateTimeDuration.Value.Minutes.Should().Be(3);
        dateTimeDuration.Value.Seconds.Should().Be(4);
        dateTimeDuration.Value.Milliseconds.Should().Be(0);
    }

    [Fact]
    public void From_WithHoursMinutesSecondsParameters_ReturnsAbsoluteValue()
    {
        var dateTimeDuration = DateTimeDuration.From(1, 2, 3);

        dateTimeDuration.Value.Days.Should().Be(0);
        dateTimeDuration.Value.Hours.Should().Be(1);
        dateTimeDuration.Value.Minutes.Should().Be(2);
        dateTimeDuration.Value.Seconds.Should().Be(3);
        dateTimeDuration.Value.Milliseconds.Should().Be(0);

    }

    [Theory]
    [InlineData(1)]
    [InlineData(1.5)]
    [InlineData(-11)]
    public void FromDays_WithVariousInputs_ReturnsValue(double days)
    {
        var dateTimeDuraion = DateTimeDuration.FromDays(days);

        dateTimeDuraion.Value.TotalDays.Should().Be(Math.Abs(days));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1.5)]
    [InlineData(-11)]
    public void FromHours_WithVariousInputs_ReturnsValue(double hours)
    {
        var dateTimeDuraion = DateTimeDuration.FromHours(hours);

        dateTimeDuraion.Value.TotalHours.Should().Be(Math.Abs(hours));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1.5)]
    [InlineData(-11)]
    public void FromMinutes_WithVariousInputs_ReturnsValue(double minutes)
    {
        var dateTimeDuraion = DateTimeDuration.FromMinutes(minutes);

        dateTimeDuraion.Value.TotalMinutes.Should().Be(Math.Abs(minutes));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1.5)]
    [InlineData(-11)]
    public void FromSeconds_WithVariousInputs_ReturnsValue(double seconds)
    {
        var dateTimeDuraion = DateTimeDuration.FromSeconds(seconds);

        dateTimeDuraion.Value.TotalSeconds.Should().Be(Math.Abs(seconds));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1.5)]
    [InlineData(-11)]
    public void FromMilliseconds_WithVariousInputs_ReturnsValue(double milliseconds)
    {
        var dateTimeDuraion = DateTimeDuration.FromMilliseconds(milliseconds);

        dateTimeDuraion.Value.TotalMilliseconds.Should().Be(Math.Abs(milliseconds));
    }

    [Fact]
    public void DaysHoursMinutesSecondsMillisecondsProperties_WithValidDateTimeDurationObject_ReturnValue()
    {
        var dateTimeDuration = DateTimeDuration.From(1, 2, 3, 4, 5);

        dateTimeDuration.Days.Should().Be(1);
        dateTimeDuration.Hours.Should().Be(2);
        dateTimeDuration.Minutes.Should().Be(3);
        dateTimeDuration.Seconds.Should().Be(4);
        dateTimeDuration.Milliseconds.Should().Be(5);
    }

    [Fact]
    public void DaysHoursMinutesSecondsMillisecondsProperties_WithFromDaysValidDateTimeDurationObject_ReturnValue()
    {
        var dateTimeDuration = DateTimeDuration.FromDays(1.5);

        dateTimeDuration.Days.Should().Be(1);
        dateTimeDuration.Hours.Should().Be(12);
        dateTimeDuration.Minutes.Should().Be(0);
        dateTimeDuration.Seconds.Should().Be(0);
        dateTimeDuration.Milliseconds.Should().Be(0);
    }

    [Fact]
    public void TotalDaysHoursMinutesSecondsMillisecondsProperties_WithValidDateTimeDurationObject_ReturnValue()
    {
        var dateTimeDuration = DateTimeDuration.FromDays(1.5);

        dateTimeDuration.TotalDays.Should().Be(1.5);
        dateTimeDuration.TotalHours.Should().Be(1.5 * 24);
        dateTimeDuration.TotalMinutes.Should().Be(1.5 * 24 * 60);
        dateTimeDuration.TotalSeconds.Should().Be(1.5 * 24 * 60 * 60);
        dateTimeDuration.TotalMilliseconds.Should().Be(1.5 * 24 * 60 * 60 * 1000);
    }

    [Fact]
    public void Equality_WithDifferentInputTypes_ShouldBeEquivalent()
    {
        var dateTimeDuration1 = DateTimeDuration.From(TimeSpan.FromHours(1));
        var dateTimeDuration2 = DateTimeDuration.From(1, 0, 0);
        var dateTimeDuration3 = DateTimeDuration.From(0, 1, 0, 0);
        var dateTimeDuration4 = DateTimeDuration.From(0, 1, 0, 0, 0);
        var dateTimeDuration5 = DateTimeDuration.FromHours(1);
        var dateTimeDuration6 = DateTimeDuration.FromMinutes(60);
        var dateTimeDuration7 = DateTimeDuration.FromSeconds(60 * 60);
        var dateTimeDuration8 = DateTimeDuration.FromMilliseconds(60 * 60 * 1000);

        var dateTimeDuration9 = DateTimeDuration.FromDays(1);
        var dateTimeDuration10 = DateTimeDuration.FromHours(24);

        AssertAreEquivalent(dateTimeDuration1, dateTimeDuration2);
        AssertAreEquivalent(dateTimeDuration1, dateTimeDuration3);
        AssertAreEquivalent(dateTimeDuration1, dateTimeDuration4);
        AssertAreEquivalent(dateTimeDuration1, dateTimeDuration5);
        AssertAreEquivalent(dateTimeDuration1, dateTimeDuration6);
        AssertAreEquivalent(dateTimeDuration1, dateTimeDuration7);
        AssertAreEquivalent(dateTimeDuration1, dateTimeDuration8);
        AssertAreEquivalent(dateTimeDuration9, dateTimeDuration10);
    }

    [Fact]
    public void NonEquality_WithDifferentValues_ShouldNotBeEquivalent()
    {
        var dateTimeDuration1 = DateTimeDuration.From(10, 5, 1);
        var dateTimeDuration2 = DateTimeDuration.From(10, 5, 1, 1);

        AssertAreNotEquivalent(dateTimeDuration1, dateTimeDuration2);
    }

    [Fact]
    public void GreaterThanOperator_WithVariousValues_ReturnsCorrectResult()
    {
        var dateTimeDuration1 = DateTimeDuration.From(10, 5, 1, 1);
        var dateTimeDuration2 = DateTimeDuration.From(10, 5, 1, 0);
        var dateTimeDuration3 = DateTimeDuration.From(10, 5, 1, 0);

        (dateTimeDuration1 > dateTimeDuration2).Should().Be(true);
        (dateTimeDuration2 > dateTimeDuration1).Should().Be(false);
        (dateTimeDuration2 > dateTimeDuration3).Should().Be(false);
    }

    [Fact]
    public void GreaterThanOrEqualOperator_WithVariousValues_ReturnsCorrectResult()
    {
        var dateTimeDuration1 = DateTimeDuration.From(10, 5, 1, 1);
        var dateTimeDuration2 = DateTimeDuration.From(10, 5, 1, 0);
        var dateTimeDuration3 = DateTimeDuration.From(10, 5, 1, 0);

        (dateTimeDuration1 >= dateTimeDuration2).Should().Be(true);
        (dateTimeDuration2 >= dateTimeDuration1).Should().Be(false);
        (dateTimeDuration2 >= dateTimeDuration3).Should().Be(true);
    }

    [Fact]
    public void LessThanOperator_WithVariousValues_ReturnsCorrectResult()
    {
        var dateTimeDuration1 = DateTimeDuration.From(10, 5, 1, 0);
        var dateTimeDuration2 = DateTimeDuration.From(10, 5, 1, 1);
        var dateTimeDuration3 = DateTimeDuration.From(10, 5, 1, 1);

        (dateTimeDuration1 < dateTimeDuration2).Should().Be(true);
        (dateTimeDuration2 < dateTimeDuration1).Should().Be(false);
        (dateTimeDuration2 < dateTimeDuration3).Should().Be(false);
    }

    [Fact]
    public void LessThanOrEqualOperator_WithVariousValues_ReturnsCorrectResult()
    {
        var dateTimeDuration1 = DateTimeDuration.From(10, 5, 1, 0);
        var dateTimeDuration2 = DateTimeDuration.From(10, 5, 1, 1);
        var dateTimeDuration3 = DateTimeDuration.From(10, 5, 1, 1);

        (dateTimeDuration1 <= dateTimeDuration2).Should().Be(true);
        (dateTimeDuration2 <= dateTimeDuration1).Should().Be(false);
        (dateTimeDuration2 <= dateTimeDuration3).Should().Be(true);
    }

    [Fact]
    public void AdditionOperator_WithValidValues_ReturnsCorrectResult()
    {
        var dateTimeDuration1 = DateTimeDuration.From(0, 12, 0, 0);
        var dateTimeDuration2 = DateTimeDuration.From(1, 0, 0, 0);

        (dateTimeDuration1 + dateTimeDuration1).Should().Be(dateTimeDuration2);
    }

    [Fact]
    public void SubtractionOperator_WithValidValues_ReturnsCorrectResult()
    {
        var dateTimeDuration1 = DateTimeDuration.From(1, 0, 0, 0);
        var dateTimeDuration2 = DateTimeDuration.From(0, 12, 0, 0);

        (dateTimeDuration1 - dateTimeDuration2).Should().Be(dateTimeDuration2);
    }

    [Fact]
    public void SubtractionOperator_WithFirstOperatorLessThanSecond_ReturnsAbsoluteResult()
    {
        var dateTimeDuration1 = DateTimeDuration.From(0, 12, 0, 0);
        var dateTimeDuration2 = DateTimeDuration.From(1, 0, 0, 0);

        (dateTimeDuration1 - dateTimeDuration2).Should().Be(dateTimeDuration1);
    }

    [Theory]
    [InlineData("en-GB")]
    [InlineData("en-US")]
    public void ToString_WithoutParameters_ReturnsFormattedStringInInvariantCulture(string culture)
    {
        static void Test()
        {
            var dateTimeDuration = DateTimeDuration.From(10, 5, 2, 1);

            dateTimeDuration.ToString().Should().Be("10.05:02:01");
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-GB", "c", "10.05:02:01")]
    [InlineData("fr-FR", "c", "10.05:02:01")]
    [InlineData("en-GB", "g", "10:5:02:01")]
    [InlineData("fr-FR", "g", "10:5:02:01")]
    [InlineData("en-GB", "G", "10:05:02:01.0000000")]
    [InlineData("fr-FR", "G", "10:05:02:01.0000000")]
    [InlineData("en-GB", @"hh\:mm\:ss", "05:02:01")]
    [InlineData("fr-FR", @"hh\:mm\:ss", "05:02:01")]
    [InlineData("en-GB", "%m' min.'", "2 min.")]
    [InlineData("fr-FR", "%m' min.'", "2 min.")]
    public void ToString_WithFormat_ReturnsFormattedStringInInvariantCulture(string culture, string format, string expected)
    {
        void Test()
        {
            var dateTimeDuration = DateTimeDuration.From(10, 5, 2, 1);

            dateTimeDuration.ToString(format).Should().Be(expected);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-GB", "c", "10.05:02:01")]
    [InlineData("fr-FR", "c", "10.05:02:01")]
    [InlineData("en-GB", "g", "10:5:02:01")]
    [InlineData("fr-FR", "g", "10:5:02:01")]
    [InlineData("en-GB", "G", "10:05:02:01.0000000")]
    [InlineData("fr-FR", "G", "10:05:02:01,0000000")]
    [InlineData("en-GB", @"hh\:mm\:ss", "05:02:01")]
    [InlineData("fr-FR", @"hh\:mm\:ss", "05:02:01")]
    [InlineData("en-GB", "%m' min.'", "2 min.")]
    [InlineData("fr-FR", "%m' min.'", "2 min.")]
    public void ToString_WithFormatAndCulture_ReturnsFormattedStringInCulture(string culture, string format, string expected)
    {
        var dateTimeDuration = DateTimeDuration.From(10, 5, 2, 1);

        dateTimeDuration.ToString(format, new CultureInfo(culture)).Should().Be(expected);
    }

    private static void AssertAreEquivalent(DateTimeDuration expected, DateTimeDuration actual)
    {
        actual.Should().Be(expected);

        expected.Equals(actual).Should().BeTrue();

        actual.Equals(expected).Should().BeTrue();

        (expected == actual).Should().BeTrue();

        (expected != actual).Should().BeFalse();
    }

    private static void AssertAreNotEquivalent(DateTimeDuration expected, DateTimeDuration actual)
    {
        actual.Should().NotBe(expected);

        expected.Equals(actual).Should().BeFalse();

        actual.Equals(expected).Should().BeFalse();

        (expected == actual).Should().BeFalse();

        (expected != actual).Should().BeTrue();
    }
}
