using Json.Schema.Generation;

namespace Nox.Solution;

public class IntegrationTargetFileOptions
{
    [Required]
    [Title("The file name.")]
    [Description("The name of the file that will be created.")]
    public string Filename { get; set; } = null!;
}