using System.Collections.Generic;
using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("The definition namespace for an application ETL data integration.")]
    [Description("Details pertaining to a solution data integration. Includes common ETL attributes like source, transform and target.")]
    [AdditionalProperties(false)]
    public class Integration
    {
        [Required]
        [Title("The name of the ETL integration. Contains no spaces.")]
        [Description("The name of the ETL integration. It should be a commonly used singular noun and be unique within a solution.")]
        [Pattern(@"^[^\s]*$")]
        public string Name { get; set; } = null!;

        [Title("A phrase describing the objective of the ETL data integration.")]
        [Description("A phrase describing the high-level objective of the ETL. A reference to data source and format is especially useful.")]
        public string? Description { get; set; }

        public IntegrationSource? Source { get; internal set; }

        public IntegrationTransform? Transform { get; internal set; }

        public IntegrationTarget? Target { get; internal set; }
    }
}