using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class PercentageConverter : ValueConverter<Percentage, float>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PercentageConverter" /> class.
    /// </summary>
    public PercentageConverter() : base(percentage => percentage.Value, percentageValue => Percentage.From(percentageValue))
    {
    }
}
