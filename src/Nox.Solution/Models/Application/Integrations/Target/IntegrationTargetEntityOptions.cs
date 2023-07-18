using System.Collections.Generic;
using Nox.Types.Schema;

namespace Nox.Solution
{
    [Title("Definition namespace for watermark columns on the ETL source data.")]
    [Description("This section lists the column(s) on the source data used to compare to the target data to indicate whether the source data has been updated.")]
    [AdditionalProperties(false)]
    public class IntegrationTargetEntityOptions
    {
        [Title("Column(s) in datetime format used for watermark purpose.")]
        [Description("List datetime columns to be compared to target data to indicate if data has changed.")]
        public IReadOnlyList<string>? DateCompareColumns { get; internal set; }
    }
}