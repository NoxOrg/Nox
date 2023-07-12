using System;
using System.Collections.Generic;
using System.Linq;

namespace Nox.Types;

/// <summary>
/// Represents the options for image types.
/// </summary>
public class ImageTypeOptions
{
    /// <summary>
    /// Default format type.
    /// </summary>
    private static ImageFormatType DefaultFormatType => ImageFormatType.All;

    /// <summary>
    /// Gets or sets the format types of the image.
    /// </summary>
    public List<ImageFormatType> ImageFormatTypes { get; set; } = new() { DefaultFormatType };
    
}