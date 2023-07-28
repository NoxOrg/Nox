using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class MarkdownConverter : ValueConverter<Markdown, string>
{
    public MarkdownConverter() : base(markdown => markdown.Value, text => Markdown.FromDatabase(text)) { }
}