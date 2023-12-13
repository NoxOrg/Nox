using Nox.Yaml.Attributes;
using Nox.Yaml.Tests.TestDesigns.Nox.Types.TypeDefinitions;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[Title("Definition namespace for a file type integration target.")]
[Description("This section specified attributes related to an integration target of type File. Attributes include the name of the file to create.")]
[AdditionalProperties(false)]
public class IntegrationTargetFileOptions
{
    [Required]
    [Title("The file name.")]
    [Description("The name of the file that will be created.")]
    public string Filename { get; set; } = null!;

    [Required]
    [Title("The attributes of the target file record.")]
    [Description("One or more attributes describing the composition of the target file record.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<NoxSimpleTypeDefinition> RecordAttributes { get; internal set; } = new List<NoxSimpleTypeDefinition>();
}