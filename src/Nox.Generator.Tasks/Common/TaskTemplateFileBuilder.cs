using Nox.Solution;
using System.IO;
using System.Text;

namespace Nox.Generator.Common;

/// <summary>
/// Template for file generation out of the Code Generators. Creating a file in the local project.
/// </summary>
internal class TaskTemplateFileBuilder : TemplateBuilderBase
{
    private string _fileExtension = "g.cs";

    private readonly string _absoluteOutputPath;

    public TaskTemplateFileBuilder(NoxCodeGenConventions codeGeneratorState, string absoluteOutputPath)
        : base (codeGeneratorState, "scriban-cs")
    {
        _absoluteOutputPath = absoluteOutputPath;
    }

    /// <summary>
    /// Optional extension to the generated file, otherwise .g.cs will be used
    /// </summary>
    /// <param name="fileExtension">Prefix to add to the file name. A dot will be added between the prefix and the class name</param>
    /// <returns></returns>
    public TaskTemplateFileBuilder WithFileExtension(string fileExtension)
    {
        _fileExtension = fileExtension;
        return this;
    }

    public override void SaveSourceCode(string fileName, string sourceCode)
    {
        string absoluteFilePath = Path.Combine(_absoluteOutputPath, $"{fileName}.{_fileExtension}");

        FileInfo file = new FileInfo(absoluteFilePath);
        file.Directory.Create(); // If the directory already exists, this method does nothing.

        File.WriteAllText(absoluteFilePath, sourceCode, Encoding.UTF8);
    }
}