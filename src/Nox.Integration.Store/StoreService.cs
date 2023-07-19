using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nox.Integration.Constants;
using Nox.Integration.Exceptions;
using Nox.Solution;

namespace Nox.Integration.Store;

public class StoreService: IStoreService
{
    private readonly ILogger<StoreService> _logger;
    private readonly IntegrationDbContext _dbContext;
    
    public StoreService(
        ILogger<StoreService> logger,
        IntegrationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public async Task<int> ConfigureIntegrationAsync(Solution.Integration definition, string[]? targetAttributes)
    {
        var integration = await _dbContext.Integrations!.FirstOrDefaultAsync(i => i.Name.Equals(definition.Name, StringComparison.OrdinalIgnoreCase));
        if (integration == null)
        {
            integration = new Integration
            {
                Name = integration!.Name,
                Definition = JsonSerializer.Serialize(definition),
                CreatedOn = DateTime.Now,
                MergeStates = new List<MergeState>()
            };
            await _dbContext.Integrations!.AddAsync(integration);
            
            bool addedMergeColumns = false;

            var mergeColumns = GetEntityMergeColumns(definition, targetAttributes);
            if (mergeColumns != null)
            {
                addedMergeColumns = true;
                foreach (var mergeColumn in mergeColumns)
                {
                    integration.MergeStates.Add(new MergeState
                    {
                        Property = mergeColumn,
                        LastDateLoadedUtc = IntegrationConstants.MinSqlDate,
                        Updated = false
                    });
                }
            }

            if (!addedMergeColumns)
            {
                integration.MergeStates.Add(new MergeState
                {
                    Property = IntegrationConstants.DefaultMergeProperty,
                    LastDateLoadedUtc = IntegrationConstants.MinSqlDate,
                    Updated = false
                });
            }
        }
        else
        {
            integration.UpdatedOn = DateTime.Now;
            //Check if the merge columns are still valid
            
        }

        await _dbContext.SaveChangesAsync();
        return integration.Id;
    }

    public async Task<IntegrationMergeStates> GetAllLastMergeDateTimeStampsAsync(int integrationId, Entity entity)
    {
        var lastMergeDateTimeStampInfo = new IntegrationMergeStates();

        var addedMergeColumn = false;

        var watermark = definition.Source!.Watermark!;
        
        if (watermark.DateColumns != null)
        {
            foreach (var dateColumn in watermark.DateColumns)
            {
                if (entity.Attributes!.Any(a => a.Name.Equals(dateColumn, StringComparison.InvariantCultureIgnoreCase)))
                {
                    addedMergeColumn = true;
                    //TODO fix loadername
                    var lastMergeDateTimeStamp = await GetLastMergeDateTimeStampAsync(definition.Name, dateColumn);

                    lastMergeDateTimeStampInfo[dateColumn] = new IntegrationMergeState()
                    {
                        IntegrationName = definition.Name,
                        Property = dateColumn,
                        LastDateLoadedUtc = lastMergeDateTimeStamp,
                    };
                }
            }
        }

        if (!addedMergeColumn)
        {
            var lastMergeDateTimeStamp = await GetLastMergeDateTimeStampAsync(definition.Name, IntegrationConstants.DefaultMergeProperty);
            lastMergeDateTimeStampInfo[IntegrationConstants.DefaultMergeProperty] = new IntegrationMergeState
            {
                IntegrationName = definition.Name,
                Property = IntegrationConstants.DefaultMergeProperty,
                LastDateLoadedUtc = lastMergeDateTimeStamp,
            };
            await RemoveEntityMergeDateTimeStampsAsync(definition.Name);
        }
        else
        {
            await RemoveDefaultMergeDateTimeStampAsync(definition.Name);
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
                        var changeEntry = lastMergeDateTimeStampInfo[IntegrationConstants.DefaultMergeProperty];
                        changeEntry.LastDateLoadedUtc = changeDateValue.ToUniversalTime();
                        changeEntry.Updated = true;
                        lastMergeDateTimeStampInfo[IntegrationConstants.DefaultMergeProperty] = changeEntry;    
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
            var lastMergeDateTime = IntegrationConstants.MinSqlDate;
            var integration = await _dbContext.Integrations!.FirstOrDefaultAsync(i => i.Name.Equals(integrationName, StringComparison.OrdinalIgnoreCase));
            if (integration == null)
            {
                integration = new Integration
                {
                    Name = integrationName,
                    Source = new Source
                    {
                        Name = 
                    }
                };
                
                await _dbContext.AddAsync(integration);
            }
            var mergeState = integration.Source!.MergeStates!.Single(ms => ms.Property.Equals(dateColumn, StringComparison.OrdinalIgnoreCase));
            return lastMergeDateTime;
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
        var defaultMergeState = integration.Source!.MergeStates!.FirstOrDefault(ms => ms.Property.Equals(IntegrationConstants.DefaultMergeProperty, StringComparison.OrdinalIgnoreCase));
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
            .Where(ms => !ms.Property.Equals(IntegrationConstants.DefaultMergeProperty, StringComparison.OrdinalIgnoreCase))
            .ToList();
        if (entityMergeStates.Any())
        {
            _dbContext.MergeStates!.RemoveRange(entityMergeStates);
            await _dbContext.SaveChangesAsync();
        }
    }

    private List<string>? GetEntityMergeColumns(Solution.Integration definition, string[]? targetAttributes)
    {
        if (definition.Target!.EntityOptions == null ||
            definition.Target.EntityOptions.DateCompareColumns == null ||
            !definition.Target.EntityOptions.DateCompareColumns.Any() ||
            targetAttributes == null ||
            !targetAttributes.Any()) return null;
        var targetMergeColumns = definition.Target.EntityOptions.DateCompareColumns;
        var mergeColumns = targetMergeColumns.Intersect(targetAttributes).ToList();
        return mergeColumns.Any() ? mergeColumns : null;
    }
}