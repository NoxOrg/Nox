// ReSharper disable once CheckNamespace
using Nox.Types.Tests.Types.CountryCode2;
using Nox.Types.Tests.Types.CountryCode3;

namespace Nox.Types.Tests.Types;

public class TimeZoneCodeTests
{
    [Theory]
    [ClassData(typeof(TimeZoneCodeTestsDataClass))]
    public void TimeZoneCode_Constructor_ReturnsSameValue_AllTimeZones(string timeZoneCodeString)
    {
        var timeZoneCode = Nox.Types.TimeZoneCode.From(timeZoneCodeString);

        Assert.Equal(timeZoneCodeString, timeZoneCode.Value);
    }

    [Fact]
    public void TimeZoneCode_Constructor_WithUnsupportedTimeZoneCode_ThrowsValidationException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
          Nox.Types.TimeZoneCode.From("ABC")
        );

        Assert.Equal("Could not create a Nox TimeZoneCode type with unsupported value 'ABC'.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void TimeZoneCode_Equality_Tests()
    {
        var timeZoneCode_1 = Nox.Types.TimeZoneCode.From("PKT");

        var timeZoneCode_2 = Nox.Types.TimeZoneCode.From("PKT");

        Assert.Equal(timeZoneCode_1, timeZoneCode_2);
    }

    [Fact]
    public void TimeZoneCode_CaseInsensiticeEquality_Tests()
    {
        var timeZoneCode_1 = Nox.Types.TimeZoneCode.From("PKT");

        var timeZoneCode_2 = Nox.Types.TimeZoneCode.From("pkt");

        Assert.Equal(timeZoneCode_1, timeZoneCode_2);
    }

    [Fact]
    public void TimeZoneCode_NotEqual_Tests()
    {
        var timeZoneCode_1 = Nox.Types.TimeZoneCode.From("PKT");

        var timeZoneCode_2 = Nox.Types.TimeZoneCode.From("PST");

        Assert.NotEqual(timeZoneCode_1, timeZoneCode_2);
    }

    [Fact]
    public void TimeZoneCode_ToString_ReturnsString()
    {
        var timeZoneCode = Nox.Types.TimeZoneCode.From("PKT");

        Assert.Equal("PKT", timeZoneCode.ToString());
    }
}