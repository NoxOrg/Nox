using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework;

public class ColorConverter : ValueConverter<Nox.Types.Color, byte[]>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ColorConverter" /> class.
    /// </summary>
    public ColorConverter() : base(color => color.Value, colorValue => Nox.Types.Color.FromDatabase(colorValue)) { }
}