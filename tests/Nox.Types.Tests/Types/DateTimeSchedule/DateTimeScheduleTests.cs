using FluentAssertions;

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
    [InlineData("55 2 */3 1-8 *")]
    [InlineData("55 2 */3 JAN-AUG *")]
    [InlineData("55 2-12 */3 JAN-AUG *")]
    [InlineData("0 0 1-5/3 2-12/2 1-8/3 5 2020-2023/1")]
    [InlineData("0 0 */3 */2 */3 5 */3")]
    [InlineData("0 0 1-5 2-12 1-8 1-3 2020-2023")]
    [InlineData("0 0 1/3 2/2 8/3 1 2022/2")]
    [InlineData("0 0 1-5/2,23 2-12/2,11 1-3,7 5,6 2020-2023/2,2000")]
    [InlineData("0 0 1-5/2,11,23 2-12/2,9,11 1-3,5,7 5,1,6 2020-2023/2,2000,1999")]
    [InlineData("0 0 1-5/3 2-12/2 1-8/3 5")]
    [InlineData("*/5 */5 */3 */2 */3 5 */3")]
    [InlineData("1-5 1-5 1-5 2-12 1-8 1-3")]
    [InlineData("1/5 1/5 1/3 2/2 8/3 1")]
    [InlineData("1-5/2 1-5/2 1-5/2,23 2-12/2,11 1-5,6 2000-2020/2,2001")]
    [InlineData("0 0 12 * * 2000")]
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
    [InlineData("63 2 */3 JAN-AUG *")]
    [InlineData("55 80 */3 JAN-AUG *")]
    [InlineData("55 2 33 JAN-AUG *")]
    [InlineData("55 2 */3 JAN-AG *")]
    [InlineData("55 2 */3 1-18 *")]
    [InlineData("55 2 */3 JAN-AUG p")]
    [InlineData("66 55 2 */3 JAN-AUG *")]
    [InlineData("88 0 12 * * ?")]
    [InlineData("0 88 12 * * ?")]
    [InlineData("0 0 25 * * ?")]
    [InlineData("0 0 12 32 * ?")]
    [InlineData("0 0 12 * 13 ?")]
    [InlineData("0 0 12 * * 7")]
    public void From_WithInvalidCronJob_ThrowsExceptione(string value)
    {
        Action comparison = () => DateTimeSchedule.From(value);

        comparison.Should().Throw<TypeValidationException>();
    }

    [Theory]
    [InlineData("at 12:00 PM every day", "0 12 * * *")]
    [InlineData("at 10:15 AM every day", "15 10 * * *")]
    //[InlineData("at 10:15 AM every day during the year 2023", "0 15 10 * * ? 2023")] actual result "0 0 * * *"
    //[InlineData("every minute from 2:00PM to 2:59PM", "0 * 14 * * ?")] // actual "*/5 * * - *"
    //[InlineData("every 5 minutes from 2:00PM to 2:55PM", "0 0/5 14 * * ?")] // actual */5 * * - *
    //[InlineData("at 2:10 PM and at 2:44 PM every Wednesday", "0 10,44 14 ? 3 3")] // actual 10 14 * * 3 - At 02:10 PM, only on Wednesday
    [InlineData("at 10:15 AM every Monday, Tuesday, Wednesday, Thursday and Friday", "15 10 * * 1,2,3,4,5")]
    [InlineData("at 10:15 AM on the 15th", "15 10 15 * *")]
    //[InlineData("at 10:15 AM on the last day of every month", "0 15 10 L * ?")] actual "15 10 1 * *" At 10:15 AM, on day 1 of the month
    //[InlineData("at 10:15 AM on the last Friday of every month", "0 15 10 ? * 6L")] // actual "15 10 1 * 5" At 10:15 AM, on day 1 of the month, only on Friday
    //[InlineData("at 10:15 AM on every last friday of every month during the years 2020, 2021, 2022, and 2023", "0 15 10 ? * 6L 2020-2023")] actual "15 10 * * 5" - At 10:15 AM, only on Friday
    //[InlineData("at 10:15 AM on the third Friday of every month", "0 15 10 ? * 6#3")] // actual "15 10 1 * 5" - At 10:15 AM, on day 1 of the month, only on Friday
    //[InlineData("at 12 PM every 5 days every month", "0 0 12 1/5 * ?")] // actual "0 12 * */5,day,every *" should be 0 12 */5 * *
    [InlineData(" every November 11 at 11:11 AM", "11 11 11 11 *")]
    [InlineData("at 11:11 AM, on 11 November", "11 11 11 11 *")]
    [InlineData("Every Hour Mondays to Fridays", "0 * * * 1-5")]
    [InlineData("at 5:15pm on christmas", "15 17 25 12 *")]
    [InlineData("At 5pm on even days", "0 17 2-30/2 * *")]
    [InlineData("At 5pm on odd days", "0 17 1-31/2 * *")]
    [InlineData("at 5:15am on 13 June", "15 5 13 6 *")]
    [InlineData("Daily at 02:00 CET", "0 1 * * *")]
    [InlineData("Daily at 02:00 UTC", "0 2 * * *")]
    [InlineData("Daily at 02:00", "0 2 * * *")]
    [InlineData("On Mondays and Fridays at 14:00", "0 14 * * 1,5")]
    [InlineData("Every 30 minutes", "*/30 * * * *")]
    [InlineData("Every Hour Mondays to Fridays and Sundays", "0 * * * 1-5,0")]
    [InlineData("Every Hour Mondays to Fridays and Sundays in October and December", "0 * * 10,12 1-5,0")]
    [InlineData("Every 5 minutes from January to June", "*/5 * * 1-6 *")]
    [InlineData("Every 3 months on the 2nd at 8am", "0 8 2 */3 *")]
    [InlineData("Every 3 months on the 2nd and 4th at 8am", "0 8 2,4 */3 *")]
    [InlineData("every 3rd day at 2:55 am from January to August", "55 2 */3 1-8 *")]
    [InlineData("Every Tuesday at 15:00", "0 15 * * 2")]
    [InlineData("every 6 hours", "0 */6 * * *")]
    [InlineData("new year", "* * 1 1 *")]
    [InlineData("on new year", "* * 1 1 *")]
    [InlineData("11:34 on 13 and 16 June", "34 11 13,16 6 *")]
    [InlineData("never", "0 0 31 2 0")]
    [InlineData("every 3 months on the 2nd and 4th at 8am", "0 8 2,4 */3 *")]
    public void FromEnglishPhrase_WithValidCronJob_ReturnsValue(string englishPhrase, string cronExpression)
    {
        var datetimeschedule = DateTimeSchedule.FromEnglishPhrase(englishPhrase);

        datetimeschedule.Value.Should().Be(cronExpression);
    }
}