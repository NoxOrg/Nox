using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class CultureCodeConverter : ValueConverter<CultureCode, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CultureCodeConverter" /> class.
    /// </summary>
    public CultureCodeConverter() : base(culture => culture.Value, cultureValue => CultureCode.From(cultureValue))
    {
    }
}