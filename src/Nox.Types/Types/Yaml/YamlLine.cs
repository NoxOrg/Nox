using System.Linq;

namespace Nox.Types;

internal class YamlLine
{
    public int IndentLevel { get; }
    public string Key { get; }
    public string Value { get; }
    
    public string Line { get; }
    
    public string LineWithoutIndent { get; }
    
    public bool IsComment => LineWithoutIndent.StartsWith("#");
    public bool IsArray => LineWithoutIndent.StartsWith("-");
    public bool IsEmpty => string.IsNullOrWhiteSpace(LineWithoutIndent);
    public bool IsPrimitive => LineWithoutIndent.StartsWith("-") && !LineWithoutIndent.Contains(":");
    public bool IsInvalid => !LineWithoutIndent.Contains(':') && !string.IsNullOrEmpty(LineWithoutIndent) && !LineWithoutIndent.StartsWith("- ");

    public YamlLine(string line)
    {
        IndentLevel = line.Length - line.TrimStart().Length;
        Line = line;
        LineWithoutIndent = line.TrimStart();
        var segments = LineWithoutIndent.Split(':');
        Key = segments.Length > 1 ? segments[0].TrimEnd() : string.Empty;
        Value = segments.Length > 1 ?  string.Join(":", segments.Skip(1)).TrimStart() : segments[0].TrimEnd();
        
    }
}
