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
}