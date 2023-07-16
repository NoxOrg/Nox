using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Nox.Solution.Exceptions;
using System.Linq;
using System.IO;

namespace Nox.Solution;

internal class YamlReferenceResolver
{
    private readonly Regex _referenceRegex = new(@"\$ref\S*:\s*(?<variable>[\w:\.\/\\]+\b[\w\-\.\/]+)\s*", RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5));

    private string _rootKey;

    private IDictionary<string, string> _filesAndContent;

    public YamlReferenceResolver(IDictionary<string,string> filesAndContent, string rootKey)
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
        var sourceLines = _filesAndContent[_rootKey].Replace("\r","").Split('\n');

        var outputLines = ResolveReferencesInternal(sourceLines.ToList());
        
        return string.Join("\n", outputLines.ToArray());
    }

    private List<string> ResolveReferencesInternal(List<string> sourceLines)
    {
        var outputLines = new List<string>();
        foreach (var sourceLine in sourceLines)
        {
            if (sourceLine.TrimStart().StartsWith("#"))
            {
                outputLines.Add(sourceLine);
                continue;
            }

            var match = _referenceRegex.Match(sourceLine);

            if (!match.Success)
            {
                outputLines.Add(sourceLine);
                continue;
            }

            var padding = new string(' ', match.Index);
            var prefixPadding = "";
            var prefix = sourceLine.Substring(0, match.Index);

            if (prefix.Contains('-')) prefixPadding = new string(' ', prefix.IndexOf('-'));

            var childPath = Path.GetFileName(match.Groups[1].Value); // strip path from $ref

            if (!_filesAndContent.TryGetValue(childPath, out var childContent))
            {
                throw new NoxYamlException($"Referenced yaml file does not exist for reference: {match.Groups[1].Value}");
            }

            var childLines = childContent.Replace("\r","").Split('\n');

            foreach ((var childLine, bool isFirst) in childLines.Select((childLine, index) => (childLine, index == 0)))
            {
                if (isFirst)
                {
                    outputLines.Add((prefix + childLine).Replace("- -", "-"));
                }
                else
                {
                    if (childLine.StartsWith("-"))
                    {
                        outputLines.Add(prefixPadding + childLine);
                    }
                    else
                    {
                        outputLines.Add(padding + childLine);
                    }

                }
            }
        }

        if (outputLines.Any(ol => ol.Contains("$ref:") && !ol.TrimStart().StartsWith("#")))
        {
            outputLines = ResolveReferencesInternal(outputLines);
        }

        return outputLines;
    }
}