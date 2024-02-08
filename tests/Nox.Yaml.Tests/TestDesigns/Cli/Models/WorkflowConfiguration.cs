namespace Nox.Yaml.Tests.TestDesigns.Cli.Models;

public class WorkflowConfiguration: YamlConfigNode<WorkflowConfiguration>
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public CliConfiguration Cli { get; set; } = null!;
    public List<JobConfiguration> Jobs { get; set; } = new();
}