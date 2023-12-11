using System.Dynamic;
using ETLBox;
using ETLBox.DataFlow;
using ETLBox.SqlServer;
using Nox.Integration.Abstractions.Constants;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace Nox.Integration.SqlServer;

public class SqlServerQueryReceiveAdapter: INoxDatabaseReceiveAdapter
{
    private readonly SqlConnectionManager _connectionManager;

    private string _query;
    
    public IntegrationSourceAdapterType AdapterType => IntegrationSourceAdapterType.DatabaseQuery;
    
    public IDataFlowExecutableSource<ExpandoObject> DataFlowSource =>
        new DbSource<ExpandoObject>
        {
            ConnectionManager = _connectionManager,
            Sql = _query
        };

    public void ApplyFilter(List<string> filterColumns, IntegrationMergeStates mergeStates)
    {
        _query = SetQueryFilters(_query, filterColumns, mergeStates);
    }

    public string Query => _query;
    public int MinimumExpectedRecords { get; }

    public SqlServerQueryReceiveAdapter(string query, int minimumExpectedRecords, string connectionString)
    {
        _query = query;
        MinimumExpectedRecords = minimumExpectedRecords;
        _connectionManager = new SqlConnectionManager(new SqlConnectionString(connectionString));
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