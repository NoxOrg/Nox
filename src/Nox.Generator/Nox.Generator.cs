using FluentValidation;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Generator.Infrastructure.Persistence.ModelConfigGenerator;
using Nox.Solution;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using YamlDotNet.Core;

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
            .Select((text, token) => (Path: text.Path, Source: text.GetText(token)))
            .Collect();
        
        context.RegisterSourceOutput(noxYamls, GenerateSource);

    }

    private void GenerateSource(SourceProductionContext context, ImmutableArray<(string Path,SourceText? Source)> noxYamls)
    {
        GenerateDebugInfo(context, noxYamls);

        if (TryGetNoxSolution(noxYamls, out var solution))
        {
            var solutionNameSpace = solution.Name;

            EntityBaseGenerator.Generate(context, solutionNameSpace);

            AuditableEntityBaseGenerator.Generate(context, solutionNameSpace);

            EntitiesGenerator.Generate(context, solutionNameSpace, solution);

            EntityTypeDefinitionsGenerator.Generate(context, solutionNameSpace, solution);

            DbContextGenerator.Generate(context, solutionNameSpace, solution);

            ODataConfigurationGenerator.Generate(context, solutionNameSpace, solution);

            ODataApiGenerator.Generate(context, solutionNameSpace, solution);
        }

    }

    private static void GenerateDebugInfo(SourceProductionContext context, ImmutableArray<(string Path, SourceText? Source)> noxYamls)
    {
        var code = new CodeBuilder($"Debug/Generator.g.cs",context);
        foreach (var (path, _) in noxYamls)
        {
            code.AppendLine($"// {path}");
        }
        code.GenerateSourceCode();
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

        var solutionFile = Path.GetFullPath(solutionFilePaths.First());

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
}

