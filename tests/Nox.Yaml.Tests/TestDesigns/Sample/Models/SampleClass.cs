using Nox.Yaml.Attributes;

namespace Nox.Yaml.Tests.TestDesigns.Sample.Models;

[GenerateJsonSchema]
[Title("Sample class title")]
[Description("Sample class description")]
[AdditionalProperties(false)]
public class SampleClass : YamlConfigNode<SampleClass,SampleClass>
{
    [Required]
    [Title("Sample string property title")]
    [Description("Sample string property description")]
    [Pattern(Constants.YamlVariableRegex)]
    public string SampleString { get; set; } = default!;

    [Title("Sample int property title")]
    [Description("Sample int property description")]
    public int SampleInt { get; set; } = default!;

    [Title("Sample number property title")]
    [Description("Sample number property description")]
    public int SampleNumber { get; set; } = default!;

    [Title("Sample bool property title")]
    [Description("Sample bool property description")]
    public bool SampleBool { get; set; } = default!;

    [Title("Sample date property title")]
    [Description("Sample date property description")]
    public DateTime SampleDate { get; set; } = default!;

    [Title("Sample string array property title")]
    [Description("Sample string array property description")]
    public IReadOnlyList<string> SampleStringArray { get; set; } = default!;

    [Required]
    [Title("Sample string enum property title")]
    [Description("Sample string enum property description")]
    public SampleEnum SampleEnum { get; set; } = default!;

    [Title("Sample address object property title")]
    [Description("Sample address object property description")]
    public SampleAddress Address { get; set; } = default!;

    [Title("Sample dictionary property title")]
    [Description("Sample dictionary property description")]
    public IReadOnlyDictionary<string, string> SampleDictionary { get; set; } = default!;

    [Title("Sample address object list property title")]
    [Description("Sample address object list property description")]
    public IReadOnlyList<SampleAddress> SampleObjectArray { get; set; } = default!;

    [Title("Sample phone number object list property title")]
    [Description("Sample phone number object list property description")]
    public IReadOnlyList<SamplePhoneNumber> SampleObjectArray2 { get; set; } = default!;

}


