using System.Collections.Generic;
using System.Linq;
using Nox.Common;

namespace Nox.Types;

/// <summary>
/// Enumeration for image format types.
/// </summary>
public sealed class ImageFormatType : Enumeration<IList<string>>
{
    /// <summary>
    /// Represents the "All" image format type, including various image file extensions.
    /// </summary>
    public static readonly ImageFormatType All = new(0, nameof(All), new List<string>
    {
        ".jpg",
        ".jpeg",
        ".png",
        ".gif",
        ".bmp",
        ".webp",
        ".svg",
        ".tiff",
        ".ico",
        ".tif"
    });

    /// <summary>
    /// Represents the "Jpeg" image format type, including the ".jpg" and ".jpeg" file extensions.
    /// </summary>
    public static readonly ImageFormatType Jpeg = new(1, nameof(Jpeg), new List<string>
    {
        ".jpg",
        ".jpeg"
    });

    /// <summary>
    /// Represents the "Png" image format type, including the ".png" file extension.
    /// </summary>
    public static readonly ImageFormatType Png = new(2, nameof(Png), new List<string>
    {
        ".png"
    });

    /// <summary>
    /// Represents the "Gif" image format type, including the ".gif" file extension.
    /// </summary>
    public static readonly ImageFormatType Gif = new(3, nameof(Gif), new List<string>
    {
        ".gif"
    });

    /// <summary>
    /// Represents the "Bmp" image format type, including the ".bmp" file extension.
    /// </summary>
    public static readonly ImageFormatType Bmp = new(4, nameof(Bmp), new List<string>
    {
        ".bmp"
    });

    /// <summary>
    /// Represents the "Webp" image format type, including the ".webp" file extension.
    /// </summary>
    public static readonly ImageFormatType Webp = new(5, nameof(Webp), new List<string>
    {
        ".webp"
    });

    /// <summary>
    /// Represents the "Svg" image format type, including the ".svg" file extension.
    /// </summary>
    public static readonly ImageFormatType Svg = new(6, nameof(Svg), new List<string>
    {
        ".svg"
    });

    /// <summary>
    /// Represents the "Tiff" image format type, including the ".tiff" file extension.
    /// </summary>
    public static readonly ImageFormatType Tiff = new(7, nameof(Tiff), new List<string>
    {
        ".tiff"
    });

    /// <summary>
    /// Represents the "Ico" image format type, including the ".ico" file extension.
    /// </summary>
    public static readonly ImageFormatType Ico = new(8, nameof(Ico), new List<string>
    {
        ".ico"
    });

    /// <summary>
    /// Represents the "Tif" image format type, including the ".tif" file extension.
    /// </summary>
    public static readonly ImageFormatType Tif = new(9, nameof(Tif), new List<string>
    {
        ".tif"
    });

    /// <summary>
    /// Initializes a new instance of the <see cref="ImageFormatType"/> class with the specified ID, name, and value.
    /// </summary>
    /// <param name="id">The ID of the image format type.</param>
    /// <param name="name">The name of the image format type.</param>
    /// <param name="value">The value of the image format type.</param>
    private ImageFormatType(int id, string name, IList<string> value) : base(id, name, value)
    {

    }
    
    
    /// <summary>
    /// Retrieves the supported image format type extensions from the <see cref="ImageTypeOptions"/>.
    /// <param name="imageFormatTypes">The image format types.</param>
    /// </summary>
    /// <returns>An enumerable collection of strings representing the supported image format type extensions.</returns>
    internal static IList<string> GetSupportedFormatTypeExtension( List<ImageFormatType> imageFormatTypes)
    {
        return imageFormatTypes.Exists(ft=>ft == All) ? All.Value : imageFormatTypes.SelectMany(ft => ft.Value).ToList();
    }
}