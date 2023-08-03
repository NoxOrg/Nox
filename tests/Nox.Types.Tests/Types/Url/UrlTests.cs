using FluentAssertions;

namespace Nox.Types.Tests.Types;

public class UrlTests
{
    [Theory]
    [InlineData("https://www.google.com")]
    [InlineData("https://www.google.com/")]
    [InlineData("https://www.google.com/test")]
    [InlineData("https://www.google.com/test/test1?q=123")]
    [InlineData("https://example.org/test/test1?search=test-question#part2")]
    [InlineData("file://website.com/pathtofile/intro.pdf")]
    [InlineData("mailto:abc@iwgplc.com")]
    public void UrlFromUri_ShouldBe_Validated(string url)
    {
        var expected = new System.Uri(url);
        var actual = Url.From(expected);
        actual.Value.AbsoluteUri.Should().Be(expected.AbsoluteUri);
    }

    [Theory]
    [InlineData("https://www.google.com/")]
    [InlineData("https://www.google.com/test")]
    [InlineData("https://www.google.com/test/test1?q=123")]
    [InlineData("https://example.org/test/test1?search=test-question#part2")]
    [InlineData("file://website.com/pathtofile/intro.pdf")]
    [InlineData("mailto:abc@iwgplc.com")]
    public void UrlFromString_ShouldBe_Validated(string expected)
    {
        var actual = Url.From(expected);
        actual.Value.AbsoluteUri.Should().Be(expected);
    }

    [Theory]
    [InlineData("abc://www.google.com/")]
    public void BadUri_Should_ThrowException(string input)
    {
        var uri = new System.Uri(input);
        Action init = () => { Url.From(uri); };

        init.Should().Throw<TypeValidationException>().And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value",
            $"Could not create a Nox Url type as value {input} is not a valid Url.")
        });
    }

    [Theory]
    [InlineData("www.com")]
    [InlineData("wwwgooglecom")]
    [InlineData("www.googlecom")]
    [InlineData("wwwgoogle/com")]
    [InlineData("abc://www.google.com/")]
    public void BadUrl_Should_ThrowException(string input)
    {
        Action init = () => { Url.From(input); };

        init.Should().Throw<TypeValidationException>().And.Errors.Should().BeEquivalentTo(new[] { new ValidationFailure("Value",
            $"Could not create a Nox Url type as value {input} is not a valid Url.")
        });
    }
}