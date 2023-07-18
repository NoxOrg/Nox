using System.Collections.Generic;
using System.Linq;

namespace Nox.Types;

/// <summary>
/// Represents a node in a YAML structure.
/// </summary>
internal class YamlNode
{
    /// <summary>
    /// Gets the indentation level of the YAML node.
    /// </summary>
    public int IndentLevel { get; }

    /// <summary>
    /// Gets the key of the YAML node.
    /// </summary>
    public string Key { get; }

    /// <summary>
    /// Gets the value of the YAML node.
    /// </summary>
    public string Value { get; }
    
    /// <summary>
    /// Gets the original line of the YAML node.
    /// </summary>
    public string Line { get; }
    
    /// <summary>
    /// Gets the dictionary of children nodes for the YAML node.
    /// </summary>
    public Dictionary<string, YamlNode> Children { get; } = new();
    
    /// <summary>
    /// Gets or sets the parent node of the YAML node.
    /// </summary>
    public YamlNode? Parent { get; set; }

    // Private properties
    private string LineWithoutIndent { get; }

    /// <summary>
    /// Determines if the YAML node represents a comment.
    /// </summary>
    public bool IsComment => LineWithoutIndent.StartsWith('#');

    /// <summary>
    /// Determines if the YAML node represents an array element.
    /// </summary>
    public bool IsArray => LineWithoutIndent.StartsWith('-');

    /// <summary>
    /// Determines if the YAML node is empty.
    /// </summary>
    public bool IsEmpty => string.IsNullOrWhiteSpace(LineWithoutIndent);

    /// <summary>
    /// Determines if the YAML node represents a primitive value.
    /// </summary>
    public bool IsPrimitive => LineWithoutIndent.StartsWith('-') && !LineWithoutIndent.Contains(':');

    /// <summary>
    /// Determines if the YAML node is invalid.
    /// </summary>
    public bool IsInvalid => !LineWithoutIndent.Contains(':') && !string.IsNullOrEmpty(LineWithoutIndent) && !LineWithoutIndent.StartsWith("- ");

    /// <summary>
    /// Initializes a new instance of the <see cref="YamlNode"/> class with the specified line.
    /// </summary>
    /// <param name="line">The original line of the YAML node.</param>
    public YamlNode(string line)
    {
        IndentLevel = line.Length - line.TrimStart().Length;
        Line = line;
        LineWithoutIndent = line.TrimStart();
        var segments = LineWithoutIndent.Split(':');
        Key = segments.Length > 1 ? segments[0].TrimEnd() : string.Empty;
        Value = segments.Length > 1 ?  string.Join(":", segments.Skip(1)).TrimStart() : segments[0].TrimEnd();
    }
}
