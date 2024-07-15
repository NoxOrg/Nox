using System.Dynamic;
using ETLBox;
using Nox.Integration.Abstractions.Constants;
using Nox.Integration.Abstractions.Interfaces;
using Nox.Integration.Abstractions.Models;
using Nox.Solution;

namespace Nox.Integration.Adapters.SqlServer;

public class SqlServerProcedureSourceAdapter : SqlServerProcedureSourceAdapterBase, INoxDatabaseProcedureSourceAdapter
{
    public string ProcedureName => BaseProcedureName;
    public List<IntegrationSourceProcedureParameter> Parameters => BaseParameters;
    private readonly SqlServerProcedureSource<ExpandoObject> _dataSource;

    public IDataFlowExecutableSource<ExpandoObject> DataFlowSource => _dataSource;
    
    public void ApplyFilter(IEnumerable<string> filterColumns, IntegrationMergeStates mergeStates)
    {
        foreach (var filterColumn in filterColumns)
        {
            if (mergeStates.Any(ms => ms.Key.Equals(filterColumn, StringComparison.InvariantCultureIgnoreCase)))
            {
                
                _dataSource.SetParameter($@"{filterColumn}", mergeStates[filterColumn]);
            }
            else
            {
                _dataSource.SetParameter($@"{filterColumn}", mergeStates[IntegrationContextConstants.DefaultFilterProperty]);
            }
        }
    }

    public SqlServerProcedureSourceAdapter(string procedureName, List<IntegrationSourceProcedureParameter> parameters, string connectionString) : base(procedureName, parameters, connectionString)
    {
        _dataSource = new SqlServerProcedureSource<ExpandoObject>();
        _dataSource.Initialize(BaseConnectionManager, procedureName);
        _dataSource.CreateParameters(parameters);
    }
}

public class SqlServerProcedureSourceAdapter<TSource> : SqlServerProcedureSourceAdapterBase, INoxDatabaseProcedureSourceAdapter<TSource> 
    where TSource: new()
{
    public string ProcedureName => BaseProcedureName;
    public List<IntegrationSourceProcedureParameter> Parameters => BaseParameters;
    private readonly SqlServerProcedureSource<TSource> _dataSource;

    public IDataFlowExecutableSource<TSource> DataFlowSource => _dataSource;

    public void ApplyFilter(IEnumerable<string> filterColumns, IntegrationMergeStates mergeStates)
    {
        foreach (var filterColumn in filterColumns)
        {
            DateTime? filterValue;
            
            if (mergeStates.Any(ms => ms.Key.Equals(filterColumn, StringComparison.InvariantCultureIgnoreCase)))
            {
                filterValue = mergeStates[filterColumn].LastDateLoadedUtc;
            }
            else
            {
                filterValue = mergeStates[IntegrationContextConstants.DefaultFilterProperty].LastDateLoadedUtc;
            }
            _dataSource.SetParameter($"@{filterColumn}", filterValue);
        }
    }

    public SqlServerProcedureSourceAdapter(string procedureName, List<IntegrationSourceProcedureParameter> parameters, string connectionString) : base(procedureName, parameters, connectionString)
    {
        _dataSource = new SqlServerProcedureSource<TSource>();
        _dataSource.Initialize(BaseConnectionManager, procedureName);
        _dataSource.CreateParameters(parameters);
    }
}