using System.Collections.Generic;

namespace Nox.Types;

/// <summary>
/// Represents the options for image types.
/// </summary>
public class ImageTypeOptions : INoxTypeOptions
{
    /// <summary>
    /// Default format type.
    /// </summary>
    private static ImageFormatType DefaultFormatType => ImageFormatType.All;

    /// <summary>
    /// Gets or sets the format types of the image.
    /// </summary>
    public  IReadOnlyList<ImageFormatType> ImageFormatTypes { get; set; } = new List<ImageFormatType>{ DefaultFormatType };
    
}