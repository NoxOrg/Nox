using Nox.Solution.Schema;
using Nox.Solution.Builders;

namespace Nox.Solution;

[GenerateJsonSchema]
public class IntegrationDatabaseServer: ServerBase
{
    [Required]
    [Title("The integration database provider.")]
    [Description("The provider used for this integration database server. Examples include SqlServer, Postgres and others.")]
    public DatabaseServerProvider Provider { get; internal set; } = DatabaseServerProvider.SqlServer;
}