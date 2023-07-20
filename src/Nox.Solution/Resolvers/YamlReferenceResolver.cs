using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Nox.Solution.Exceptions;
using System.Linq;
using System.IO;
using System.Text;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

namespace Nox.Solution;

internal class YamlReferenceResolver
{
    private bool _isResolved = false;

    private string _resolvedYaml = string.Empty;

    private readonly Regex _referenceRegex = new(@"\$ref\S*:\s*(?<fileref>[\w:\.\/\\]+\b[\w\-\.\/]+)\s*", RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5));

    private readonly Regex _variableRegex = new Regex(@"\$\{\{\s*(?<type>[\w\.\-_:]+)\.(?<variable>[\w\.\-_:]+)\s*\}\}", RegexOptions.Compiled, TimeSpan.FromMilliseconds(10000));

    private readonly string _rootKey;

    private IDictionary<string, Func<TextReader>> _filesAndContent;

    private List<VariableInfo> _variables = new();
    public IReadOnlyList<string> Variables(string type) => _variables
        .Where(i => i.Type == type)
        .Select(i => i.Name)
        .Distinct()
        .ToList();

    public YamlReferenceResolver(IDictionary<string,Func<TextReader>> filesAndContent, string rootKey)
    {
        if(!filesAndContent.TryGetValue(rootKey, out var _)) 
        { 
            throw new NoxYamlException($"The key [{rootKey}] was not found in the file and content dictionary.");
        }

        _filesAndContent = filesAndContent;

        _rootKey = rootKey;

        _isResolved = false;
    }

    public string ResolveReferences()
    {
        if (_isResolved) return _resolvedYaml;

        using var sourceLines = _filesAndContent[_rootKey].Invoke();

        var outputLines = ResolveReferencesInternal(sourceLines, _rootKey, true);
        
        _resolvedYaml = outputLines.ToString();

        _isResolved = true;

        ExtractVariablesIfExist();

        return _resolvedYaml;
    }

    private StringBuilder ResolveReferencesInternal(TextReader sourceLines, string sourceName, bool firstPass = false)
    {
        var outputLines = new StringBuilder();

        var containsRef = false;

        var lineNumber = 0;

        while (true)
        {
            var sourceLine = sourceLines.ReadLine();

            if (sourceLine == null) break;

            lineNumber++;

            if (sourceLine.TrimStart().StartsWith("#") || string.IsNullOrWhiteSpace(sourceLine))
            {
                continue;
            }

            containsRef = containsRef || sourceLine.Contains("$ref:");

            var match = _referenceRegex.Match(sourceLine);

            if (!match.Success)
            {
                if (firstPass)
                {
                    outputLines.Append(sourceLine).AppendLine($"   ##$ -> {sourceName},{lineNumber}");
                }
                else
                {
                    outputLines.AppendLine(sourceLine);
                }
                continue;
            }

            var padding = new string(' ', match.Index);
            var prefixPadding = string.Empty;
            var prefix = sourceLine.Substring(0, match.Index);

            if (prefix.Contains('-')) prefixPadding = new string(' ', prefix.IndexOf('-'));

            var childPath = Path.GetFileName(match.Groups["fileref"].Value); // strip path from $ref

            if (!_filesAndContent.ContainsKey(childPath))
            {
                throw new NoxYamlException($"Referenced yaml file does not exist for reference: {childPath}");
            }

            using var childContent = _filesAndContent[childPath].Invoke();

            bool isFirstLine = true;

            var childLineNumber = 0; 

            while (true)
            {
                var childLine = childContent.ReadLine();

                if (childLine == null) break;

                childLineNumber++;

                if (childLine.TrimStart().StartsWith("#") || string.IsNullOrWhiteSpace(childLine))
                {
                    continue;
                }
                
                containsRef = containsRef || childLine.Contains("$ref:");

                string output;

                if (isFirstLine)
                {
                    output = $"{prefix}{childLine}".Replace("- -", "-");
                    
                    isFirstLine = false;
                }
                else if (childLine.StartsWith("-"))
                {
                    output = $"{prefixPadding}{childLine}";
                }
                else
                {
                    output = $"{padding}{childLine}";
                }
                outputLines.Append(output).AppendLine($"   ##$ -> {childPath},{childLineNumber}");

            }
        }

        if (containsRef)
        {
            using var sr = new StringReader(outputLines.ToString());
            outputLines = ResolveReferencesInternal(sr,sourceName);
        }

        return outputLines;
    }

    private void ExtractVariablesIfExist()
    {
        if (!_isResolved) throw new NoxSolutionConfigurationException("Variables can't be extracted before the yaml configuration is processed.");

        var variableMatches = _variableRegex.Matches(_resolvedYaml);

        foreach(Match match in variableMatches) 
        {
            _variables.Add( new VariableInfo(
                type: match.Groups["type"].Value,
                name: match.Groups["variable"].Value,
                index: match.Index,
                length: match.Value.Length
            ));
        }
    }

    public string ReplaceVariablesIfExist(IDictionary<string, string?> variableValues)
    {
        if (!_isResolved ) throw new NoxSolutionConfigurationException("Variables can't be replaced before the yaml configuration is processed.");

        if (!variableValues.Any()) return _resolvedYaml;

        var serializer = new SerializerBuilder().Build();

        var sb = new StringBuilder(_resolvedYaml);

        foreach(var info in _variables.Select(i => i).Reverse()) 
        {
            var variableValue = variableValues[info.Name];

            if (variableValue is null)
            {
                // Should probably terminate with:
                // throw new NoxSolutionConfigurationException($"Variable [{info.Type}.{info.Name}] was not found or resolved.");
                variableValue = string.Empty;
            }

            sb.Remove(info.Index, info.Length);
            sb.Insert(info.Index, serializer.Serialize(variableValue));
        }

        return sb.ToString();
    }

    private class VariableInfo
    {
        public string Type { get; }
        public string Name { get; }
        public int Index { get; }
        public int Length { get; }

        public VariableInfo(string type, string name, int index, int length)
        {
            Type = type;
            Name = name;
            Index = index;
            Length = length;
        }
    }
}