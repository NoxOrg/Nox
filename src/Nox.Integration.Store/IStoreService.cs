using Nox.Solution;

namespace Nox.Integration.Store;

public interface IStoreService
{
    Task<int> ConfigureIntegrationAsync(Solution.Integration definition, IReadOnlyList<EntityAttribute>? targetAttributes);
    Task<IntegrationMergeStates> GetLastMergeStateAsync(int integrationId);
    Task SetLastMergeState(int integrationId, IntegrationMergeStates mergeStates);
    void UpdateMergeStates(IntegrationMergeStates lastMergeDateTimeStampInfo, IDictionary<string, object?> record);
    Task LogMergeAnalytics(int integrationId, int inserts, int updates, int unchanged, IntegrationMergeStates lastMergeDateTimeStampInfo);
}