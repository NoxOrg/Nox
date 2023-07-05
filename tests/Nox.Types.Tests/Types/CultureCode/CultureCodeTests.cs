namespace Nox.Types.Tests.Types;

public class CultureCodeTests
{
    [Theory]
    [InlineData("en")]
    [InlineData("tr-TR")]
    [InlineData("az-AZ-Latn")]
    public void Culture_ValidCultureCode_ShouldBeAbleToCreate(string cultureCode)
    {
        // Act
        var culture = CultureCode.From(cultureCode);

        // Assert
        Assert.NotNull(culture);
       
    }

    [Theory]
    [InlineData("eng")]
    [InlineData("tR")]
    [InlineData("Sr-Sp")]
    [InlineData("sr-SP-CYRL")]
    [InlineData("invalid")]
    public void Culture_InvalidCultureCode_ShouldBeInvalid(string cultureCode)
    {
        
        // Arrange & Act
        var exception = Assert.Throws<TypeValidationException>(() => _ = CultureCode.From(cultureCode));

        // Assert
        Assert.Equal($"Could not create a Nox CultureCode type with unsupported value '{cultureCode}'.", exception.Errors.First().ErrorMessage);
    }
    
    [Fact]
    public void Culture_Equality_Tests()
    {
        // Arrange & Act
        var culture1 = CultureCode.From("tr-TR");
        var culture2 =  CultureCode.From("tr-TR");

        // Assert
        Assert.Equal(culture1, culture2);
    }
    
    [Fact]
    public void Culture_NotEqual_Tests()
    {
        // Arrange & Act
        var culture1 = CultureCode.From("tr-TR");
        var culture2 =  CultureCode.From("en-US");

        // Assert
        Assert.NotEqual(culture1, culture2);
    }
    
    [Fact]
    public void Culture_ToString_ReturnsString()
    {
        // Arrange & Act
        var culture = CultureCode.From("tr-TR");

        // Assert
        Assert.Equal("tr-TR", culture.ToString());
    }
}