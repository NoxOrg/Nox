using Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.Extensions;

internal static class ImageFormatTypeExtensions
{
    internal static IEnumerable<string> SupportedExtensions(this ImageFormatType imageFormatType)
    {
        return imageFormatType switch
        {
            ImageFormatType.All => new List<string>
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
            },
            ImageFormatType.Jpeg => new List<string> { ".jpg", ".jpeg" },
            ImageFormatType.Png => new List<string> { ".png" },
            ImageFormatType.Bmp => new List<string> { ".bmp" },
            ImageFormatType.Gif => new List<string> { ".gif" },
            ImageFormatType.Ico => new List<string> { ".ico" },
            ImageFormatType.Svg => new List<string> { ".svg" },
            ImageFormatType.Webp => new List<string> { ".webp" },
            ImageFormatType.Tiff => new List<string> { ".tiff", ".tif" },
            _ => throw new InvalidOperationException($"The image format type '{imageFormatType}' is not supported.")
        };
    }

    internal static IEnumerable<string> SupportedExtensions(this IEnumerable<ImageFormatType> imageFormatTypes)
    {
        var formatTypes = imageFormatTypes.ToList();
        var result = formatTypes.Exists(ft => ft == ImageFormatType.All) ? ImageFormatType.All.SupportedExtensions() : formatTypes.SelectMany(imageFormatType => imageFormatType.SupportedExtensions()).ToList();
        return result;
    }
}