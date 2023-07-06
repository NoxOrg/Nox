using System.Reflection;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;

namespace Nox.Tests.ProjectDependencies;

public class CodeAnalysisSolutionFixture : IAsyncLifetime
{
    private const string SolutionPath = "src/Nox.Generator.sln";

    public Solution Solution { get; private set; } = null!;
    public Project NoxTypesProject { get; private set; } = null!;
    public Project NoxSolutionNet7 { get; private set; } = null!;
    public Project NoxSolutionNetStd20 { get; private set; } = null!;

    public async Task InitializeAsync()
    {
        MSBuildLocator.RegisterDefaults();

        var workspace = MSBuildWorkspace.Create();

        Solution = await workspace.OpenSolutionAsync(GetSolutionFile());

        NoxTypesProject = Solution.Projects.Single(project => project.Name == "Nox.Types");
        NoxSolutionNet7 = Solution.Projects.Single(project => project.Name == "Nox.Solution(net7.0)");
        NoxSolutionNetStd20 = Solution.Projects.Single(project => project.Name == "Nox.Solution(netstandard2.0)");
    }

    public Task DisposeAsync()
    {
        return Task.CompletedTask;
    }
    private string GetSolutionFile()
    {
        return GetSolutionFile(Directory.GetParent(Assembly.GetExecutingAssembly().Location));
    }

    private string GetSolutionFile(DirectoryInfo? directoryInfo)
    {
        if (directoryInfo == null)
            throw new Exception($"Could not find solution {SolutionPath}");

        var filePath = Path.Combine(directoryInfo.FullName, SolutionPath);

        if (File.Exists(filePath))
        {
            return filePath;
        }

        return GetSolutionFile(directoryInfo.Parent);
    }
}