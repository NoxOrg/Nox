using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("Definition namespace for a database ETL source.")]
    [Description("This section specified attributes related to an ETL source of type Database. Attributes include the database query as well as minimumexpected records.")]
    [AdditionalProperties(false)]
    public class IntegrationSourceDatabaseOptions
    {
        [Required]
        [Title("The query to execute.")]
        [Description("The query that will be executed on the source database.")]
        public string Query { get; set; } = null!;

        [Title("The minimum expected record count.")]
        [Description("The minimum expected record count as a result of this data ingestion.")]
        public int? MinimumExpectedRecords { get; set; } = 1;
    }
}