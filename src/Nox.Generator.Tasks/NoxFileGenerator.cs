using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System;
using Nox.Solution;
using Nox.Generator.Tasks.Common;
using System.Linq;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Core;

namespace Nox.Generator.Tasks;

internal class NoxFileGenerator
{
    private const string _outputFolder = "Nox.Generated";

    private readonly List<string> _errors = new();
    private readonly IEnumerable<string> _noxYamls = Array.Empty<string>();
    private readonly string? _projectRootDirectory;

    private string AbsoluteOutputPath { 
        get 
        { 
            return Path.Combine(_projectRootDirectory, _outputFolder); 
        } 
    }

    public NoxFileGenerator(IEnumerable<string> noxYamls)
    {
        _noxYamls = noxYamls;
        _projectRootDirectory = GetProjectRootDirectory();
    }

    public void GenerateFiles()
    {
        var _debug = new CodeBuilder($"Generator.g.cs", AbsoluteOutputPath);
        _errors.Clear();

        _debug.AppendLine("/* v 1 0 0 11");
        _debug.AppendLine("Found files ->");
        _debug.AppendLine(string.Join("\r\n", _noxYamls.Select(path => $"- {Path.GetFileName(path)}")));

        try
        {
            if (TryGetGeneratorConfig(out var config) && TryGetNoxSolution(out var solution))
            {
                _debug.AppendLine($"Logging Verbosity {config.LoggingVerbosity}");

                var codeGeneratorState = new NoxCodeGenConventions(solution);

                var generatorFlows = new (NoxGeneratorKind GeneratorKind, bool IsEnabled)[]
                {
                    (NoxGeneratorKind.None,true),
                    (NoxGeneratorKind.Domain,config.Domain),
                    (NoxGeneratorKind.Infrastructure,config.Infrastructure),
                    (NoxGeneratorKind.Presentation,config.Presentation),
                    (NoxGeneratorKind.Application,config.Application),
                    (NoxGeneratorKind.Ui,config.Ui)
                }
                .Where(x => x.IsEnabled)
                .Select(x => x.GeneratorKind)
                .ToArray();

                if (config.LoggingVerbosity == LoggingVerbosity.Diagnostic)
                {
                    _debug.AppendLine($"Enabled Generators Types");
                    _debug.AppendLine(string.Join("\r\n", generatorFlows.Select(flow => $"- {flow}")));
                }

                var generatorInstances = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .Where(x => x.IsClass && !x.IsAbstract && typeof(INoxFileGenerator).IsAssignableFrom(x))
                    .Select(x => (INoxFileGenerator)Activator.CreateInstance(x))
                    .ToArray();

                if (config.LoggingVerbosity == LoggingVerbosity.Diagnostic)
                {
                    _debug.AppendLine($"Found Generators");
                    _debug.AppendLine(string.Join("\r\n", generatorInstances.Select(i => $"- {i}")));
                }

                foreach (var flow in generatorFlows)
                {
                    foreach (var flowInstance in generatorInstances.Where(x => x.GeneratorKind == flow))
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
            _errors.Add(e.Message + e.StackTrace);
        }

        if (_errors.Any())
        {
            _debug.AppendLine("Errors ->");
            foreach (var e in _errors)
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

    private bool TryGetGeneratorConfig(out GeneratorConfig config)
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
            _errors.Add("More than one *generator.nox.yaml found in project.");
            return false;
        }

        var configContent = File.ReadAllText(configFilesAndContent.First());

        if (configContent is null)
        {
            _errors.Add($"Error loading config file contents from {configFilesAndContent.First()}.");
            return false;
        }

        try
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

            config = deserializer.Deserialize<GeneratorConfig>(configContent);
            config.Validate();
        }
        catch (YamlException e)
        {
            _errors.Add(e.Message);
            if (e.InnerException is not null)
            {
                _errors.Add(e.InnerException.Message);
            }

            return false;
        }

        return true;
    }

    private bool TryGetNoxSolution(out NoxSolution solution)
    {
        solution = null!;

        var solutionFilePaths = _noxYamls
            .Where(p => p.EndsWithIgnoreCase(".solution.nox.yaml"));

        if (!solutionFilePaths.Any())
        {
            _errors.Add("No *.solution.nox.yaml files found.");
            return false;
        }

        if (solutionFilePaths.Count() > 1)
        {
            _errors.Add("More than one *.solution.nox.yaml found.");
            return false;
        }

        try
        {
            var yamlsFilesAndContent = _noxYamls.ToDictionary(
                item => item,
                item => new Func<TextReader>(() => new StringReader(File.ReadAllText(item)))
            );

            solution = new NoxSolutionBuilder()
                .UseYamlFilesAndContent(yamlsFilesAndContent)
                .Build();
        }
        catch (YamlException e)
        {
            _errors.Add(e.Message);
            if (e.InnerException is not null)
            {
                _errors.Add(e.InnerException.Message);
            }

            return false;
        }

        return true;
    }

    private string? GetProjectRootDirectory()
    {
        var generatorPath = _noxYamls.FirstOrDefault(x => x.EndsWith("generator.nox.yaml"));
        if(generatorPath != null)
            return Path.GetDirectoryName(generatorPath);

        return AppDomain.CurrentDomain.BaseDirectory;
    }
}