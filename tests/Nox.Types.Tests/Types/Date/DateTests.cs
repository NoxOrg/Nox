using FluentAssertions;
using System.Globalization;

namespace Nox.Types.Tests.Types;

public class DateTests
{
    [Fact]
    public void From_WithDateOnlyInput_ReturnsValue()
    {
        DateOnly dateOnly = new DateOnly(2023, 12, 4);

        var date = Date.From(dateOnly, new DateTypeOptions());

        date.Value.Should().Be(dateOnly);
        date.Value.Year.Should().Be(2023);
        date.Value.Month.Should().Be(12);
        date.Value.Day.Should().Be(4);
    }

    [Fact]
    public void From_WithYearMonthDayInput_ReturnsValue()
    {
        var date = Date.From(2023, 4, 12, new());

        date.Value.Should().Be(new DateOnly(2023, 4, 12));
        date.Value.Year.Should().Be(2023);
        date.Value.Month.Should().Be(4);
        date.Value.Day.Should().Be(12);
    }

    [Fact]
    public void From_WithDateTimeInput_ReturnsValue()
    {
        var dateTime = new System.DateTime(2023, 4, 12, 10, 15, 10);
        var date = Date.From(dateTime);

        date.Value.Year.Should().Be(2023);
        date.Value.Month.Should().Be(4);
        date.Value.Day.Should().Be(12);
    }

    [Fact]
    public void From_WithDateOnlyInputAndValueOverMaxValue_ThrowsValidationException()
    {
        var options = new DateTypeOptions
        {
            MaxValue = new System.DateTime(2023, 06, 01),
            MinValue = new System.DateTime(2023, 04, 01)
        };

        var action = () => Date.From(new DateOnly(2023, 07, 01), options);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Date type as value 07/01/2023 is greater than than the maximum specified value of 06/01/2023") });
    }

    [Fact]
    public void From_WithDateOnlyInputAndValueUnderMinValue_ThrowsValidationException()
    {
        var options = new DateTypeOptions
        {
            MaxValue = new System.DateTime(2023, 06, 01),
            MinValue = new System.DateTime(2023, 04, 01)
        };

        var action = () => Date.From(new DateOnly(2023, 03, 01), options);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Date type as value 03/01/2023 is less than than the minimum specified value of 04/01/2023") });
    }

    [Fact]
    public void From_WithYearMonthDayInputAndValueOverMaxValue_ThrowsValidationException()
    {
        var options = new DateTypeOptions
        {
            MaxValue = new System.DateTime(2023, 06, 01),
            MinValue = new System.DateTime(2023, 04, 01)
        };

        var action = () => Date.From(2023, 07, 01, options);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Date type as value 07/01/2023 is greater than than the maximum specified value of 06/01/2023") });
    }

    [Fact]
    public void From_WithYearMonthDayInputAndValueUnderMinValue_ThrowsValidationException()
    {
        var options = new DateTypeOptions
        {
            MaxValue = new System.DateTime(2023, 06, 01),
            MinValue = new System.DateTime(2023, 04, 01)
        };

        var action = () => Date.From(2023, 03, 01, options);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value", "Could not create a Nox Date type as value 03/01/2023 is less than than the minimum specified value of 04/01/2023") });
    }

    [Fact]
    public void Equality_WithDifferentInputTypes_ShouldBeEquivalent()
    {
        var date1 = Date.From(new DateOnly(2023, 06, 01), new());
        var date2 = Date.From(2023, month: 06, 01, new());
        var date3 = Date.From(new System.DateTime(2023, 06, 01, 10, 15, 20));

        AssertAreEquivalent(date1, date2);
        AssertAreEquivalent(date1, date3);
    }

    [Fact]
    public void Equality_WithDateTimeIncludingAndExcludingTime_ShouldBeEquivalent()
    {
        var date1 = Date.From(new System.DateTime(2023, 06, 01, 10, 10, 10), new());
        var date2 = Date.From(new System.DateTime(2023, 06, 01), new());

        AssertAreEquivalent(date1, date2);
    }

    [Fact]
    public void NonEquality_WithDifferentValues_ShouldNotBeEquivalent()
    {
        var date1 = Date.From(2023, 05, 01, new());
        var date2 = Date.From(2023, 06, 01, new());

        AssertAreNotEquivalent(date1, date2);
    }

    [Fact]
    public void YearMonthDayProperties_WithValidDateObject_ShouldReturnValue()
    {
        var date = Date.From(2023, 07, 10, new());

        date.Day.Should().Be(10);
        date.Month.Should().Be(7);
        date.Year.Should().Be(2023);
    }

    [Fact]
    public void DayOfWeekAndDayOfYearProperties_WithValidDateObject_ShouldReturnValue()
    {
        var date = Date.From(2023, 07, 10, new());

        date.DayOfWeek.Should().Be(System.DayOfWeek.Monday);
        date.DayOfYear.Should().Be(191);
    }

    [Theory]
    [InlineData("en-US")]
    [InlineData("en-GB")]
    public void ToString_WithoutParameters_ReturnsFormattedStringInInvariantCulture(string culture)
    {
        static void Test()
        {
            var date = Date.From(2023, 11, 23, new());

            date.ToString().Should().Be("11/23/2023");
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-GB", "d", "06/20/2023")]
    [InlineData("en-US", "d", "06/20/2023")]
    [InlineData("en-US", "dd/MM/yy", "20/06/23")]
    [InlineData("en-GB", "dd/MM/yy", "20/06/23")]
    [InlineData("en-GB", "dd MMM", "20 Jun")]
    public void ToString_WithFormat_ReturnsFormattedStringInInvariantCulture(string culture, string format, string expected)
    {
        void Test()
        {
            var date = Date.From(2023, 6, 20, new());
            date.ToString(format).Should().Be(expected);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-US", "11/23/2023")]
    [InlineData("en-GB", "23/11/2023")]
    public void ToString_WithCulture_ReturnsFormattedStringInCulture(string culture, string expected)
    {
        var date = Date.From(2023, 11, 23, new());

        date.ToString(new CultureInfo(culture)).Should().Be(expected);
    }

    [Theory]
    [InlineData("en-GB", "d", "20/06/2023")]
    [InlineData("en-US", "d", "6/20/2023")]
    // TODO check with someone with Win11 - This returns "20 June 2023" on my PC (Windows 11 Pro 10.0.22621 Build 22621) - Andre Sharpe
    //[InlineData("en-GB", "D", "Tuesday, 20 June 2023")]
    [InlineData("en-US", "D", "Tuesday, June 20, 2023")]
    [InlineData("en-GB", "o", "2023-06-20")]
    [InlineData("en-US", "o", "2023-06-20")]
    [InlineData("en-GB", "O", "2023-06-20")]
    [InlineData("en-US", "O", "2023-06-20")]
    [InlineData("en-GB", "r", "Tue, 20 Jun 2023")]
    [InlineData("en-US", "r", "Tue, 20 Jun 2023")]
    [InlineData("en-GB", "R", "Tue, 20 Jun 2023")]
    [InlineData("en-US", "R", "Tue, 20 Jun 2023")]
    [InlineData("en-US", "dd/MM/yy", "20/06/23")]
    [InlineData("en-GB", "dd/MM/yy", "20/06/23")]
    [InlineData("en-GB", "dd MMM", "20 Jun")]
    public void ToString_WithFormatAndCulture_ReturnsFormattedStringInCulture(string culture, string format, string expected)
    {
        var date = Date.From(2023, 6, 20, new());

        date.ToString(format, new CultureInfo(culture)).Should().Be(expected);
    }

    [Theory]
    [InlineData("test")]
    [InlineData("dd/MM/yyyy hh")]
    [InlineData("dd/MM/yyyy HHs")]
    [InlineData("dd/MM/yyyy mm")]
    [InlineData("dd/MM/yyyy ss")]
    [InlineData("dd/MM/yyyy hh:mm")]
    [InlineData("dd/MM/yyyy ss.fffffffK")]
    public void ToString_WithInvalidFormat_ThrowsFormatException(string format)
    {
        var date = Date.From(2023, 06, 01, new());

        var action = () => date.ToString(format);

        action.Should().Throw<FormatException>()
            .WithMessage("Input string was not in a correct format.");
    }

    [Theory]
    [InlineData("2023-06-01", "2023-01-01", true)]
    [InlineData("2023-06-01", "2023-06-01", false)]
    [InlineData("2023-01-01", "2023-06-01", false)]
    public void GreaterThanOperator_WithVariousValues_ReturnsCorrectResult(string dateStr1, string dateStr2, bool expected)
    {
        var date1 = Date.From(DateOnly.Parse(dateStr1), new());
        var date2 = Date.From(DateOnly.Parse(dateStr2), new());

        (date1 > date2).Should().Be(expected);
    }

    [Theory]
    [InlineData("2023-06-01", "2023-06-01", true)]
    [InlineData("2023-06-01", "2023-01-01", true)]
    [InlineData("2023-01-01", "2023-06-01", false)]
    public void GreaterThanOrEqualOperator_WithVariousValues_ReturnsCorrectResult(string dateStr1, string dateStr2, bool expected)
    {
        var date1 = Date.From(DateOnly.Parse(dateStr1), new());
        var date2 = Date.From(DateOnly.Parse(dateStr2), new());

        (date1 >= date2).Should().Be(expected);
    }

    [Theory]
    [InlineData("2023-01-01", "2023-06-01", true)]
    [InlineData("2023-06-01", "2023-06-01", false)]
    [InlineData("2023-06-01", "2023-01-01", false)]
    public void LessThanOperator_WithVariousValues_ReturnsCorrectResult(string dateStr1, string dateStr2, bool expected)
    {
        var date1 = Date.From(DateOnly.Parse(dateStr1), new());
        var date2 = Date.From(DateOnly.Parse(dateStr2), new());

        (date1 < date2).Should().Be(expected);
    }

    [Theory]
    [InlineData("2023-06-01", "2023-06-01", true)]
    [InlineData("2023-01-01", "2023-06-01", true)]
    [InlineData("2023-06-01", "2023-01-01", false)]
    public void LessThanOrEqualOperator_WithVariousValues_ReturnsCorrectResult(string dateStr1, string dateStr2, bool expected)
    {
        var date1 = Date.From(DateOnly.Parse(dateStr1), new());
        var date2 = Date.From(DateOnly.Parse(dateStr2), new());

        (date1 <= date2).Should().Be(expected);
    }

    private static void AssertAreEquivalent(Date expected, Date actual)
    {
        actual.Should().Be(expected);

        expected.Equals(actual).Should().BeTrue();

        actual.Equals(expected).Should().BeTrue();

        (expected == actual).Should().BeTrue();

        (expected != actual).Should().BeFalse();
    }

    private static void AssertAreNotEquivalent(Date expected, Date actual)
    {
        actual.Should().NotBe(expected);

        expected.Equals(actual).Should().BeFalse();

        actual.Equals(expected).Should().BeFalse();

        (expected == actual).Should().BeFalse();

        (expected != actual).Should().BeTrue();
    }
}
