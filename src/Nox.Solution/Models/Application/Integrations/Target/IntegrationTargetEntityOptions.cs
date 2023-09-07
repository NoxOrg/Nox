using Nox.Types.Schema;

namespace Nox.Solution;

public class IntegrationTargetEntityOptions
{
    [Required]
    [Title("The entity name.")]
    [Description("The name of the entity that will be synchronized.")]
    public string Entity { get; set; } = null!;
}