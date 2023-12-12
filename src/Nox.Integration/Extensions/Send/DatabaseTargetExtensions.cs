using System.Dynamic;
using ETLBox;
using ETLBox.DataFlow;
using Nox.Integration.Abstractions.Interfaces;

namespace Nox.Integration.Extensions.Send;

public static class DatabaseTargetExtensions
{
    public static CustomDestination LinkToDatabaseTable(this IDataFlowSource<ExpandoObject> source, INoxDatabaseSendAdapter sendAdapter, List<string>? idColumns, List<string>? dateColumns)
    {
        var tableTarget = sendAdapter.TableTarget!;
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
        var result = new CustomDestination();
        tableTarget.LinkTo(result);
        return result;
    }
}