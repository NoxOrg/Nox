// ReSharper disable once CheckNamespace
using System.Globalization;

namespace Nox.Types.Tests.Types;

public class LatLongTests
{
    [Fact]
    public void LatLong_Constructor_ReturnsSameValue()
    {
        var coords = LatLong.From(46.94809, 7.44744);

        Assert.Equal((46.94809, 7.44744), coords.Value);
    }

    [Fact]
    public void LatLong_Constructor_WithOutOfRangeLatitude_ThrowsValidationException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
          LatLong.From(100, 0)
        );

        Assert.Equal("Could not create a Nox LatLong type with latitude 100 as it is not in the range -90 to 90 degrees.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void LatLong_Constructor_WithOutOfRangeLongitude_ThrowsValidationException()
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
          LatLong.From(0, 200)
        );

        Assert.Equal("Could not create a Nox LatLong type with longitude 200 as it is not in the range -180 to 180 degrees.", exception.Errors.First().ErrorMessage);
    }

    [Fact]
    public void LatLong_Equality_Tests()
    {
        var coords1 = LatLong.From(46.94809, 7.44744);

        var coords2 = LatLong.From((Latitude: 46.94809, Longitude: 7.44744));

        Assert.Equal(coords1, coords2);
    }

    [Fact]
    public void LatLong_Equality_WithDifferentContructor_Tests()
    {
        var coords1 = LatLong.From(46.94809, 7.44744);

        var coords2 = LatLong.From((46.94809, 7.44744));

        Assert.Equal(coords1, coords2);
    }

    [Fact]
    public void LatLong_NotEqual_Tests()
    {
        var coords1 = LatLong.From(46.94809, 7.44744);

        var coords2 = LatLong.From(46.204391, 6.143158);

        Assert.NotEqual(coords1, coords2);
    }

    [Theory]
    [InlineData("en-us")]
    [InlineData("pt-PT")]
    public void LatLong_ToString_IsCultureIndependent(string culture)
    {
        string expectedResult = "46.948090 7.447440";
        void Test()
        {
            var coords = LatLong.From(46.94809, 7.44744);
            Assert.Equal(expectedResult, coords.ToString());
        }

        TestUtility.RunInCulture(Test,culture);
    }

    [Theory]
    [InlineData("en-us", "46.94809 7.44744")]
    [InlineData("pt-PT", "46,94809 7,44744")]
    public void LatLong_ToStringFormatProvider_IsCultureDependent(string culture, string expectedResult)
    {        
        void Test()
        {
            var coords = LatLong.From(46.94809, 7.44744);

            Assert.Equal(expectedResult, coords.ToString(new CultureInfo(culture)));
        }

        TestUtility.RunInCulture(Test, culture);
    }


    [Fact]
    public void LatLong_ToString_DMS_ReturnsString()
    {
        var coords = LatLong.From(46.94809, 7.44744);

        var str = coords.ToString("dms");

        Assert.Equal("46°56'53.124\" N 7°26'50.784\" E", coords.ToString("dms"));
    }

    [Theory]
    [InlineData("en-us")]
    [InlineData("pt-PT")]
    public void LatLong_ToString_DMS_IsCultureIndependent(string culture)
    {
        void Test()
        {
            var coords = LatLong.From(46.94809, 7.44744);

            var dmsLatLongString = coords.ToString("dms");

            Assert.Equal("46°56'53.124\" N 7°26'50.784\" E", dmsLatLongString);
        }

        TestUtility.RunInCulture(Test, culture);       
    }
    [Theory]
    [InlineData("en-us")]
    [InlineData("pt-PT")]
    public void LatLong_ToString_DMS_IsCultureIndependent_For_InvalidFormat(string culture)
    {
        void Test()
        {
            var coords = LatLong.From(46.94809, 7.44744);

            var dmsLatLongString = coords.ToString("INVALID");

            Assert.Equal("46.948090 7.447440", dmsLatLongString);
        }

        TestUtility.RunInCulture(Test, culture);
    }
}