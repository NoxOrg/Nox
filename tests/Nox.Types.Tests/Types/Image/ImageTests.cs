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
        Assert.Equal(size, image.SizeInBytes);
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
        Assert.Equal($"Could not create a Nox Image type with an image having an unsupported extension '{url}'.", exception.Errors[0].ErrorMessage);
    }
    
    [Fact]
    public void Image_WithInvalidUrl_ShouldBeInvalid()
    {
        // Arrange & Act
        var exception = Assert.Throws<TypeValidationException>(() => _ = Image.From("invalid url", "Image1", 100));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal($"Could not create a Nox Image type with an invalid Url 'invalid url'.", exception.Errors[0].ErrorMessage);
    }
    
    [Fact]
    public void Image_With_Unsupported_Extension_ShouldBeInvalid()
    {
        // Arrange &
        
        var imageTypeOptions = new ImageTypeOptions
        {
            ImageFormatTypes = new List<ImageFormatType> { ImageFormatType.Jpeg, ImageFormatType.Bmp }
        };
        // Act
        var exception = Assert.Throws<TypeValidationException>(() => _ = Image.From("https://example.com/image.png", "Image1", 100, imageTypeOptions));

        // Assert
        Assert.NotNull(exception);
        Assert.Equal($"Could not create a Nox Image type with an image having an unsupported extension 'https://example.com/image.png'.", exception.Errors[0].ErrorMessage);
    }
    
    [Fact]
    public void Image_With_Supported_Extension_ShouldBeValid()
    {
        // Arrange &
        
        var imageTypeOptions = new ImageTypeOptions
        {
            ImageFormatTypes = new() { ImageFormatType.Jpeg, ImageFormatType.Bmp }
        };
        // Act
        var image = Image.From("https://example.com/image.jpg", "Image1", 100, imageTypeOptions);
        var image2 = Image.From("https://example.com/image.bmp", "Image2", 100, imageTypeOptions);

        // Assert
        Assert.NotNull(image);
        Assert.NotNull(image2);
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
    
    [Fact]
    public void ToString_WithValidValues_ShouldReturnString()
    {

        // Arrange & Act
        var image = Image.From("https://example.com/image.jpg", "Image1", 100);

        // Assert
        Assert.Equal("Image1: https://example.com/image.jpg", image.ToString());
    }
    
    [Fact]
    public void GetImageExtension_WithValidValues_ShouldReturnString()
    {

        // Arrange & Act
        var image = Image.From("https://example.com/image.jpg", "Image1", 100);

        // Assert
        Assert.Equal(".jpg", image.GetImageExtension());
    }


    [Fact]
    public void Correct_ImageFormatType_ShouldReturn()
    {
        // Arrange & Act
        var imageFormatType = ImageFormatType.FromId<ImageFormatType>(0);
        
        // Assert
        Assert.Equal(ImageFormatType.All, imageFormatType);
    }
    
    [Fact]
    public void Correct_ImageFormatType_ShouldReturn_ByName()
    {
        // Arrange & Act
        var imageFormatType = ImageFormatType.FromName<ImageFormatType>("Bmp");
        
        // Assert
        Assert.Equal(ImageFormatType.Bmp, imageFormatType);
    }
}
