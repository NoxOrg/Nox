using FluentValidation;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Generator.Application.DtoGenerator;
using Nox.Generator.Application.EventGenerator;
using Nox.Generator.Common;
using Nox.Generator.Domain.CqrsGenerators;
using Nox.Generator.Domain.DomainEventGenerator;
using Nox.Generator.Presentation.Rest;
using Nox.Solution;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace Nox.Generator;

[Generator]
public class NoxCodeGenerator : IIncrementalGenerator
{
    private static readonly List<string> _errors = new();

    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
#if DEBUG
        if (!Debugger.IsAttached)
        {
            // Debugger.Launch(); 
        }
#endif
        // var compilation = context.CompilationProvider.Select((ctx,token) => ctx.GlobalNamespace);

        var noxYamls = context.AdditionalTextsProvider
            .Where(text => text.Path.EndsWithIgnoreCase(".nox.yaml"))
            .Select((text, token) => (Path: Path.GetFullPath(text.Path), Source: text.GetText(token)))
            .Collect();

        context.RegisterSourceOutput(noxYamls, GenerateSource);
    }

    private void GenerateSource(SourceProductionContext context, ImmutableArray<(string Path, SourceText? Source)> noxYamls)
    {
        var _debug = new CodeBuilder($"Generator.g.cs", context);
        _errors.Clear();

        _debug.AppendLine("// Found files ->");
        foreach (var (path, _) in noxYamls)
        {
            _debug.AppendLine($"//  - {Path.GetFileName(path)}");
        }

        try
        {
            if (TryGetGeneratorConfig(noxYamls, out var generate) && TryGetNoxSolution(noxYamls, out var solution))
            {
                var solutionNameSpace = solution.Name;

                if (generate.Domain)
                {
                    EntityBaseGenerator.Generate(context, solutionNameSpace);

                    AuditableEntityBaseGenerator.Generate(context, solutionNameSpace);

                    EntitiesGenerator.Generate(context, solutionNameSpace, solution);
                    
                    DomainEventGenerator.Generate(context, solutionNameSpace, solution);
                    
                    CommandGenerator.Generate(context, solutionNameSpace, solution);
                    
                    QueryGenerator.Generate(context, solutionNameSpace, solution);
                }

                if (generate.Infrastructure)
                {
                    DbContextGenerator.Generate(context, solutionNameSpace, solution);
                }

                if (generate.Presentation)
                {
                    ODataConfigurationGenerator.Generate(context, solutionNameSpace, solution);

                    ODataApiGenerator.Generate(context, solutionNameSpace, solution);

                    ApiControllerGenerator.Generate(context, solutionNameSpace, solution);
                }

                if (generate.Application)
                {
                    DtoGenerator.Generate(context, solutionNameSpace, solution);
                    ApplicationEventGenerator.Generate(context, solutionNameSpace, solution);
                }
            }


        }
        catch (Exception e)
        {
            _errors.Add(e.Message);
        }


        if (_errors.Any())
        {
            _debug.AppendLine("// Errors ->");
            foreach (var e in _errors)
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

    private static bool TryGetNoxSolution(ImmutableArray<(string Path, SourceText? Source)> noxYamls,
        out NoxSolution solution)
    {
        solution = null!;

        var solutionFilePaths = noxYamls
            .Select(y => y.Path)
            .Where(p => p.EndsWithIgnoreCase(".solution.nox.yaml"))
            .ToImmutableArray();

        if (solutionFilePaths.Length == 0)
        {
            _errors.Add("No *.solution.nox.yaml files found.");
            return false;
        }

        if (solutionFilePaths.Length > 1)
        {
            _errors.Add("More than one *.solution.nox.yaml found.");
            return false;
        }

        var solutionFile = solutionFilePaths.First();

        try
        {
            solution = new NoxSolutionBuilder().UseYamlFile(solutionFile).Build();
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

    private static bool TryGetGeneratorConfig(ImmutableArray<(string Path, SourceText? Source)> noxYamls,
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
            _errors.Add("More than one *generator.nox.yaml found in project.");
            return false;
        }

        var configContent = configFilesAndContent.First().Source?.ToString();

        if (configContent is null)
        {
            _errors.Add($"Error loading config file contents from {configFilesAndContent.First().Path}.");
            return false;
        }

        try
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();

            config = deserializer.Deserialize<GeneratorConfig>(configContent);
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

}

