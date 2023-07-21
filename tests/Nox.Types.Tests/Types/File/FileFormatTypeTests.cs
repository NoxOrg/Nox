using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class FileFormatTypeTests
{
    [Theory]
    [InlineData(FileFormatType.Pdf, new string[] { ".pdf" })]
    [InlineData(FileFormatType.Txt, new string[] { ".txt" })]
    [InlineData(FileFormatType.Xls, new string[] { ".xls" })]
    [InlineData(FileFormatType.Xlsx, new string[] { ".xlsx" })]
    [InlineData(FileFormatType.Doc, new string[] { ".doc" })]
    [InlineData(FileFormatType.Docx, new string[] { ".docx" })]
    [InlineData(FileFormatType.Csv, new string[] { ".csv" })]
    [InlineData(FileFormatType.Ppt, new string[] { ".ppt" })]
    [InlineData(FileFormatType.Pptx, new string[] { ".pptx" })]
    [InlineData(FileFormatType.Eml, new string[] { ".eml" })]
    public void GetExtensions_WithVariousFileFormatTypes_ReturnsValue(FileFormatType fileFormatType, string[] expectedExtensions)
    {
        fileFormatType.GetExtensions().Should().BeEquivalentTo(expectedExtensions);
    }

    [Fact]
    public void GetExtensions_WithAllFileFormatType_ReturnsAllExtensions()
    {
        FileFormatType.All.GetExtensions().Should()
            .BeEquivalentTo(".pdf", ".txt", ".xls", ".xlsx", ".doc", ".docx", ".csv", ".ppt", ".pptx", ".eml");
    }
}
