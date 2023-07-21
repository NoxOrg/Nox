using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Nox.Integration.Constants;
using Nox.Integration.Exceptions;

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

    public async Task<int> ConfigureIntegrationAsync(Solution.Integration definition, IReadOnlyList<EntityAttribute>? targetAttributes)
    {
        try
        {
            var jsonDef = JsonSerializer.Serialize(definition);
            var integration = await _dbContext
                .Integrations!
                .Include(i => i.MergeStates)
                .FirstOrDefaultAsync(i => i.Name.Equals(definition.Name));
            if (integration == null)
            {
                integration = new Integration
                {
                    Name = definition.Name,
                    Definition = jsonDef,
                    CreatedOn = DateTime.Now,
                    MergeStates = new List<MergeState>(),
                };
                await _dbContext.Integrations!.AddAsync(integration);
            }
            else
            {
                if (integration.Definition != jsonDef)
                {
                    integration.Definition = jsonDef;
                    integration.UpdatedOn = DateTime.Now;
                }
            }

            bool addedMergeColumns = false;

            var mergeColumns = GetEntityMergeColumns(definition, targetAttributes);
            if (mergeColumns != null)
            {
                addedMergeColumns = true;
                AddEntityMergeState(integration, mergeColumns);
            }

            if (!addedMergeColumns)
            {
                AddDefaultMergeState(integration);
            }

            await _dbContext.SaveChangesAsync();
            return integration.Id;
        }
        catch(Exception ex)
        {
            throw new NoxIntegrationException($"Unable to configure the integration store for integration: {definition.Name}", ex);
        }
    }

    public async Task<IntegrationMergeStates> GetLastMergeStateAsync(int integrationId)
    {
        var integration = await _dbContext.Integrations!.SingleAsync(i => i.Id == integrationId);

        var result = new IntegrationMergeStates();

        foreach (var mergeState in integration.MergeStates!)
        {
            result.TryAdd(mergeState.Property, new IntegrationMergeState
            {
                IntegrationName = integration.Name,
                Property = mergeState.Property,
                Updated = mergeState.Updated,
                LastDateLoadedUtc = mergeState.LastDateLoadedUtc
            });
        }

        return result;
    }

    public async Task SetLastMergeState(int integrationId, IntegrationMergeStates mergeStates)
    {
        var integration = await _dbContext
            .Integrations!
            .Include(i => i.MergeStates)
            .SingleAsync(i => i.Id == integrationId);
            
        foreach (var (dateColumn, mergeState) in mergeStates.Where(ms => ms.Value.Updated))
        {
            var dbMergeState = integration.MergeStates!.Single(dbms => dbms.Property.Equals(dateColumn));
            dbMergeState.LastDateLoadedUtc = mergeState.LastDateLoadedUtc;
        }

        await _dbContext.SaveChangesAsync();
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

    public async Task LogMergeAnalytics(int integrationId, int inserts, int updates, int unchanged, IntegrationMergeStates lastMergeDateTimeStampInfo)
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
                _logger.LogInformation("{nochanges} records found but no change found to merge, last merge at: {lastMergeDateTimeStamp}", unchanged, lastMergeDateTimeStamp);
            }
            else
            {
                _logger.LogInformation("...no changes found to merge");
            }

        }

        var changes = lastMergeDateTimeStampInfo.Values
            .Where(v => v.Updated)
            .Select(v => v.LastDateLoadedUtc)
            .ToList();

        if (changes.Any())
        {
            lastMergeDateTimeStamp = changes.Max();
        }

        var integration = await _dbContext.Integrations!.SingleAsync(i => i.Id == integrationId);
        integration.MergeAnalytics ??= new List<MergeAnalytic>();
        integration.MergeAnalytics.Add(new MergeAnalytic
        {
            Inserts = inserts,
            Updates = updates,
            Unchanged = unchanged,
            Timestamp = lastMergeDateTimeStamp
        });

        await _dbContext.SaveChangesAsync();
        

        _logger.LogInformation("{inserts} records inserted, last merge at {lastMergeDateTimeStamp}", inserts, lastMergeDateTimeStamp);

        _logger.LogInformation("{updates} records updated, last merge at {lastMergeDateTimeStamp}", updates, lastMergeDateTimeStamp);
    }

    private List<string>? GetEntityMergeColumns(Solution.Integration definition, IReadOnlyList<EntityAttribute>? targetAttributes)
    {
        if (definition.Target!.EntityOptions == null ||
            definition.Target.EntityOptions.DateCompareColumns == null ||
            !definition.Target.EntityOptions.DateCompareColumns.Any() ||
            targetAttributes == null ||
            !targetAttributes.Any()) return null;
        var targetMergeColumns = definition.Target.EntityOptions.DateCompareColumns;
        var mergeColumns = targetMergeColumns.Intersect(targetAttributes.Select(n => n.Name)).ToList();
        return mergeColumns.Any() ? mergeColumns : null;
    }

    private void AddDefaultMergeState(Integration integration)
    {
        //Remove any entity merge states
        if (integration.MergeStates!.Any(ms => !ms.Property.Equals(IntegrationConstants.DefaultMergeProperty, StringComparison.OrdinalIgnoreCase)))
        {
            integration.MergeStates!.Clear();
        }

        //Add the default merge state
        if (!integration.MergeStates!.Any(ms => ms.Property.Equals(IntegrationConstants.DefaultMergeProperty, StringComparison.OrdinalIgnoreCase)))
        {
            integration.MergeStates!.Add(new MergeState
            {
                Property = IntegrationConstants.DefaultMergeProperty,
                LastDateLoadedUtc = IntegrationConstants.MinSqlDate,
                Updated = false
            });
        }
    }

    private void AddEntityMergeState(Integration integration, List<string> mergeColumns)
    {
        //Remove the default mergse state
        var defaultMergeColumn = integration.MergeStates!.FirstOrDefault(ms => ms.Property.Equals(IntegrationConstants.DefaultMergeProperty, StringComparison.OrdinalIgnoreCase));
        if (defaultMergeColumn != null) integration.MergeStates!.Remove(defaultMergeColumn);
        
        //Add the entity merge states
        foreach (var mergeColumn in mergeColumns)
        {
            var existingMergeColumn = integration.MergeStates!.FirstOrDefault(ms => ms.Property.Equals(mergeColumn, StringComparison.OrdinalIgnoreCase));
            if (existingMergeColumn == null)
            {
                integration.MergeStates!.Add(new MergeState
                {
                    Property = mergeColumn,
                    LastDateLoadedUtc = IntegrationConstants.MinSqlDate,
                    Updated = false
                });                
            }
        }
    }
}