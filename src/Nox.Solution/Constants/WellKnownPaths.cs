using System.IO;

namespace Nox.Solution.Constants;

public static class WellKnownPaths
{
    private static readonly string _userApps = System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData);
    public static readonly string CachePath = Path.Combine(_userApps, "nox");
    public static readonly string SecretsCachePath = Path.Combine(CachePath, "store");
    public static readonly string CacheTokenFile = Path.Combine(SecretsCachePath, "NoxCache-token.json");
}

