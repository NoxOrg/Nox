namespace Nox.Docs.Models;

public class MarkdownFile
{
    public string Name { get; init; } = string.Empty;
    public string Content { get; init; } = string.Empty;
    public IEnumerable<MarkdownFile> ReferencedFiles { get; init; } = Array.Empty<MarkdownFile>();
}

public class EntityMarkdownFile : MarkdownFile
{
    public string EntityName { get; init; } = string.Empty;
}