using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Nox.Solution.Exceptions;
using System.IO;
using System.Text;
using System.Linq;

namespace Nox.Solution;

internal class YamlReferenceResolver
{
    private readonly Regex _referenceRegex = new(@"\$ref\S*:\s*(?<fileref>[\w:\.\/\\]+\b[\w\-\.\/]+)\s*", RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5));

    private readonly Regex _variableRegex = new Regex(@"\$\{\{\s*(?<type>[\w\.\-_:]+)\.(?<variable>[\w\.\-_:]+)\s*\}\}", RegexOptions.Compiled, TimeSpan.FromMilliseconds(10000));

    private readonly string _rootKey;

    private IDictionary<string, Func<TextReader>> _filesAndContent;

    public YamlResolverResult? Result { get; private set; }

    public YamlReferenceResolver(IDictionary<string,Func<TextReader>> filesAndContent, string rootKey)
    {
        if(!filesAndContent.TryGetValue(rootKey, out var _)) 
        { 
            throw new NoxYamlException($"The key [{rootKey}] was not found in the file and content dictionary.");
        }

        _filesAndContent = filesAndContent;

        _rootKey = rootKey;
    }

    public string ResolveReferences()
    {
        if (Result is not null) return Result.RefResolvedYaml;

        using var sourceLines = _filesAndContent[_rootKey].Invoke();

        var outputLines = ResolveReferencesInternal(sourceLines, _rootKey, true);
        
        var resolvedYaml = outputLines.ToString();

        var variables = ExtractVariablesIfExist(resolvedYaml);

        Result = new YamlResolverResult(resolvedYaml, variables);

        return resolvedYaml;
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
                // AS: removed the source line number references, not yet used and it breaks multiline strings.
                // Will probably be better to track these in a list behind the content.
                if (false && firstPass)
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

            if (prefix.Contains("-")) prefixPadding = new string(' ', prefix.IndexOf('-'));

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

                // AS: removed the source line number references, not yet used and it breaks multiline strings.
                // Will probably be better to track these in a list behind the content

                // outputLines.Append(output).AppendLine($"   ##$ -> {childPath},{childLineNumber}");

                outputLines.AppendLine(output);

            }
        }

        if (containsRef)
        {
            using var sr = new StringReader(outputLines.ToString());
            outputLines = ResolveReferencesInternal(sr,sourceName);
        }

        return outputLines;
    }

    private List<YamlVariableInfo> ExtractVariablesIfExist(string yaml)
    {
        var variableMatches = _variableRegex.Matches(yaml);

        var variables = new List<YamlVariableInfo>();

        foreach(Match match in variableMatches) 
        {
            variables.Add( new YamlVariableInfo(
                type: match.Groups["type"].Value,
                name: match.Groups["variable"].Value,
                index: match.Index,
                length: match.Value.Length
            ));
        }

        return variables;
    }

    public IReadOnlyList<string> GetVariables(string type)
    {
        if (Result is null) throw new NoxSolutionConfigurationException("Yaml is unresolved. Call 'ResolveReferences()' method first.");

        return Result.Variables(type);
    }

    public string ResolveVariables(IDictionary<string,string?> variables)
    {
        if (Result is null) throw new NoxSolutionConfigurationException("Yaml is unresolved. Call 'ResolveReferences()' method first.");

        // replace all variables conaining variable refs
        foreach(var variable in variables) 
        {
            if (variable.Value is null) continue;

            var matches = _variableRegex.Matches(variable.Value);

            foreach (var match in matches.Cast<Match>())
            {
                if (variables.TryGetValue(match.Groups["variable"].Value, out var variableValue))
                {
                    variables[variable.Key] = _variableRegex.Replace(variable.Value,
                        variableValue ?? string.Empty, 1);
                }
                else
                {
                    throw new NoxSolutionConfigurationException($"Variable [{match.Groups["variable"].Value}] was not found or resolved.");
                }
            }
        }

        return Result.ReplaceVariables(variables);
    }

}
