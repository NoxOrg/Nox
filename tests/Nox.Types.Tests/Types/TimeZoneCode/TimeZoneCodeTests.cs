// ReSharper disable once CheckNamespace
using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class TimeZoneCodeTests
{
    [Theory]
    [ClassData(typeof(TimeZoneCodeTestsDataClass))]
    public void TimeZoneCode_Constructor_ReturnsSameValue_AllTimeZones(string timeZoneCodeString)
    {
        var timeZoneCode = Nox.Types.TimeZoneCode.From(timeZoneCodeString);

        timeZoneCode.Value.Should().Be(timeZoneCodeString);
    }

    [Fact]
    public void TimeZoneCode_Constructor_WithUnsupportedTimeZoneCode_ThrowsValidationException()
    {
        var exception = Assert.Throws<NoxTypeValidationException>(() => _ =
          Nox.Types.TimeZoneCode.From("ABC")
        );

        exception.Errors.First().ErrorMessage.Should().Be("Could not create a Nox TimeZoneCode type with unsupported value 'ABC'.");
    }

    [Fact]
    public void TimeZoneCode_Equality_Tests()
    {
        var timeZoneCode_1 = Nox.Types.TimeZoneCode.From("PKT");

        var timeZoneCode_2 = Nox.Types.TimeZoneCode.From("PKT");

        timeZoneCode_1.Should().BeEquivalentTo(timeZoneCode_2);
    }

    [Fact]
    public void TimeZoneCode_CaseInsensitiveEquality_Tests()
    {
        var timeZoneCode_1 = Nox.Types.TimeZoneCode.From("PKT");

        var timeZoneCode_2 = Nox.Types.TimeZoneCode.From("pkt");

        timeZoneCode_1.Should().BeEquivalentTo(timeZoneCode_2);
    }

    [Fact]
    public void TimeZoneCode_NotEqual_Tests()
    {
        var timeZoneCode_1 = Nox.Types.TimeZoneCode.From("PKT");

        var timeZoneCode_2 = Nox.Types.TimeZoneCode.From("PST");

        timeZoneCode_1.Should().NotBeEquivalentTo(timeZoneCode_2);
    }

    [Fact]
    public void TimeZoneCode_ToString_ReturnsString()
    {
        var timeZoneCode = Nox.Types.TimeZoneCode.From("PKT");

        timeZoneCode.ToString().Should().BeEquivalentTo("PKT");
    }
}