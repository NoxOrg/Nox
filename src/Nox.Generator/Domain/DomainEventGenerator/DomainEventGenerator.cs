﻿using Microsoft.CodeAnalysis;
using Nox.Generator._Common;
using Nox.Solution;
using Nox.Solution.Events;
using System.Linq;
using System.Reflection;

namespace Nox.Generator.Domain.DomainEventGenerator;

public class DomainEventGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace, NoxSolution solution)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (solution.Domain == null) return;

        foreach (var entity in solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            if (entity.Events == null || !entity.Events.Any()) continue;
            foreach (var evt in entity.Events)
            {
                context.CancellationToken.ThrowIfCancellationRequested();
                GenerateEvent(context, solutionNameSpace, evt);    
            }
            
        }
    }
    
    private static void GenerateEvent(SourceProductionContext context, string solutionNameSpace, DomainEvent evt)
    {
        var code = new CodeBuilder($"{evt.Name}.g.cs", context);

        code.AppendLine($"// Generated by {nameof(DomainEventGenerator)}::{MethodBase.GetCurrentMethod()!.Name}");
        code.AppendLine();
        //NOTE: this must point to Nox abstractions
        code.AppendLine($"using Nox.Abstractions;");
        code.AppendLine($"using Nox.Types;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Domain;");

        GenerateClassDocs(context, code, evt);

        code.AppendLine($"public partial class {evt.Name} : INoxDomainEvent");
        code.StartBlock();

        GenerateProperties(context, code, evt);

        code.EndBlock();
        
        code.GenerateSourceCode();
    }
    
    private static void GenerateClassDocs(SourceProductionContext context, CodeBuilder code, DomainEvent evt)
    {
        if (evt.Description is not null)
        {
            code.AppendLine();
            code.AppendLine($"/// <summary>");
            code.AppendLine($"/// {evt.Description.EnsureEndsWith('.')}");
            code.AppendLine($"/// </summary>");
        }
    }
    
    private static void GenerateProperties(SourceProductionContext context, CodeBuilder code, DomainEvent evt)
    {
        if (evt.ObjectTypeOptions != null)
        {
            foreach (var attribute in evt.ObjectTypeOptions.Attributes)
            {
                context.CancellationToken.ThrowIfCancellationRequested();
        
                GeneratePropertyDocs(context, code, attribute);
        
                var propType = attribute.Type;
                var propName = attribute.Name;
                var nullable = attribute.IsRequired ? string.Empty : "?";
        
                code.AppendLine($"public {propType}{nullable} {propName} {{ get; set; }} = null!;");
            }
        }
    }
    
    private static void GeneratePropertyDocs(SourceProductionContext context, CodeBuilder code, NoxSimpleTypeDefinition prop)
    {
        if (!string.IsNullOrWhiteSpace(prop.Description))
        {
            code.AppendLine();
            code.AppendLine($"/// <summary>");
            code.AppendLine($"/// {prop.Description!.TrimEnd('.')}.");
            code.AppendLine($"/// </summary>"); 
        }
    }
}