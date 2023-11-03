using Nox.Types.Schema;

namespace Nox.Solution;

[Title("Definition namespace for a database integration target.")]
[Description("This section specified attributes related to an integration target of type Database Table. Attributes include the name of the table that will be updated.")]
[AdditionalProperties(false)]
public class IntegrationTargetTableOptions
{
    [Required]
    [Title("The name of the table to update.")]
    [Description("The table that will be updated on the target database.")]
    public string TableName { get; set; } = null!;
    
    [Required]
    [Title("Schema Name")]
    [Description("The name of the schema in which the table resides.")]
    public string SchemaName { get; set; } = null!;
}