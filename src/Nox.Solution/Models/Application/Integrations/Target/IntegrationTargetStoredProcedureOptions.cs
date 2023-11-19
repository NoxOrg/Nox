using Nox.Yaml.Attributes;

namespace Nox.Solution;

public class IntegrationTargetStoredProcedureOptions
{
    [Title("The stored procedure to execute.")]
    [Description("The stored procedure that will be executed on the target database.")]
    public string StoredProcedure { get; set; } = null!;
    
    [Title("Schema Name")]
    [Description("The name of the schema in which the stored procedure resides.")]
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