using System.Collections.Generic;
using Nox.Yaml.Attributes;

namespace Nox.Solution
{
    [Title("Definition namespace for watermark columns on the integration source data.")]
    [Description("This section lists the column(s) on the source data used to indicate whether a record in the source data has changed.")]
    [AdditionalProperties(false)]
    public class IntegrationSourceWatermark
    {
        [Title("Column(s) in datetime format used for watermark purpose.")]
        [Description("List datetime columns to be compared to target data to indicate if data has changed.")]
        public IReadOnlyList<string>? DateColumns { get; internal set; }

        [Title("Sequential key column used for watermark purpose.")]
        [Description("Specify a sequential key columns to be compared to target data to indicate if data has changed.")]
        public string? SequentialKeyColumn { get; internal set; }
    }
}