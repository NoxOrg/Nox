using Nox.Types.Schema;

namespace Nox.Solution;

[Title("Definition namespace for a database integration source.")]
[Description("This section specified attributes related to an integration source of type Database Stored Procedure. Attributes include the stored procedue as well as minimum expected records.")]
[AdditionalProperties(false)]
public class IntegrationSourceStoredProcedureOptions
{
    [Required]
    [Title("The store procedure to execute.")]
    [Description("The stored procedure that will be executed on the source database.")]
    public string StoredProcedure { get; set; } = null!;

    [Title("The minimum expected record count.")]
    [Description("This integration will not run, as per scheduled, unless a minimum number of records in the source have changed.")]
    public int? MinimumExpectedRecords { get; set; } = 1;
}