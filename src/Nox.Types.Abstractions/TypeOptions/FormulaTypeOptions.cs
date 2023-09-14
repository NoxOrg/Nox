namespace Nox.Types;

public class FormulaTypeOptions : INoxTypeOptions
{
    public string Expression { get; set; } = null!;
    public FormulaReturnType Returns { get; set; } = FormulaReturnType.@string;
}
