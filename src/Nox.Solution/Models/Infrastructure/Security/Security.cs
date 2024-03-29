using Nox.Yaml.Attributes;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("The definition namespace for security settings pertaining to a Nox solution.")]
[Description("Define security settings pertinent to a Nox solution here. These may include secrets among other.")]
[AdditionalProperties(false)]
public class Security
{
    public Secrets? Secrets { get; internal set; }

    public UserIdentity? UserIdentity { get; internal set; }
}