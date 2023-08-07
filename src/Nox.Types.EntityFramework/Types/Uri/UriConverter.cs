using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;
public class UriConverter : ValueConverter<Uri, string>
{
    public UriConverter() : base(uri => uri.Value.AbsoluteUri, uriValue => Uri.FromDatabase(uriValue)) { }
}