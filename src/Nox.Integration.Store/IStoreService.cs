using Nox.Integration.Abstractions;
using Nox.Solution;

namespace Nox.Integration.Store;

public interface IStoreService
{
    Task ConfigureAsync(IReadOnlyList<Solution.Integration> definition);
    Task<IntegrationMergeStates> GetAllLastMergeDateTimeStampsAsync(string integrationName, IntegrationSourceWatermark watermark, Entity entity);
    void UpdateMergeStates(IntegrationMergeStates lastMergeDateTimeStampInfo, IDictionary<string, object?> record);
    void LogMergeAnalytics(int inserts, int updates, int unchanged, IntegrationMergeStates lastMergeDateTimeStampInfo);
}