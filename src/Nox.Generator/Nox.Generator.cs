using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Generator.Application.DtoGenerator;
using Nox.Generator.Application.EventGenerator;
using Nox.Generator.Common;
using Nox.Generator.Domain.CqrsGenerators;
using Nox.Generator.Domain.DomainEventGenerator;
using Nox.Generator.Infrastructure.Persistence.DbContextGenerator;
using Nox.Generator.Presentation.Api;
using Nox.Solution;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using Nox.Generator.Domain.ModelGenerator;
using Nox.Generator.Presentation.Api.OData;
using YamlDotNet.Core;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;
using Nox.Generator.Application;
using Nox.Generator.Application.Queries;

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
            //Debugger.Launch(); 
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
                var codeGeneratorState = new NoxSolutionCodeGeneratorState(solution, Assembly.GetEntryAssembly()!);

                NoxWebApplicationExtensionGenerator.Generate(context, solution, generate.Presentation);
                
                if (generate.Domain)
                {
                    EntityBaseGenerator.Generate(context, codeGeneratorState);

                    EntitiesGenerator.Generate(context, codeGeneratorState);

                    Application.Queries.QueryGenerator.Generate(context, codeGeneratorState);

                    ByIdQueryGenerator.Generate(context, codeGeneratorState);

                    DomainEventGenerator.Generate(context, codeGeneratorState);
                    
                    CommandGenerator.Generate(context, codeGeneratorState);

                    Domain.CqrsGenerators.QueryGenerator.Generate(context, codeGeneratorState);
                }

                if (generate.Infrastructure)
                {
                    DbContextGenerator.Generate(context, codeGeneratorState);
                }

                if (generate.Presentation)
                {
                    ODataServiceCollectionExtensions.Generate(context, codeGeneratorState);

                    ODataModelGenerator.Generate(context, codeGeneratorState);

                    ODataDbContextGenerator.Generate(context, codeGeneratorState);

                    ApiGenerator.Generate(context, codeGeneratorState);
                }

                if (generate.Application)
                {
                    DtoGenerator.Generate(context, codeGeneratorState);
                    ApplicationEventGenerator.Generate(context, codeGeneratorState);
                }
            }
        }
        catch (Exception e)
        {
            _errors.Add(e.Message +  e.StackTrace);
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


        var solutionFileAndContent = noxYamls
            .Where(s => s.Source is not null)
            .ToDictionary( 
                s => s.Path, 
                s => new Func<TextReader>(() => new StringReader(s.Source!.ToString()) )
            );

        try
        {
            solution = new NoxSolutionBuilder()
                .UseYamlFilesAndContent(solutionFileAndContent)
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

