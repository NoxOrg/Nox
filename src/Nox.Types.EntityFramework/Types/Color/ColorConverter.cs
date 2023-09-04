using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework;

public class ColorConverter : ValueConverter<Color, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ColorConverter" /> class.
    /// </summary>
    public ColorConverter() : base(color => color.Value, colorValue => Color.FromDatabase(colorValue)) { }
}