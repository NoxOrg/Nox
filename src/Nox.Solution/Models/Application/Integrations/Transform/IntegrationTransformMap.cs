using Nox.Yaml.Attributes;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("Definition namespace for attributes describing the transformation mapping of a field.")]
[Description("This section details integration transformation mapping attributes like sourceName, sourceType, targetType.")]
[AdditionalProperties(false)]
public class IntegrationTransformMap
{
    [Title("The name of the source attribute. If omitted the target field will be considered a calculated value.")]
    [Description("Specify the name of the source field. For json and xml files it refers to the attribute name. For csv files must start at Column1 and end at the last column to be imported. For xlsx files it refers to the column heading.")]
    public string? SourceName { get; set; } = null!;

    [Title("The data type of the source field")]
    [Description("Specify the data type of the source field. Valid values are integer, double, bool, string, date, time, datetime, guid")]
    public IntegrationMapDataType? SourceType { get; set; } = null!;

    [Required]
    [Title("The data type of the target field")]
    [Description("Specify the data type of the target field. Valid values are integer, double, bool, string, date, time, datetime, guid")]
    public IntegrationMapDataType TargetType { get; set; }
}