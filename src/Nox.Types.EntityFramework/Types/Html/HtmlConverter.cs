using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class HtmlConverter : ValueConverter<Html, string>
{
    public HtmlConverter() : base(html => html.Value, htmlValue => Html.FromDatabase(htmlValue)) { }
}