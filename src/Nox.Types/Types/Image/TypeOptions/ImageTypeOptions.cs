using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Types;

/// <summary>
/// Represents the options for image types.
/// </summary>
public class ImageTypeOptions
{
    private static ImageFormatType DefaultFormatType => ImageFormatType.All;

    /// <summary>
    /// Gets or sets the format types of the image.
    /// </summary>
    public List<ImageFormatType> ImageFormatTypes { get; set; } = new() { DefaultFormatType };

    /// <summary>
    /// Retrieves the supported image format type extensions based on the configured format types.
    /// </summary>
    /// <returns>A list of supported image format type extensions.</returns>
    internal IList<string> GetSupportedImageFormatTypeExtensions()
    {
        var result = ImageFormatTypes.Contains(ImageFormatType.All)
            ? AllowedExtensions
            : ImageFormatTypes.Select(GetExtensionFromFormatType).ToList();

        if (result.Contains(".jpeg") && !result.Contains(".jpg"))
            result.Add(".jpg");

        return result;
    }

    private static IList<string> AllowedExtensions { get; } = new List<string>
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

    private static string GetExtensionFromFormatType(ImageFormatType formatType)
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
            _ => throw new NotImplementedException($"No extension defined for format type {formatType}.")
        };
    }
}