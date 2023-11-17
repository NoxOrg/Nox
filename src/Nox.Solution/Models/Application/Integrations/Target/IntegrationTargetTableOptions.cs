using Nox.Yaml.Attributes;

namespace Nox.Solution;

[Title("Definition namespace for a database table integration target.")]
[Description("This section specified attributes related to an integration target of type Database Table. Attributes include the table name that will be updated.")]
[AdditionalProperties(false)]
public class IntegrationTargetTableOptions
{
    [Required]
    [Title("The name of the table to update.")]
    [Description("The table that will be updated on the target database.")]
    public string TableName { get; set; } = null!;
    
    [Title("Schema Name")]
    [Description("The name of the schema in which the table resides.")]
    public string SchemaName { get; set; } = string.Empty;

    internal bool ApplyDefaults(DataConnectionProvider provider)
    {
        if (string.IsNullOrWhiteSpace(SchemaName))
        {
            switch (provider)
            {
                case DataConnectionProvider.Postgres:
                    SchemaName = "public";
                    break;
                case DataConnectionProvider.SqlServer:
                    SchemaName = "dbo";
                    break;
            }
        }

        return true;
    }

}