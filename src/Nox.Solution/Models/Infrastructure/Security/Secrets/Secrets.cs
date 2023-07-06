using System.Security.Permissions;
using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("The definition namespace for secrets used in a Nox solution.")]
    [Description("Specify properties pertinent to secrets as configured within a Nox solution here. Examples include servers and validity period.")]
    [AdditionalProperties(false)]
    public class Secrets
    {
        
        [Title("The organization secrets server.")]
        [Description("Specify the provider and server attributes for secrets stored at an organizational level (org.secret.<secret_key>).")]
        [AdditionalProperties(false)]
        public SecretsServer? OrgSecretsServer { get; internal set; }
        
        [Title("The solution secrets server.")]
        [Description("Specify the provider and server attributes for secrets stored at a solution level (solution.secret.<secret_key>).")]
        [AdditionalProperties(false)]
        public SecretsServer? SolutionSecretsServer { get; internal set; }
    }
}