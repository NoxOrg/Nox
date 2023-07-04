using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("Definition namespace for a file type ETL source.")]
    [Description("This section specified attributes related to an ETL source of type File. Attributes include the database query as well as minimumexpected records.")]
    [AdditionalProperties(false)]
    public class IntegrationSourceFileOptions
    {
        [Required]
        [Title("The file name.")]
        [Description("The name of the file that will be ingested.")]
        public string Filename { get; set; } = null!;

        [Title("The minimum expected record count.")]
        [Description("The minimum expected record count as a result of this data ingestion.")]
        public int? MinimumExpectedRecords { get; set; } = 1;
    }
}