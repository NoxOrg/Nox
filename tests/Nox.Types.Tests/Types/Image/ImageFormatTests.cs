using Nox.Types.Extensions;

namespace Nox.Types.Tests.Types;

using FluentAssertions;
using Xunit;

public class ImageFormatTypeTests
{
    [Fact]
    public void ImageFormat_All_ShouldHaveCorrectExtensions()
    {
        // Arrange
        var expectedValue = new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp", ".svg", ".tiff", ".ico", ".tif" };

        // Act
        var imageFormatType = ImageFormatType.All;

        // Assert
    
        imageFormatType.SupportedExtensions().Should().BeEquivalentTo(expectedValue);
    }

    
    
    [Fact]
    public void ImageFormatType_Jpeg_ShouldHaveCorrectExtensions()
    {
        // Arrange
        var expectedValue = new List<string> { ".jpg", ".jpeg" };

        // Act
        var imageFormatType = ImageFormatType.Jpeg;

        // Assert
    
        imageFormatType.SupportedExtensions().Should().BeEquivalentTo(expectedValue);
    }
    
    [Fact]
    public void ImageFormatType_Png_ShouldHaveCorrectExtensions()
    {
        // Arrange
        var expectedValue = new List<string> { ".png" };

        // Act
        var imageFormatType = ImageFormatType.Png;

        // Assert
    
        imageFormatType.SupportedExtensions().Should().BeEquivalentTo(expectedValue);
    }
    
    [Fact]
    public void ImageFormatType_Bmp_ShouldHaveCorrectExtensions()
    {
        // Arrange
        var expectedValue = new List<string> { ".bmp" };

        // Act
        var imageFormatType = ImageFormatType.Bmp;

        // Assert
    
        imageFormatType.SupportedExtensions().Should().BeEquivalentTo(expectedValue);
    }
    
    [Fact]
    public void ImageFormatType_Wepb_ShouldHaveCorrectExtensions()
    {
        // Arrange
        var expectedValue = new List<string> { ".webp" };

        // Act
        var imageFormatType = ImageFormatType.Webp;

        // Assert
    
        imageFormatType.SupportedExtensions().Should().BeEquivalentTo(expectedValue);
    }
    
    [Fact]
    public void ImageFormatType_Ico_ShouldHaveCorrectExtensions()
    {
        // Arrange
        var expectedValue = new List<string> { ".ico" };

        // Act
        var imageFormatType = ImageFormatType.Ico;

        // Assert
    
        imageFormatType.SupportedExtensions().Should().BeEquivalentTo(expectedValue);
    }
    
    [Fact]
    public void ImageFormatType_Tiff_ShouldHaveCorrectExtensions()
    {
        // Arrange
        var expectedValue = new List<string> { ".tiff", ".tif" };

        // Act
        var imageFormatType = ImageFormatType.Tiff;

        // Assert
    
        imageFormatType.SupportedExtensions().Should().BeEquivalentTo(expectedValue);
    }
    
    [Fact]
    public void ImageFormatType_Svg_ShouldHaveCorrectExtensions()
    {
        // Arrange
        var expectedValue = new List<string> { ".svg" };

        // Act
        var imageFormatType = ImageFormatType.Svg;

        // Assert
    
        imageFormatType.SupportedExtensions().Should().BeEquivalentTo(expectedValue);
    }
    
    [Fact]
    public void ImageFormatType_Gif_ShouldHaveCorrectExtensions()
    {
        // Arrange
        var expectedValue = new List<string> { ".gif" };

        // Act
        var imageFormatType = ImageFormatType.Gif;

        // Assert
    
        imageFormatType.SupportedExtensions().Should().BeEquivalentTo(expectedValue);
    }

    [Fact]
    public void ListOf_ImageFormatType__ShouldHaveCorrectExtensions()
    {
        // Arrange
        var imageFormatTypes = new List<ImageFormatType> { ImageFormatType.Jpeg, ImageFormatType.Png };
        var expectedValue = new List<string> { ".jpg", ".jpeg", ".png" };
        
        // Act
        var imageFormatType = imageFormatTypes.SupportedExtensions();
        
        // Assert
        imageFormatType.Should().BeEquivalentTo(expectedValue);
    }
}
