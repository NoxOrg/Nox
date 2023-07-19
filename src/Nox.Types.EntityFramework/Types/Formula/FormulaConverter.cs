using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class FormulaConverter : ValueConverter<Formula, string>
{
    public FormulaConverter() : base(dt => dt.Value, dtValue => Formula.From(dtValue)) { }
}