using Nox.Yaml.Attributes;
using Nox.Yaml.Tests.TestDesigns.Nox.Enums;

namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[GenerateJsonSchema]
[Title("Definition namespace for attributes describing the source component of an ETL integration.")]
[Description("This section details ETL source attributes like name, description, scheduling and watermark specifications.")]
[AdditionalProperties(false)]
public class IntegrationSource
{
    [Required]
    [Title("The name of the Integration source. Contains no spaces.")]
    [Description("The name should be a commonly used singular noun and be unique within a solution.")]
    [Pattern(@"^[^\s]*$")]
    public string Name { get; internal set; } = null!;

    [Title("A description of the Integration source.")]
    [Description("A phrase describing the source component of the Integration. Think about describing the what/where of this data source.")]
    public string? Description { get; internal set; }

    [Required]
    [Title("The type of source.")]
    [Description("Specify the type of the source. Options include entity, database, file, webAPI and message queue.")]
    public IntegrationAdapterType SourceAdapterType { get; internal set; } = default;

    [Title("The name of the data connection. Contains no spaces.")]
    [Description("The name of the data connection for this integration source. This must refer to an existing data connection in infrastructure, dependencies, dataConnections. Data Connection is required when the source is not a Nox Entity")]
    [Pattern(@"^[^\s]*$")]
    [AdditionalProperties(false)]
    [ExistInCollection( 
        nameof(NoxSolution.Infrastructure),
        nameof(NoxSolution.Infrastructure.Dependencies),
        nameof(NoxSolution.Infrastructure.Dependencies.DataConnections),
        nameof(DataConnection.Name)
    )]
    public string DataConnectionName { get; internal set; } = null!;

    public IntegrationSourceWatermark? Watermark { get; internal set; }

    [IfEquals(nameof(SourceAdapterType), IntegrationAdapterType.Database)]
    public IntegrationSourceDatabaseOptions? DatabaseOptions { get; set; }

    [IfEquals(nameof(SourceAdapterType), IntegrationAdapterType.File)]
    public IntegrationSourceFileOptions? FileOptions { get; set; }

    [IfEquals(nameof(SourceAdapterType), IntegrationAdapterType.MessageQueue)]
    public IntegrationSourceMessageQueueOptions? MessageQueueOptions { get; set; }

    [IfEquals(nameof(SourceAdapterType), IntegrationAdapterType.WebApi)]
    public IntegrationSourceWebApiOptions? WebApiOptions { get; set; }

    [AdditionalProperties(false)]
    [IfEquals(nameof(SourceAdapterType), IntegrationAdapterType.Entity)]
    public IntegrationTargetEntityOptions? EntityOptions { get; set; }
}