using FluentValidation;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Generator.Infrastructure.Persistence.ModelConfigGenerator;
using Nox.Solution;
using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using YamlDotNet.Core;
using YamlDotNet.Serialization.NamingConventions;
using YamlDotNet.Serialization;

namespace Nox.Generator;

[Generator]
	public class NoxCodeGenerator : IIncrementalGenerator
	{

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

    private void GenerateSource(SourceProductionContext context, ImmutableArray<(string Path,SourceText? Source)> noxYamls)
    {
        var _debug = new CodeBuilder($"Debug/Generator.g.cs", context);

        foreach (var (path, _) in noxYamls) {_debug.AppendLine($"// {Path.GetFileName(path)}");}

        if (TryGetNoxSolution(noxYamls, out var solution) && TryGetGeneratorConfig(noxYamls, out var generate))
        {
            var solutionNameSpace = solution.Name;

            if (generate.Domain)
            {
                EntityBaseGenerator.Generate(context, solutionNameSpace);

                AuditableEntityBaseGenerator.Generate(context, solutionNameSpace);

                EntitiesGenerator.Generate(context, solutionNameSpace, solution);
            }

            if (generate.Infrastructure)
            {
                DbContextGenerator.Generate(context, solutionNameSpace, solution);

                EntityTypeDefinitionsGenerator.Generate(context, solutionNameSpace, solution);
            }

            if (generate.Presentation)
            {
                ODataConfigurationGenerator.Generate(context, solutionNameSpace, solution);

                ODataApiGenerator.Generate(context, solutionNameSpace, solution);
            }
        }

        _debug.GenerateSourceCode();
    }

    private static bool TryGetNoxSolution(ImmutableArray<(string Path, SourceText? Source)> noxYamls, out NoxSolution solution)
    {
        solution = null!;

        var solutionFilePaths = noxYamls
            .Select(y => y.Path)
            .Where(p => p.EndsWithIgnoreCase(".solution.nox.yaml"))
            .ToImmutableArray();

        if (solutionFilePaths.Length != 1)
            return false;

        var solutionFile = solutionFilePaths.First();

        try
        {
            solution = new NoxSolutionBuilder().UseYamlFile(solutionFile).Build();
        }
        catch (YamlException)
        {
            return false;
        }

        return true;
    }

    private static bool TryGetGeneratorConfig(ImmutableArray<(string Path, SourceText? Source)> noxYamls, out GeneratorConfig config)
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
            return false;

        var configContent = configFilesAndContent.First().Source?.ToString();

        if (configContent is null)
            return false;

        try
        {
            var deserializer = new DeserializerBuilder()
                .WithNamingConvention(CamelCaseNamingConvention.Instance)
                .Build();
            
            config = deserializer.Deserialize<GeneratorConfig>(configContent);
        }
        catch (YamlException)
        {
            return false;
        }

        return true;
    }

}

