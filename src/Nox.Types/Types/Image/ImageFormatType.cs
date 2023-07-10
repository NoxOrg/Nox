using System;
using System.Collections.Generic;

namespace Nox.Types;

/// <summary>
/// Represents the format type of an image.
/// </summary>
public enum ImageFormatType
{
    All = 0,
    Jpeg = 1,
    Png = 2,
    Gif = 3,
    Bmp = 4,
    Webp = 5,
    Svg = 6,
    Tif = 7,
    Tiff = 8,
    Ico = 9
}

/// <summary>
/// Provides methods for working with image format types.
/// </summary>
internal static class ImageFormat
{
    
    /// <summary>
    /// Gets the file extension of the image format type.
    /// </summary>
    /// <param name="formatType">The image format type.</param>
    /// <returns>The file extension of the image format type.</returns>
    internal static string GetExtensionFromFormatType(ImageFormatType formatType)
    {
        return formatType switch
        {
            ImageFormatType.Jpeg => ".jpeg",
            ImageFormatType.Png => ".png",
            ImageFormatType.Gif => ".gif",
            ImageFormatType.Bmp => ".bmp",
            ImageFormatType.Webp => ".webp",
            ImageFormatType.Svg => ".svg",
            ImageFormatType.Tiff => ".tiff",
            ImageFormatType.Ico => ".ico",
            ImageFormatType.Tif => ".tif",
            _ => throw new ArgumentOutOfRangeException(nameof(formatType), formatType, null)
        };
    }
    
    /// <summary>
    /// The list of allowed image format type extensions.
    /// </summary>
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