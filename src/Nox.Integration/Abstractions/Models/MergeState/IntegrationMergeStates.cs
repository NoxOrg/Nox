using System.Collections.Concurrent;

namespace Nox.Integration.Abstractions.Models;

public class IntegrationMergeStates: ConcurrentDictionary<string, IntegrationMergeState>
{
}