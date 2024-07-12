using System.Collections.Generic;
using Nox.Yaml.Attributes;

namespace Nox.Solution;

public class IntegrationSourceProcedureOptions
{
    [Required]
    [Title("The database procedure to execute.")]
    [Description("The procedure that will be executed on the source database.")]
    public string StoredProcedure { get; set; } = null!;

    [Title("The procedure parameters.")]
    [Description("The parameters to pass to the database procedure stored procedure.")]
    public List<IntegrationSourceProcedureParameter>? Parameters { get; set; }
}