using FluentAssertions;

namespace Nox.Types.Tests.Types
{
    public class CountryPostalCodeValidatorTests
    {
        [Theory]
        [InlineData("GB", "KT16 0RS", true)]
        [InlineData("GB", "4420-55", false)]
        public void WhenPostCodeIs_IsValidShouldBe(string countryCode, string postalCode, bool expectedResult)
        {
            CountryPostalCodeValidator.IsValid(countryCode, postalCode).Should().Be(expectedResult);
        }
    }
}
