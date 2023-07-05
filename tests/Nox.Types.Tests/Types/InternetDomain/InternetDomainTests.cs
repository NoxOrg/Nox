// ReSharper disable once CheckNamespace
namespace Nox.Types.Tests.Types;

public class InternetDomainTests
{
    [Theory]
    [InlineData("example.com")]
    [InlineData("example.org")]
    [InlineData("example1.net")]
    [InlineData("example.co.uk")]
    [InlineData("example.com.au")]
    public void InternetDomain_WithValidDomain_ShouldBeValid(string validDomain)
    {
       
        // Arrange & Act
        var internetDomain = InternetDomain.From(validDomain);

        // Assert
        Assert.NotNull(internetDomain);
        Assert.Equal(validDomain, internetDomain.Value);
    }

    [Theory] 
    [InlineData(null)]
    [InlineData("")]
    public void InternetDomain_WithNullOrEmptyDomain_ShouldBeInvalid(string invalidDomain)
    {
        // Arrange & Act
        var exception = Assert.Throws<TypeValidationException> (() => _ = InternetDomain.From(invalidDomain));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal("Could not create a Nox InternetDomain type with an empty value.", exception.Errors.First().ErrorMessage);
        
    }
    
    
    [Theory] 
    [InlineData("example")]
    [InlineData("example.123")]
    [InlineData("example.org.1234")]
    [InlineData("https://example.com")]
    [InlineData("https://www.example.com")]
    public void InternetDomain_WithInvalidDomain_ShouldBeInvalid(string invalidDomain)
    {
        // Arrange & Act
        var exception = Assert.Throws<TypeValidationException>(() => _ = InternetDomain.From(invalidDomain));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal($"Could not create a Nox InternetDomain type with unsupported value '{invalidDomain}'.", exception.Errors.First().ErrorMessage);
    }
    
    [Fact]
    public void Compare_Same_InternetDomains_WithEqual_IsTrue()
    {
        // Arrange & Act
        var internetDomain1 = InternetDomain.From("example.com");
        var internetDomain2 =  InternetDomain.From("example.com");

        // Assert
        Assert.Equal(internetDomain1, internetDomain2);
    }
    
    [Fact]
    public void Compare_Same_InternetDomains_WithEqual_IsFalse()
    {
        // Arrange & Act
        var internetDomain1 = InternetDomain.From("example.com");
        var internetDomain2 =  InternetDomain.From("example.org");

        // Assert
        Assert.NotEqual(internetDomain1, internetDomain2);
    }
}