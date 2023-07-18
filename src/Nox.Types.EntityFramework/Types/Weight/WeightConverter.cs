using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class WeightToPoundsConverter : ValueConverter<Weight, double>
{
    public WeightToPoundsConverter() : base(weight => (double)weight.ToPounds(), weightValue => Weight.FromPounds(weightValue)) { }
}
public class WeightToKilogramsConverter : ValueConverter<Weight, double>
{
    public WeightToKilogramsConverter() : base(weight => (double)weight.ToKilograms(), weightValue => Weight.FromKilograms(weightValue)) { }
}
