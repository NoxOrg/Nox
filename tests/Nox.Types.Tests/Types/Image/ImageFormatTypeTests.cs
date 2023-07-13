namespace Nox.Types.Tests.Types;

using Nox.Types.Common;
using FluentAssertions;
using Xunit;

public class ImageFormatTypeTests
{
    [Fact]
    public void ImageFormatType_All_ShouldHaveCorrectIdAndNameAndValue()
    {
        // Arrange
        var expectedId = 0;
        var expectedName = "All";
        var expectedValue = new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".webp", ".svg", ".tiff", ".ico", ".tif" };

        // Act
        var imageFormatType = ImageFormatType.All;

        // Assert
        imageFormatType.Id.Should().Be(expectedId);
        imageFormatType.Name.Should().Be(expectedName);
        imageFormatType.Extensions.Should().BeEquivalentTo(expectedValue);
    }

    
    
    [Fact]
    public void ImageFormatType_FromId_ShouldReturn_Jpeg()
    {
        // Arrange
        var expectedImageFormatType = ImageFormatType.Jpeg;
        var expectedId = 1;
        var expectedName = "Jpeg";
        var expectedExtensions = new List<string> { ".jpg", ".jpeg" };
        var id = 1;

        // Act
        var result = Enumeration.FromId<ImageFormatType>(id);

        // Assert
        result.Should().Be(expectedImageFormatType);
        result.Extensions.Should().BeEquivalentTo(expectedExtensions);
        result.Id.Should().Be(expectedId);
        result.Name.Should().Be(expectedName);
        
    }
    
    [Fact]
    public void ImageFormatType_FromId_ShouldReturn_Png()
    {
        // Arrange
        var expectedImageFormatType = ImageFormatType.Png;
        var expectedId = 2;
        var expectedName = "Png";
        var expectedExtensions = new List<string> { ".png" };
        var id = 2;

        // Act
        var result = Enumeration.FromId<ImageFormatType>(id);

        // Assert
        result.Should().Be(expectedImageFormatType);
        result.Extensions.Should().BeEquivalentTo(expectedExtensions);
        result.Id.Should().Be(expectedId);
        result.Name.Should().Be(expectedName);
        
    }
    
    [Fact]
    public void ImageFormatType_FromId_ShouldReturn_Gif()
    {
        // Arrange
        var expectedImageFormatType = ImageFormatType.Gif;
        var expectedId = 3;
        var expectedName = "Gif";
        var expectedExtensions = new List<string> { ".gif" };
        var id = 3;

        // Act
        var result = Enumeration.FromId<ImageFormatType>(id);

        // Assert
        result.Should().Be(expectedImageFormatType);
        result.Extensions.Should().BeEquivalentTo(expectedExtensions);
        result.Id.Should().Be(expectedId);
        result.Name.Should().Be(expectedName);
        
    }
    
    [Fact]
    public void ImageFormatType_FromId_ShouldReturn_Bmp()
    {
        // Arrange
        var expectedImageFormatType = ImageFormatType.Bmp;
        var expectedId = 4;
        var expectedName = "Bmp";
        var expectedExtensions = new List<string> { ".bmp" };
        var id = 4;

        // Act
        var result = Enumeration.FromId<ImageFormatType>(id);

        // Assert
        result.Should().Be(expectedImageFormatType);
        result.Extensions.Should().BeEquivalentTo(expectedExtensions);
        result.Id.Should().Be(expectedId);
        result.Name.Should().Be(expectedName);
        
    }
    
    [Fact]
    public void ImageFormatType_FromId_ShouldReturn_Webp()
    {
        // Arrange
        var expectedImageFormatType = ImageFormatType.Webp;
        var expectedId = 5;
        var expectedName = "Webp";
        var expectedExtensions = new List<string> { ".webp" };
        var id = 5;

        // Act
        var result = Enumeration.FromId<ImageFormatType>(id);

        // Assert
        result.Should().Be(expectedImageFormatType);
        result.Extensions.Should().BeEquivalentTo(expectedExtensions);
        result.Id.Should().Be(expectedId);
        result.Name.Should().Be(expectedName);
        
    }
    
    [Fact]
    public void ImageFormatType_FromId_ShouldReturn_Svg()
    {
        // Arrange
        var expectedImageFormatType = ImageFormatType.Svg;
        var expectedId = 6;
        var expectedName = "Svg";
        var expectedExtensions = new List<string> { ".svg" };
        var id = 6;

        // Act
        var result = Enumeration.FromId<ImageFormatType>(id);

        // Assert
        result.Should().Be(expectedImageFormatType);
        result.Extensions.Should().BeEquivalentTo(expectedExtensions);
        result.Id.Should().Be(expectedId);
        result.Name.Should().Be(expectedName);
        
    }
    
    [Fact]
    public void ImageFormatType_FromId_ShouldReturn_Tiff()
    {
        // Arrange
        var expectedImageFormatType = ImageFormatType.Tiff;
        var expectedId = 7;
        var expectedName = "Tiff";
        var expectedExtensions = new List<string> { ".tiff", ".tif" };
        var id = 7;

        // Act
        var result = Enumeration.FromId<ImageFormatType>(id);

        // Assert
        result.Should().Be(expectedImageFormatType);
        result.Extensions.Should().BeEquivalentTo(expectedExtensions);
        result.Id.Should().Be(expectedId);
        result.Name.Should().Be(expectedName);
        
    }
    
    [Fact]
    public void ImageFormatType_FromId_ShouldReturn_Ico()
    {
        // Arrange
        var expectedImageFormatType = ImageFormatType.Ico;
        var expectedId = 8;
        var expectedName = "Ico";
        var expectedExtensions = new List<string> { ".ico" };
        var id = 8;

        // Act
        var result = Enumeration.FromId<ImageFormatType>(id);

        // Assert
        result.Should().Be(expectedImageFormatType);
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
        FluentActions.Invoking(() => Enumeration.FromId<ImageFormatType>(id))
            .Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void FromName_ExistingName_ShouldReturnCorrectImageFormatType()
    {
        // Arrange
        var expectedImageFormatType = ImageFormatType.Png;
        var name = "Png";

        // Act
        var result = Enumeration.FromName<ImageFormatType>(name);

        // Assert
        result.Should().Be(expectedImageFormatType);
    }

    [Fact]
    public void FromName_NonExistingName_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var name = "InvalidName";

        // Act & Assert
        FluentActions.Invoking(() => Enumeration.FromName<ImageFormatType>(name))
            .Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void GetAll_ShouldReturnAllImageFormatTypes()
    {
        // Arrange
        var expectedImageFormatTypesCount = 9;

        // Act
        var result = Enumeration.GetAll<ImageFormatType>();

        // Assert
        result.Should().HaveCount(expectedImageFormatTypesCount);
    }
}
