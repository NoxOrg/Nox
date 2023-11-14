using Nox.Yaml.Attributes;
using Nox.Yaml.Tests.TestDesigns.Nox.Enums;


namespace Nox.Yaml.Tests.TestDesigns.Nox.Models;

[GenerateJsonSchema]
public class DatabaseServer : ServerBase
{
    [Required]
    [Title("The database provider.")]
    [Description("The provider used for this database server. Examples include SqlServer, Postgres and others.")]
    public DatabaseServerProvider Provider { get; internal set; } = DatabaseServerProvider.SqlServer;
}
