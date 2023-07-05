using FluentValidation;

namespace Nox.Types.Tests.Types;

using Xunit;

public class ImageTests
{
    [Theory]
    [InlineData("https://example.com/image.jpg", "Image1", 100)]
    [InlineData("https://example.com/image.png", "Image2", 200)]
    public void Image_WithValidValues_ShouldBeValid(string url, string prettyName, int size)
    {
        // Arrange & Act
        var image = Image.From(url, prettyName, size);

        // Assert
        Assert.Equal(url, image.Url);
        Assert.Equal(prettyName, image.PrettyName);
        Assert.Equal(size, image.Size);
    }

    [Theory]
    [InlineData("", "Image1", 100)]
    [InlineData("https://example.com/image.jpg", "", 200)]
    [InlineData("https://example.com/image.jpg", "Image1", 0)]
    public void Image_WithInvalidValues_ShouldBeInvalid(string url, string prettyName, int size)
    {
        // Arrange & Act
        var exception = Assert.Throws<TypeValidationException>(() => _ = Image.From(url, prettyName, size));

        // Assert
        Assert.NotNull(exception);
        Assert.Contains("Could not create a Nox Image type", exception.Errors[0].ErrorMessage);
    }

    [Theory]
    [InlineData("https://example.com/image.abc", "Image1", 100)]
    public void Image_WithInvalidUrlExtension_ShouldBeInvalid(string url, string prettyName, int size)
    {
        // Arrange & Act
        var exception = Assert.Throws<TypeValidationException>(() => _ = Image.From(url, prettyName, size));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal($"Could not create a Nox Image type with an image having an invalid extension '{url}'.", exception.Errors[0].ErrorMessage);
    }
    
    [Fact]
    public void Compare_Same_Images_WithEqual_IsTrue()
    {
        // Arrange & Act
        var image1 = Image.From("https://example.com/image.jpg", "Image1", 100);
        var image2 = Image.From("https://example.com/image.jpg", "Image1", 100);

        // Assert
        Assert.True(image1.Equals(image2));
    }
    
    
    [Fact]
    public void Compare_Different_Images_WithEqual_IsFalse()
    {
        // Arrange & Act
        var image1 = Image.From("https://example.com/image.jpg", "Image1", 100);
        var image2 = Image.From("https://example.com/image.jpg", "Image2", 100);
        var image3 = Image.From("https://example.com/image.jpg", "Image1", 200);
        var image4 = Image.From("https://example.com/image.png", "Image1", 100);

        // Assert
        Assert.False(image1.Equals(image2));
        Assert.False(image1.Equals(image3));
        Assert.False(image1.Equals(image4));
        
    }
    
}
