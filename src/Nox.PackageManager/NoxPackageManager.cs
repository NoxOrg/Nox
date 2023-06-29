using Nox.PackageManager.Exceptions;
using Nox.Utilities.Configuration;
using NuGet.Configuration;
using NuGet.Packaging;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using NullLogger = NuGet.Common.NullLogger;

namespace Nox.PackageManager;

public class NoxPackageManager
{
    private readonly PackageSource _nuGetPackageSource = new PackageSource("https://api.nuget.org/v3/index.json", "v3");
    private readonly PackageSource _localPackageSource = new PackageSource(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "packages"), "v3");
    private readonly SourceRepository _nugetRepo;
    private readonly SourceRepository? _localRepo;
    private readonly SourceCacheContext _cache;
    private readonly bool _useLocalSource;
    private readonly string _executionPath;

    public NoxPackageManager(string executionPath, bool useLocalSource = false)
    {
        _executionPath = executionPath;
        _useLocalSource = useLocalSource;
        _nugetRepo = Repository
            .Factory
            .GetCoreV3(_nuGetPackageSource);
        if (useLocalSource)
        {
            _localRepo = Repository
                .Factory
                .GetCoreV3(_localPackageSource);
        }
        
        _cache = new SourceCacheContext();
    }

    public void DownloadPackage(string packageId, NuGetVersion? version = null)
    {
        PackageDefinition? packageDefinition = null;
        if (_useLocalSource)
        {
            packageDefinition = FindPackage(_localRepo!, packageId, version);    
        }

        packageDefinition ??= FindPackage(_nugetRepo, packageId, version);

        if (packageDefinition == null) return;
        
        var dependencies = packageDefinition.Resource!.GetDependencyInfoAsync(
            packageId,
            packageDefinition.LatestVersion!,
            _cache,
            NullLogger.Instance,
            CancellationToken.None
        ).Result;

        PackageDependencyGroup? dependencyGroup;
        var targetMoniker = "";
        var netSeven = dependencies.DependencyGroups.FirstOrDefault(dg => dg.TargetFramework.Version.Major == 7);
        var netSix = dependencies.DependencyGroups.FirstOrDefault(dg => dg.TargetFramework.Version.Major == 6);
        var netFive = dependencies.DependencyGroups.FirstOrDefault(dg => dg.TargetFramework.Version.Major == 5);
        if (netSeven != null)
        {
            dependencyGroup = netSeven;
            targetMoniker = "net7.0";
        }
        else if(netSix != null)
        {
            dependencyGroup = netSix;
            targetMoniker = "net6.0";
        } else if (netFive != null)
        {
            dependencyGroup = netFive;
            targetMoniker = "net5.0";
        }
        else
        {
            return;
            //Not all packages have net5, net6, net7 versions
            throw new NoxPackageManagerException($"Package ({packageId}) does not contain a compatible target framework for this solution.");
        }

        foreach (var package in dependencyGroup.Packages)
        {
            DownloadPackage(package.Id, package.VersionRange.MinVersion);
        }

        using var packageStream = new MemoryStream();
        var copyResult = packageDefinition.Resource.CopyNupkgToStreamAsync(
            packageId,
            packageDefinition.LatestVersion,
            packageStream,
            _cache,
            NullLogger.Instance,
            CancellationToken.None).Result;

        if (!copyResult) return;
        using var packageArchiveReader = new PackageArchiveReader(packageStream);
        var dllFiles = packageArchiveReader.GetFiles().Where(f => f.StartsWith($"lib/{targetMoniker}") && f.EndsWith(".dll"));
        foreach (var dllFile in dllFiles)
        {
            var targetFilePath = Path.Combine(_executionPath, Path.GetFileName(dllFile));
            if (!File.Exists(targetFilePath))
            {
                packageArchiveReader.ExtractFile(dllFile, targetFilePath, NullLogger.Instance);    
            }
            
        }

    }

    private PackageDefinition? FindPackage(SourceRepository repo, string packageId, NuGetVersion? version = null)
    {
        var resource = repo.GetResource<FindPackageByIdResource>();
        
        if (version == null)
        {
            var versions = resource.GetAllVersionsAsync(
                packageId,
                _cache,
                NullLogger.Instance,
                CancellationToken.None).Result.ToList();
            if (!versions.Any()) return null;
            var latestVersion = versions.Select(s => new NuGetVersion(s)).Where(s => !s.IsPrerelease).Max();
            return new PackageDefinition
            {
                Resource = resource,
                LatestVersion = latestVersion!
            };
        }

        var versionExists = resource.DoesPackageExistAsync(
            packageId,
            version,
            _cache,
            NullLogger.Instance,
            CancellationToken.None).Result;
        if (!versionExists) return null;
        return new PackageDefinition
        {
            Resource = resource,
            LatestVersion = version
        };
    } 
    
    
}