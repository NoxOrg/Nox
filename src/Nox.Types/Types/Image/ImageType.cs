using System.Collections.Generic;

namespace Nox.Types;

public static class ImageType
{
    public static IList<string> AllowedExtensions { get; } = new List<string>
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
