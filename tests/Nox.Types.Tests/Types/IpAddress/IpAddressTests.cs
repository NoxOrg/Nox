// ReSharper disable once CheckNamespace
namespace Nox.Types.Tests.Types;

public class IpAddressTests
{
    [Theory]
    [InlineData("0.0.0.0")]
    [InlineData("10.0.0.0")]
    [InlineData("127.0.0.1")]
    [InlineData("172.16.0.0")]
    [InlineData("192.0.2.1")]
    [InlineData("255.255.255.255")]
    public void IpAddress_Constructor_WithIPv4Value_ReturnsSameValue(string ipV4Value)
    {
        var ipAddress = IpAddress.From(ipV4Value);

        Assert.Equal(ipV4Value, ipAddress.Value);
    }

    [Fact]
    public void Ip_Address_Constructor_WithIPv4ValueWithLeadingZeroInOctet_ReturnsValue()
    {
        var ipAddress = IpAddress.From("192.00.02.001");

        Assert.Equal("192.0.2.1", ipAddress.Value);
    }

    [Theory]
    [InlineData("192.168.0", "192.168.0.0")]    //  missing last octet
    [InlineData("192.168", "192.0.0.168")]      //  missing last two octets
    public void IpAddress_Constructor_WithIPv4ValueWithMissingOctets_ReturnsValue(string ipV4Value, string expectedValue)
    {
        var ipAddress = IpAddress.From(ipV4Value);

        Assert.Equal(expectedValue, ipAddress.Value);
    }

    [Theory]
    [InlineData("-1.0.0.0")]    //  out of range
    [InlineData("256.0.0.0")]   //  out of range
    [InlineData("192.0.2.1.")]  //  trailing dot
    [InlineData("192.0.2.1.5")] //  extra octet
    [InlineData("0192.0.2.1")]  //  leading zero in first octet
    [InlineData("192.168.")]    //  missing octets with trailing dot
    [InlineData("192.168.1.")]  //  missing octets with trailing dot
    public void IpAddress_Constructor_WithInvalidIPv4Value_ThrowsException(string ipV4Value)
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            IpAddress.From(ipV4Value)
        );

        Assert.Equal($"Could not create a Nox IP Address type as value {ipV4Value} is not a valid IP Address.", exception.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData("::")]
    [InlineData("::1")]
    [InlineData("2001:db8:85a3::8a2e:370:7334")]
    [InlineData("2001:db8:85a3:10a6:8a50:8a2e:370:7334")]
    [InlineData("::ffff:192.0.2.1")]                        //  embeded IPv4 address
    [InlineData("ffff:ffff:ffff:ffff:ffff:ffff:ffff:ffff")]
    public void IpAddress_Constructor_WithIPv6Value_ReturnsSameValue(string ipV6Value)
    {
        var ipAddress = IpAddress.From(ipV6Value);

        Assert.Equal(ipV6Value, ipAddress.Value);
    }

    [Fact]
    public void IpAddress_Constructor_WithIPv6ValueWithLeadingZeroesInGroups_ReturnsValue()
    {
        var ipAddress = IpAddress.From("2001:0db8:85a3:0000:0000:8a2e:0370:7334");

        Assert.Equal("2001:db8:85a3::8a2e:370:7334", ipAddress.Value);
    }

    [Theory]
    [InlineData("2001:0db8:85a3:::8a2e:0370:7334")]             //  repeated colon
    [InlineData("2001:0db8:85a3:00000:0000:8a2e:0370:7334")]    //  extra zero
    [InlineData(":::")]                                         //  consecutive colons without filling
    [InlineData("gggg:0db8::1")]                                //  invalid characters
    public void IpAddress_Constructor_WithInvalidIPv6Value_ThrowsException(string ipV6Value)
    {
        var exception = Assert.Throws<TypeValidationException>(() => _ =
            IpAddress.From(ipV6Value)
        );

        Assert.Equal($"Could not create a Nox IP Address type as value {ipV6Value} is not a valid IP Address.", exception.Errors.First().ErrorMessage);
    }

    [Theory]
    [InlineData("192.0.2.1")]
    [InlineData("2001:db8:85a3::8a2e:370:7334")]
    public void IpAddress_ToString_ReturnsValue(string value)
    {
        void Test()
        {
            var ipAddress = IpAddress.From(value);

            Assert.Equal(value, ipAddress.ToString());
        }

        TestUtility.RunInInvariantCulture(Test);
    }
}