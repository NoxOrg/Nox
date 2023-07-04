using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("Mapping details of the ETL transform component.")]
    [Description("Specifies how columns are mapped between source and target in an ETL data integration.")]
    [AdditionalProperties(false)]
    public class IntegrationMapping
    {
        [Required]
        [Title("Column name to be mapped at the ETL data source.")]
        [Description("Specifies the source column to be mapped during the ETL transform.")]
        public string SourceColumn { get; internal set; } = null!;

        [Title("Specify case conversion during source to target transform.")]
        [Description("Specifies whether any case conversion is performed during the ETL transform. Source data may be converted to lowercase or uppercase for example.")]
        public IntegrationMappingConverter? Converter { get; internal set; }

        [Required]
        [Title("Target attribute to which source column is to be mapped.")]
        [Description("Specifies the name of the target attribute to to which the source column is mapped during the ETL transform.")]
        public string TargetAttribute { get; internal set; } = null!;
    }
}