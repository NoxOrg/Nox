namespace Nox.Types.Tests.Types;

using Nox.Common;
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
        imageFormatType.Value.Should().BeEquivalentTo(expectedValue);
    }

    // Add similar tests for the other ImageFormatType instances like Jpeg, Png, Gif, etc.

    [Fact]
    public void FromId_ExistingId_ShouldReturnCorrectImageFormatType()
    {
        // Arrange
        var expectedImageFormatType = ImageFormatType.Jpeg;
        var id = 1;

        // Act
        var result = Enumeration<IList<string>>.FromId<ImageFormatType>(id);

        // Assert
        result.Should().Be(expectedImageFormatType);
    }

    [Fact]
    public void FromId_NonExistingId_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var id = 99;

        // Act & Assert
        FluentActions.Invoking(() => Enumeration<IList<string>>.FromId<ImageFormatType>(id))
            .Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void FromName_ExistingName_ShouldReturnCorrectImageFormatType()
    {
        // Arrange
        var expectedImageFormatType = ImageFormatType.Png;
        var name = "Png";

        // Act
        var result = Enumeration<IList<string>>.FromName<ImageFormatType>(name);

        // Assert
        result.Should().Be(expectedImageFormatType);
    }

    [Fact]
    public void FromName_NonExistingName_ShouldThrowInvalidOperationException()
    {
        // Arrange
        var name = "InvalidName";

        // Act & Assert
        FluentActions.Invoking(() => Enumeration<IList<string>>.FromName<ImageFormatType>(name))
            .Should().Throw<InvalidOperationException>();
    }

    [Fact]
    public void GetAll_ShouldReturnAllImageFormatTypes()
    {
        // Arrange
        var expectedImageFormatTypesCount = 10;

        // Act
        var result = Enumeration<IList<string>>.GetAll<ImageFormatType>();

        // Assert
        result.Should().HaveCount(expectedImageFormatTypesCount);
    }
}
