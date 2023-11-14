using Nox.Yaml.Attributes;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[AdditionalProperties(false)]
public enum VersionControlProvider
{
    AzureDevops
}

[GenerateJsonSchema]
[Title("Source code repository and related info for the solution.")]
[Description("Contains information about where source code is kept and the folders of the main components thereof.")]
[AdditionalProperties(false)]
public class VersionControl
{
    [Required]
    [Title("The source code and repository provider or service.")]
    [Description("The name of the provider or service for source code and version control")]
    [Pattern(@"^[^\s]*$")]
    public VersionControlProvider Provider { get; internal set; } = VersionControlProvider.AzureDevops;

    [Required]
    [Title("The URI for the host of the version control service.")]
    [Description("The URI for the person or organization's projects and repositories. Usually https://dev.azure.com/<organization>")]
    [Pattern(@"^[^\s]*$")]
    public Uri Host { get; internal set; } = new Uri("https://noxorg.dev");

    // These descriptors should be moved to the class when the generator is fixed
    [Title("A list of well-known folders pertaining to version control for the solution.")]
    [Description("The relative path to source code, tests, containers and other well-known code assets.")]
    [AdditionalProperties(false)]
    public VersionControlFolders? Folders { get; internal set; }

    [Title("Overrides repository name for Nox solution.")]
    [Description("Can be set when the repository name in DevOps is something different to the Nox convension. If it left undefined, Nox must default it to {Solution.Name}.v{solution.version}")]
    public string? RepositoryName { get; internal set; }
}