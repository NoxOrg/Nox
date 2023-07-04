using Json.Schema.Generation;


namespace Nox.Solution
{
    public class DatabaseServer : ServerBase
    {
        [Required]
        [Title("The database provider.")]
        [Description("The provider used for this database server. Examples include SqlServer, Postgres and others.")]
        public DatabaseServerProvider Provider { get; internal set; } = DatabaseServerProvider.SqlServer;
    }
}
