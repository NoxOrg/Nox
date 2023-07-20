using Nox.Solution;

namespace Nox.Integration.Store;

public interface IStoreService
{
    Task<int> ConfigureIntegrationAsync(Solution.Integration definition, IReadOnlyList<string>? targetAttributes);
    Task<IntegrationMergeStates> GetAllLastMergeDateTimeStampsAsync(int integrationId);
    void UpdateMergeStates(IntegrationMergeStates lastMergeDateTimeStampInfo, IDictionary<string, object?> record);
    Task LogMergeAnalytics(int integrationId, int inserts, int updates, int unchanged, IntegrationMergeStates lastMergeDateTimeStampInfo);
}