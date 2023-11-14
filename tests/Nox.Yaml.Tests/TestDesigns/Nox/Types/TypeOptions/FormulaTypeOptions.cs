using Nox.Yaml.Tests.TestDesigns.Nox.Types.Enums;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.Interfaces;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeOptions;

public class FormulaTypeOptions : INoxTypeOptions
{
    public string Expression { get; set; } = null!;
    public FormulaReturnType Returns { get; set; } = FormulaReturnType.@string;
}
