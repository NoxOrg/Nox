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
    [Title("The file name.")]
    [Description("The name of the file that will be ingested.")]
    public string Filename { get; set; } = null!;
   
}