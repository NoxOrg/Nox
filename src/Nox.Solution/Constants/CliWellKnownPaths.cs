using System.IO;

namespace Nox.Solution.Constants;

public static class CliWellKnownPaths
{
    public static readonly string CacheFile = Path.Combine(WellKnownPaths.CachePath, "NoxCliCache.json");
    public static readonly string WorkflowsCachePath = Path.Combine(WellKnownPaths.CachePath, "workflows");
    public static readonly string TemplatesCachePath = Path.Combine(WellKnownPaths.CachePath, "templates");
    public static readonly string CacheTokenFile = Path.Combine(WellKnownPaths.SecretsCachePath, "NoxCliCache-token.json");
}