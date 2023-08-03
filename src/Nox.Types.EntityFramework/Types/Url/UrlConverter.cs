using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class UrlConverter : ValueConverter<Url, string>
{
    public UrlConverter() : base(url => url.Value.AbsoluteUri, url => Url.FromDatabase(url)) { }
}
