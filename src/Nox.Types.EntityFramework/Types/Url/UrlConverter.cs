using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class UrlConverter : ValueConverter<Url, System.Uri>
{
    public UrlConverter() : base(url => url.Value, url => Url.FromDatabase(url)) { }
}
