namespace Nox.Generator._Common;

internal static class StringExtensions
{
    public static string EnsureEndsWith(this string text, string suffix)
    {
        if (text.EndsWith(suffix)) return text;

        return text + suffix;
    }
 
    public static string EnsureEndsWith(this string text, char suffix)
    {
        if (text.Length == 0) return text; 

        if (text[text.Length - 1] == suffix) return text;

        return text + suffix;
    }
    

    public static bool EndsWithIgnoreCase(this string text, string value) 
    {
        return text.EndsWith(value, System.StringComparison.OrdinalIgnoreCase);
    }
    
    public static string ToLowerFirstChar(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return char.ToLower(input[0]) + input.Substring(1);
    }
    
    public static string ToUpperFirstChar(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        return char.ToUpper(input[0]) + input.Substring(1);
    }
}

