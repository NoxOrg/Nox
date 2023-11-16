using Nox.Yaml.Attributes;

namespace Nox.Solution;

[Title("Definition namespace for a database integration target.")]
[Description("This section specified attributes related to an integration target of type Database. Attributes include the stored procedure that will be executed.")]
[AdditionalProperties(false)]
public class IntegrationTargetDatabaseOptions
{
    [Required]
    [Title("The stored procedure to execute.")]
    [Description("The stored procedure that will be executed on the target database.")]
    public string StoredProcedure { get; set; } = null!;
}