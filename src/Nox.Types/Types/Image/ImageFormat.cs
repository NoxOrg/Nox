using System.Collections.Generic;
using System.Linq;
using Nox.Types.Common;

namespace Nox.Types;

public enum ImageFormatType
{
    /// <summary>
    /// Represents all image format types.
    /// </summary>
    All,

    /// <summary>
    /// Represents the JPEG image format.
    /// </summary>
    Jpeg,

    /// <summary>
    /// Represents the PNG image format.
    /// </summary>
    Png,

    /// <summary>
    /// Represents the GIF image format.
    /// </summary>
    Gif,

    /// <summary>
    /// Represents the BMP image format.
    /// </summary>
    Bmp,

    /// <summary>
    /// Represents the WebP image format.
    /// </summary>
    Webp,

    /// <summary>
    /// Represents the SVG image format.
    /// </summary>
    Svg,

    /// <summary>
    /// Represents the TIFF image format.
    /// </summary>
    Tiff,

    /// <summary>
    /// Represents the ICO image format.
    /// </summary>
    Ico,
}



/// <summary>
/// Custom enumeration for image format.
/// </summary>
internal sealed class ImageFormat : Enumeration
{
    /// <summary>
    /// Gets the list of file extensions associated with the image format type.
    /// </summary>
    public List<string> Extensions { get; }
    
    /// <summary>
    /// Represents the "All" image format, including various image file extensions.
    /// </summary>
    public static readonly ImageFormat All = new(0, nameof(All), new List<string>
    {
        ".jpg",
        ".jpeg",
        ".png",
        ".gif",
        ".bmp",
        ".webp",
        ".svg",
        ".tiff",
        ".tif",
        ".ico",
    });

    /// <summary>
    /// Represents the "Jpeg" image format, including the ".jpg" and ".jpeg" file extensions.
    /// </summary>
    public static readonly ImageFormat Jpeg = new(1, nameof(Jpeg), new List<string>
    {
        ".jpg",
        ".jpeg"
    });

    /// <summary>
    /// Represents the "Png" image format, including the ".png" file extension.
    /// </summary>
    public static readonly ImageFormat Png = new(2, nameof(Png), new List<string>
    {
        ".png"
    });

    /// <summary>
    /// Represents the "Gif" image format, including the ".gif" file extension.
    /// </summary>
    public static readonly ImageFormat Gif = new(3, nameof(Gif), new List<string>
    {
        ".gif"
    });

    /// <summary>
    /// Represents the "Bmp" image format, including the ".bmp" file extension.
    /// </summary>
    public static readonly ImageFormat Bmp = new(4, nameof(Bmp), new List<string>
    {
        ".bmp"
    });

    /// <summary>
    /// Represents the "Webp" image format, including the ".webp" file extension.
    /// </summary>
    public static readonly ImageFormat Webp = new(5, nameof(Webp), new List<string>
    {
        ".webp"
    });

    /// <summary>
    /// Represents the "Svg" image format, including the ".svg" file extension.
    /// </summary>
    public static readonly ImageFormat Svg = new(6, nameof(Svg), new List<string>
    {
        ".svg"
    });

    /// <summary>
    /// Represents the "Tiff" image format, including the ".tiff" and ".tif" file extensions.
    /// </summary>
    public static readonly ImageFormat Tiff = new(7, nameof(Tiff), new List<string>
    {
        ".tiff",
        ".tif",
    });

    /// <summary>
    /// Represents the "Ico" image format, including the ".ico" file extension.
    /// </summary>
    public static readonly ImageFormat Ico = new(8, nameof(Ico), new List<string>
    {
        ".ico"
    });

    /// <summary>
    /// Initializes a new instance of the <see cref="ImageFormat"/> class with the specified ID, name, and value.
    /// </summary>
    /// <param name="id">The ID of the image format.</param>
    /// <param name="name">The name of the image format.</param>
    /// <param name="extensions">The list of file extensions associated with the image format.</param>
    private ImageFormat(int id, string name, IEnumerable<string> extensions) : base(id, name)
    {
        Extensions = extensions.ToList();
    }
    
    
    /// <summary>
    /// Returns an enumerable collection of strings representing the supported image format extensions.
    /// <param name="imageFormatTypes">The image format types.</param>
    /// </summary>
    /// <returns>An enumerable collection of strings representing the supported image format extensions.</returns>
    internal static IList<string> GetSupportedFormatTypeExtension( List<ImageFormatType> imageFormatTypes)
    {
        return imageFormatTypes.Exists(ft=>ft == ImageFormatType.All) ? All.Extensions : imageFormatTypes.SelectMany(ft => FromId<ImageFormat>((int)ft).Extensions).ToList();
    }
}