using System.Text.RegularExpressions;
using Nox.Yaml.Exceptions;
using System.Text;
using YamlDotNet.Serialization;

namespace Nox.Yaml.Parser;

internal class YamlReferenceResolver
{
    private readonly Regex _referenceRegex = new(@"^\s*[^#]\s*[-]*\s*(?<refkey>\$ref)\s*:\s*(?<refvalue>[\w:\.\/\\]+\b[\w\-\.\/]+)\s*", RegexOptions.Compiled | RegexOptions.IgnoreCase, TimeSpan.FromSeconds(5));

    private readonly Regex _variableRegex = new(@"\$\{\{\s*(?<type>[\w\.\-_:]+)\.(?<variable>[\w\.\-_:]+)\s*\}\}", RegexOptions.Compiled, TimeSpan.FromMilliseconds(10000));

    private readonly string _rootKey;

    private readonly IDictionary<string, Func<TextReader>> _filesAndContent;

    private readonly IList<YamlLineInfo> _content;

    private readonly IList<YamlVariableInfo> _variables;

    private readonly StringBuilder _contentAsStringBuilder;


    public YamlReferenceResolver(IDictionary<string, Func<TextReader>> filesAndContent, string rootKey)
    {
        _filesAndContent = filesAndContent;

        _rootKey = rootKey;

        _content = new List<YamlLineInfo>();

        ReadYamlStreamRecursive(_rootKey, string.Empty);

        _contentAsStringBuilder = ToStringBuilder();

        _variables = ExtractVariablesIfExist();
    }

    public string ToYamlString() => _contentAsStringBuilder.ToString();


    private void ReadYamlStreamRecursive(string sourceName, string padding)
    {
        if (!_filesAndContent.ContainsKey(sourceName))
        {
            throw new NoxYamlException($"Referenced yaml content does not exist in the dictionry for key '{sourceName}'");
        }
        using var sourceLines = _filesAndContent[sourceName].Invoke();

        var lineNumber = 0;

        while (true)
        {
            var sourceLine = sourceLines.ReadLine();

            if (sourceLine == null) break;

            lineNumber++;

            sourceLine = $"{padding}{sourceLine}";

            var match = _referenceRegex.Match(sourceLine);

            if (!match.Success)
            {
                _content.Add(new YamlLineInfo(sourceName, lineNumber, sourceLine));
                continue;
            }

            var includePath = Path.GetFileName(match.Groups["refvalue"].Value); // strip path from $ref

            if (!_filesAndContent.ContainsKey(includePath))
            {
                throw new NoxYamlException($"Referenced yaml file does not exist for reference: {includePath} (in '{sourceName}' line {lineNumber}).");
            }

            var pos = match.Groups["refkey"].Index; 

            var includeLine = sourceLine.Substring(0, pos);
            
            _content.Add(new YamlLineInfo(sourceName, lineNumber, includeLine, comment: sourceLine));

            var includePadding = new string(' ', pos);

            ReadYamlStreamRecursive(includePath, includePadding);
        }

    }

    private StringBuilder ToStringBuilder()
    {
        var sb = new StringBuilder();
        foreach (var i in _content)
        {
            if (i.Comment is null)
            {
                sb.AppendLine(i.Text);
            }
            else
            {
                sb.AppendLine(i.Text + "###" + i.Comment);
            }
        }
        return sb;
    }

    internal YamlLineInfo GetLineInfo(int lineNumber)
    {
        if(lineNumber < 1 || lineNumber > _content.Count)
        {
            return new YamlLineInfo("unknown", -1, "unknown", "lineNumber is out of range");
        }

        return _content[lineNumber-1];
    }

    private List<YamlVariableInfo> ExtractVariablesIfExist()
    {
        var variableMatches = _variableRegex.Matches(this.ToYamlString());

        var variables = new List<YamlVariableInfo>();

        foreach (Match match in variableMatches)
        {
            variables.Add(new YamlVariableInfo(
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
        return _variables
         .Where(i => i.Type == type)
         .Select(i => i.Name)
         .Distinct()
         .ToList();
    }

    public void ResolveVariables(IDictionary<string, string?> variables)
    {

        // replace all variables conaining variable refs
        foreach (var variable in variables)
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
                    throw new NoxYamlException($"Variable [{match.Groups["variable"].Value}] was not found or resolved.");
                }
            }
        }

        ReplaceVariables(variables);
    }

    private void ReplaceVariables(IDictionary<string, string?> variableValues)
    {
        if (!variableValues.Any()) return;

        var serializer = new SerializerBuilder().Build();

        var sb = _contentAsStringBuilder;

        foreach (var info in _variables.Select(i => i).Reverse())
        {
            var variableValue = variableValues[info.Name] ?? throw new NoxYamlException($"Variable [{info.Type}.{info.Name}] was not found or resolved.");
            var serializedValue = serializer.Serialize(variableValue).TrimEnd(); // remove trailing \r\n that gets added by serializer

            sb.Remove(info.Index, info.Length);
            sb.Insert(info.Index, serializedValue);
        }
    }
}