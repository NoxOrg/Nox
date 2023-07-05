using Nox.Solution.Utils;

namespace Nox.Solution.Macros;

public static class MacroParser
{
    public static readonly IMacroParser[] Defaults = new IMacroParser[]{new EnvironmentVariableMacroParser(new EnvironmentProvider())};
}