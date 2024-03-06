using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System;
using Nox.Solution;
using System.Linq;
using Nox.Generator.Common;

namespace Nox.Generator.Tasks;

public class NoxFileGenerator: NoxGeneratorBase
{
    private readonly IEnumerable<string> _noxYamls = Array.Empty<string>();
    private readonly string? _projectRootDirectory;
    private readonly string _outputDirectory;

    private string AbsoluteOutputPath { 
        get 
        { 
            return Path.Combine(_projectRootDirectory, _outputDirectory); 
        } 
    }

    public NoxFileGenerator(IEnumerable<string> noxYamls, string outputDirectory)
    {
        _noxYamls = noxYamls;
        _outputDirectory = outputDirectory;
        _projectRootDirectory = GetProjectRootDirectory();
    }

    public void GenerateFiles()
    {
        var _debug = new TaskCodeBuilder($"Generator.g.cs", AbsoluteOutputPath);
        List<string> errorCollection = new();

        _debug.AppendLine("/* Found files ->");
        _debug.AppendLine(string.Join("\r\n", _noxYamls.Select(path => $"- {Path.GetFileName(path)}")));

        try
        {
            if (TryGetGeneratorConfig(errorCollection, out var config) && TryGetNoxSolution(errorCollection, out var solution, out string? solutionPath))
            {
                _debug.AppendLine($"Logging Verbosity {config.LoggingVerbosity}");
                
                var codeGeneratorState = new NoxCodeGenConventions(solution, solutionPath);

                NoxGeneratorKind[] enabledGenerators = GetEnabledGenerators(config);

                if (config.LoggingVerbosity == LoggingVerbosity.Diagnostic)
                {
                    _debug.AppendLine($"Enabled Generators Types");
                    _debug.AppendLine(string.Join("\r\n", enabledGenerators.Select(flow => $"- {flow}")));
                }

                INoxFileGenerator[] generators = GetGenerators();

                if (config.LoggingVerbosity == LoggingVerbosity.Diagnostic)
                {
                    _debug.AppendLine($"Found Generators");
                    _debug.AppendLine(string.Join("\r\n", generators.Select(i => $"- {i}")));
                }

                foreach (var flow in enabledGenerators)
                {
                    foreach (var flowInstance in generators.Where(x => x.GeneratorKind == flow))
                    {
                        flowInstance.Generate(
                            codeGeneratorState,
                            config,
                            (logMessage) => _debug.AppendLine($"{flowInstance} {logMessage}"),
                            AbsoluteOutputPath
                            );
                    }
                }
            }
        }
        catch (Exception e)
        {
            errorCollection.Add(e.Message + e.StackTrace);
        }

        if (errorCollection.Any())
        {
            _debug.AppendLine("Errors ->");
            foreach (var e in errorCollection)
            {
                _debug.AppendLine($"- {e}");
            }
        }
        else
        {
            _debug.AppendLine("SUCCESS.");
        }

        _debug.AppendLine("*/");
        _debug.GenerateSourceCode();
    }

    private static INoxFileGenerator[] GetGenerators()
    {
        return Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.IsClass && !x.IsAbstract && typeof(INoxFileGenerator).IsAssignableFrom(x))
            .Select(x => (INoxFileGenerator)Activator.CreateInstance(x))
            .ToArray();
    }

    private bool TryGetGeneratorConfig(IList<string> errorCollection, out GeneratorConfig config)
    {
        config = null!;

        var configFilesAndContent = _noxYamls
            .Where(p => p.EndsWithIgnoreCase("generator.nox.yaml"));

        if (!configFilesAndContent.Any())
        {
            config = new GeneratorConfig();
            return true;
        }

        if (configFilesAndContent.Count() > 1)
        {
            errorCollection.Add("More than one *generator.nox.yaml found in project.");
            return false;
        }

        var configContent = File.ReadAllText(configFilesAndContent.First());

        if (configContent is null)
        {
            errorCollection.Add($"Error loading config file contents from {configFilesAndContent.First()}.");
            return false;
        }

        return DesirializeGeneratorConfig(configContent, errorCollection, out config);
    }
    
    private bool TryGetNoxSolution(List<string> errorCollection, out NoxSolution solution, out string solutionPath)
    {
        solution = null!;
        solutionPath = null!;

        var solutionFilePaths = _noxYamls
            .Where(p => p.EndsWithIgnoreCase(".solution.nox.yaml"));

        if (!solutionFilePaths.Any())
        {
            errorCollection.Add("No *.solution.nox.yaml files found.");
            return false;
        }

        if (solutionFilePaths.Count() > 1)
        {
            errorCollection.Add("More than one *.solution.nox.yaml found.");
            return false;
        }

        var solutionYamlFiles = _noxYamls.ToDictionary(
                item => item,
                item => new Func<TextReader>(() => new StringReader(File.ReadAllText(item)))
            );

        solutionPath = solutionFilePaths.First();

        return TryCreateSolution(errorCollection, ref solution, solutionYamlFiles);
    }

    private string? GetProjectRootDirectory()
    {
        var generatorPath = _noxYamls.FirstOrDefault(x => x.EndsWith("generator.nox.yaml"));
        if(generatorPath != null)
            return Path.GetDirectoryName(generatorPath);

        return AppDomain.CurrentDomain.BaseDirectory;
    }
}