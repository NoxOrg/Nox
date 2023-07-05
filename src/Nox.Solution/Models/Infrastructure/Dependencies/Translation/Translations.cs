using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("The definition namespace for the translation server used in a Nox solution.")]
    [Description("Specify properties pertinent to the solution translation server here. Examples include name, serverUri, Port and connection credentials")]
    [AdditionalProperties(false)]
    public class Translations: ServerBase
    {
        
    }
}