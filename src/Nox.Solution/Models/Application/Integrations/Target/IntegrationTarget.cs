using Nox.Yaml;
using Nox.Yaml.Attributes;
using Nox.Yaml.Validation;
using System.Linq;

namespace Nox.Solution;

[GenerateJsonSchema]
[Title("Definition namespace for attributes describing the target component of an integration integration.")]
[Description("This section details integration target attributes like name, description and type among other.")]
[AdditionalProperties(false)]
public class IntegrationTarget : YamlConfigNode<NoxSolution, Integration>
{
    [Required]
    [Title("The name of the ETL target. Contains no spaces.")]
    [Description("The name of the ETL target. It should be a commonly used singular noun and be unique within a solution.")]
    [Pattern(Nox.Yaml.Constants.StringWithNoSpacesRegex)]
    public string Name { get; internal set; } = null!;

    [Title("The description of the ETL target.")]
    [Description("A phrase describing the ETL target.")]
    public string? Description { get; internal set; }

    [Required]
    [Title("The type of target.")]
    [Description("Specify the type of target. Options include entity, database, file, webAPI and message queue.")]
    public IntegrationTargetAdapterType TargetAdapterType { get; internal set; } = default;

    [Required]
    [Title("The name of the integration target data connection. Contains no spaces.")]
    [Description("The name should be a commonly used singular noun and be unique within a solution.")]
    [Pattern(Yaml.Constants.StringWithNoSpacesRegex)]
    [AdditionalProperties(false)]
    public string DataConnectionName { get; internal set; } = null!;

    [IfEquals(nameof(TargetAdapterType), IntegrationTargetAdapterType.DatabaseTable)]
    [Required]
    [AdditionalProperties(false)]
    public IntegrationTargetTableOptions? TableOptions { get; set; }
    
    [IfEquals(nameof(TargetAdapterType), IntegrationTargetAdapterType.MessageBroker)]
    [Required]
    [AdditionalProperties(false)]
    public IntegrationTargetMessageBrokerOptions? MessageBrokerOptions { get; set; }

    /*
    [IfEquals(nameof(TargetAdapterType), IntegrationTargetAdapterType.File)]
    [Required]
    [AdditionalProperties(false)]
    public IntegrationTargetFileOptions? FileOptions { get; set; }

    [IfEquals(nameof(TargetAdapterType), IntegrationTargetAdapterType.WebApi)]
    [Required]
    [AdditionalProperties(false)]
    public IntegrationTargetWebApiOptions? WebApiOptions { get; set; }

    [IfEquals(nameof(TargetAdapterType), IntegrationTargetAdapterType.Entity)]
    [Required]
    [AdditionalProperties(false)]
    public IntegrationTargetEntityOptions? EntityOptions { get; set; }
    */

    public override ValidationResult Validate(NoxSolution topNode, Integration parentNode, string yamlPath)
    {
        var result = base.Validate(topNode, parentNode, yamlPath);

        ValidateDataConnectionName(result, parentNode, topNode);

        return result;
    }

    private void ValidateDataConnectionName(ValidationResult result, Integration parentNode, NoxSolution topNode)
    {
        if (!topNode.DataConnections.Any(d => d.Name.Equals(DataConnectionName)))
        {
            result.Errors.Add(new ValidationFailure(
                DataConnectionName, $"Data connection [{DataConnectionName}] does not exist on integration [{parentNode.Name}]."
            ));
        }
    }
}