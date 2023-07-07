namespace Nox.Abstractions.Configuration;

public class WellKnownPaths
{
    private static readonly string UserApps = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
    public static readonly string CachePath = Path.Combine(UserApps, "nox");
    public static readonly string SecretsCachePath = Path.Combine(CachePath, "store");
}

