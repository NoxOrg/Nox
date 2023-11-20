using Nox.Yaml.Attributes;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("The definition namespace for the UI localization server used in a Nox solution.")]
[Description("Specify properties for the user interface localization and translation server here. Examples include name, serverUri, Port and connection credentials")]
[AdditionalProperties(false)]
public class UiLocalizations: DatabaseServer
{
}