using ETLBox.SqlServer;
using Nox.Integration.Abstractions.Constants;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;

namespace Nox.Integration.Adapters.SqlServer;

public abstract class SqlServerQuerySourceAdapterBase
{
    internal readonly SqlConnectionManager BaseConnectionManager;

    internal string BaseQuery;
    
    public static IntegrationSourceAdapterType AdapterType => IntegrationSourceAdapterType.DatabaseQuery;
    internal int BaseMinimumExpectedRecords { get; }
    
    protected SqlServerQuerySourceAdapterBase(string query, int minimumExpectedRecords, string connectionString)
    {
        BaseQuery = query;
        BaseMinimumExpectedRecords = minimumExpectedRecords;
        BaseConnectionManager = new SqlConnectionManager(new SqlConnectionString(connectionString));
    }
    
    public void ApplyFilter(IEnumerable<string> filterColumns, IntegrationMergeStates mergeStates)
    {
        BaseQuery = SetQueryFilters(BaseQuery, filterColumns, mergeStates);
    }
    
    private string SetQueryFilters(string sql, IEnumerable<string> filterColumns, IntegrationMergeStates mergeStates)
    {
        var result = sql;
        foreach (var filterColumn in filterColumns)
        {
            if (mergeStates.Any(ms => ms.Key.Equals(filterColumn, StringComparison.InvariantCultureIgnoreCase)))
            {
                result = sql.Replace($"@{filterColumn}", $"'{mergeStates[filterColumn].LastDateLoadedUtc:yyyy-MM-dd HH:mm:ss:fff}'");
            }
            else
            {
                result = sql.Replace($"@{filterColumn}", $"'{mergeStates[IntegrationContextConstants.DefaultFilterProperty].LastDateLoadedUtc:yyyy-MM-dd HH:mm:ss:fff}'");
            }
        }

        return result;
    }
}