using FluentAssertions;
using Nox.Yaml.Enums.CultureCode;

namespace Nox.Types.Tests.Types;


public class CultureCodeTests
{
    [Theory]
    [InlineData("en")]
    [InlineData("tr-TR")]
    [InlineData("az-Latn-AZ")]
    public void CreateCulture_FromValidCultureCode_ShouldNotBeNull(string cultureCode)
    {
        // Act
        var culture = CultureCode.From(cultureCode);

        // Assert
        culture.Should().NotBeNull();
    }
    
    [Theory]
    [InlineData(Culture.en)]
    [InlineData(Culture.tr_TR)]
    [InlineData(Culture.az_Latn_AZ)]
    public void CreateCultureCode_FromValidCulture_ShouldNotBeNull(Culture culture)
    {
        // Act
        var cultureCode = CultureCode.From(culture);

        // Assert
        cultureCode.Should().NotBeNull();
    }
    
    [Theory]
    [InlineData((Culture)(-1))]
    [InlineData((Culture)(5000))]
    public void CreateCulture_FromInvalidCulture_ShouldThrowNoxTypeValidationException(Culture culture)
    {
        // Arrange & Act
        var action = () => CultureCode.From(culture);

        // Assert
        action.Should().Throw<NoxTypeValidationException>()
              .WithMessage($"The Nox type validation failed with 1 error(s). PropertyName: Value. Error: Could not create a Nox CultureCode type with unsupported value '{culture}'.");
    }

    [Theory]
    [InlineData("eng")]
    [InlineData("tR")]
    [InlineData("Sr-Sp")]
    [InlineData("sr-SP-CYRL")]
    [InlineData("invalid")]
    public void CreateCulture_FromInvalidCultureCode_ShouldThrowNoxTypeValidationException(string cultureCode)
    {
        // Arrange & Act
        var action = () => CultureCode.From(cultureCode);

        // Assert
        action.Should().Throw<NoxTypeValidationException>()
              .WithMessage($"The Nox type validation failed with 1 error(s). PropertyName: Value. Error: Could not create a Nox CultureCode type with unsupported value '{cultureCode}'.");
    }
    
    [Fact]
    public void TryCreateCulture_FromValidInput_ShouldSucceed()
    {
        // Arrange & Act
        var result = CultureCode.TryFrom("tr-TR", out var culture);

        // Assert
        result.IsValid.Should().BeTrue();
        culture!.Value.Should().Be("tr-TR");
    }
    
    [Fact]
    public void TryCreateCulture_FromInvalidInput_ShouldFail()
    {
        // Arrange & Act
        var result = CultureCode.TryFrom("aaaa", out var culture);

        // Assert
        result.IsValid.Should().BeFalse();
        culture.Should().BeNull();
    }
    
    [Fact]
    public void CompareEqualCultures_ShouldBeEqual()
    {
        // Arrange & Act
        var culture1 = CultureCode.From("tr-TR");
        var culture2 =  CultureCode.From("tr-TR");

        // Assert
        culture1.Should().BeEquivalentTo(culture2);
    }
    
    [Fact]
    public void CompareUnequalCultures_ShouldNotBeEqual()
    {
        // Arrange & Act
        var culture1 = CultureCode.From("tr-TR");
        var culture2 =  CultureCode.From("en-US");

        // Assert
        culture1.Should().NotBeEquivalentTo(culture2);
    }
    
    [Fact]
    public void ToStringOnCulture_ShouldReturnCorrectString()
    {
        // Arrange & Act
        var culture = CultureCode.From("tr-TR");

        // Assert
        culture.ToString().Should().Be("tr-TR");
    }
}
