using Nox.Types.Schema;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("The definition namespace for the translation server used in a Nox solution.")]
[Description("Specify properties pertinent to the solution translation server here. Examples include name, serverUri, Port and connection credentials")]
[AdditionalProperties(false)]
public class Translations: ServerBase
{
    
}