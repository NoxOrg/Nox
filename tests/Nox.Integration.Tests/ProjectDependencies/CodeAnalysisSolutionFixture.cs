using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using System.Reflection;

namespace Nox.Integration.Tests.ProjectDependencies;

public class CodeAnalysisSolutionFixture : IAsyncLifetime
{
    private const string SolutionPath = "src/Nox.Generator.sln";

    public Microsoft.CodeAnalysis.Solution Solution { get; private set; } = null!;
    public ProjectDependencyGraph ProjectDependencyGraph { get; private set; } = null!;

    public Project NoxYamlProject { get; private set; } = null!;
    public Project NoxTypesAbstractionsProject { get; private set; } = null!;
    public Project NoxTypesProject { get; private set; } = null!;
    public Project NoxSolution { get; private set; } = null!;
    public Project NoxGenerator { get; private set; } = null!;
    public Project NoxAbstractions { get; private set; } = null!;

    public async Task InitializeAsync()
    {
        MSBuildLocator.RegisterDefaults();

        var workspace = MSBuildWorkspace.Create();

        Solution = await workspace.OpenSolutionAsync(GetSolutionFile());

        ProjectDependencyGraph = Solution.GetProjectDependencyGraph();

        NoxYamlProject = Solution.Projects.Single(project => project.Name == "Nox.Yaml");
        NoxTypesProject = Solution.Projects.Single(project => project.Name == "Nox.Types");
        NoxTypesAbstractionsProject = Solution.Projects.Single(project => project.Name == "Nox.Types.Abstractions");
        NoxSolution = Solution.Projects.Single(project => project.Name == "Nox.Solution");
        NoxGenerator = Solution.Projects.Single(project => project.Name == "Nox.Generator");
        NoxAbstractions = Solution.Projects.Single(project => project.Name == "Nox.Abstractions");
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