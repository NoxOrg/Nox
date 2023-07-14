using System.Data.SqlClient;
using System.Dynamic;
using ETLBox.Connection;
using ETLBox.DataFlow;
using ETLBox.DataFlow.Connectors;
using Nox.Integration;
using Nox.Integration.Abstractions;
using Nox.Integration.Constants;
using Nox.Solution;
using SqlKata.Compilers;

namespace Nox.IntegrationTarget.SqlServer;

public class SqlServerIntegrationTarget: IIntegrationTarget
{
    private readonly string _name;
    private string _connectionString = "";
    private readonly IConnectionManager _connectionManager;
    private readonly Compiler _compiler;

    public string Name => _name;
    
    public string Type => IntegrationTargetTypeNames.SqlServer;

    public Compiler SqlCompiler => _compiler;

    public SqlServerIntegrationTarget(string targetName, ServerBase serverDefinition, string integrationName)
    {
        _name = targetName;
        _compiler = new SqlServerCompiler();
        SetConnectionString(serverDefinition, integrationName);
        _connectionManager = new SqlConnectionManager
        {
            ConnectionString = new SqlConnectionString(_connectionString)
        };
    }
    
    public IDataFlowExecutableSource<ExpandoObject> DataFlowSource()
    {
        var dataFlowExecutableSource = new DbSource<ExpandoObject>
        {
            ConnectionManager = _connectionManager,
            Sql = "",
        };

        return dataFlowExecutableSource;
    }

    public IConnectionManager ConnectionManager => _connectionManager;

    public void ApplyMergeInfo(IntegrationMergeStates lastMergeInfo, string[] dateTimeStampColumns, string[] targetColumns)
    {
        throw new NotImplementedException();
    }

    private void SetConnectionString(ServerBase serverDefinition, string integrationName)
    {
        var csb = new SqlConnectionStringBuilder(serverDefinition.Options)
        {
            DataSource = $"{serverDefinition.ServerUri},{serverDefinition.Port ?? 1433}",
            UserID = serverDefinition.User,
            Password = serverDefinition.Password,
            InitialCatalog = serverDefinition.Name,
            ApplicationName = integrationName
        };
        _connectionString = csb.ConnectionString;
    }
}