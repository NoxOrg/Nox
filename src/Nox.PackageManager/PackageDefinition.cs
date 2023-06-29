using NuGet.Protocol.Core.Types;
using NuGet.Versioning;

namespace Nox.PackageManager;

public class PackageDefinition
{
    public FindPackageByIdResource? Resource { get; set; }
    public NuGetVersion? LatestVersion { get; set; }
}