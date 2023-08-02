using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using Nox.Enums;

namespace Nox.Types.EntityFramework.Types;

public class WeightToPoundsConverter : ValueConverter<Weight, decimal>
{
    public WeightToPoundsConverter() : base(weight => (decimal)weight.ToPounds(), weightValue => Weight.FromDatabase(weightValue, WeightTypeUnit.Pound)) { }
}
public class WeightToKilogramsConverter : ValueConverter<Weight, decimal>
{
    public WeightToKilogramsConverter() : base(weight => (decimal)weight.ToKilograms(), weightValue => Weight.FromDatabase(weightValue, WeightTypeUnit.Kilogram)) { }
}
