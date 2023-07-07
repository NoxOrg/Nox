namespace Nox.Secrets.Helpers;

public static class SecretKeyHelper
{
    public static string ToFlattenedKey(this string source, string prefix)
    {
        return source
            .Replace("${{", "")
            .Replace("}}", "")
            .Replace($"{prefix}.secrets.", "")
            .Trim();
    }
}