using Nox.Types.Schema;

namespace Nox.Solution;

[Title("Definition namespace for an entity integration source.")]
[Description("This section specified attributes related to an integration source of type Entity. Attributes include the entity name as well as minimum expected records.")]
public class IntegrationSourceEntityOptions
{
    [Required]
    [Title("The entity name.")]
    [Description("The name of the entity from which data will be synchronized.")]
    public string EntityName { get; set; } = null!;
    
    [Title("The minimum expected record count.")]
    [Description("This integration will not run, as per scheduled, unless a minimum number of records in the source have changed.")]
    public int? MinimumExpectedRecords { get; set; } = 1;
}