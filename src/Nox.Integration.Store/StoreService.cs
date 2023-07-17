using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nox.Integration.Abstractions;
using Nox.Integration.Constants;
using Nox.Integration.Exceptions;
using Nox.Solution;

namespace Nox.Integration.Store;

public class StoreService: IStoreService
{
    private readonly ILogger _logger;
    private readonly IntegrationDbContext _dbContext;
    
    public StoreService(
        ILogger logger,
        IntegrationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }
    
    public async Task ConfigureAsync(IReadOnlyList<Solution.Integration> definition)
    {
        foreach (var integration in definition)
        {
            await _dbContext
                .Integrations!
                .AddAsync(new Integration
            {
                Name = integration.Name,
                Source = new Source
                {
                    Name = integration.Source!.Name,
                    MergeStates = integration.Source.Watermark!.DateColumns!.Select(dc => new MergeState
                    {
                        Property = dc,
                        LastDateLoadedUtc = IntegrationExecutorConstants.MinSqlDate,
                        Updated = false
                    }).ToList()
                }
            });
        }

        await _dbContext.SaveChangesAsync();
    }

    public async Task<IntegrationMergeStates> GetAllLastMergeDateTimeStampsAsync(string integrationName, IntegrationSourceWatermark watermark, Entity entity)
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
                    var lastMergeDateTimeStamp = await GetLastMergeDateTimeStampAsync(integrationName, dateColumn);

                    lastMergeDateTimeStampInfo[dateColumn] = new IntegrationMergeState()
                    {
                        IntegrationName = integrationName,
                        Property = dateColumn,
                        LastDateLoadedUtc = lastMergeDateTimeStamp,
                    };
                }
            }
        }

        if (!addedMergeColumn)
        {
            var lastMergeDateTimeStamp = await GetLastMergeDateTimeStampAsync(integrationName, IntegrationExecutorConstants.DefaultMergeProperty);
            lastMergeDateTimeStampInfo[IntegrationExecutorConstants.DefaultMergeProperty] = new IntegrationMergeState
            {
                IntegrationName = integrationName,
                Property = IntegrationExecutorConstants.DefaultMergeProperty,
                LastDateLoadedUtc = lastMergeDateTimeStamp,
            };
            await RemoveEntityMergeDateTimeStampsAsync(integrationName);
        }
        else
        {
            await RemoveDefaultMergeDateTimeStampAsync(integrationName);
        }

        return lastMergeDateTimeStampInfo;
    }

    public void UpdateMergeStates(IntegrationMergeStates lastMergeDateTimeStampInfo, IDictionary<string, object?> record)
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

    public void LogMergeAnalytics(int inserts, int updates, int unchanged, IntegrationMergeStates lastMergeDateTimeStampInfo)
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

    private async Task<DateTime> GetLastMergeDateTimeStampAsync(string integrationName, string dateColumn)
    {
        try
        {
            var integration = await _dbContext.Integrations!.SingleAsync(i => i.Name.Equals(integrationName, StringComparison.OrdinalIgnoreCase));
            var mergeState = integration.Source!.MergeStates!.Single(ms => ms.Property.Equals(dateColumn, StringComparison.OrdinalIgnoreCase));
            return mergeState.LastDateLoadedUtc;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            throw new NoxIntegrationException($"Error getting last merge date time for integration {integrationName}.", ex);
        }
    }
    
    private async Task RemoveDefaultMergeDateTimeStampAsync(string integrationName)
    {
        var integration = await _dbContext.Integrations!.SingleAsync(i => i.Name.Equals(integrationName, StringComparison.OrdinalIgnoreCase));
        var defaultMergeState = integration.Source!.MergeStates!.FirstOrDefault(ms => ms.Property.Equals(IntegrationExecutorConstants.DefaultMergeProperty, StringComparison.OrdinalIgnoreCase));
        if (defaultMergeState != null)
        {
            _dbContext.MergeStates!.Remove(defaultMergeState);
            await _dbContext.SaveChangesAsync();
        }
    }
    
    private async Task RemoveEntityMergeDateTimeStampsAsync(string integrationName)
    {
        var integration = await _dbContext.Integrations!.SingleAsync(i => i.Name.Equals(integrationName, StringComparison.OrdinalIgnoreCase));
        var entityMergeStates = integration
            .Source!
            .MergeStates!
            .Where(ms => !ms.Property.Equals(IntegrationExecutorConstants.DefaultMergeProperty, StringComparison.OrdinalIgnoreCase))
            .ToList();
        if (entityMergeStates.Any())
        {
            _dbContext.MergeStates!.RemoveRange(entityMergeStates);
            await _dbContext.SaveChangesAsync();
        }
    }
}