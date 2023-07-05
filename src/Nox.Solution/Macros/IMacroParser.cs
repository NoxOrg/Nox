namespace Nox.Solution.Macros;

public interface IMacroParser
{
    /// <summary>
    /// Looks and Expands Macros found in the Text
    /// </summary>
    string Parse(string text);
}