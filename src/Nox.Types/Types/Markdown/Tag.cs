namespace Nox.Types;

public static class Tag
{
    public static readonly (string Markdown, string Html) ItalicA = ("*", "em");
    public static readonly (string Markdown, string Html) ItalicU = ("_", "em");
    public static readonly (string Markdown, string Html) BoldA = ("**", "strong");
    public static readonly (string Markdown, string Html) BoldU = ("__", "strong");
}