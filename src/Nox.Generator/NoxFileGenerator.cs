using Nox.Generator.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using YamlDotNet.Core;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;
using Nox.Solution;
using System.Reflection;
using Nox.Generator.Application.Commands;

namespace Nox.Generator;

[System.Diagnostics.CodeAnalysis.SuppressMessage("MicrosoftCodeAnalysisCorrectness", "RS1035:Do not use APIs banned for analyzers", Justification = "<Pending>")]
public class NoxFileGenerator
{
    private readonly List<string> _errors = new();
    private readonly IEnumerable<string> _noxYamls = Array.Empty<string>();

    public NoxFileGenerator(IEnumerable<string> noxYamls)
    {
#if DEBUG
        if (!Debugger.IsAttached)
        {
            //Debugger.Launch();
        }
#endif
        _noxYamls = noxYamls;
    }

    public void GenerateFiles()
    {
        try
        {
            if (TryGetGeneratorConfig(out var config) && TryGetNoxSolution(out var solution))
            {
                var codeGeneratorState = new NoxSolutionCodeGeneratorState(solution, Assembly.GetEntryAssembly()!);

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

                //var generatorInstances = Assembly
                //    .GetExecutingAssembly()
                //    .GetTypes()
                //    .Where(x => x.IsClass && !x.IsAbstract && typeof(INoxFileGenerator).IsAssignableFrom(x))
                //    .Select(x => (INoxFileGenerator)Activator.CreateInstance(x))
                //    .ToArray();

                var generatorInstances = new List<INoxFileGenerator> 
                { 
                    new NavigationMenuRazorGenerator() 
                };

                var projectRoot = GetProjectRootDirectory();

                foreach (var flow in generatorFlows)
                {
                    foreach (var flowInstance in generatorInstances.Where(x => x.GeneratorKind == flow))
                    {
                        flowInstance.Generate(codeGeneratorState, projectRoot);
                    }
                }
            }
        }
        catch (Exception e)
        {
            _errors.Add(e.Message + e.StackTrace);
        }
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
        return Path.GetDirectoryName(generatorPath);
    }
}
