using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Generator.Common;
using Nox.Solution;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Nox.Generator;

public abstract class NoxGeneratorBase
{
    protected static bool DesirializeGeneratorConfig(string configContent, IList<string> errorCollection, out GeneratorConfig config)
    {
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
            errorCollection.Add(e.Message);
            if (e.InnerException is not null)
            {
                errorCollection.Add(e.InnerException.Message);
            }
            config = new GeneratorConfig();
            return false;
        }
        return true;
    }
    protected static bool TryCreateSolution(IList<string> errorCollection, ref NoxSolution solution, Dictionary<string, Func<TextReader>> solutionFileAndContent)
    {
        try
        {
            solution = new NoxSolutionBuilder()
                .WithYamlFilesAndContent(solutionFileAndContent)
                .Build();
        }
        catch (YamlException e)
        {
            errorCollection.Add(e.Message);
            if (e.InnerException is not null)
            {
                errorCollection.Add(e.InnerException.Message);
            }

            return false;
        }

        return true;
    }
    protected static NoxGeneratorKind[] GetEnabledGenerators(GeneratorConfig config)
    {
        return new (NoxGeneratorKind GeneratorKind, bool IsEnabled)[]
        {
                    (NoxGeneratorKind.None,true),
                    (NoxGeneratorKind.Domain,config.Domain),
                    (NoxGeneratorKind.Infrastructure,config.Infrastructure),
                    (NoxGeneratorKind.Presentation,config.Presentation),
                    (NoxGeneratorKind.Application,config.Application),
                    (NoxGeneratorKind.ApplicationDto,config.ApplicationDto),
                    (NoxGeneratorKind.Ui,config.Ui)
        }
        .Where(x => x.IsEnabled)
        .Select(x => x.GeneratorKind)
        .ToArray();
    }
}

[Generator]
public class NoxCodeGenerator : NoxGeneratorBase, IIncrementalGenerator
{

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
#if DEBUG
        if (!Debugger.IsAttached)
        {
           // Debugger.Launch();
        }
        // var compilation = context.CompilationProvider.Select((ctx,token) => ctx.GlobalNamespace);
#endif
        var noxYamls = context.AdditionalTextsProvider
            .Where(text => text.Path.EndsWithIgnoreCase(".nox.yaml"))
            .Select((text, token) => (Path: Path.GetFullPath(text.Path), Source: text.GetText(token)))
            .Collect();

        context.RegisterSourceOutput(noxYamls, GenerateSource);
    }

    private void GenerateSource(SourceProductionContext context, ImmutableArray<(string Path, SourceText? Source)> noxYamls)
    {
        var _debug = new CodeBuilder($"Generator.g.cs", context);
        List<string> errorCollection = new();

        _debug.AppendLine("// Found files ->");
        foreach (var (path, _) in noxYamls)
        {
            _debug.AppendLine($"//  - {Path.GetFileName(path)}");
        }

        try
        {
            if (TryGetGeneratorConfig(noxYamls, errorCollection, out var config) && TryGetNoxSolution(noxYamls, errorCollection, out var solution))
            {
                _debug.AppendLine($"// Logging Verbosity {config.LoggingVerbosity}");

                var codeGenConventions = new NoxCodeGenConventions(solution);

                NoxGeneratorKind[] enabledGenerators = GetEnabledGenerators(config);

                if (config.LoggingVerbosity == LoggingVerbosity.Diagnostic)
                {
                    _debug.AppendLine($"// Enabled Generators Types");
                    foreach (var flow in enabledGenerators)
                    {
                        _debug.AppendLine($"//  - {flow}");
                    }
                }

                INoxCodeGenerator[] generators = GetGenerators();

                if (config.LoggingVerbosity == LoggingVerbosity.Diagnostic)
                {
                    _debug.AppendLine($"// Found Generators");
                    foreach (var generatorInstance in generators)
                    {
                        _debug.AppendLine($"//  - {generatorInstance}");
                    }
                }


                var projectRoot = GetProjectRootDirectory(noxYamls);

                foreach (var flow in enabledGenerators)
                {
                    foreach (var flowInstance in generators.Where(x => x.GeneratorKind == flow))
                    {
                        try
                        {
                            flowInstance.Generate(
                            context,
                            codeGenConventions,
                            config,
                            (logMessage) => _debug.AppendLine($"// {flowInstance} {logMessage}"),
                            projectRoot
                            );
                        }
                        catch
                        {
                            _debug.AppendLine($"// Error in Generator: {flowInstance}");
                            throw;
                        }
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
            _debug.AppendLine("// Errors ->");
            foreach (var e in errorCollection)
            {
                _debug.AppendLine($"//  - {e}");
            }
        }
        else
        {
            _debug.AppendLine("// SUCCESS.");
        }

        _debug.GenerateSourceCode();
    }

    private static INoxCodeGenerator[] GetGenerators()
    {
        return Assembly
            .GetExecutingAssembly()
            .GetTypes()
            .Where(x => x.IsClass && !x.IsAbstract && typeof(INoxCodeGenerator).IsAssignableFrom(x))
            .Select(x => (INoxCodeGenerator)Activator.CreateInstance(x))
            .ToArray();
    }

    protected static bool TryGetNoxSolution(
       ImmutableArray<(string Path, SourceText? Source)> noxYamls,
       IList<string> errorCollection,
       out NoxSolution solution)
    {
        solution = null!;

        var solutionFilePaths = noxYamls
            .Select(y => y.Path)
            .Where(p => p.EndsWithIgnoreCase(".solution.nox.yaml"))
            .ToImmutableArray();

        if (solutionFilePaths.Length == 0)
        {
            errorCollection.Add("No *.solution.nox.yaml files found.");
            return false;
        }

        if (solutionFilePaths.Length > 1)
        {
            errorCollection.Add("More than one *.solution.nox.yaml found.");
            return false;
        }

        var solutionYamlFiles = noxYamls
            .Where(s => s.Source is not null)
            .ToDictionary(
                s => s.Path,
                s => new Func<TextReader>(() => new StringReader(s.Source!.ToString()))
            );

        return TryCreateSolution(errorCollection, ref solution, solutionYamlFiles);
    }

    protected static bool TryGetGeneratorConfig(
        ImmutableArray<(string Path, SourceText? Source)> noxYamls,
        IList<string> errorCollection,
        out GeneratorConfig config)
    {
        config = null!;

        var configFilesAndContent = noxYamls
            .Where(p => p.Path.EndsWithIgnoreCase("generator.nox.yaml"))
            .ToImmutableArray();

        if (configFilesAndContent.Length == 0)
        {
            config = new GeneratorConfig();
            return true;
        }

        if (configFilesAndContent.Length != 1)
        {
            errorCollection.Add("More than one *generator.nox.yaml found in project.");
            return false;
        }

        var configContent = configFilesAndContent.First().Source?.ToString();

        if (configContent is null)
        {
            errorCollection.Add($"Error loading config file contents from {configFilesAndContent.First().Path}.");
            return false;
        }

        return DesirializeGeneratorConfig(configContent, errorCollection, out config);
    }

    private static string? GetProjectRootDirectory(ImmutableArray<(string Path, SourceText? Source)> noxYamls)
    {
        var generatorPath = noxYamls.FirstOrDefault(x => x.Path.EndsWith("generator.nox.yaml")).Path;
        return Path.GetDirectoryName(generatorPath);
    }
}