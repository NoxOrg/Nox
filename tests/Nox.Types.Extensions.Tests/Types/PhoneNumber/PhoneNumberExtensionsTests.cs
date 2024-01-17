using FluentAssertions;

namespace Nox.Types.Extensions.Tests.Types;

public class PhoneNumberExtensionsTests: WorldTestBase
{
    [Theory]
    [InlineData("+14842989019", "US", false)]
    [InlineData("+380965370001", "UA", true)]
    [InlineData("+902124737373", "TR", false)] 
    [InlineData("+905325320000", "TR", true)] 
    public void GetReferencePhoneNumberInfo(string inputPhoneNumber, string region, bool isMobile)
    {
        var phoneNumber =PhoneNumber.From(inputPhoneNumber);
        var phoneNumberInfo = phoneNumber.GetReferencePhoneNumberInfo();
        
        
        phoneNumberInfo.Should().NotBeNull();
        phoneNumberInfo.RegionCode.Should().Be(region);
        phoneNumberInfo.IsMobile.Should().Be(isMobile);
        
    }
}