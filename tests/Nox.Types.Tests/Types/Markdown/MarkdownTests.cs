using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class MarkdownTests
{
    [Fact]
    public void Markdown_Constructor_ReturnsSameValue()
    {
        string text = "**bold with *italic* inside**";

        Markdown.From(text).Value.Should().Be(text);
    }

    [Fact]
    public void Markdown_Equals_ReturnsTrue()
    {
        string text = "**bold with *italic* inside**";

        var markdown1 = Markdown.From(text);
        var markdown2 = Markdown.From(text);

        markdown1.Should().Be(markdown2);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("normal text", "normal text")]
    [InlineData("**bold**", "<strong>bold</strong>")]
    [InlineData("__bold__", "<strong>bold</strong>")]
    [InlineData("normal **bold** normal", "normal <strong>bold</strong> normal")]
    [InlineData("normal __bold__ normal", "normal <strong>bold</strong> normal")]
    [InlineData("*italic*", "<em>italic</em>")]
    [InlineData("_italic_", "<em>italic</em>")]
    [InlineData("normal *italic* normal", "normal <em>italic</em> normal")]
    [InlineData("normal _italic_ normal", "normal <em>italic</em> normal")]
    [InlineData("**bold with *italic* inside**", "<strong>bold with <em>italic</em> inside</strong>")]
    [InlineData("*italic with **bold** inside*", "<em>italic with <strong>bold</strong> inside</em>")]
    public void Markdown_ToHtml_ReturnsExpectedResult(string markdown, string html)
    {
        Markdown.From(markdown).ToHtml().Should().Be(html);
    }

    [Fact]
    public void MarkdownOptions_Constructor_ReturnsDefaults()
    {
        var textOptions = new MarkdownTypeOptions();

        textOptions.IsUnicode.Should().BeTrue();
        textOptions.MinLength.Should().Be(0u);
        textOptions.MaxLength.Should().Be(255u);
    }

    [Fact]
    public void Markdown_Constructor_SpecifyingMaxLength_WithLongerLengthInput_ThrowsValidationException()
    {
        var fromAct = () => Text.From("long text", new TextTypeOptions { MaxLength = 3 });

        fromAct.Should().Throw<TypeValidationException>();
    }
}