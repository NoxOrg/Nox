using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("The definition namespace for secrets used in a Nox solution.")]
    [Description("Specify properties pertinent to secrets as configured within a Nox solution here. Examples include servers and validity period.")]
    [AdditionalProperties(false)]
    public class Secrets
    {
        public SecretsServer? SecretsServer { get; internal set; }
        public SecretsValidFor? ValidFor { get; internal set; }
    }
}