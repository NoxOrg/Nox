using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Types;

public class Yaml : ValueObject<string, Yaml>
{
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
        return ParseYamlString(Value);
    }

    // public override bool Equals(object obj)
    // {
    //     if (obj == null || obj.GetType() != GetType())
    //     {
    //         return false;
    //     }
    //
    //     var other = (ValueObject<string, Yaml>)obj;
    //
    //     return AreYamlStringsEqual(Value, other.Value);
    // }

    
    private static bool IsValidYaml(string yamlString)
    {
        var lines = yamlString.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.Add(string.Empty);
        var indentStack = new Stack<int>();
        var indentStackExplicit = new List<YamlLine>();
        int count = 0;

        void AddLine(YamlLine line)
        {
            indentStackExplicit!.Add(line);
            count++;
        }
   
       
          
        indentStack.Push(0);
        AddLine(new YamlLine(string.Empty));

        // int? indentLevelPrevious = 0;
        string previousValue = string.Empty;
        string previousKey = string.Empty;
        
        // Final stack -1 and 0
        // indentStack.Push(-1);
        //
        // int? indentLevelPrevious = -1;

        foreach (var line in lines)
        {
            var yamlLine = new YamlLine(line);
            
            if (yamlLine.IsComment || yamlLine.IsEmpty)
            {
                continue;
            }

            // if(line.TrimStart().StartsWith("#"))
            // {
            //     continue;
            // }
            
            var previousLine = indentStackExplicit[count - 1];
            
            if (yamlLine.IsInvalid)
            {
                return false;
            }

            if (previousLine.IsEmpty)
            {
                AddLine(yamlLine);
            }
            else
            {
                if (yamlLine.IndentLevel > previousLine.IndentLevel)
                {
                    if(previousLine.Value == string.Empty || previousLine.IsArray)
                    {
                       AddLine(yamlLine);
                    }
                    else
                    {
                        // Invalid YAML: Indentation level must be consistent
                        return false;
                    }
                }
                else if(yamlLine.IndentLevel < previousLine.IndentLevel)
                {
                    var previousSameLevel = indentStackExplicit.LastOrDefault(s=>s.IndentLevel == yamlLine.IndentLevel);
                    if(previousSameLevel != null && previousSameLevel.IsArray == yamlLine.IsArray )
                    {
                        AddLine(yamlLine);
                    }
                    else
                    {
                        // Invalid YAML: Indentation level must be consistent
                        return false;
                    }
                }
                else
                {
                    if (previousLine.IsArray == yamlLine.IsArray)
                    {
                        AddLine(yamlLine);
                    }
                    else
                    {
                        // Invalid YAML: Indentation level must be consistent
                        return false;
                    }
                }
                
            }
            
            
            
            // if(previousLine.IndentLevel > yamlLine.IndentLevel)
            // {
            //     while (indentStackExplicit.Peek().IndentLevel > yamlLine.IndentLevel)
            //     {
            //         indentStackExplicit.Pop();
            //     }
            // }
            // else if(previousLine.IndentLevel <= yamlLine.IndentLevel)
            // {
            //     if(previousLine.IsArray || string.IsNullOrEmpty(previousLine.Value))
            //     {
            //         indentStackExplicit.Push(yamlLine);
            //     }
            //     else
            //     {
            //         // Invalid YAML: Indentation level must be consistent
            //         return false;
            //     }
            // }
            // else if(previousLine.IndentLevel != yamlLine.IndentLevel)
            // {
            //     return false;
            // }
            
            
            // var indentLevel = line.Length - line.TrimStart().Length;
            //
            // if (indentStack.Count == 0 || indentLevel > indentStack.Peek())
            // {
            //     if (string.IsNullOrEmpty(previousValue) || previousKey.TrimStart().StartsWith("-"))
            //     {
            //         indentStack.Push(indentLevel);
            //     }
            //     else
            //     {
            //         // Invalid YAML: Indentation level must be consistent
            //         return false;
            //     }
            // }
            // else if (indentLevel < indentStack.Peek())
            // {
            //     while (indentStack.Count > 0 && indentLevel < indentStack.Peek())
            //     {
            //         indentStack.Pop();
            //     }
            // }
            // else if(indentLevel != indentLevelPrevious)
            // {
            //     // Invalid YAML: Indentation level must be consistent
            //     return false;
            // }
            
            // indentLevelPrevious = indentLevel;
            
            // var lineWithoutIndent = line.TrimStart();
            //
            // //  Missing key-value separator (e.g., ':')
            // if (!lineWithoutIndent.Contains(':'))
            // {
            //     // A line that starts with '-' is valid YAML (it's a primitive type list item) or it's end of file
            //     if ( string.IsNullOrEmpty(lineWithoutIndent) || lineWithoutIndent.StartsWith("- "))
            //     {
            //         continue;
            //     }
            //     return false;
            // }
            
            if(yamlLine.IsInvalid)
            {
                return false;
            }

            // if (indentLevel < indentStack.Peek())
            // {
            //     return false;
            // }
            // else if (indentLevel > indentStack.Peek())
            // {
            //     indentStack.Push(indentLevel);
            // }
            // else if(indentLevel > 0)
            // {
            //     indentStack.Pop();
            // }


            

            // var segments = lineWithoutIndent.Split(':');
            // var key = segments[0].TrimEnd();
            // var value = string.Join(":", segments.Skip(1)).TrimStart();
            //
            // // Invalid YAML: Invalid key or value format
            // if (!IsValidKey(key) || !IsValidValue(value))
            // {
            //     return false;
            // }
            
            if( yamlLine is { IsEmpty: false, IsPrimitive: false } && ( !IsValidKey(yamlLine.Key) || !IsValidValue(yamlLine.Value)))
            {
                return false;
            }
            
            // previousValue = value;
            // previousKey = key;
        }

        return true;

        // var isValid = indentStackExplicit.Count == 1 && indentStackExplicit.Peek().IndentLevel == 0;
        // // Invalid YAML: Indentation level is not consistent across the entire YAML string
        // return indentStack.Count == 1 && indentStack.Peek() == 0 && isValid;
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

    // private static bool AreYamlStringsEqual(string yamlString1, string yamlString2)
    // {
    //     var dictionary1 = ParseYamlString(yamlString1);
    //     var dictionary2 = ParseYamlString(yamlString2);
    //
    //     return AreDictionariesEqual(dictionary1, dictionary2);
    // }

    private static Dictionary<string, object> ParseYamlString(string yamlString)
    {
        var lines = yamlString.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        var dictionary = new Dictionary<string, object>();

        foreach (var line in lines)
        {
            var segments = line.Split(':');
            var key = segments[0].TrimEnd();
            var value = string.Join(":", segments.Skip(1)).TrimStart();

            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, value);
            }
        }

        dictionary = dictionary.OrderBy(kvp => kvp.Key).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        return dictionary;
    }

    // private static bool AreDictionariesEqual(Dictionary<string, string> dictionary1, Dictionary<string, string> dictionary2)
    // {
    //     if (dictionary1.Count != dictionary2.Count)
    //     {
    //         return false;
    //     }
    //
    //     foreach (var kvp in dictionary1)
    //     {
    //         var key = kvp.Key;
    //         var value1 = kvp.Value;
    //
    //         if (!dictionary2.TryGetValue(key, out var value2))
    //         {
    //             return false;
    //         }
    //
    //         if (value1 != value2)
    //         {
    //             return false;
    //         }
    //     }
    //
    //     return true;
    // }
}