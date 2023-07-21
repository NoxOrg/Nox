using System.Collections.Generic;
using System.Linq;

namespace Nox.Types;

public class FileTypeOptions
{
    public static IReadOnlyList<FileFormatType> DefaultSupportedFileFormats => new List<FileFormatType> { FileFormatType.All };
    public IReadOnlyList<FileFormatType> SupportedFileFormats { get; set; } = DefaultSupportedFileFormats;

    public IReadOnlyList<string> GetSupportedExtensions()
        => SupportedFileFormats.SelectMany(x => x.GetExtensions()).ToList().AsReadOnly();
}
