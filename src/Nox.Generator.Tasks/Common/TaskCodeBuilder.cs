using System.IO;
using System.Text;

namespace Nox.Generator.Common;

internal class TaskCodeBuilder : CodeBuilder
{
    private readonly string _outputPath;
    public TaskCodeBuilder(string sourceFileName, string outputPath): base(sourceFileName)
    {
        _outputPath = outputPath;
    }

    public override string ToString()
    {
        return _stringBuilder.ToString();
    }

    public override void GenerateSourceCode()
    {
        string absoluteFilePath = Path.Combine(_outputPath, _sourceFileName);

        FileInfo file = new FileInfo(absoluteFilePath);
        file.Directory.Create(); // If the directory already exists, this method does nothing.

        File.WriteAllText(absoluteFilePath, _stringBuilder.ToString(), Encoding.UTF8);
    }
}
