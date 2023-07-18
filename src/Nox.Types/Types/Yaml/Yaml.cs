using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Nox.Types;

/// <summary>
///  Represents a Nox <see cref="Yaml"/> type and value object.
/// </summary>
public class Yaml : ValueObject<string, Yaml>
{
    private readonly List<YamlNode> _yamlNodes = new();
    private bool _isValidated;

    /// <summary>
    /// Gets the equality components used for value comparison.
    /// </summary>
    /// <returns>The equality components.</returns>
    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        var properties = GenerateKeyValuePairs();
        return properties;
    }
    /// <summary>
    /// Validates the YAML object and returns the validation result.
    /// </summary>
    /// <returns>The validation result.</returns>
    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        
        var lines = Value.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        HashSet<string> anchors = new();

    

        foreach (var yamlLine in lines.Select(line => new YamlNode(line))
                     .Where(yamlLine => yamlLine is { IsComment: false, IsEmpty: false }))
        {
            ValidateYamlLine(yamlLine, result);
            AddYamlAnchorIfExists(yamlLine.Line, anchors, result);
            CheckAnchorUsage(yamlLine, anchors, result);

            if (_yamlNodes.Count == 0)
            {
                yamlLine.Parent = new YamlNode("default_nox_yaml_parent_node:");
                _yamlNodes.Add(yamlLine);
            }
            else
            {
                var previousLine = _yamlNodes[^1];
                if (yamlLine.IndentLevel > previousLine.IndentLevel)
                {
                    ValidateBiggerIndentLevel(previousLine, yamlLine, result);
                }
                else if (yamlLine.IndentLevel < previousLine.IndentLevel)
                {
                    ValidateSmallerIndentLevel(yamlLine, result);
                }
                else
                {
                    ValidateSameIndentLevel(previousLine, yamlLine, result);
                }
            }

            
        }

        _isValidated = result.IsValid;
        return result;
    }

    /// <summary>
    /// Validates that the YAML line has the same indentation level as the previous line and adds it to the YAML object.
    /// </summary>
    private void ValidateSameIndentLevel(YamlNode previousLine, YamlNode yamlLine, ValidationResult result)
    {
        if (previousLine.IsArray == yamlLine.IsArray && previousLine.Parent != null &&
            !previousLine.Parent.Children.ContainsKey(yamlLine.Key))
        {
            yamlLine.Parent = previousLine.Parent;
            previousLine.Parent.Children.Add(
                yamlLine.IsArray ? "#" + _yamlNodes.Count + "#" + yamlLine.Key : yamlLine.Key, yamlLine);
            _yamlNodes.Add(yamlLine);
        }
        else
        {
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox Yaml type with invalid yaml value '{Value}'. Yaml line '{yamlLine.Line}' indent must be consistent and keys must be unique."));
        }
    }

    /// <summary>
    /// Validates that the YAML line has a smaller indentation level than the previous line and adds it to the YAML object.
    /// </summary>
    private void ValidateSmallerIndentLevel(YamlNode yamlLine, ValidationResult result)
    {
        var previousSameLevel =
            _yamlNodes.LastOrDefault(s => s.IndentLevel == yamlLine.IndentLevel);
        if (previousSameLevel != null && previousSameLevel.IsArray == yamlLine.IsArray &&
            previousSameLevel.Parent != null &&
            !previousSameLevel.Parent.Children.ContainsKey(yamlLine.Key))
        {
            yamlLine.Parent = previousSameLevel.Parent;
            previousSameLevel.Parent.Children.Add(
                yamlLine.IsArray ? "#" + _yamlNodes.Count + "#" + yamlLine.Key : yamlLine.Key, yamlLine);
            _yamlNodes.Add(yamlLine);
        }
        else
        {
            // Invalid YAML: Indentation level must be consistent and keys must be unique
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox Yaml type with invalid yaml value '{Value}'.  Yaml line '{yamlLine.Line}' indent must be consistent and keys must be unique."));
        }
    }

    /// <summary>
    /// Validates that the YAML line has a bigger indentation level than the previous line and adds it to the YAML object.
    /// </summary>
    private void ValidateBiggerIndentLevel(YamlNode previousLine, YamlNode yamlLine, ValidationResult result)
    {
        if ((previousLine.Value == string.Empty || previousLine.IsArray))
        {
            yamlLine.Parent = previousLine;
            previousLine.Children.Add(yamlLine.IsArray ? "#" + _yamlNodes.Count + "#" + yamlLine.Key : yamlLine.Key,
                yamlLine);
            _yamlNodes.Add(yamlLine);
        }
        else
        {
            // Invalid YAML: Indentation level must be consistent
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox Yaml type with invalid yaml value '{Value}'. Yaml line '{yamlLine.Line}' indent must be consistent."));
        }
    }

    

    /// <summary>
    /// Validates that the YAML line is valid.
    /// </summary>
    private void ValidateYamlLine(YamlNode yamlLine, ValidationResult result)
    {
        if (yamlLine.IsInvalid && (yamlLine is { IsEmpty: false, IsPrimitive: false } &&
                                   (!IsValidKey(yamlLine.Key))))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox Yaml type with invalid yaml value '{Value}', yaml line is invalid '{yamlLine.Line}'."));
        }
    }

    

    
    /// <summary>
    /// Checks if the key is valid.
    /// </summary>
    private static bool IsValidKey(string key)
    {
        // Validate key format (any non-empty string is considered valid)
        return !string.IsNullOrEmpty(key);
    }

    /// <summary>
    /// Adds the YAML anchor to the set of anchors if it exists in the line.
    /// </summary>
    private void AddYamlAnchorIfExists(string line, HashSet<string> anchors, ValidationResult result)
    {
        string pattern = @"&(\w+)\b";
        Match match = Regex.Match(line, pattern);

        if (!match.Success) return;
        if (!anchors.Add(match.Groups[1].Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox Yaml type with invalid yaml value '{Value}'. Anchor '{match.Groups[1].Value}' already exists."));
        }
    }
    
    /// <summary>
    /// Checks the usage of YAML anchors in the line.
    /// </summary>
    private void CheckAnchorUsage(YamlNode yamlLine, HashSet<string> anchors, ValidationResult result)
    {
        var pattern = @"\*(\w+)\b";
        var match = Regex.Match(yamlLine.Line, pattern);

        if (!match.Success) return;
        if (!anchors.Contains(match.Groups[1].Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox Yaml type with invalid yaml value '{Value}', invalid yaml line '{yamlLine.Line}'. Anchor '{match.Groups[1].Value}' does not exist."));
        }
    }

   
    /// <summary>
    /// Generates the key-value pairs representing the YAML object.
    /// </summary>
    private List<KeyValuePair<string, object>> GenerateKeyValuePairs()
    {
        if (!_isValidated)
        {
            var validationResult = Validate();

            if (!validationResult.IsValid)
            {
                throw new TypeValidationException(validationResult.Errors);
            }
        }

        List<KeyValuePair<string, object>> properties = new();

        foreach (var yamlNode in _yamlNodes.Where(n => n.Children.Count == 0))
        {
            StringBuilder keyBuilder = new();
            StringBuilder valueBuilder = new();
            KeyValueBuilder(yamlNode, keyBuilder, valueBuilder);
            properties.Add(new KeyValuePair<string, object>(keyBuilder.ToString(), valueBuilder.ToString()));
        }

        properties = properties.OrderBy(kvp=>kvp.Key).ThenBy(kvp=>kvp.Value).ToList();
        return properties;
       
    }
    /// <summary>
    /// Builds the key and value of the YAML object.
    /// </summary>
    private static void KeyValueBuilder(YamlNode yamlNode, StringBuilder keyBuilder, StringBuilder valueBuilder)
    {
        while (true)
        {
            keyBuilder.Append(yamlNode.IsArray ? string.Concat(yamlNode.Key,yamlNode.Value) : yamlNode.Key);
            keyBuilder.Append('#');
            valueBuilder.Append(yamlNode.Value);
            valueBuilder.Append('#');

            if (yamlNode.Parent != null)
            {
                yamlNode = yamlNode.Parent;
                continue;
            }

            break;
        }
    }

}