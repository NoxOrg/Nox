using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Nox.Types.EntityFramework.Types;

public class FormulaConverter : ValueConverter<Formula, string>
{
    public FormulaConverter() : base(formula => formula.Value, formulaValue => Formula.From(formulaValue)) { }
}