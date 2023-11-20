using Nox.Yaml;
using Nox.Yaml.Attributes;
using System.Linq;

namespace Nox.Solution;

public class IntegrationTargetStoredProcedureOptions : YamlConfigNode<NoxSolution, IntegrationTarget>
{
    [Title("The stored procedure to execute.")]
    [Description("The stored procedure that will be executed on the target database.")]
    public string StoredProcedure { get; set; } = null!;
    
    [Title("Schema Name")]
    [Description("The name of the schema in which the stored procedure resides.")]
    public string SchemaName { get; set; } = string.Empty;

    public override void SetDefaults(NoxSolution topNode, IntegrationTarget parentNode, string yamlPath)
    {
        DefaultConnectionProvider(topNode, parentNode);
    }

    internal void DefaultConnectionProvider(NoxSolution topNode, IntegrationTarget parentNode)
    {
        var dataConnection = topNode
            .DataConnections.First(d => d.Name.Equals(parentNode.DataConnectionName));

        if (string.IsNullOrWhiteSpace(SchemaName))
        {
            switch (dataConnection.Provider)
            {
                case DataConnectionProvider.Postgres:
                    SchemaName = "public";
                    break;
                case DataConnectionProvider.SqlServer:
                    SchemaName = "dbo";
                    break;
            }
        }
    }
}