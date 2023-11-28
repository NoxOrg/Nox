using System.Collections.Generic;
using Nox.Yaml.Attributes;

namespace Nox.Solution;

[Title("Definition namespace for watermark columns on the integration target data.")]
[Description("This section lists the column(s) on the target data used to determine whether a record is new or has been updated.")]
[AdditionalProperties(false)]
public class IntegrationTargetWatermark
{
    [Title("Sequential key column used for watermark purpose.")]
    [Description("Specify one or more sequential key columns to be compared to source data to determine if a record exits in the target.")]
    public IReadOnlyList<string>? SequentialKeyColumns { get; internal set; }
    
    [Title("Column(s) in datetime format used for watermark purpose.")]
    [Description("List od datetime columns to be compared to source data to determine if data has changed.")]
    public IReadOnlyList<string>? DateColumns { get; internal set; }
}