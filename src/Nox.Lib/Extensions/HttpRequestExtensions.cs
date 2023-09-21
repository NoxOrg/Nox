using Microsoft.AspNetCore.Http;

using System.Net.Http.Headers;

namespace Nox.Extensions;

public static class HttpRequestExtensions
{
    public static System.Guid? GetDecodedEtagHeader(this HttpRequest request)
    {
        var ifMatchValue = request.Headers.IfMatch.FirstOrDefault();
        string? rawEtag = ifMatchValue;

        if (EntityTagHeaderValue.TryParse(ifMatchValue, out var encodedEtag))
        {
            rawEtag = encodedEtag.Tag.Trim('\"');
        }

        return System.Guid.TryParse(rawEtag, out var etag) ? etag : null;
    }
}