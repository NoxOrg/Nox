using Nox.Types.Schema;

namespace Nox.Solution;

[Title("Definition namespace for a database integration target.")]
[Description("This section specified attributes related to an integration target of type Database Table. Attributes include the name of the stored procedure that will be executed.")]
[AdditionalProperties(false)]
public class IntegrationTargetStoredProcedureOptions
{
    [Required]
    [Title("The stored procedure to execute.")]
    [Description("The stored procedure that will be executed on the target database.")]
    public string StoredProcedure { get; set; } = null!;
    
    [Required]
    [Title("Schema Name")]
    [Description("The name of the schema in which the stored procedure resides.")]
    public string SchemaName { get; set; } = null!;
}