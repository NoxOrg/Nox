using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("Definition namespace for attributes describing the transform component of an ETL integration.")]
    [Description("This section details ETL transform attributes like field mapping and value lookups.")]
    [AdditionalProperties(false)]
    public class IntegrationTransform
    {
        [Title("Source to target column mappings details of the ETL transform component.")]
        [Description("Specifies one or more column mappings between source and target in an ETL data integration.")]
        [AdditionalProperties(false)] 
        public IReadOnlyList<IntegrationMapping>? Mappings { get; internal set; }

        [Title("Details of lookups performed during the ETL transform component.")]
        [Description("Specifies information related to lookups during the ETL transform. Attributes include source columns and target attributes, as well as match directives like lookup table and column and return column name.")]
        [AdditionalProperties(false)] 
        public IReadOnlyList<IntegrationLookup>? Lookups { get; internal set; }
    }
}