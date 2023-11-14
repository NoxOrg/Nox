using Nox.Yaml.Attributes;

namespace Nox.Yaml.Tests.TestDesigns.Sample.Models;

[GenerateJsonSchema]
[Title("Sample address class title")]
[Description("Sample address class description")]
[AdditionalProperties(false)]
public class SamplePhoneNumber
{
    [Required]
    public string FirstName { get; set; } = default!;

    [Required]
    public string LastName { get; set; } = default!;

    [Required]
    public string PhoneType { get; set; } = default!;

    [Required]
    public string PhoneNumber { get; set; } = default!;

    [Required]
    public Guid GlobalId { get; set; } = default!;

    [Required]
    public Uri Website { get; set; } = default!;

    [Required]
    public TimeSpan LastSessionDuration { get; set; } = default!;
}
