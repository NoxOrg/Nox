using Json.Schema.Generation;

namespace Nox.Solution
{
    [Title("Details pertaining to a lookup performed during the ETL transform component.")]
    [Description("Specifies information related to a data lookup. Includes the source column and target attribute, as well as match directives like lookup table, column and return column name.")]
    [AdditionalProperties(false)]
    public class IntegrationLookup
    {
        [Required]
        [Title("Source column used as key for lookup.")]
        [Description("Specify the source column of which the content will serve as the key for the lookup.")]
        public string? SourceColumn { get; internal set; }

        [Required]
        // These descriptors should be moved to the class when the generator is fixed
        [Title("Attributes related to source table used for the lookup.")]
        [Description("Specify information about the source lookup table. This includes table name, lookup column and return column.")]
        [AdditionalProperties(false)]
        public IntegrationMatch Match { get; internal set; } = new();

        [Required]
        [Title("Target attribute for lookup result.")]
        [Description("Specify the name of the target attribute to which the lookup result will be persisted.")]
        public string TargetAttribute { get; internal set; } = string.Empty;
    }
}