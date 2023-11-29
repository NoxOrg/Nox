using Microsoft.AspNetCore.Http;
using Nox.Exceptions;
using System.Net;
using System.Net.Http.Headers;

namespace Nox.Extensions;

public static class HttpRequestExtensions
{
    public static Guid GetDecodedEtagHeader(this HttpRequest request)
    {
        var ifMatchValue = request.Headers.IfMatch.FirstOrDefault();

        if (string.IsNullOrEmpty(ifMatchValue))
        {
            throw new ConcurrencyException("ETag is empty. ETag should be provided via the If-Match HTTP Header.", HttpStatusCode.PreconditionRequired);
        }
        //If the ETag is a guid then we can use it directly.
        if (Guid.TryParse(ifMatchValue, out var etag))
        {
            return etag;
        }
        //ETag needs to follow Tag header conventions
        if (EntityTagHeaderValue.TryParse(ifMatchValue, out var encodedEtag))
        {
            var rawEtag = encodedEtag.Tag.Trim('\"');
            if (Guid.TryParse(rawEtag, out etag))
            {
                return etag;
            }
        }

        throw new ConcurrencyException("ETag is not well-formed.", HttpStatusCode.PreconditionFailed);
    }
}