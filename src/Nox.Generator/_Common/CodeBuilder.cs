using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Text;

namespace Nox.Generator;

internal class CodeBuilder 
{
    private const int _spacing = 4;
    
    private readonly string _sourceFileName;

    private readonly StringBuilder _stringBuilder;

    private int _indentation = 0;

    private readonly SourceProductionContext _context;

    public CodeBuilder(string sourceFileName, SourceProductionContext context)
    {
        _sourceFileName = sourceFileName;

        _stringBuilder = new StringBuilder();

        _context = context;

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
        _context.AddSource(_sourceFileName, SourceText.From(_stringBuilder.ToString(), Encoding.UTF8));
    }
}
