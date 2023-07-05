using System;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Nox.Solution.Utils;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Nox.Solution.Macros;

public class EnvironmentVariableMacroParser: IMacroParser
{
    private readonly IEnvironmentProvider _environmentProvider;
    private readonly Regex _regex = new Regex(@"\$\{{\s*env.\S+\s*\}}", RegexOptions.Compiled, TimeSpan.FromMilliseconds(10000));
    private readonly ISerializer _serializer;

    public EnvironmentVariableMacroParser(IEnvironmentProvider environmentProvider)
    {
        _environmentProvider = environmentProvider;

        _serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();
    }

    public string Parse(string text)
    {
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
            //Example: "${{ env.SECRETS_PASSWORD   }}"
            //Remove Start "${{", Remove End "}}"
            var variableName = match.Value.Substring(3, match.Value.Length - 3 - 2).Trim();
            //var variableName = match.Value[3..^2].Trim(); (in .Net Standard 2.1 we can use Range)
            //Remove "env."
            variableName = variableName.Substring(4);

            var environmentValue = _environmentProvider.GetEnvironmentVariable(variableName);

            if (environmentValue != null)
            {
                //Ensure special characters in password, for example @"#{}$%@'\\", are yaml valid values
                environmentValue = _serializer.Serialize(environmentValue);
                parsed = parsed.Replace(match.Value, environmentValue);
            }
        }

        return parsed;
    }
}