using Nox.Yaml.Attributes;

namespace Nox.Solution;

public class IntegrationSourceProcedureParameter
{
    [Required]
    [Title("Parameter name.")]
    [Description("The name of the database procedure parameter.")]
    public string Name { get; set; } = null!;

    [Required]
    [Title("Parameter Type.")]
    [Description("The type of the database procedure parameter. Note: this is database implementation specific.")]
    public string DataType { get; set; } = null!;
}