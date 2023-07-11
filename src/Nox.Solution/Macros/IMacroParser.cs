using System.Collections.Generic;

namespace Nox.Solution.Macros;

public interface IMacroParser
{
    /// <summary>
    /// Looks and Expands Macros found in the Text
    /// </summary>
    string Parse(string text, IReadOnlyDictionary<string, string>? locals = null);
}