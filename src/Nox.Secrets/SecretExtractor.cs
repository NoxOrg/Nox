using System.Diagnostics;
using System.Text.RegularExpressions;

namespace Nox.Secrets;

public static class SecretExtractor
{
    public static string[]? Extract(string sourceText)
    {
        var regex = new Regex(@"\$\{\{\s*secrets\.(?<variable>[\w\.\-_:]+)\s*\}\}", RegexOptions.Compiled, TimeSpan.FromMilliseconds(10000));
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
            var secretKey = matched[index].Groups["variable"].Value;
            result.Add(secretKey);
        }

        return result.ToArray();
    }
}