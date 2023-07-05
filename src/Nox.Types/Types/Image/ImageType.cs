using System.Collections.Generic;

namespace Nox.Types;

internal static class ImageType
{
    internal static IList<string> AllowedExtensions { get; } = new List<string>
    {
        ".jpg",
        ".jpeg",
        ".png",
        ".gif",
        ".bmp",
        ".webp",
        ".svg",
        ".tif",
        ".tiff",
        ".ico"
    };
}
