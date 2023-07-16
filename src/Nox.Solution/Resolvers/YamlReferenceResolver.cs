using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Nox.Solution.Exceptions;
using System.Linq;
using System.IO;
using System.Text;

namespace Nox.Solution;

internal class YamlReferenceResolver
{
    private readonly Regex _referenceRegex = new(@"\$ref\S*:\s*(?<variable>[\w:\.\/\\]+\b[\w\-\.\/]+)\s*", RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5));

    private string _rootKey;

    private IDictionary<string, Func<TextReader>> _filesAndContent;

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
        using var sourceLines = _filesAndContent[_rootKey].Invoke();

        var outputLines = ResolveReferencesInternal(sourceLines, _rootKey, true);
        
        return outputLines.ToString();
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

            var childPath = Path.GetFileName(match.Groups[1].Value); // strip path from $ref

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

}