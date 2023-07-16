using System.Dynamic;
using ETLBox.Connection;
using ETLBox.DataFlow;
using SqlKata.Compilers;

namespace Nox.Integration.Abstractions;

public interface IIntegrationTarget
{
    string Name { get; }
    string Type { get; }
    Compiler SqlCompiler { get; }
    IDataFlowExecutableSource<ExpandoObject> DataFlowSource();
    IConnectionManager ConnectionManager { get; }
    void ApplyMergeInfo(IntegrationMergeStates lastMergeInfo, string[] dateTimeStampColumns, string[] targetColumns);
    
    string ToTableNameForSql(string table, string schema);
    string ToTableNameForSqlRaw(string table, string schema);
}