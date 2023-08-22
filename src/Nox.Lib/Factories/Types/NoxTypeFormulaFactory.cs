using Nox.Solution;
using Nox.Types;

namespace Nox.Factories.Types;

public class NoxTypeFormulaFactory : NoxTypeFactoryBase<Formula>
{
    public NoxTypeFormulaFactory(NoxSolution solution) : base(solution)
    {
    }

    public override Formula? CreateNoxType(NoxSimpleTypeDefinition simpleTypeDefinition, dynamic? value)
    {
        if (value == null)
        {
            return null;
        }

        var formulaValue = simpleTypeDefinition.FormulaTypeOptions ?? new FormulaTypeOptions();
        formulaValue.Expression = value;

        return Formula.From(formulaValue);
    }
}