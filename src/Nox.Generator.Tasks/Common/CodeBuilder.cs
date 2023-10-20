using System.IO;
using System.Text;

namespace Nox.Generator.Tasks.Common;

internal class CodeBuilder 
{
    private const int _spacing = 4;
    
    private readonly string _sourceFileName;

    private readonly string _outputPath;

    private readonly StringBuilder _stringBuilder;

    private int _indentation = 0;

    public CodeBuilder(string sourceFileName, string outputPath)
    {
        _sourceFileName = sourceFileName;
        _outputPath = outputPath;

        _stringBuilder = new StringBuilder();

        _stringBuilder.AppendLine("// Generated");
        _stringBuilder.AppendLine();
        _stringBuilder.AppendLine("#nullable enable");
        _stringBuilder.AppendLine();
    }

    public void AppendLine(string text = "")
    {
        _stringBuilder.Append(new string(' ', _spacing * _indentation));
        _stringBuilder.AppendLine(text);
    }
    public void AppendLines(string[] strings)
    {
        for (int i = 0; i <  strings.Length; i++)
        {
            AppendLine(strings[i]);
        }
    }
    public void AppendIndented(string text = "")
    {
        _stringBuilder.Append(new string(' ', _spacing * _indentation));
        _stringBuilder.Append(text);
    }

    public void Append(string text = "")
    {
        _stringBuilder.Append(text);
    }

    public void StartBlock()
    {
        AppendLine($"{{");
        Indent();
    }

    public void EndBlock()
    {
        UnIndent();
        AppendLine($"}}");
    }

    public void EndBlockWithBracket()
    {
        UnIndent();
        AppendLine($"}});");
    }

    public override string ToString()
    {
        return _stringBuilder.ToString();
    }

    public int Indent()
    {
        _indentation++;

        return _spacing * _indentation;
    }

    public int UnIndent()
    {
        _indentation--;

        return _spacing * _indentation;
    }

    public int CurrentIndentSpacing()
    {
        return _spacing * _indentation;
    }

    public void GenerateSourceCode()
    {
        string absoluteFilePath = Path.Combine(_outputPath, _sourceFileName);

        FileInfo file = new FileInfo(absoluteFilePath);
        file.Directory.Create(); // If the directory already exists, this method does nothing.

        File.WriteAllText(absoluteFilePath, _stringBuilder.ToString(), Encoding.UTF8);
    }    
}
