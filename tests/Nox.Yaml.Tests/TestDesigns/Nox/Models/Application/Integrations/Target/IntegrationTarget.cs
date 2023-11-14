using Nox.Yaml.Attributes;
using Nox.Yaml.Tests.TestDesigns.Nox.Enums;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[GenerateJsonSchema]
[Title("Definition namespace for attributes describing the target component of an integration integration.")]
[Description("This section details integration target attributes like name, description and type among other.")]
[AdditionalProperties(false)]
public class IntegrationTarget
{
    [Required]
    [Title("The name of the ETL target. Contains no spaces.")]
    [Description("The name of the ETL target. It should be a commonly used singular noun and be unique within a solution.")]
    [Pattern(@"^[^\s]*$")]
    public string Name { get; internal set; } = null!;

    [Title("The description of the ETL target.")]
    [Description("A phrase describing the ETL target.")]
    public string? Description { get; internal set; }

    [Required]
    [Title("The type of target.")]
    [Description("Specify the type of target. Options include entity, database, file, webAPI and message queue.")]
    public IntegrationAdapterType TargetAdapterType { get; internal set; } = default;

    [Title("The name of the integration target data connection. Contains no spaces.")]
    [Description("The name should be a commonly used singular noun and be unique within a solution.")]
    [Pattern(@"^[^\s]*$")]
    [Required]
    [AdditionalProperties(false)]
    public string DataConnectionName { get; internal set; } = null!;

    [AdditionalProperties(false)]
    [IfEquals(nameof(TargetAdapterType), IntegrationAdapterType.Database)]
    public IntegrationTargetDatabaseOptions? DatabaseOptions { get; set; }

    [AdditionalProperties(false)]
    [IfEquals(nameof(TargetAdapterType), IntegrationAdapterType.File)]
    public IntegrationTargetFileOptions? FileOptions { get; set; }

    [AdditionalProperties(false)]
    [IfEquals(nameof(TargetAdapterType), IntegrationAdapterType.WebApi)]
    public IntegrationTargetWebApiOptions? WebApiOptions { get; set; }

    [AdditionalProperties(false)]
    [IfEquals(nameof(TargetAdapterType), IntegrationAdapterType.MessageQueue)]
    public IntegrationTargetMessageQueueOptions? MessageQueueOptions { get; set; }

    [AdditionalProperties(false)]
    [IfEquals(nameof(TargetAdapterType), IntegrationAdapterType.Entity)]
    public IntegrationTargetEntityOptions? EntityOptions { get; set; }
}