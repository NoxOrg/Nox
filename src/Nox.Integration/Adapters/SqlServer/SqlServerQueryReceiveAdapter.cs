using System.Dynamic;
using ETLBox;
using ETLBox.DataFlow;
using ETLBox.SqlServer;
using Nox.Integration.Abstractions.Adapters;
using Nox.Integration.Constants;

namespace Nox.Integration.Adapters.SqlServer;

public class SqlServerQueryReceiveAdapter: INoxDatabaseReceiveAdapter
{
    private readonly DbSource<ExpandoObject> _dataSource;
    public IntegrationSourceAdapterType AdapterType => IntegrationSourceAdapterType.DatabaseQuery;
    public IDataFlowExecutableSource<ExpandoObject> DataFlowSource => _dataSource;
    public void ApplyFilter(List<string> filterColumns, IntegrationMergeStates mergeStates)
    {
        var sql = _dataSource.Sql;
        sql = SetQueryFilters(sql, filterColumns, mergeStates);
        _dataSource.Sql = sql;
    }

    public string Query { get; }
    public int MinimumExpectedRecords { get; }

    public SqlServerQueryReceiveAdapter(string query, int minimumExpectedRecords, string connectionString)
    {
        Query = query;
        MinimumExpectedRecords = minimumExpectedRecords;
        var connectionManager = new SqlConnectionManager(new SqlConnectionString(connectionString));
        _dataSource = new DbSource<ExpandoObject>
        {
            ConnectionManager = connectionManager,
            Sql = query
        };
    }

    private string SetQueryFilters(string sql, IEnumerable<string> filterColumns, IntegrationMergeStates mergeStates)
    {
        var result = sql;
        foreach (var filterColumn in filterColumns)
        {
            if (mergeStates.Any(ms => ms.Key.Equals(filterColumn, StringComparison.InvariantCultureIgnoreCase)))
            {
                if (mergeStates[filterColumn].LastDateLoadedUtc.Equals(IntegrationContextConstants.MinSqlMergeDate))
                {
                    result = result.Replace($"@{filterColumn}", $"'{IntegrationContextConstants.MinSqlMergeDate:yyyy-MM-dd HH:mm:ss:fff}'");
                }
                else
                {
                    result = result.Replace($"@{filterColumn}", $"'{mergeStates[filterColumn].LastDateLoadedUtc:yyyy-MM-dd HH:mm:ss:fff}'");
                }
            }
            else
            {
                if (mergeStates.Any(c => c.Key.Equals(IntegrationContextConstants.DefaultFilterProperty, StringComparison.InvariantCultureIgnoreCase)))
                {
                    if (mergeStates[IntegrationContextConstants.DefaultFilterProperty].LastDateLoadedUtc.Equals(IntegrationContextConstants.MinSqlMergeDate))
                    {
                        result = result.Replace($"@{filterColumn}", $"'{IntegrationContextConstants.MinSqlMergeDate:yyyy-MM-dd HH:mm:ss:fff}'");
                    }
                    else
                    {
                        result = result.Replace($"@{filterColumn}", $"'{mergeStates[IntegrationContextConstants.DefaultFilterProperty].LastDateLoadedUtc:yyyy-MM-dd HH:mm:ss:fff}'");
                    }   
                }
            }
        }

        return result;
    }
    
}