using System;
using System.Collections.Generic;
using System.Linq;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

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
    public IReadOnlyList<ImageFormatType> ImageFormatTypes { get; set; } = new List<ImageFormatType> { DefaultFormatType };

}