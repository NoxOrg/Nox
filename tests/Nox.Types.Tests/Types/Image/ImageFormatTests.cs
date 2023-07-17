using Microsoft.Extensions.Primitives;

namespace Nox.Types.Tests.Types;

using Nox.Types.Common;
using FluentAssertions;
using Xunit;

public class ImageFormatTests
{
    [Fact]
    public void ImageFormat_All_ShouldHaveCorrectIdAndNameAndValue()
    {
        // Arrange
        var expectedId = 0;
        var expectedName = "All";
        var expectedValue = new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp", ".svg", ".tiff", ".ico", ".tif" };

        // Act
        var imageFormat = ImageFormat.All;

        // Assert
        imageFormat.Id.Should().Be(expectedId);
        imageFormat.Name.Should().Be(expectedName);
        imageFormat.Extensions.Should().BeEquivalentTo(expectedValue);
    }

    
    
    [Fact]
    public void ImageFormat_FromId_ShouldReturn_Jpeg()
    {
        // Arrange
        var expectedImageFormat = ImageFormat.Jpeg;
        var expectedId = 1;
        var expectedName = "Jpeg";
        var expectedExtensions = new List<string> { ".jpg", ".jpeg" };
        var id = 1;

        // Act
        var result = Enumeration.FromId<ImageFormat>(id);

        // Assert
        result.Should().Be(expectedImageFormat);
        result.Extensions.Should().BeEquivalentTo(expectedExtensions);
        result.Id.Should().Be(expectedId);
        result.Name.Should().Be(expectedName);
        
    }
    
    [Fact]
    public void ImageFormat_FromId_ShouldReturn_Png()
    {
        // Arrange
        var expectedImageFormat = ImageFormat.Png;
        var expectedId = 2;
        var expectedName = "Png";
        var expectedExtensions = new List<string> { ".png" };
        var id = 2;

        // Act
        var result = Enumeration.FromId<ImageFormat>(id);

        // Assert
        result.Should().Be(expectedImageFormat);
        result.Extensions.Should().BeEquivalentTo(expectedExtensions);
        result.Id.Should().Be(expectedId);
        result.Name.Should().Be(expectedName);
        
    }
    
    [Fact]
    public void ImageFormat_FromId_ShouldReturn_Gif()
    {
        // Arrange
        var expectedImageFormat = ImageFormat.Gif;
        var expectedId = 3;
        var expectedName = "Gif";
        var expectedExtensions = new List<string> { ".gif" };
        var id = 3;

        // Act
        var result = Enumeration.FromId<ImageFormat>(id);

        // Assert
        result.Should().Be(expectedImageFormat);
        result.Extensions.Should().BeEquivalentTo(expectedExtensions);
        result.Id.Should().Be(expectedId);
        result.Name.Should().Be(expectedName);
        
    }
    
    [Fact]
    public void ImageFormat_FromId_ShouldReturn_Bmp()
    {
        // Arrange
        var expectedImageFormat = ImageFormat.Bmp;
        var expectedId = 4;
        var expectedName = "Bmp";
        var expectedExtensions = new List<string> { ".bmp" };
        var id = 4;

        // Act
        var result = Enumeration.FromId<ImageFormat>(id);

        // Assert
        result.Should().Be(expectedImageFormat);
        result.Extensions.Should().BeEquivalentTo(expectedExtensions);
        result.Id.Should().Be(expectedId);
        result.Name.Should().Be(expectedName);
        
    }
    
    [Fact]
    public void ImageFormat_FromId_ShouldReturn_Webp()
    {
        // Arrange
        var expectedImageFormat = ImageFormat.Webp;
        var expectedId = 5;
        var expectedName = "Webp";
        var expectedExtensions = new List<string> { ".webp" };
        var id = 5;

        // Act
        var result = Enumeration.FromId<ImageFormat>(id);

        // Assert
        result.Should().Be(expectedImageFormat);
        result.Extensions.Should().BeEquivalentTo(expectedExtensions);
        result.Id.Should().Be(expectedId);
        result.Name.Should().Be(expectedName);
        
    }
    
    [Fact]
    public void ImageFormat_FromId_ShouldReturn_Svg()
    {
        // Arrange
        var expectedImageFormat = ImageFormat.Svg;
        var expectedId = 6;
        var expectedName = "Svg";
        var expectedExtensions = new List<string> { ".svg" };
        var id = 6;

        // Act
        var result = Enumeration.FromId<ImageFormat>(id);

        // Assert
        result.Should().Be(expectedImageFormat);
        result.Extensions.Should().BeEquivalentTo(expectedExtensions);
        result.Id.Should().Be(expectedId);
        result.Name.Should().Be(expectedName);
        
    }
    
    [Fact]
    public void ImageFormat_FromId_ShouldReturn_Tiff()
    {
        // Arrange
        var expectedImageFormat = ImageFormat.Tiff;
        var expectedId = 7;
        var expectedName = "Tiff";
        var expectedExtensions = new List<string> { ".tiff", ".tif" };
        var id = 7;

        // Act
        var result = Enumeration.FromId<ImageFormat>(id);

        // Assert
        result.Should().Be(expectedImageFormat);
        result.Extensions.Should().BeEquivalentTo(expectedExtensions);
        result.Id.Should().Be(expectedId);
        result.Name.Should().Be(expectedName);
        
    }
    
    [Fact]
    public void ImageFormat_FromId_ShouldReturn_Ico()
    {
        // Arrange
        var expectedImageFormat = ImageFormat.Ico;
        var expectedId = 8;
        var expectedName = "Ico";
        var expectedExtensions = new List<string> { ".ico" };
        var id = 8;

        // Act
        var result = Enumeration.FromId<ImageFormat>(id);

        // Assert
        result.Should().Be(expectedImageFormat);
        result.Extensions.Should().BeEquivalentTo(expectedExtensions);
        result.Id.Should().Be(expectedId);
        result.Name.Should().Be(expectedName);
        
    }
    
    [Fact]
    public void FromId_NonExistingId_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var id = 99;

        // Act & Assert
        FluentActions.Invoking(() => Enumeration.FromId<ImageFormat>(id))
            .Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void FromName_ExistingName_ShouldReturnCorrectImageFormatType()
    {
        // Arrange
        var expectedImageFormatType = ImageFormat.Png;
        var name = "Png";

        // Act
        var result = Enumeration.FromName<ImageFormat>(name);

        // Assert
        result.Should().Be(expectedImageFormatType);
    }

    [Fact]
    public void FromName_NonExistingName_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var name = "InvalidName";

        // Act & Assert
        FluentActions.Invoking(() => Enumeration.FromName<ImageFormat>(name))
            .Should().Throw<InvalidOperationException>();
    }


    [Fact]
    public void All_ImageFormatType_Enum_ShouldMatch_CustomImageFormat()
    {
        // Arrange & Act & Assert
        foreach (var imageFormatType in System.Enum.GetValues<ImageFormatType>())
        {
            var imageFormat = Enumeration.FromId<ImageFormat>((int)imageFormatType);
            imageFormat.Id.Should().Be((int)imageFormatType);
            imageFormat.Name.Should().Be(imageFormatType.ToString());
        }
    }


    [Fact]
    public void All_ImageFormat_ShouldMatch_ImageFormatType_Enum()
    {
        // Arrange & Act & Assert
        foreach (var imageFormat in Enumeration.GetAll<ImageFormat>())
        {
            var imageFormatType = (ImageFormatType)imageFormat.Id;
            imageFormatType.ToString().Should().Be(imageFormat.Name);
        }
    }
}
