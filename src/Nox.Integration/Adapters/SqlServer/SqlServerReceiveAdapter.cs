using System.Dynamic;
using ETLBox;
using ETLBox.SqlServer;
using Nox.Integration.Abstractions.Adapters;
using ETLBox.DataFlow;

namespace Nox.Integration.Adapters;

public class SqlServerReceiveAdapter: INoxDatabaseReceiveAdapter
{
    public IntegrationSourceAdapterType AdapterType => IntegrationSourceAdapterType.DatabaseQuery;
    public IDataFlowExecutableSource<ExpandoObject> DataFlowSource { get; }
    
    public string Query { get; }
    public int MinimumExpectedRecords { get; }

    public SqlServerReceiveAdapter(string query, int minimumExpectedRecords, string connectionString)
    {
        Query = query;
        MinimumExpectedRecords = minimumExpectedRecords;
        var connectionManager = new SqlConnectionManager(new SqlConnectionString(connectionString));
        DataFlowSource = new DbSource<ExpandoObject>
        {
            ConnectionManager = connectionManager,
            Sql = query
        };
    }
    
}