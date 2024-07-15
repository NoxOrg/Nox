using System.Data;
using System.Data.Common;
using System.Globalization;
using ETLBox;
using ETLBox.DataFlow;
using Microsoft.Data.SqlClient;

namespace Nox.Integration.Abstractions.Models;

public class DatabaseProcedureSource<TOutput>: CustomSource<TOutput> where TOutput: new()
{
    private string _connectionString = string.Empty;
    private string _procName = string.Empty;
    private int _recordCount = 1;
    private List<string> _fieldNames = new();
    private List<TOutput> _rows = new();

    protected List<DbParameter>? Parameters { get; set; }

    protected DatabaseProcedureSource()
    {
        ReadFunc = ReadFuncInternal;
        ReadingCompleted = ReadingCompletedInternal;
    }

    public void Initialize(IConnectionManager connectionManager, string procedureName)
    {
        _connectionString = connectionManager.ConnectionString.ToString();
        _procName = procedureName;
    }

    public void SetParameter(string name, object value)
    {
        var parameter = Parameters!.Single(p => p.ParameterName.Equals(name, StringComparison.OrdinalIgnoreCase));
        parameter.Value = value;
    }
    
    private bool ReadingCompletedInternal(int obj)
    {
        return obj >= _recordCount;
    }

    protected override void OnExecutionDoAsyncWork()
    {
        using var connection = new SqlConnection(_connectionString);
        connection.Open();
        using var cmd = new SqlCommand(_procName, connection);
        cmd.CommandType = CommandType.StoredProcedure;
        AddParameters(cmd);
        var reader = cmd.ExecuteReader();
        SetFieldNames(reader);
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                AddRow(reader);
            }    
        }
        connection.Close();
        _recordCount = _rows.Count;
        base.OnExecutionDoAsyncWork();
    }

    private TOutput ReadFuncInternal(int arg)
    {
        return _rows[arg];
    }

    private void AddParameters(SqlCommand cmd)
    {
        if (Parameters != null && Parameters.Any())
        {
            foreach (var param in Parameters)
            {
                cmd.Parameters.Add(param);
            }
        }
    }

    private void SetFieldNames(SqlDataReader reader)
    {
        for (int i = 0; i < reader.FieldCount; i++)
        {   
            _fieldNames.Add(reader.GetName(i));
        }
    }

    private void AddRow(SqlDataReader reader)
    {
        var row = new TOutput();
        for (int i = 0; i < reader.FieldCount; i++)
        {
            (row as IDictionary<string, object>)![_fieldNames[i]] = reader.GetValue(i);
        }
        _rows.Add(row);
    }
}