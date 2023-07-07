namespace Nox.Types.Tests.Types;
using FluentAssertions;
using System.Globalization;

public class DateTimeTests
{
    [Fact]
    public void From_WithValidDate_ReturnsValue()
    {
        var datetimeExpected = System.DateTime.Now;
        var datetime = DateTime.From(datetimeExpected.Year, datetimeExpected.Month, datetimeExpected.Day);

        datetime.Year.Should().Be(datetimeExpected.Year);
        datetime.Month.Should().Be(datetimeExpected.Month);
        datetime.Day.Should().Be(datetimeExpected.Day);
    }

    [Fact]
    public void From_WithDateTimeTypeOptions_InvalidValue_ThrowsException()
    {
        DateTimeTypeOptions dateTimeTypeOptions = new() { AllowFutureOnly = true };
        Action comparison = () => DateTime.From(dateTimeTypeOptions, 2000, 01, 01);

        comparison.Should().Throw<TypeValidationException>();
    }

    [Fact]
    public void From_WithYearTypeOptions_InvalidValue_ThrowsException()
    {
        DateTimeTypeOptions dateTimeTypeOptions = new() { MaxValue = new System.DateTime(2022, 01, 01) };
        Action comparison = () => DateTime.From(dateTimeTypeOptions, 2023, 01, 01);

        comparison.Should().Throw<TypeValidationException>();
    }

    [Fact]
    public void From_WithValidDateTime_ReturnsValue()
    {
        var datetimeExpected = System.DateTime.Now;
        var datetime = DateTime.From(datetimeExpected.Year, datetimeExpected.Month, datetimeExpected.Day, datetimeExpected.Hour, datetimeExpected.Minute, datetimeExpected.Second);

        datetime.Year.Should().Be(datetimeExpected.Year);
        datetime.Month.Should().Be(datetimeExpected.Month);
        datetime.Day.Should().Be(datetimeExpected.Day);
        datetime.Hour.Should().Be(datetimeExpected.Hour);
        datetime.Minute.Should().Be(datetimeExpected.Minute);
        datetime.Second.Should().Be(datetimeExpected.Second);
    }

    [Fact]
    public void From_SystemDateTime_ReturnsValue()
    {
        var datetimeExpected = System.DateTime.Now;
        var datetime = DateTime.From(datetimeExpected);

        datetime.Year.Should().Be(datetimeExpected.Year);
        datetime.Month.Should().Be(datetimeExpected.Month);
        datetime.Day.Should().Be(datetimeExpected.Day);
        datetime.Hour.Should().Be(datetimeExpected.Hour);
        datetime.Minute.Should().Be(datetimeExpected.Minute);
        datetime.Second.Should().Be(datetimeExpected.Second);
    }

    [Fact]
    public void From_ValidDateTimeString_ReturnsValue()
    {
        var datetimeExpected = System.DateTime.Now;
        var datetime = DateTime.From(datetimeExpected.ToString());

        datetime.Year.Should().Be(datetimeExpected.Year);
        datetime.Month.Should().Be(datetimeExpected.Month);
        datetime.Day.Should().Be(datetimeExpected.Day);
        datetime.Hour.Should().Be(datetimeExpected.Hour);
        datetime.Minute.Should().Be(datetimeExpected.Minute);
        datetime.Second.Should().Be(datetimeExpected.Second);
    }

    [Fact]
    public void From_InValidDateTimeString_ThrowsException()
    {
        Action comparison = () => DateTime.From("2023-31-31");

        comparison.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void From_InValidDateTime_ThrowsException()
    {
        Action comparison = () => DateTime.From(2023, 12, 32);

        comparison.Should().Throw<TypeValidationException>();
    }

    [Fact]
    public void From_InValidYear_ThrowsException()
    {
        Action comparison = () => DateTime.From(1, 12, 32);

        comparison.Should().Throw<TypeValidationException>();
    }

    [Fact]
    public void From_InValidMonth_ThrowsException()
    {
        Action comparison = () => DateTime.From(2022, 18, 32);

        comparison.Should().Throw<TypeValidationException>();
    }

    [Fact]
    public void OperatorPlus_ReturnsValue_TestCopy()
    {
        var datetimeOriginalExpected = System.DateTime.UtcNow;
        var datetimeOriginal = DateTime.From(System.DateTime.UtcNow);
        var timeSpan = TimeSpan.FromDays(20);

        var datetimeExpected = datetimeOriginalExpected + timeSpan;
        var datetime = datetimeOriginal + timeSpan;

        datetime.Year.Should().Be(datetimeExpected.Year);
        datetime.Month.Should().Be(datetimeExpected.Month);
        datetime.Day.Should().Be(datetimeExpected.Day);
        datetime.Hour.Should().Be(datetimeExpected.Hour);
        datetime.Minute.Should().Be(datetimeExpected.Minute);
        datetime.Second.Should().Be(datetimeExpected.Second);

        datetimeOriginal.Year.Should().Be(datetimeOriginalExpected.Year);
        datetimeOriginal.Month.Should().Be(datetimeOriginalExpected.Month);
        datetimeOriginal.Day.Should().Be(datetimeOriginalExpected.Day);
        datetimeOriginal.Hour.Should().Be(datetimeOriginalExpected.Hour);
        datetimeOriginal.Minute.Should().Be(datetimeOriginalExpected.Minute);
        datetimeOriginal.Second.Should().Be(datetimeOriginalExpected.Second);
    }

    [Fact]
    public void Add_ReturnsCorrcetValueValue()
    {
        var datetime = DateTime.From(System.DateTime.UtcNow);
        var timeSpan = TimeSpan.FromDays(20);

        var datetimeExpected = datetime + timeSpan;
        datetime.Add(timeSpan);

        datetime.Year.Should().Be(datetimeExpected.Year);
        datetime.Month.Should().Be(datetimeExpected.Month);
        datetime.Day.Should().Be(datetimeExpected.Day);
        datetime.Hour.Should().Be(datetimeExpected.Hour);
        datetime.Minute.Should().Be(datetimeExpected.Minute);
        datetime.Second.Should().Be(datetimeExpected.Second);
    }

    [Fact]
    public void Add_NegativeValue_ReturnsCorrcetValueValue()
    {
        var datetimeExpectedOriginal = System.DateTime.UtcNow;
        var datetime = DateTime.From(datetimeExpectedOriginal);
        var timeSpan = TimeSpan.FromDays(-20);

        var datetimeExpected = datetimeExpectedOriginal.Add(timeSpan);
        datetime.Add(timeSpan);

        datetime.Year.Should().Be(datetimeExpected.Year);
        datetime.Month.Should().Be(datetimeExpected.Month);
        datetime.Day.Should().Be(datetimeExpected.Day);
        datetime.Hour.Should().Be(datetimeExpected.Hour);
        datetime.Minute.Should().Be(datetimeExpected.Minute);
        datetime.Second.Should().Be(datetimeExpected.Second);
    }

    [Fact]
    public void OperatorMinus_ReturnsValue_TestCopy()
    {

        var systemDatetime = System.DateTime.UtcNow;
        var timeSpan = TimeSpan.FromDays(20);
        var datetimeOriginal = DateTime.From(systemDatetime);
        var datetimeDaysAdded = DateTime.From(systemDatetime.Add(timeSpan));

        var timeSpanActual = datetimeDaysAdded - datetimeOriginal;

        timeSpanActual.Should().Be(timeSpan);
    }

    [Fact]
    public void EquationSigns_NotEqual_ReturnsValue()
    {

        var systemDatetime = System.DateTime.UtcNow;
        var timeSpan = TimeSpan.FromDays(20);
        var datetime = DateTime.From(systemDatetime);
        var datetimeDaysAdded = DateTime.From(systemDatetime.Add(timeSpan));

        (datetime < datetimeDaysAdded).Should().BeTrue();
        (datetimeDaysAdded < datetime).Should().BeFalse();
        (datetime <= datetimeDaysAdded).Should().BeTrue();
        (datetimeDaysAdded <= datetime).Should().BeFalse();
        (datetime > datetimeDaysAdded).Should().BeFalse();
        (datetimeDaysAdded > datetime).Should().BeTrue();
        (datetime <= datetimeDaysAdded).Should().BeTrue();
        (datetimeDaysAdded <= datetime).Should().BeFalse();
        (datetime >= datetimeDaysAdded).Should().BeFalse();
        (datetimeDaysAdded >= datetime).Should().BeTrue();
        (datetime != datetimeDaysAdded).Should().BeTrue();
    }

    [Fact]
    public void EquationSigns_Equal_ReturnsValue()
    {

        var systemDatetime = System.DateTime.UtcNow;
        var datetime = DateTime.From(systemDatetime);
        var datetime2 = DateTime.From(systemDatetime);

        (datetime < datetime2).Should().BeFalse();
        (datetime <= datetime2).Should().BeTrue();
        (datetime > datetime2).Should().BeFalse();
        (datetime >= datetime2).Should().BeTrue();
        (datetime == datetime2).Should().BeTrue();
        (datetime != datetime2).Should().BeFalse();
    }

    [Theory]
    [InlineData("en-GB", "d", "20/06/2023")]
    [InlineData("en-US", "d", "6/20/2023")]
    [InlineData("en-US", "dd/MM/yy", "20/06/23")]
    [InlineData("en-GB", "dd/MM/yy", "20/06/23")]
    [InlineData("en-GB", "dd MMM HH:mm:ss", "20 Jun 10:05:00")]
    public void ToString_WithCultureAndFormatParameters_ReturnsFormattedString(string culture, string format, string expectedResult)
    {
        var datetime = DateTime.From(2023, 6, 20, 10, 5, 0);

        var dateTimeString = datetime.ToString(format, new CultureInfo(culture));

        Assert.Equal(expectedResult, dateTimeString);
    }

    [Theory]
    [InlineData("en-GB", "06/20/2023 10:05:00")]
    [InlineData("en-US", "06/20/2023 10:05:00")]
    public void ToString_WithoutParameters_ReturnsFormattedStringInInvariantCulture(string culture, string expectedResult)
    {
        void Test()
        {
            var dateTime = DateTime.From(2023, 6, 20, 10, 5, 0);

            var dateTimeString = dateTime.ToString();

            Assert.Equal(expectedResult, dateTimeString);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-GB", "d", "06/20/2023")]
    [InlineData("en-US", "d", "06/20/2023")]
    [InlineData("en-US", "dd/MM/yy", "20/06/23")]
    [InlineData("en-GB", "dd/MM/yy", "20/06/23")]
    [InlineData("en-GB", "dd MMM HH:mm:ss", "20 Jun 10:05:00")]
    public void ToString_WithFormatParameter_ReturnsFormattedStringInInvariantCulture(string culture, string format, string expectedResult)
    {
        void Test()
        {
            var dateTime = DateTime.From(2023, 6, 20, 10, 5, 0);
            var dateTimeString = dateTime.ToString(format);

            Assert.Equal(expectedResult, dateTimeString);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-GB", "20/06/2023 10:05:00")]
    [InlineData("en-US", "6/20/2023 10:05:00 AM")]
    public void ToString_WithCultureParameter_ReturnsFormattedString(string culture, string expectedResult)
    {
        var dateTime = DateTime.From(2023, 6, 20, 10, 5, 0);
        var dateTimeString = dateTime.ToString(new CultureInfo(culture));

        Assert.Equal(expectedResult, dateTimeString);
    }

    [Fact]
    public void Equals_ReturnsTrue()
    {

        var systemDatetime = System.DateTime.UtcNow;
        var datetime = DateTime.From(systemDatetime);
        var datetime2 = DateTime.From(systemDatetime);

        (datetime.Equals(datetime2)).Should().BeTrue();
    }

    [Fact]
    public void Equals_ReturnsFalse()
    {

        var systemDatetime = System.DateTime.UtcNow;
        var datetime = DateTime.From(systemDatetime);
        var datetime2 = DateTime.From(systemDatetime.AddDays(20));

        (datetime.Equals(datetime2)).Should().BeFalse();
    }
}

