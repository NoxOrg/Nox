using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using ETLBox;
using ETLBox.DataFlow;

namespace Nox.Integration.EtlTests.Json;

public static class IntegrationExtensions
{
    public static DbMerge<TTarget> WithMergeFields<TTarget>(this DbMerge<TTarget> target, List<string>? idColumns, List<string>? compareColumns)
    {
        if (idColumns != null && idColumns.Any())
        {
            var mergeIdColumns = idColumns.Select(idColumn => new IdColumn { IdPropertyName = idColumn }).ToList();
            target.IdColumns = mergeIdColumns;    
        }

        if (compareColumns != null && compareColumns.Any())
        {
            var mergeDateColumns = compareColumns.Select(dateColumn => new CompareColumn { ComparePropertyName = dateColumn }).ToList();
            target.CompareColumns = mergeDateColumns;
        }

        return target;
    }
}