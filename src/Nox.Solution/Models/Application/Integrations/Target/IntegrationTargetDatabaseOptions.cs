using Json.Schema.Generation;

namespace Nox.Solution;

public class IntegrationTargetDatabaseOptions
{
    [Required]
    [Title("The stored procedure to execute.")]
    [Description("The stored procedure that will be executed on the target database.")]
    public string StoredProcedure { get; set; } = null!;
}