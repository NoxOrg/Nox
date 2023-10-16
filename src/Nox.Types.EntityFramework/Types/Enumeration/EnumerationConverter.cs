using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

/// <summary>
/// The enumeration converter.
/// </summary>
public class EnumerationConverter : ValueConverter<Enumeration, int>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EnumerationConverter"/> class.
    /// </summary>
    public EnumerationConverter() : base(id => id.Value, id => Enumeration.FromDatabase(id)) { }
}
