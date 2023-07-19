using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Nox.Solution.Macros;

public class SecretMacroParser: IMacroParser
{
    private readonly Regex _regex = new Regex(@"\$\{\{\s*secrets\.(?<variable>[\w\.\-_:]+)\s*\}\}", RegexOptions.Compiled, TimeSpan.FromMilliseconds(10000));
    private readonly ISerializer _serializer;

    public SecretMacroParser()
    {
        _serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
    }
    
    public string Parse(string text, IReadOnlyDictionary<string, string?>? values = null)
    {
        if (values == null || !values.Any()) return text;
        
        var parsed = text;
        MatchCollection? matched = default;
        try
        {
            matched = _regex.Matches(text);
        }
        catch (RegexMatchTimeoutException e)
        {
            Debug.WriteLine(e);
            Console.WriteLine(e);
            return text;
        }

        for (int count = 0; count < matched.Count; count++)
        {
            var match = matched[count];
            var secretName = match.Groups["variable"].Value;

            if (values != null)
            {
                if (values.ContainsKey(secretName) && !string.IsNullOrWhiteSpace(values[secretName]))
                {
                    var secretValue = values[secretName];
                    //Ensure special characters in password, for example @"#{}$%@'\\", are yaml valid values
                    secretValue = _serializer.Serialize(secretValue);
                    parsed = parsed.Replace(match.Value, secretValue);
                }
            }
        }

        return parsed;
    }
}