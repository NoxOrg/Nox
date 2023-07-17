using FluentAssertions;

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
        image.Url.Should().Be(url);
        image.PrettyName.Should().Be(prettyName);
        image.SizeInBytes.Should().Be(size);
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
        exception.Should().NotBeNull();
        exception.Errors.Should().HaveCount(1);
        exception.Errors[0].ErrorMessage.Should().StartWith("Could not create a Nox Image type");
    }

    [Theory]
    [InlineData("https://example.com/image.abc", "Image1", 100)]
    public void Image_WithInvalidUrlExtension_ShouldBeInvalid(string url, string prettyName, int size)
    {
        // Arrange & Act
        var exception = Assert.Throws<TypeValidationException>(() => _ = Image.From(url, prettyName, size));

        // Assert
        exception.Should().NotBeNull();
        exception.Errors.Should().HaveCount(1);
        exception.Errors[0].ErrorMessage.Should().Be($"Could not create a Nox Image type with an image having an unsupported extension '{url}'.");
    }

    [Fact]
    public void Image_WithInvalidUrl_ShouldBeInvalid()
    {
        // Arrange & Act
        var exception = Assert.Throws<TypeValidationException>(() => _ = Image.From("invalid url", "Image1", 100));

        // Assert
        exception.Should().NotBeNull();
        exception.Errors.Should().HaveCount(1);
        exception.Errors[0].ErrorMessage.Should().Be($"Could not create a Nox Image type with an invalid Url 'invalid url'.");
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
        var exception = Assert.Throws<TypeValidationException>(() =>
            _ = Image.From("https://example.com/image.png", "Image1", 100, imageTypeOptions));

        // Assert
        exception.Should().NotBeNull();
        exception.Errors.Should().HaveCount(1);
        exception.Errors[0].ErrorMessage.Should().Be($"Could not create a Nox Image type with an image having an unsupported extension 'https://example.com/image.png'.");
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
        image.Should().NotBeNull();
        image2.Should().NotBeNull();
    }

    [Fact]
    public void Compare_Same_Images_WithEqual_IsTrue()
    {
        // Arrange & Act
        var image1 = Image.From("https://example.com/image.jpg", "Image1", 100);
        var image2 = Image.From("https://example.com/image.jpg", "Image1", 100);

        // Assert
        image1.Should().Be(image2);
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
        image1.Should().NotBe(image2);
        image1.Should().NotBe(image3);
        image1.Should().NotBe(image4);
    }

    [Fact]
    public void ToString_WithValidValues_ShouldReturnString()
    {
        // Arrange & Act
        var image = Image.From("https://example.com/image.jpg", "Image1", 100);

        // Assert
        image.ToString().Should().Be("Image1: https://example.com/image.jpg");
    }

    [Fact]
    public void GetImageExtension_WithValidValues_ShouldReturnString()
    {
        // Arrange & Act
        var image = Image.From("https://example.com/image.jpg", "Image1", 100);

        // Assert
        image.GetImageExtension().Should().Be(".jpg");
    }
}