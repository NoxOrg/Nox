using Nox.Yaml.Attributes;

namespace Nox.Yaml.Tests.TestDesigns.Sample.Models;

[GenerateJsonSchema]
[Title("Sample address class title")]
[Description("Sample address class description")]
[AdditionalProperties(false)]
public class SampleAddress
{
    [Required]
    public string Line1 { get; set; } = default!;

    public string Line2 { get; set; } = default!;

    public string City { get; set; } = default!;

    [Required]
    public string Country { get; set; } = default!;

    [Required]
    public string PostCode { get; set; } = default!;
}
