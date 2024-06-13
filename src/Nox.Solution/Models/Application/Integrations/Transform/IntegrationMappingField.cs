using Nox.Yaml.Attributes;

namespace Nox.Solution;

[Title("Definition namespace for integration mapping fields.")]
[Description("This section details integration transformation mapping field attributes like Name and Type.")]
[AdditionalProperties(false)]
public class IntegrationMappingField
{
    [Title("The name of the field.")]
    [Description("Specify the name of the field. For json and xml files it refers to the attribute name. For csv files must start at Column1 and end at the last column to be imported. For xlsx files it refers to the column heading.")]
    public string? Name { get; set; } = null!;

    [Title("The data type of the field")]
    [Description("Specify the data type of the field. Valid values are integer, double, bool, string, date, time, datetime, guid")]
    public IntegrationMapDataType? Type { get; set; } = null!;
}