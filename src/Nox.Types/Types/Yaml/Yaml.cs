using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nox.Types;

public class Yaml : ValueObject<string, Yaml>
{
    private List<YamlNode> _yamlNodes = new();
    private bool _isValidated = false;

    internal override ValidationResult Validate()
    {
        var result = base.Validate();

        if (!IsValidYaml(Value))
        {
            result.Errors.Add(new ValidationFailure(nameof(Value),
                $"Could not create a Nox Yaml type with invalid yaml value '{Value}'."));
        }

        return result;
    }

    protected override IEnumerable<KeyValuePair<string, object>> GetEqualityComponents()
    {
        var properties = GenerateKeyValuePairs();
        foreach (var property in properties)
        {
            yield return property;
        }
    }

    private bool IsValidYaml(string yamlString)
    {
        var lines = yamlString.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.Add(string.Empty);
        var indentStackExplicit = new List<YamlNode>();
        int count = 0;

        void AddLine(YamlNode line)
        {
            indentStackExplicit!.Add(line);
            count++;
        }

        var isValid = true;
        foreach (var yamlLine in lines.Select(line => new YamlNode(line))
                     .Where(yamlLine => !yamlLine.IsComment && !yamlLine.IsEmpty))
        {
            if (yamlLine.IsInvalid)
            {
                isValid = false;
                break;
            }


            if (indentStackExplicit.Count == 0)
            {
                yamlLine.Parent = new YamlNode("default_nox_yaml_parent_node:");
                AddLine(yamlLine);
            }
            else
            {
                var previousLine = indentStackExplicit[count - 1];
                if (yamlLine.IndentLevel > previousLine.IndentLevel)
                {
                    if ((previousLine.Value == string.Empty || previousLine.IsArray))
                    {
                        yamlLine.Parent = previousLine;
                        previousLine.Children.Add(yamlLine.IsArray ? "#" + count + "#" + yamlLine.Key : yamlLine.Key,
                            yamlLine);
                        AddLine(yamlLine);
                    }
                    else
                    {
                        // Invalid YAML: Indentation level must be consistent
                        isValid = false;
                        break;
                    }
                }
                else if (yamlLine.IndentLevel < previousLine.IndentLevel)
                {
                    var previousSameLevel =
                        indentStackExplicit.LastOrDefault(s => s.IndentLevel == yamlLine.IndentLevel);
                    if (previousSameLevel != null && previousSameLevel.IsArray == yamlLine.IsArray &&
                        previousSameLevel.Parent != null &&
                        !previousSameLevel.Parent.Children.ContainsKey(yamlLine.Key))
                    {
                        yamlLine.Parent = previousSameLevel.Parent;
                        previousSameLevel.Parent.Children.Add(
                            yamlLine.IsArray ? "#" + count + "#" + yamlLine.Key : yamlLine.Key, yamlLine);
                        AddLine(yamlLine);
                    }
                    else
                    {
                        // Invalid YAML: Indentation level must be consistent and keys must be unique
                        isValid = false;
                        break;
                    }
                }
                else
                {
                    if (previousLine.IsArray == yamlLine.IsArray && previousLine.Parent != null &&
                        !previousLine.Parent.Children.ContainsKey(yamlLine.Key))
                    {
                        yamlLine.Parent = previousLine.Parent;
                        previousLine.Parent.Children.Add(
                            yamlLine.IsArray ? "#" + count + "#" + yamlLine.Key : yamlLine.Key, yamlLine);
                        AddLine(yamlLine);
                    }
                    else
                    {
                        // Invalid YAML: Indentation level must be consistent and keys must be unique
                        isValid = false;
                        break;
                    }
                }
            }

            if (yamlLine is { IsEmpty: false, IsPrimitive: false } &&
                (!IsValidKey(yamlLine.Key) || !IsValidValue(yamlLine.Value)))
            {
                isValid = false;
                break;
            }
        }

        _yamlNodes = indentStackExplicit;
        _isValidated = true;
        return isValid;
    }

    private static bool IsValidKey(string key)
    {
        // Validate key format (any non-empty string is considered valid)
        return !string.IsNullOrEmpty(key);
    }

    private static bool IsValidValue(string value)
    {
        // Validate value format (any string is considered valid)
        return true;
    }


    private static void KeyValueBuilder(YamlNode yamlNode, StringBuilder keyBuilder, StringBuilder valueBuilder)
    {
        while (true)
        {
            keyBuilder.Append(yamlNode.IsArray ? string.Concat(yamlNode.Key,yamlNode.Value) : yamlNode.Key);
            keyBuilder.Append("#");
            valueBuilder.Append(yamlNode.Value);
            valueBuilder.Append("#");

            if (yamlNode.Parent != null)
            {
                yamlNode = yamlNode.Parent;
                continue;
            }

            break;
        }
    }

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

}