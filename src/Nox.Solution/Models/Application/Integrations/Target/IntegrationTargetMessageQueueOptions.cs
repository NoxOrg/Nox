using Nox.Solution.Schema;

namespace Nox.Solution;

public class IntegrationTargetMessageQueueOptions
{
    [Required]
    [Title("The target name.")]
    [Description("The name of the queue, topic or subscription to which messages will be sent.")]
    public string TargetName { get; set; } = null!;
}