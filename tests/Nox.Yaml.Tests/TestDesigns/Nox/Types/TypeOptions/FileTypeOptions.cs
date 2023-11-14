using System.Collections.Generic;
using System.Linq;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

public class FileTypeOptions
{
    public static IReadOnlyList<FileFormatType> DefaultSupportedFileFormats => new List<FileFormatType> { FileFormatType.All };
    public IReadOnlyList<FileFormatType> SupportedFileFormats { get; set; } = DefaultSupportedFileFormats;

    public IReadOnlyList<string> GetSupportedExtensions()
        => SupportedFileFormats.SelectMany(x => x.GetExtensions()).ToList().AsReadOnly();
}
