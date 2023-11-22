// ReSharper disable once CheckNamespace
using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class FileTests
{
    [Theory]
    [InlineData("https://example.com/file.pdf", "MyPdfFile", 1024)]
    [InlineData("https://example.com/file.csv?x=y", "MyPdfFile2", 2048)]
    public void From_WithTupleInputType_ShouldReturnValue(string url, string prettyName, ulong sizeInBytes)
    {
        var file = File.From((url, prettyName, sizeInBytes));

        file.Value.Url.Should().Be(url);
        file.Value.PrettyName.Should().Be(prettyName);
        file.Value.SizeInBytes.Should().Be(sizeInBytes);
    }

    [Theory]
    [InlineData("https://example.com/file.pdf", "MyPdfFile", 1024)]
    [InlineData("https://example.com/file.csv?x=y", "MyPdfFile2", 2048)]
    public void From_WithIndividualInputs_ShouldReturnValue(string url, string prettyName, ulong sizeInBytes)
    {
        var file = File.From(url, prettyName, sizeInBytes);

        file.Value.Url.Should().Be(url);
        file.Value.PrettyName.Should().Be(prettyName);
        file.Value.SizeInBytes.Should().Be(sizeInBytes);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void From_WithMissingUrl_ShouldThrowValidationException(string? url)
    {
        var action = () => File.From(url!, "MyFile", 512);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Url", "Could not create a Nox File type with an empty Url.") });
    }

    [Fact]
    public void From_WithUrlLongerThanMaxAllowed_ShouldThrowValidationException()
    {
        var action = () => File.From($"https://www.example.com/{new string('a', 2050)}/file1.pdf", "File1", 100);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Url", "Could not create a Nox File type with an Url length greater than max allowed length of 2083.") });
    }

    [Fact]
    public void From_WithInvalidUrl_ShouldThrowValidationException()
    {
        var action = () => File.From("test", "MyFile", 512);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Url", "Could not create a Nox File type with an invalid Url 'test'.") });
    }

    [Theory]
    [InlineData("https://example.com/myfile.test", ".test")]
    [InlineData("https://example.com/myfile.txt", ".txt")]
    [InlineData("https://example.com/myfile.txt?a=b", ".txt")]
    public void From_WithUnsupportedFileExtension_ShouldThrowValidationException(string url, string expected)
    {
        var action = () => File.From(url, "MyFile", 512,
            new FileTypeOptions
            {
                SupportedFileFormats = new List<FileFormatType> { FileFormatType.Pdf, FileFormatType.Docx }
            });

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Url", $"Could not create a Nox File type with a file having an unsupported extension '{expected}'.") });
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" ")]
    public void From_WithMissingPrettyname_ShouldThrowValidationException(string? prettyName)
    {
        var action = () => File.From("https://example.com/myfile.pdf", prettyName!, 512);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("PrettyName", "Could not create a Nox File type with an empty PrettyName.") });
    }

    [Fact]
    public void From_WithPrettyNameLongerThanMaxAllowed_ShouldThrowValidationException()
    {
        var action = () => File.From("https://example.com/myfile.pdf", new string('a', 512), 100);

        action.Should().Throw<NoxTypeValidationException>()
            .And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("PrettyName", "Could not create a Nox File type with a PrettyName length greater than max allowed length of 511.") });
    }

    [Theory]
    [InlineData("https://example.com/file.pdf", "MyPdfFile", 1024)]
    [InlineData("https://example.com/file.csv?x=y", "MyPdfFile2", 2048)]
    public void UrlPrettyNameSizeInBytesProperties_WithValidObject_ShouldReturnValue(string url, string prettyName, ulong sizeInBytes)
    {
        var file = File.From(url, prettyName, sizeInBytes);

        file.Url.Should().Be(url);
        file.PrettyName.Should().Be(prettyName);
        file.SizeInBytes.Should().Be(sizeInBytes);
    }

    [Theory]
    [InlineData("https://example/test/myfile.pdf", ".pdf")]
    [InlineData("https://example/test/myfile.pdf?a=b", ".pdf")]
    [InlineData("https://example/test/myfile.csv?a=b&c=d", ".csv")]
    [InlineData("https://example/test/myfile.CSV?a=b&c=d", ".csv")]
    [InlineData("https://example/test/myfile.txt", ".txt")]
    [InlineData("https://example.com/test/myfile.txt", ".txt")]
    [InlineData("https://azurestoragetestcontent.blob.core.windows.net/efiles/2023/07/10/72944bf2-591d-4f00-ad26-35ffbd7384e5/Card%20Transaction%20Confirmation%20emailDT_9291ccb26ff748cab2e8ebee8c6ee318_20210920.15.02.41.498.eml?sv=2017-11-09&sr=b&sig=v5Ve3fQeWJzLG8x%2Fe5qNVZtwPsML9XzJjQoiRnhG1i0%3D&se=2023-07-13T14%3A47%3A12Z&sp=r", ".eml")]
    public void GetFileExtension_WithVariousUrls_ReturnsExtension(string url, string expected)
    {
        var file = File.From(url, "MyFile", 1024);

        file.GetFileExtension().Should().Be(expected);
    }

    [Fact]
    public void ToString_WithValidObject_ReturnsString()
    {
        var file = File.From("https://exmaple.com/myfile.txt", "MyFile", 1024);

        file.ToString().Should().Be("MyFile: https://exmaple.com/myfile.txt");
    }
}