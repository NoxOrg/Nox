using System.Collections.Generic;
using Nox.Types;
using Nox.Yaml.Attributes;

namespace Nox.Solution;

[Title("Definition namespace for a file type integration source.")]
[Description("This section specified attributes related to an integration source of type File. Attributes include the name and attributes of the file to ingest.")]
[AdditionalProperties(false)]
public class IntegrationSourceFileOptions
{
    [Required]
    [Title("The file uri.")]
    [Description("The URI of the file that will be ingested. Supported URI schemes are file, https, blob")]
    public string FileUri { get; set; } = null!;
    
    [Required]
    [Title("The attributes of the source file record.")]
    [Description("One or more attributes describing the composition of the source file record.")]
    [AdditionalProperties(false)]
    public IReadOnlyList<NoxSimpleTypeDefinition> RecordAttributes { get; internal set; } = new List<NoxSimpleTypeDefinition>();
}