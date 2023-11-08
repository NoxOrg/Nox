using System.Dynamic;
using ETLBox;
using ETLBox.DataFlow;

namespace Nox.Integration.Abstractions.Adapters;

public interface INoxDatabaseSendAdapter: INoxSendAdapter
{
    string? StoredProcedure { get; }
    string? TableName { get; }
    DbMerge<ExpandoObject>? TableTarget { get; }
    CustomDestination<ExpandoObject>? StoredProcTarget { get; } 
    string? SchemaName { get; }
}