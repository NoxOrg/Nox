using System.Globalization;

namespace Nox.Types.Tests.Types;

public class DateTimeRangeTests
{
    [Fact]
    public void From_WithValidStartAndEnd_ReturnsValue()
    {
        var start = DateTime.UtcNow;
        var end = start.AddDays(1);

        var dateTimeRange = DateTimeRange.From(start, end);

        Assert.Equal(start, dateTimeRange.Start);
        Assert.Equal(end, dateTimeRange.End);
        Assert.Equal((start, end), dateTimeRange.Value);
    }

    [Fact]
    public void From_WithSameStartAndEnd_ReturnsValue()
    {
        var start = DateTime.UtcNow;
        var end = start;

        var dateTimeRange = DateTimeRange.From(start, end);

        Assert.Equal(start, dateTimeRange.Start);
        Assert.Equal(end, dateTimeRange.End);
        Assert.Equal((start, end), dateTimeRange.Value);
    }

    [Fact]
    public void From_WithTimeSpan_ReturnsValue()
    {
        var start = DateTime.UtcNow;
        var timeSpan = TimeSpan.FromDays(20);

        var dateTimeRange = DateTimeRange.From(start, timeSpan);

        Assert.Equal(start, dateTimeRange.Start);
        Assert.Equal(start + timeSpan, dateTimeRange.End);
        Assert.Equal((start, start + timeSpan), dateTimeRange.Value);
    }

    [Fact]
    public void From_WithInvalidDates_ThrowsValidationException()
    {
        void Test()
        {
            var start = new DateTime(2023, 05, 01);
            var end = new DateTime(2023, 04, 01);
            var exception = Assert.Throws<TypeValidationException>(() => _ =
              DateTimeRange.From(start, end)
            );

            Assert.Equal("Could not create a Nox DateTimeRange type with Start value 01/05/2023 00:00:00 and End value 01/04/2023 00:00:00 as start of the time range must be the same or after the end of the time range.", exception.Errors.First().ErrorMessage);
        }

        TestUtility.RunInCulture(Test, "en-GB");
    }

    [Fact]
    public void Equality_WithSameStartAndEnd_ShouldBeEquivalent()
    {
        var start = new DateTime(2020, 5, 1);
        var end = new DateTime(2020, 8, 1);

        var dateTimeRange1 = DateTimeRange.From(start, end);
        var dateTimeRange2 = DateTimeRange.From(start, end);

        AssertAreEquivalent(dateTimeRange1, dateTimeRange2);
    }

    [Fact]
    public void Equality_WithRegularAndWithTimeSpanConstructors_ShouldBeEquivalent()
    {
        var start = DateTime.UtcNow;
        var end = start.AddDays(1);
        var timeSpan = TimeSpan.FromDays(1);

        var dateTimeRange1 = DateTimeRange.From(start, end);
        var dateTimeRange2 = DateTimeRange.From(start, timeSpan);

        AssertAreEquivalent(dateTimeRange1, dateTimeRange2);
    }

    [Fact]
    public void Equality_WithRegularAndWithTupleConstructors_ShouldBeEquivalent()
    {
        var start = DateTime.UtcNow;
        var end = start.AddDays(1);

        var dateTimeRange1 = DateTimeRange.From(start, end);
        var dateTimeRange2 = DateTimeRange.From((start, end));

        AssertAreEquivalent(dateTimeRange1, dateTimeRange2);
    }


    [Theory]
    [InlineData("2021-01-01", "2021-05-01", "2023-01-01", "2023-05-01")]
    [InlineData("2021-01-01", "2021-05-01", "2021-01-01", "2023-05-01")]
    [InlineData("2021-01-01", "2021-05-01", "2020-01-01", "2021-05-01")]
    public void NonEquality_WithDifferentStartAndEnd_ShouldNotBeEquivalent(string startStr1, string endStr1, string startStr2, string endStr2)
    {
        var start1 = DateTime.Parse(startStr1);
        var end1 = DateTime.Parse(endStr1);

        var start2 = DateTime.Parse(startStr2);
        var end2 = DateTime.Parse(endStr2);

        var dateTimeRange1 = DateTimeRange.From(start1, end1);
        var dateTimeRange2 = DateTimeRange.From(start2, end2);

        AssertAreNotEquivalent(dateTimeRange1, dateTimeRange2);
    }

    [Fact]
    public void NonEquality_WithRegularAndWithTimeSpanConstructors_ShouldNotBeEquivalent()
    {
        var start = DateTime.UtcNow;
        var end = start.AddDays(1);
        var timeSpan = TimeSpan.FromDays(3);

        var dateTimeRange1 = DateTimeRange.From(start, end);
        var dateTimeRange2 = DateTimeRange.From(start, timeSpan);

        AssertAreNotEquivalent(dateTimeRange1, dateTimeRange2);
    }

    [Theory]
    [InlineData("2021-01-01", "2021-05-01", "2023-01-01", "2023-05-01")]
    [InlineData("2021-01-01", "2021-05-01", "2021-01-01", "2023-05-01")]
    [InlineData("2021-01-01", "2021-05-01", "2020-01-01", "2021-05-01")]
    public void NonEquality_WithRegularAndWithTupleConstructors_ShouldNotBeEquivalent(string startStr1, string endStr1, string startStr2, string endStr2)
    {
        var start1 = DateTime.Parse(startStr1);
        var end1 = DateTime.Parse(endStr1);

        var start2 = DateTime.Parse(startStr2);
        var end2 = DateTime.Parse(endStr2);

        var dateTimeRange1 = DateTimeRange.From(start1, end1);
        var dateTimeRange2 = DateTimeRange.From((start2, end2));

        AssertAreNotEquivalent(dateTimeRange1, dateTimeRange2);
    }

    [Fact]
    public void Duration_WithValidStarnAndEnd_ReturnsValue()
    {
        var start = new DateTime(2023, 01, 01);
        var end = new DateTime(2023, 01, 20);
        var duration = TimeSpan.FromDays(19);

        var dateTimeRange = DateTimeRange.From(start, end);

        Assert.Equal(duration, dateTimeRange.Duration);
    }

    [Theory]
    [InlineData("2023-01-01")]
    [InlineData("2024-01-01")]
    [InlineData("2023-06-06")]
    public void Contains_WithDateWithinTheRange_ReturnsTrue(string dateTimeStr)
    {
        var dateTime = DateTime.Parse(dateTimeStr);
        var dateTimeRange = DateTimeRange.From(new DateTime(2023, 01, 01), new DateTime(2024, 01, 01));

        Assert.True(dateTimeRange.Contains(dateTime));
    }

    [Theory]
    [InlineData("2022-12-31")]
    [InlineData("2024-01-02")]
    [InlineData("2021-06-06")]
    public void Contains_WithDateOutsideTheRange_ReturnsFalse(string dateTimeStr)
    {
        var dateTime = DateTime.Parse(dateTimeStr);
        var dateTimeRange = DateTimeRange.From(new DateTime(2023, 01, 01), new DateTime(2024, 01, 01));

        Assert.False(dateTimeRange.Contains(dateTime));
    }

    [Theory]
    [InlineData("2023-01-01", "2023-06-01", "2023-02-01", "2023-04-01", "2023-02-01", "2023-04-01")]
    [InlineData("2023-01-01", "2023-04-01", "2023-02-01", "2023-06-01", "2023-02-01", "2023-04-01")]
    [InlineData("2023-02-01", "2023-06-01", "2023-01-01", "2023-04-01", "2023-02-01", "2023-04-01")]
    [InlineData("2023-01-01", "2023-02-01", "2023-02-01", "2023-04-01", "2023-02-01", "2023-02-01")]
    public void Intersect_WithOverlappingRanges_ReturnsIntersectedDateTimeRange(string startStr1, string endStr1, string startStr2, string endStr2, string expectedStartStr, string expectedEndStr)
    {
        var start1 = DateTime.Parse(startStr1);
        var end1 = DateTime.Parse(endStr1);

        var start2 = DateTime.Parse(startStr2);
        var end2 = DateTime.Parse(endStr2);

        var expectedStart = DateTime.Parse(expectedStartStr);
        var expectedEnd = DateTime.Parse(expectedEndStr);

        var dateTimeRange1 = DateTimeRange.From(start1, end1);
        var dateTimeRange2 = DateTimeRange.From(start2, end2);

        var intersection = dateTimeRange1.Intersect(dateTimeRange2);
        var intersection2 = dateTimeRange2.Intersect(dateTimeRange1);

        Assert.Equal(intersection, intersection2);
        Assert.NotNull(intersection);
        Assert.Equal(expectedStart, intersection.Start);
        Assert.Equal(expectedEnd, intersection.End);
    }

    [Fact]
    public void Intersect_WithNonOverlappingRanges_ReturnsNull()
    {
        var start1 = new DateTime(2023, 01, 01);
        var end1 = new DateTime(2023, 02, 01);

        var start2 = new DateTime(2021, 03, 01);
        var end2 = new DateTime(2021, 04, 01);

        var dateTimeRange1 = DateTimeRange.From(start1, end1);
        var dateTimeRange2 = DateTimeRange.From(start2, end2);

        var intersection = dateTimeRange1.Intersect(dateTimeRange2);
        var intersection2 = dateTimeRange2.Intersect(dateTimeRange1);

        Assert.Equal(intersection, intersection2);
        Assert.Null(intersection);
    }

    [Theory]
    [InlineData("en-GB", "06/20/2023 10:05:00 - 08/20/2023 10:05:00")]
    [InlineData("en-US", "06/20/2023 10:05:00 - 08/20/2023 10:05:00")]
    public void ToString_WithoutParameters_ReturnsFormattedStringInInvariantCulture(string culture, string expectedResult)
    {
        void Test()
        {
            var start = new DateTime(2023, 6, 20, 10, 5, 0);
            var end = new DateTime(2023, 8, 20, 10, 5, 0);

            var dateTimeRange = DateTimeRange.From(start, end);
            var dateTimeRangeString = dateTimeRange.ToString();

            Assert.Equal(expectedResult, dateTimeRangeString);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-GB", "d", "06/20/2023 - 08/20/2023")]
    [InlineData("en-US", "d", "06/20/2023 - 08/20/2023")]
    [InlineData("en-US", "dd/MM/yy", "20/06/23 - 20/08/23")]
    [InlineData("en-GB", "dd/MM/yy", "20/06/23 - 20/08/23")]
    [InlineData("en-GB", "dd MMM HH:mm:ss", "20 Jun 10:05:00 - 20 Aug 10:05:00")]
    public void ToString_WithFormatParameter_ReturnsFormattedStringInInvariantCulture(string culture, string format, string expectedResult)
    {
        void Test()
        {
            var start = new DateTime(2023, 6, 20, 10, 5, 0);
            var end = new DateTime(2023, 8, 20, 10, 5, 0);

            var dateTimeRange = DateTimeRange.From(start, end);
            var dateTimeRangeString = dateTimeRange.ToString(format);

            Assert.Equal(expectedResult, dateTimeRangeString);
        }

        TestUtility.RunInCulture(Test, culture);
    }

    [Theory]
    [InlineData("en-GB", "20/06/2023 10:05:00 - 20/08/2023 10:05:00")]
    [InlineData("en-US", "6/20/2023 10:05:00 AM - 8/20/2023 10:05:00 AM")]
    public void ToString_WithCultureParameter_ReturnsFormattedString(string culture, string expectedResult)
    {
        var start = new DateTime(2023, 6, 20, 10, 5, 0);
        var end = new DateTime(2023, 8, 20, 10, 5, 0);

        var dateTimeRange = DateTimeRange.From(start, end);
        var dateTimeRangeString = dateTimeRange.ToString(new CultureInfo(culture));

        Assert.Equal(expectedResult, dateTimeRangeString);
    }

    [Theory]
    [InlineData("en-GB", "d", "20/06/2023 - 20/08/2023")]
    [InlineData("en-US", "d", "6/20/2023 - 8/20/2023")]
    [InlineData("en-US", "dd/MM/yy", "20/06/23 - 20/08/23")]
    [InlineData("en-GB", "dd/MM/yy", "20/06/23 - 20/08/23")]
    [InlineData("en-GB", "dd MMM HH:mm:ss", "20 Jun 10:05:00 - 20 Aug 10:05:00")]
    public void ToString_WithCultureAndFormatParameters_ReturnsFormattedString(string culture, string format, string expectedResult)
    {
        var start = new DateTime(2023, 6, 20, 10, 5, 0);
        var end = new DateTime(2023, 8, 20, 10, 5, 0);

        var dateTimeRange = DateTimeRange.From(start, end);
        var dateTimeRangeString = dateTimeRange.ToString(format, new CultureInfo(culture));

        Assert.Equal(expectedResult, dateTimeRangeString);
    }

    private static void AssertAreEquivalent(DateTimeRange dateTimeRange1, DateTimeRange dateTimeRange2)
    {
        Assert.Equal(dateTimeRange1, dateTimeRange2);
        Assert.True(dateTimeRange1.Equals(dateTimeRange2));
        Assert.True(dateTimeRange2.Equals(dateTimeRange1));
        Assert.True(dateTimeRange1 == dateTimeRange2);
        Assert.False(dateTimeRange1 != dateTimeRange2);
    }

    private static void AssertAreNotEquivalent(DateTimeRange dateTimeRange1, DateTimeRange dateTimeRange2)
    {
        Assert.NotEqual(dateTimeRange1, dateTimeRange2);
        Assert.False(dateTimeRange1.Equals(dateTimeRange2));
        Assert.False(dateTimeRange2.Equals(dateTimeRange1));
        Assert.False(dateTimeRange1 == dateTimeRange2);
        Assert.True(dateTimeRange1 != dateTimeRange2);
    }
}
