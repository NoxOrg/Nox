using FluentAssertions;

using System.Globalization;

namespace Nox.Types.Tests.Types;

public class DateTimeDurationTests
{
    [Fact]
    public void From_WithLongInput_ReturnsValue()
    {
        var ticks = 937_840_050_000;

        var dateTimeDuration = DateTimeDuration.From(ticks);

        var value = new TimeSpan(dateTimeDuration.Value);
        value.Days.Should().Be(1);
        value.Hours.Should().Be(2);
        value.Minutes.Should().Be(3);
        value.Seconds.Should().Be(4);
        value.Milliseconds.Should().Be(5);
        value.TotalMilliseconds.Should().Be(5 + 4000 + (3 * 60 * 1000) + (2 * 60 * 60 * 1000) + (1 * 24 * 60 * 60 * 1000));
    }

    [Fact]
    public void From_WithTimeSpanInput_ReturnsValue()
    {
        var timeSpan = new TimeSpan(1, 2, 3, 4, 5);

        var dateTimeDuration = DateTimeDuration.From(timeSpan);

        var value = new TimeSpan(dateTimeDuration.Value);
        value.Days.Should().Be(1);
        value.Hours.Should().Be(2);
        value.Minutes.Should().Be(3);
        value.Seconds.Should().Be(4);
        value.Milliseconds.Should().Be(5);
        value.TotalMilliseconds.Should().Be(5 + 4000 + (3 * 60 * 1000) + (2 * 60 * 60 * 1000) + (1 * 24 * 60 * 60 * 1000));
    }

    [Fact]
    public void From_WithNegativeTimeSpanInput_ReturnsAbsoluteValue()
    {
        var timeSpan = new TimeSpan(1, 2, 3, 4, 5);

        var dateTimeDuration = DateTimeDuration.From(-timeSpan);

        var value = new TimeSpan(dateTimeDuration.Value);
        value.Days.Should().Be(1);
        value.Hours.Should().Be(2);
        value.Minutes.Should().Be(3);
        value.Seconds.Should().Be(4);
        value.Milliseconds.Should().Be(5);
        value.TotalMilliseconds.Should().Be(5 + 4000 + (3 * 60 * 1000) + (2 * 60 * 60 * 1000) + (1 * 24 * 60 * 60 * 1000));
    }

    [Fact]
    public void From_WithHoursDaysMinutesSecondsMillisecondsParameters_ReturnsAbsoluteValue()
    {
        var dateTimeDuration = DateTimeDuration.From(1, 2, 3, 4, 5);

        var value = new TimeSpan(dateTimeDuration.Value);
        value.Days.Should().Be(1);
        value.Hours.Should().Be(2);
        value.Minutes.Should().Be(3);
        value.Seconds.Should().Be(4);
        value.Milliseconds.Should().Be(5);
    }

    [Fact]
    public void From_WithDaysHoursMinutesSecondsParameters_ReturnsAbsoluteValue()
    {
        var dateTimeDuration = DateTimeDuration.From(1, 2, 3, 4);

        var value = new TimeSpan(dateTimeDuration.Value);
        value.Days.Should().Be(1);
        value.Hours.Should().Be(2);
        value.Minutes.Should().Be(3);
        value.Seconds.Should().Be(4);
        value.Milliseconds.Should().Be(0);
    }

    [Fact]
    public void From_WithHoursMinutesSecondsParameters_ReturnsAbsoluteValue()
    {
        var dateTimeDuration = DateTimeDuration.From(1, 2, 3);

        var value = new TimeSpan(dateTimeDuration.Value);
        value.Days.Should().Be(0);
        value.Hours.Should().Be(1);
        value.Minutes.Should().Be(2);
        value.Seconds.Should().Be(3);
        value.Milliseconds.Should().Be(0);

    }

    [Theory]
    [InlineData(1)]
    [InlineData(1.5)]
    [InlineData(-11)]
    public void FromDays_WithVariousInputs_ReturnsValue(double days)
    {
        var dateTimeDuration = DateTimeDuration.FromDays(days);

        var value = new TimeSpan(dateTimeDuration.Value);
        value.TotalDays.Should().Be(Math.Abs(days));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1.5)]
    [InlineData(-11)]
    public void FromHours_WithVariousInputs_ReturnsValue(double hours)
    {
        var dateTimeDuration = DateTimeDuration.FromHours(hours);

        var value = new TimeSpan(dateTimeDuration.Value);
        value.TotalHours.Should().Be(Math.Abs(hours));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1.5)]
    [InlineData(-11)]
    public void FromMinutes_WithVariousInputs_ReturnsValue(double minutes)
    {
        var dateTimeDuration = DateTimeDuration.FromMinutes(minutes);

        var value = new TimeSpan(dateTimeDuration.Value);
        value.TotalMinutes.Should().Be(Math.Abs(minutes));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1.5)]
    [InlineData(-11)]
    public void FromSeconds_WithVariousInputs_ReturnsValue(double seconds)
    {
        var dateTimeDuration = DateTimeDuration.FromSeconds(seconds);

        var value = new TimeSpan(dateTimeDuration.Value);
        value.TotalSeconds.Should().Be(Math.Abs(seconds));
    }

    [Theory]
    [InlineData(1)]
    [InlineData(1.5)]
    [InlineData(-11)]
    public void FromMilliseconds_WithVariousInputs_ReturnsValue(double milliseconds)
    {
        var dateTimeDuration = DateTimeDuration.FromMilliseconds(milliseconds);

        var value = new TimeSpan(dateTimeDuration.Value);
        value.TotalMilliseconds.Should().Be(Math.Abs(milliseconds));
    }

    [Fact]
    public void From_WithOptions_ReturnsValue()
    {
        var dateTimeDuration = DateTimeDuration.From(10, 12, 0, 0, new DateTimeDurationTypeOptions
        {
            MaxDuration = 10.5,
            TimeUnit = TimeUnit.Day,
        });

        var value = new TimeSpan(dateTimeDuration.Value);
        value.Days.Should().Be(10);
        value.Hours.Should().Be(12);
        value.Minutes.Should().Be(0);
        value.Seconds.Should().Be(0);
        value.Milliseconds.Should().Be(0);
    }

    [Fact]
    public void From_WithValueLessThanMinimum_ThrowsValidationException()
    {
        var action = () => DateTimeDuration.From(10, 0, 2, 1, new DateTimeDurationTypeOptions
        {
            MaxDuration = 20,
            MinDuration = 10.5,
            TimeUnit = TimeUnit.Day,
        });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox DateTimeDuration type as value 10.00:02:01 is less than than the minimum specified value of 10.12:00:00") });
    }

    [Fact]
    public void From_WithValueGreaterThanMaximum_ThrowsValidationException()
    {
        var action = () => DateTimeDuration.From(10, 12, 2, 1, new DateTimeDurationTypeOptions
        {
            MaxDuration = 10.5,
            TimeUnit = TimeUnit.Day,
        });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox DateTimeDuration type as value 10.12:02:01 is greater than than the maximum specified value of 10.12:00:00") });
    }

    [Fact]
    public void From_WithCustomFormatLimitsAndValueLessThanMinimum_ThrowsValidationException()
    {
        var action = () => DateTimeDuration.From(10, 0, 2, 1, new DateTimeDurationTypeOptions
        {
            MaxDurationCustomFormat = "20:00:00:00",
            MinDurationCustomFormat = "10:12:00:00",
            TimeUnit = TimeUnit.CustomFormat,
        });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox DateTimeDuration type as value 10.00:02:01 is less than than the minimum specified value of 10.12:00:00") });
    }

    [Fact]
    public void From_WithCustomFormatLimitsAndValueGreaterThanMaximum_ThrowsValidationException()
    {
        var action = () => DateTimeDuration.From(10, 12, 2, 1, new DateTimeDurationTypeOptions
        {
            MaxDurationCustomFormat = "10:12:00:00",
            TimeUnit = TimeUnit.CustomFormat,
        });

        action.Should().Throw<TypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", $"Could not create a Nox DateTimeDuration type as value 10.12:02:01 is greater than than the maximum specified value of 10.12:00:00") });
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
    public void TotalDaysHoursMinutesSecondsMillisecondsAndTicksProperties_WithValidDateTimeDurationObject_ReturnValue()
    {
        var dateTimeDuration = DateTimeDuration.FromDays(1.5);

        dateTimeDuration.TotalDays.Should().Be(1.5);
        dateTimeDuration.TotalHours.Should().Be(1.5 * 24);
        dateTimeDuration.TotalMinutes.Should().Be(1.5 * 24 * 60);
        dateTimeDuration.TotalSeconds.Should().Be(1.5 * 24 * 60 * 60);
        dateTimeDuration.TotalMilliseconds.Should().Be(1.5 * 24 * 60 * 60 * 1000);
        dateTimeDuration.Ticks.Should().Be((long)(1.5 * 24 * 60 * 60 * 1000 * 10000));
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
