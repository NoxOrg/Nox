using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("Definition namespace for a Message Queue ETL source.")]
    [Description("This section specified attributes related to an ETL source of type Message Queue. Attributes include the route, format and verb.")]
    [AdditionalProperties(false)]
    public class IntegrationSourceMessageQueueOptions
    {
        [Required]
        [Title("The source name.")]
        [Description("The name of the queue or topic subscription from which messages will be consumed.")]
        public string SourceName { get; set; } = null!;
    }
}