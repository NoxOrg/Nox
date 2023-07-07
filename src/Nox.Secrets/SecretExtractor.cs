using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Nox.Secrets;

public static class SecretExtractor
{
    public static List<string>? Extract(string prefix, string sourceText)
    {
        var regex = new Regex($@"\$\{{{{\s*{prefix}\.secrets\.\S+\s*\}}}}", RegexOptions.Compiled, TimeSpan.FromMilliseconds(10000));
        MatchCollection? matched = default;
        try
        {
            matched = regex.Matches(sourceText);
        }
        catch (RegexMatchTimeoutException e)
        {
            Debug.WriteLine(e);
            Console.WriteLine(e);
            return null;
        }

        var result = new List<string>();
        for (var index = 0; index < matched.Count; index++)
        {
            var match = matched[index];
            var secretName = match.Value.Substring(3, match.Value.Length - 3 - 2).Trim();
            result.Add(secretName);
        }

        return result;
    }
}