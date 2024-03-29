using FluentAssertions;

namespace Nox.Types.Tests.Types;

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

    [Fact]
    public void Image_WithEmptyUrl_ShouldBeInvalid()
    {
        // Arrange & Act
        var action = () => Image.From("", "Image1", 100);

        // Assert
        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Url", "Could not create a Nox Image type with an empty Url.") });
    }

    [Fact]
    public void Image_WithUrlLongerThanMaxAllowed_ShouldBeInvalid()
    {
        // Arrange & Act
        var action = () => Image.From($"https://www.example.com/{new string('a', 2050)}/image.jpg", "Image1", 100);

        // Assert
        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Url", "Could not create a Nox Image type with an Url length greater than max allowed length of 2083.") });
    }

    [Fact]
    public void Image_WithEmptyPrettyName_ShouldBeInvalid()
    {
        // Arrange & Act
        var action = () => Image.From("https://example.com/image.jpg", "", 100);

        // Assert
        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("PrettyName", "Could not create a Nox Image type with an empty PrettyName.") });
    }

    [Fact]
    public void Image_WithPrettyNameLongerThanMaxAllowed_ShouldBeInvalid()
    {
        // Arrange & Act
        var action = () => Image.From("https://example.com/image.jpg", new string('a', 512), 100);

        // Assert
        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("PrettyName", "Could not create a Nox Image type with a PrettyName length greater than max allowed length of 511.") });
    }

    [Fact]
    public void Image_WithZeroSizeInBytes_ShouldBeInvalid()
    {
        // Arrange & Act
        var action = () => Image.From("https://example.com/image.jpg", "Image1", 0);

        // Assert
        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("SizeInBytes", "Could not create a Nox Image type with a Size of 0.") });
    }

    [Theory]
    [InlineData("https://example.com/image.abc", "Image1", 100)]
    public void Image_WithInvalidUrlExtension_ShouldBeInvalid(string url, string prettyName, int size)
    {
        // Arrange & Act
        var action = () => Image.From(url, prettyName, size);

        // Assert
        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Url", $"Could not create a Nox Image type with an image having an unsupported extension '{url}'.") });
    }

    [Fact]
    public void Image_WithInvalidUrl_ShouldBeInvalid()
    {
        // Arrange & Act
        var action = () => Image.From("invalid url", "Image1", 100);

        // Assert
        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Url", "Could not create a Nox Image type with an invalid Url 'invalid url'.") });
    }

    [Fact]
    public void Image_With_Unsupported_Extension_ShouldBeInvalid()
    {
        // Arrange
        var imageTypeOptions = new ImageTypeOptions
        {
            ImageFormatTypes = new List<ImageFormatType> { ImageFormatType.Jpeg, ImageFormatType.Bmp }
        };

        // Act
        var action = () => Image.From("https://example.com/image.png", "Image1", 100, imageTypeOptions);

        // Assert
        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Url", "Could not create a Nox Image type with an image having an unsupported extension 'https://example.com/image.png'.") });
    }

    [Fact]
    public void Image_With_Supported_Extension_ShouldBeValid()
    {
        // Arrange
        var imageTypeOptions = new ImageTypeOptions
        {
            ImageFormatTypes = new List<ImageFormatType> { ImageFormatType.Jpeg, ImageFormatType.Bmp }
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