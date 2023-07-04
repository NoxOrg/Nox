using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("Definition namespace for attributes describing the source component of an ETL integration.")]
    [Description("This section details ETL source attributes like name, description, scheduling and watermark specifications.")]
    [AdditionalProperties(false)]
    public class IntegrationSource
    {
        [Required]
        [Title("The name of the ETL source. Contains no spaces.")]
        [Description("The name should be a commonly used singular noun and be unique within a solution.")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; internal set; } = null!;

        [Title("A description of the ETL source.")]
        [Description("A phrase describing the source component of the ETL. Think about describing the what/where of this data source.")]
        public string? Description { get; internal set; }

        public IntegrationSchedule? Schedule { get; internal set; }

        [Required]
        [Title("The name of the integration source. Contains no spaces.")]
        [Description("The name of the data connection for this integration source. This must refer to an existing data connection in infrastructure, dependencies, dataConnections.")]
        [Pattern(@"^[^\s]*$")]
        [AdditionalProperties(false)]
        public string DataConnectionName { get; internal set; } = null!;

        public IntegrationSourceDatabaseWatermark? Watermark { get; internal set; }

        public IntegrationSourceDatabaseOptions? DatabaseOptions { get; set; }

        public IntegrationSourceFileOptions? FileOptions { get; set; }

        public IntegrationSourceMessageQueueOptions? MessageQueueOptions { get; set; }

        public IntegrationSourceWebApiOptions? WebApiOptions { get; set; }
    }
}