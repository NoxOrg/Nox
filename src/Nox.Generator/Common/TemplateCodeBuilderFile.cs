using Nox.Solution;
using System;
using System.IO;
using System.Text;

namespace Nox.Generator.Common;

internal class TemplateCodeBuilderFile : TemplateCodeBuilderBase
{
    private const string _outputFolder = "Nox.Generated";

    private string? _fileExtension;

    private string _outputPath;

    public TemplateCodeBuilderFile(NoxSolutionCodeGeneratorState codeGeneratorState, string outputPath)
        : base (codeGeneratorState)
    {
        _outputPath = outputPath;
    }

    /// <summary>
    /// Oprional extension to the generated file, otherwise .g.cs will be used
    /// </summary>
    /// <param name="fileExtension">Prefix to add to the file name. A dot will be added between the prefix and the class name</param>
    /// <returns></returns>
    public TemplateCodeBuilderFile WithFileExtension(string fileExtension)
    {
        _fileExtension = fileExtension;
        return this;
    }

    public override void SaveSourceCode(string fileName, string sourceCode)
    {
#pragma warning disable RS1035 // Do not use APIs banned for analyzers

        string absoluteFilePath = Path.Combine(_outputPath, _outputFolder, $"{fileName}.g.{_fileExtension}");

        FileInfo file = new FileInfo(absoluteFilePath);
        file.Directory.Create(); // If the directory already exists, this method does nothing.

        File.WriteAllText(absoluteFilePath, sourceCode, Encoding.UTF8);

#pragma warning restore RS1035 // Do not use APIs banned for analyzers
    }
}