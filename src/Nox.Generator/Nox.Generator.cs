using FluentValidation;
using Microsoft.CodeAnalysis;
using Nox.Solution;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using FluentValidation;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Text;
using Nox.Generator.Infrastructure.Persistence.ModelConfigGenerator;
using Nox.Solution;
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
        var compilation = context.CompilationProvider.Select((ctx,token) => ctx.GlobalNamespace);

        var solutionDeclaration = context.AdditionalTextsProvider
            .Where(text => text.Path.EndsWith(".solution.nox.yaml", System.StringComparison.OrdinalIgnoreCase))
            .Select((text, token) => text.Path)
            .Collect();
        
        context.RegisterSourceOutput(solutionDeclaration, GenerateSource);

    }

    private void GenerateSource(SourceProductionContext context, ImmutableArray<string> solutionFilePaths)
    {

        if (solutionFilePaths.Length != 1)
            return;

        var solutionFile = Path.GetFullPath(solutionFilePaths.First());

        try
        {
            var solution = new NoxSolutionBuilder().UseYamlFile(solutionFile).Build();

            var solutionNameSpace = solution.Name;

            if (solution.Domain is null)
                return;

            context.CancellationToken.ThrowIfCancellationRequested();

            EntityBaseGenerator.Generate(context, solutionNameSpace);

            context.CancellationToken.ThrowIfCancellationRequested();

            AuditableEntityBaseGenerator.Generate(context, solutionNameSpace);

            foreach (var entity in solution.Domain.Entities)
            {
                context.CancellationToken.ThrowIfCancellationRequested();

                EntitiesGenerator.Generate(context, solutionNameSpace, entity);
            }

            context.CancellationToken.ThrowIfCancellationRequested();

            EntityTypeDefinitionsGenerator.Generate(context, solutionNameSpace, solution);

            context.CancellationToken.ThrowIfCancellationRequested();

            DbContextGenerator.Generate(context, solutionNameSpace, solution);

            ODataConfigurationGenerator.Generate(context, solutionNameSpace, solution);

            ODataApiGenerator.Generate(context, solutionNameSpace, solution);
        }
        catch (YamlException)
        {
            // write to notimessage here.
        }

    }
}

