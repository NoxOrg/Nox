namespace Nox.Types.Tests.Types;

public class HtmlTests
{
    [Theory]
    [InlineData("<html></html>")]
    [InlineData("<HTML></HTML>")]
    [InlineData("<html  >text inside</html   >")]
    [InlineData("<HTML ><body>text inside</body ></HTML>")]
    public void Html_Constructor_WithValidInput_ReturnsSameValue(string htmlString)
    {
        var html = Html.From(htmlString);

        Assert.Equal(htmlString, html.Value);
    }

    [Theory]
    [InlineData("<html>")]
    [InlineData("</html>")]
    [InlineData("html/html")]
    [InlineData("<html>/<html>")]
    [InlineData("<body></body>")]
    [InlineData("plain text")]
    public void Html_Constructor_WithInvalidInput_ThrowsValidationException(string badHtmlString)
    {
        Assert.Throws<NoxTypeValidationException>(() => Html.From(badHtmlString));
    }
}