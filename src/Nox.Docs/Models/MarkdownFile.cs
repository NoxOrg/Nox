namespace Nox.Docs.Models;

public class MarkdownFile
{
    public string Name { get; init; } = string.Empty;
    public string Content { get; init; } = string.Empty;
}

public class EntityMarkdownFile : MarkdownFile
{
    public string EntityName { get; init; } = string.Empty;
}

public class MarkdownReadme : MarkdownFile
{
    public MarkdownFile[] ReferencedMarkdowns { get; init; } = Array.Empty<MarkdownFile>();
}