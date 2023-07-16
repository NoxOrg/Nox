using Json.Schema.Generation;

namespace Nox.Solution;

public class IntegrationDatabaseServer: ServerBase
{
    [Required]
    [Title("The integration database provider.")]
    [Description("The provider used for this integration database server. Examples include SqlServer, Postgres and others.")]
    public DatabaseServerProvider Provider { get; internal set; } = DatabaseServerProvider.SqlServer;
}