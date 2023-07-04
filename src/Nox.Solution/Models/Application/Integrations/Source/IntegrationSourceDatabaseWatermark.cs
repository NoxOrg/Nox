using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("Definition namespace for watermark columns on the ETL source data.")]
    [Description("This section lists the column(s) on the source data used to compare to the target data to indicate whether the source data has been updated.")]
    [AdditionalProperties(false)]
    public class IntegrationSourceDatabaseWatermark
    {
        [Title("Column(s) in datetime format used for watermark purpose.")]
        [Description("List datetime columns to be compared to target data to indicate if data has changed.")]
        public string[]? DateColumns { get; internal set; }

        [Title("Sequential key column used for watermark purpose.")]
        [Description("Specify a sequential key columns to be compared to target data to indicate if data has changed.")]
        public string? SequentialKeyColumn { get; internal set; }
    }
}