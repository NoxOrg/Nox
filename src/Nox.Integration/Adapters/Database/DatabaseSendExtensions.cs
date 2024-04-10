using System.Dynamic;
using ETLBox;
using ETLBox.DataFlow;
using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Adapters;

public static class DatabaseTargetExtensions
{
    public static CustomDestination<ExpandoObject> LinkToDatabaseTable(this IDataFlowSource<ExpandoObject> source, INoxDatabaseTargetAdapter TargetAdapter, List<string>? idColumns, List<string>? dateColumns)
    {
        var tableTarget = TargetAdapter.TableTarget!;
        if (idColumns != null && idColumns.Any())
        {
            var mergeIdColumns = idColumns.Select(idColumn => new IdColumn { IdPropertyName = idColumn }).ToList();
            tableTarget.IdColumns = mergeIdColumns;    
        }

        if (dateColumns != null && dateColumns.Any())
        {
            var mergeDateColumns = dateColumns.Select(dateColumn => new CompareColumn { ComparePropertyName = dateColumn }).ToList();
            tableTarget.CompareColumns = mergeDateColumns;
        }

        source.LinkTo(tableTarget);
        var result = new CustomDestination<ExpandoObject>();
        tableTarget.LinkTo(result);
        return result;
    }
}