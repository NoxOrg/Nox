using ETLBox.ControlFlow.Tasks;
using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Constants;
using Nox.Solution;

namespace Nox.Integration.Executor;

public abstract class IntegrationExecutorBase
{
    private readonly ILogger _logger;

    protected ILogger Logger => _logger;
    
    protected IntegrationExecutorBase(ILogger logger)
    {
        _logger = logger;
    }
    
    //
    protected IntegrationMergeStates GetAllLastMergeDateTimeStamps(IntegrationSourceWatermark watermark, IIntegrationTarget dataProvider, Entity entity)
    {
        var lastMergeDateTimeStampInfo = new IntegrationMergeStates();

        var addedMergeColumn = false;

        if (watermark.DateColumns != null)
        {
            foreach (var dateColumn in watermark.DateColumns)
            {
                if (entity.Attributes!.Any(a => a.Name.Equals(dateColumn, StringComparison.InvariantCultureIgnoreCase)))
                {
                    addedMergeColumn = true;
                    //TODO fix loadername
                    var lastMergeDateTimeStamp = GetLastMergeDateTimeStamp("TestLoader", dateColumn, dataProvider);

                    lastMergeDateTimeStampInfo[dateColumn] = new IntegrationMergeState()
                    {
                        SourceName = "TestLoader",
                        Property = dateColumn,
                        LastDateLoadedUtc = lastMergeDateTimeStamp,
                    };
                }
            }
        }

        if (!addedMergeColumn)
        {
            var lastMergeDateTimeStamp = GetLastMergeDateTimeStamp(loader.Name, EtlExecutorConstants.DefaultMergeProperty, dataProvider);
            lastMergeDateTimeStampInfo[EtlExecutorConstants.DefaultMergeProperty] = new MergeState()
            {
                Loader = loader.Name,
                Property = EtlExecutorConstants.DefaultMergeProperty,
                LastDateLoadedUtc = lastMergeDateTimeStamp,
            };
            RemoveEntityMergeDateTimeStamps(loader.Name, dataProvider);
        }
        else
        {
            RemoveDefaultMergeDateTimeStamp(loader.Name, dataProvider);
        }

        return lastMergeDateTimeStampInfo;
    }
    
    private DateTime GetLastMergeDateTimeStamp(string sourceName, string dateColumn, IIntegrationTarget destination)
    {
        var lastMergeDateTime = IntegrationExecutorConstants.MinSqlDate;

        var mergeStateTableName = destination.ToTableNameForSqlRaw(IntegrationExecutorConstants.MergeStateTableName, IntegrationExecutorConstants.MergeSchemaName);

        var findQuery = new SqlKata.Query(mergeStateTableName)
            .Where("Property", dateColumn)
            .Where("SourceName", sourceName)
            .Select("LastDateLoadedUtc");

        var findSql = destination.SqlCompiler.Compile(findQuery).ToString();

        object? resultDate = null;
        SqlTask.ExecuteReader(destination.ConnectionManager, findSql, r => resultDate = r);
        if (resultDate is not null)
        {
            if (DateTime.TryParse(resultDate!.ToString(), out var result))
            {
                return result;
            }
        }

        var insertQuery = new SqlKata.Query(mergeStateTableName).AsInsert(
            new
            {
                SourceName = sourceName,
                Property = dateColumn,
                LastDateLoadedUtc = lastMergeDateTime,
                Updated = '1'
            });

        var insertSql = destination.SqlCompiler.Compile(insertQuery).ToString();

        SqlTask.ExecuteNonQuery(destination.ConnectionManager, insertSql);

        return lastMergeDateTime;

    }
    
    protected void UpdateMergeStates(IntegrationMergeStates lastMergeDateTimeStampInfo, IDictionary<string, object?> record)
    {
        foreach (var dateColumn in lastMergeDateTimeStampInfo.Keys)
        {
            if (record.TryGetValue(dateColumn, out var dateColumnValue))
            {
                if (dateColumnValue == null) continue;

                if (DateTime.TryParse(dateColumnValue.ToString(), out var fieldValue))
                {
                    if (fieldValue > lastMergeDateTimeStampInfo[dateColumn].LastDateLoadedUtc)
                    {
                        var changeEntry = lastMergeDateTimeStampInfo[dateColumn];
                        changeEntry.LastDateLoadedUtc = fieldValue;
                        changeEntry.Updated = true;
                        lastMergeDateTimeStampInfo[dateColumn] = changeEntry;
                    }
                }
            }
            else
            {
                if (record.TryGetValue("ChangeDate", out var changeDate))
                {
                    if (changeDate == null) continue;
                    if (DateTime.TryParse(changeDate.ToString(), out var changeDateValue))
                    {
                        var changeEntry = lastMergeDateTimeStampInfo[IntegrationExecutorConstants.DefaultMergeProperty];
                        changeEntry.LastDateLoadedUtc = changeDateValue.ToUniversalTime();
                        changeEntry.Updated = true;
                        lastMergeDateTimeStampInfo[IntegrationExecutorConstants.DefaultMergeProperty] = changeEntry;    
                    }
                }
            }
        }
    }
    
    protected void LogMergeAnalytics(int inserts, int updates, int unchanged, IntegrationMergeStates lastMergeDateTimeStampInfo)
    {
        var lastMergeDateTimeStamp = DateTime.MinValue;
        
        var info = lastMergeDateTimeStampInfo.Values.Select(v => v.LastDateLoadedUtc).ToList();

        if (info.Any())
        {
            lastMergeDateTimeStamp = info.Max();
        }

        if (inserts == 0 && updates == 0)
        {
            if (unchanged > 0)
            {
                _logger.LogInformation(
                    "{nochanges} records found but no change found to merge, last merge at: {lastMergeDateTimeStamp}", unchanged, lastMergeDateTimeStamp);
            }
            else
            {
                _logger.LogInformation("...no changes found to merge");
            }

            return;
        }

        var changes = lastMergeDateTimeStampInfo.Values
            .Where(v => v.Updated)
            .Select(v => v.LastDateLoadedUtc);

        if (changes.Any())
        {
            lastMergeDateTimeStamp = changes.Max();
        }

        _logger.LogInformation("{inserts} records inserted, last merge at {lastMergeDateTimeStamp}", inserts, lastMergeDateTimeStamp);

        _logger.LogInformation("{updates} records updated, last merge at {lastMergeDateTimeStamp}", updates, lastMergeDateTimeStamp);
    }
}