using ETLBox;
using ETLBox.DataFlow;
using ETLBox.SqlServer;
using Nox.Integration.Abstractions.Adapters;

namespace Nox.Integration.Adapters;

public class SqlServerSendAdapter: INoxDatabaseSendAdapter
{
    public IntegrationSourceAdapterType SourceAdapterType => IntegrationSourceAdapterType.Database;
    public IDataFlowDestination DataFlowTarget { get; }
    public string StoredProcedure { get; }

    public SqlServerSendAdapter(string storedProcedure, string connectionString)
    {
        StoredProcedure = storedProcedure;
        var connectionManager = new SqlConnectionManager(new SqlConnectionString(connectionString));
        DataFlowTarget = new DbMerge(connectionManager, )
    }
    
}