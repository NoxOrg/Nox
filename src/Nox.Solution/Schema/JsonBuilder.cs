using System.Collections.Generic;
using System.Linq;
using System.Text;
using YamlDotNet.Core.Tokens;

namespace Nox.Solution.Schema;

internal class JsonBuilder
{
    private const int _spacing = 2;

    private readonly StringBuilder _stringBuilder;

    private int _indentation = 0;

    public JsonBuilder()
    {
        _stringBuilder = new StringBuilder();
    }

    public void AppendLine(string text = "")
    {
        _stringBuilder.Append(new string(' ', _spacing * _indentation));
        _stringBuilder.AppendLine(text);
    }

    public void AppendProperty(string name, string value) 
    {
        AppendLine($"{ToJson(name)}: {ToJson(value)},");
    }

    public void AppendProperty(string name, bool value)
    {
        AppendLine($"{ToJson(name)}: {ToJson(value)},");
    }

    public void AppendProperty(string name, object value)
    {
        AppendIndented($"{ToJson(name)}: ");
        StartBlock();
        var props = value.GetType().GetProperties();
        foreach (var prop in props) 
        {
            var propValue = prop.GetValue(value)?.ToString() ?? string.Empty;
            AppendProperty(prop.Name, propValue);
        }
        EndBlock();
    }

    public void AppendProperty(string name, string[] values)
    {
        AppendProperty(name, values.ToList());
    }


    public void AppendProperty(string name, List<string> values)
    {
        AppendLine($"{ToJson(name)}: [");
        Indent();
        foreach (var value in values) 
        { 
            AppendLine($"{ToJson(value)},");
        }
        RemoveTrailingCommas();
        UnIndent();
        AppendLine($"],");
    }

    public void AppendLines(string[] lines)
    {
        for (int i = 0; i < lines.Length; i++)
        {
            AppendLine(lines[i]);
        }
    }

    public void AppendLines(string text, bool writeFirstLineOutdented = true)
    {
        var lines = text.Replace("\r", "").Split('\n').Where(l => !string.IsNullOrWhiteSpace(l)).ToList();

        if(writeFirstLineOutdented && lines.Count > 0) 
        {
            Append(lines[0]);
            AppendLine();
            lines.RemoveAt(0);
        }

        AppendLines(lines.ToArray());
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
        RemoveTrailingCommas();
        UnIndent();
        AppendLine($"}}");
    }

    public void RemoveTrailingCommas()
    {
        int i = _stringBuilder.Length - 1;
        for (; i >= 0; i--)
        {
            if (!char.IsWhiteSpace(_stringBuilder[i]))
                break;
        }

        while (_stringBuilder[i] == ',')
        {
            _stringBuilder.Remove(i, 1);
            i--;
        }
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

    public string Build()
    {
        return _stringBuilder.ToString() ;
    }

    private static string ToJson(bool input)
    {
        return input.ToString().ToLowerInvariant();
    }

    private static string ToJson(string input)
    {
        return $"\"{EscapeJson(input)}\"";
    }

    private static string EscapeJson(string input)
    {
        if (input == null || input.Length == 0)
        {
            return "";
        }

        int i;
        int len = input.Length;
        var sb = new StringBuilder(len + 4);

        for (i = 0; i < len; i += 1)
        {
            char c = input[i];
            switch (c)
            {
                case '\\':
                case '"':
                    sb.Append('\\');
                    sb.Append(c);
                    break;
                case '\b':
                    sb.Append("\\b");
                    break;
                case '\t':
                    sb.Append("\\t");
                    break;
                case '\n':
                    sb.Append("\\n");
                    break;
                case '\f':
                    sb.Append("\\f");
                    break;
                case '\r':
                    sb.Append("\\r");
                    break;
                default:
                    if (c < ' ')
                    {
                        var t = "000" + string.Format("X", c);
                        sb.Append(string.Concat("\\u", t.Substring(t.Length - 4)));
                    }
                    else
                    {
                        sb.Append(c);
                    }
                    break;
            }
        }
        return sb.ToString();
    }

}

