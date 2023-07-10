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
            ? ImageFormat.AllowedExtensions
            : ImageFormatTypes.Select(ImageFormat.GetExtensionFromFormatType).ToList();

        if (result.Contains(".jpeg") && !result.Contains(".jpg"))
            result.Add(".jpg");

        return result;
    }
}