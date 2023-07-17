using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class WeightToPoundConverter : ValueConverter<Weight, double>
{
    public WeightToPoundConverter() : base(weight => (double)weight.ToPounds(), weightValue => Weight.FromPounds(weightValue)) { }
}
public class WeightToKilogramConverter : ValueConverter<Weight, double>
{
    public WeightToKilogramConverter() : base(weight => (double)weight.ToKilograms(), weightValue => Weight.FromKilograms(weightValue)) { }
}
