using FluentAssertions;
using System.Globalization;

namespace Nox.Types.Tests.Types;

public class DateTimeScheduleTests
{
    [Theory]
    [InlineData("0 0 12 * * ?")]
    [InlineData("0 15 10 ? * *")]
    [InlineData("0 15 10 * * ?")]
    [InlineData("0 15 10 * * ? *")]
    [InlineData("0 15 10 * * ? 2023")]
    [InlineData("0 0/5 14 * * ?")]
    [InlineData("0 0/5 14,18 * * ?")]
    [InlineData("0 10,44 14 ? 3 WED")]
    [InlineData("0 15 10 ? * MON-FRI")]
    [InlineData("0 15 10 15 * ?")]
    [InlineData("0 15 10 L * ?")]
    [InlineData("0 15 10 ? * 6L")]
    [InlineData("0 15 10 ? * 6L 2020-2023")]
    [InlineData("0 15 10 ? * 6#3")]
    [InlineData("0 0 12 1/5 * ?")]
    [InlineData("0 11 11 11 11 ?")]
    public void From_WithValidCronJob_ReturnsValue(string value)
    {
        var datetimeschedule = DateTimeSchedule.From(value);

        datetimeschedule.Value.Should().Be(value);
    }

    [Theory]
    [InlineData("")]
    [InlineData("0 0 23 1/ * ? *")]
    [InlineData("0 15 10 * * 18")]
    [InlineData("0 15 10 ? * MON-YY")]
    public void From_WithInvalidCronJob_ThrowsExceptione(string value)
    {
        Action comparison = () => DateTimeSchedule.From(value);

        comparison.Should().Throw<TypeValidationException>();
    }

    [Theory]
    [InlineData("at 12:00 PM every day", "0 0 12 * * ?")]
    [InlineData("at 10:15 AM every day", "15 10 * * *")]
    //[InlineData("at 10:15 AM every day during the year 2023", "0 15 10 * * ? 2023")]
    [InlineData("every minute starting at 2:00 PM and ending at 2:59 PM, every day", "0 0/5 14 * * ?")]
    [InlineData("every 5 minutes starting at 2:00 PM and ending at 2:55 PM, every day", "0 0/5 14,18 * * ?")]
    [InlineData("at 2:10 PM and at 2:44 PM every Wednesday in the month of March", "0 10,44 14 ? 3 WED")]
    [InlineData("at 10:15 AM every Monday, Tuesday, Wednesday, Thursday and Friday", "0 15 10 ? * MON-FRI")]
    [InlineData("at 10:15 AM on the 15th day of every month", "0 15 10 15 * ?")]
    [InlineData("at 10:15 AM on the last day of every month", "0 15 10 L * ?")]
    [InlineData("at 10:15 AM on the last Friday of every month", "0 15 10 ? * 6L")]
    [InlineData("at 10:15 AM on every last friday of every month during the years 2020, 2021, 2022, and 2023", "0 15 10 ? * 6L 2020-2023")]
    [InlineData("at 10:15 AM on the third Friday of every month", "0 15 10 ? * 6#3")]
    [InlineData("at 12 PM (noon) every 5 days every month, starting on the first day of the month", "0 0 12 1/5 * ?")]
    [InlineData(" every November 11 at 11:11 AM", "11 11 11 11 *")]
    [InlineData("at 11:11 AM, on day 11 of the month, only in November", "11 11 11 11 *")]
    public void FromEnglishPhrase_WithValidCronJob_ReturnsValue(string englishPhrase, string cronExpression)
    {
        var datetimeschedule = DateTimeSchedule.FromEnglishPhrase(englishPhrase);

        datetimeschedule.Value.Should().Be(cronExpression);
    }
}