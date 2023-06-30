using NuGet.Configuration;

namespace Nox.PackageManager;

public class NoxPackageSourceProvider: IPackageSourceProvider
{
    private IEnumerable<PackageSource> PackageSources { get; set; }

    public NoxPackageSourceProvider(IEnumerable<PackageSource> packageSources)
    {
        PackageSources = packageSources;
    }

    public IEnumerable<PackageSource> LoadPackageSources() => PackageSources;
    
    public event EventHandler? PackageSourcesChanged;
    
    public void SavePackageSources(IEnumerable<PackageSource> sources)
    {
        PackageSources = sources;
        PackageSourcesChanged?.Invoke(this, null!);
    }

    public PackageSource GetPackageSourceByName(string name)
    {
        throw new NotImplementedException();
    }

    public PackageSource GetPackageSourceBySource(string source)
    {
        throw new NotImplementedException();
    }

    public void RemovePackageSource(string name)
    {
        throw new NotImplementedException();
    }

    public void EnablePackageSource(string name)
    {
        throw new NotImplementedException();
    }

    public void DisablePackageSource(string name)
    {
        throw new NotImplementedException();
    }

    public void UpdatePackageSource(PackageSource source, bool updateCredentials, bool updateEnabled)
    {
        throw new NotImplementedException();
    }

    public void AddPackageSource(PackageSource source)
    {
        throw new NotImplementedException();
    }

    public bool IsPackageSourceEnabled(string name)
    {
        throw new NotImplementedException();
    }

    public void SaveActivePackageSource(PackageSource source)
    {
        throw new NotImplementedException();
    }

    public string ActivePackageSourceName => throw new NotImplementedException();
    public string DefaultPushSource => throw new NotImplementedException();
    
}