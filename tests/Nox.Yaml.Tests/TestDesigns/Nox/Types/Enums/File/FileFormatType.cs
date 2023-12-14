namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;

/// <summary>
/// Enumeration for file format types.
/// </summary>
public enum FileFormatType
{
    /// <summary>
    /// Represents all file format types.
    /// </summary>
    All,

    /// <summary>
    /// Represents the PDF file format type.
    /// </summary>
    Pdf,

    /// <summary>
    /// Represents the TXT file format type.
    /// </summary>
    Txt,

    /// <summary>
    /// Represents the XLS file format type.
    /// </summary>
    Xls,

    /// <summary>
    /// Represents the XLSX file format type.
    /// </summary>
    Xlsx,

    /// <summary>
    /// Represents the DOC file format type.
    /// </summary>
    Doc,

    /// <summary>
    /// Represents the DOCX file format type.
    /// </summary>
    Docx,

    /// <summary>
    /// Represents the CSV file format type.
    /// </summary>
    Csv,

    /// <summary>
    /// Represents the PPT file format type.
    /// </summary>
    Ppt,

    /// <summary>
    /// Represents the PPTX file format type.
    /// </summary>
    Pptx,
    /// <summary>
    /// Represents the EML file format type.
    /// </summary>
    Eml,
}

public static class FileFormatTypeExtensions
{
    public static IReadOnlyList<string> GetExtensions(this FileFormatType fileFormatType)
    {
        if (fileFormatType == FileFormatType.All)
        {
            var allEnums = Enum.GetValues(typeof(FileFormatType))
                .Cast<FileFormatType>()
                .Except(new List<FileFormatType> { FileFormatType.All });

            return allEnums.SelectMany(x => x.GetExtensions()).ToList().AsReadOnly();
        }

        return fileFormatType switch
        {
            FileFormatType.Pdf => new List<string> { ".pdf" },
            FileFormatType.Txt => new List<string> { ".txt" },
            FileFormatType.Xls => new List<string> { ".xls" },
            FileFormatType.Xlsx => new List<string> { ".xlsx" },
            FileFormatType.Doc => new List<string> { ".doc" },
            FileFormatType.Docx => new List<string> { ".docx" },
            FileFormatType.Csv => new List<string> { ".csv" },
            FileFormatType.Ppt => new List<string> { ".ppt" },
            FileFormatType.Pptx => new List<string> { ".pptx" },
            FileFormatType.Eml => new List<string> { ".eml" },
            _ => throw new NotImplementedException(),
        };
    }
}