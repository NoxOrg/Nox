using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using FluentValidation;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using Nox.Solution;
using YamlDotNet.Core;

namespace NoxSourceGenerator
{
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
            var solutionDeclaration = context.AdditionalTextsProvider
                .Where(text => text.Path.EndsWith(".solution.nox.yaml", System.StringComparison.OrdinalIgnoreCase))
                .Select((text, token) => text.Path)
                .Collect();
            
            context.RegisterSourceOutput(solutionDeclaration, GenerateSource);
        }

        private void GenerateSource(SourceProductionContext context, ImmutableArray<string> solutionFilePaths)
        {

            var sb = new StringBuilder();
            sb.AppendLine($"// Nox Generator - {DateTime.Now:dddd, dd MMMM yyyy HH:mm:ss}");

            if (solutionFilePaths.Length != 1)
                return;

            var solutionFile = Path.GetFullPath(solutionFilePaths.First());
            sb.AppendLine($"// File: {solutionFile}");
            sb.AppendLine($"//");

            try
            {
                var solution = new NoxSolutionBuilder().UseYamlFile(solutionFile).Build();

                var solutionNameSpace = solution.Name;

                if (solution.Domain is null)
                    return;

                foreach (var entity in solution.Domain.Entities)
                {
                    sb.AppendLine($"// Entity: {entity.Name}");

                    EntityGenerator.Generate(context, solutionNameSpace, entity);
                }

            }
            catch (YamlException e)
            {
                sb.AppendLine($"// ERROR: {e.Message} - {e.InnerException?.Message}");
            }

            context.AddSource($"Nox.Generator.Info.cs", SourceText.From(sb.ToString(), Encoding.UTF8));
        }
    }
}

