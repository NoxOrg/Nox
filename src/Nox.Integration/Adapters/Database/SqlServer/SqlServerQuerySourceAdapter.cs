using System.Dynamic;
using ETLBox;
using ETLBox.DataFlow;
using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Adapters.SqlServer;

public class SqlServerQuerySourceAdapter: SqlServerQuerySourceAdapterBase, INoxDatabaseSourceAdapter
{
    public string Query => BaseQuery;
    public int MinimumExpectedRecords => BaseMinimumExpectedRecords;

    public IDataFlowExecutableSource<ExpandoObject> DataFlowSource =>
        new DbSource<ExpandoObject>
        {
            ConnectionManager = BaseConnectionManager,
            Sql = BaseQuery
        };

    public SqlServerQuerySourceAdapter(string query, int minimumExpectedRecords, string connectionString): base(query, minimumExpectedRecords, connectionString)
    {
    }
}

public class SqlServerQuerySourceAdapter<TSource> : SqlServerQuerySourceAdapterBase, INoxDatabaseSourceAdapter<TSource>
{
    public string Query => BaseQuery;
    public int MinimumExpectedRecords => BaseMinimumExpectedRecords;

    public IDataFlowExecutableSource<TSource> DataFlowSource => new DbSource<TSource>
    {
        ConnectionManager = BaseConnectionManager,
        Sql = BaseQuery
    };
    
    public SqlServerQuerySourceAdapter(string query, int minimumExpectedRecords, string connectionString): base(query, minimumExpectedRecords, connectionString)
    {
        
    }
}