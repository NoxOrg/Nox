﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator._Common;
using Nox.Solution;

using static Nox.Generator._Common.BaseGenerator;
using static Nox.Generator._Common.NamingConstants;

namespace Nox.Generator.Domain.CqrsGenerators;

public class CommandGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace, NoxSolution solution)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (solution.Domain == null) return;

        foreach (var entity in solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            if (entity.Commands == null || !entity.Commands.Any()) continue;
            foreach (var cmd in entity.Commands)
            {
                context.CancellationToken.ThrowIfCancellationRequested();
                GenerateCommand(context, solutionNameSpace, cmd);
            }
        }
    }

    private static void GenerateCommand(SourceProductionContext context, string solutionNameSpace, DomainCommand cmd)
    {
        var className = cmd.Name.EnsureEndsWith("CommandHandlerBase");

        var code = new CodeBuilder($"{className}.cs", context);

        code.AppendLine($"using Nox.Types;");
        code.AppendLine($"using System.Collections.Generic;");
        code.AppendLine($"using Nox.Core.Interfaces.Messaging;");
        code.AppendLine($"using Nox.Core.Interfaces.Entity.Commands;");
        code.AppendLine($"using {solutionNameSpace}.Domain;");
        code.AppendLine($"using {solutionNameSpace}.Application.DataTransferObjects;");
        code.AppendLine($"using SampleService.Infrastructure.Persistence;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Application;");

        if (!string.IsNullOrWhiteSpace(cmd.Description))
        {
            GenerateDocs(code, cmd.Description!);
        }

        code.AppendLine($"public abstract partial class {className}");
        code.StartBlock();

        // Add Db Context
        var dbContextName = $"{solutionNameSpace}{DbContextName}";
        AddProperty(code, dbContextName, DbContextName, "Represents the DB context.");

        // Add Messanger
        AddProperty(code, "INoxMessenger", "Messenger", "Represents the Nox messanger.");

        // Add constructor
        AddConstructor(code, className, new Dictionary<string, string>
        {
            { dbContextName, DbContextName },
            { "INoxMessenger", "Messenger" }
        });

        var typeDefinition = GenerateTypeDefinition(context, solutionNameSpace, cmd);

        // Add params
        code.AppendLine($@"public abstract Task<INoxCommandResult> ExecuteAsync({typeDefinition} command);");

        // Add Events
        if (cmd.EmitEvents != null)
        {
            foreach (var domainEvent in cmd.EmitEvents)
            {
                AddDomainEvent(code, domainEvent);
            }
        }

        code.EndBlock();

        code.GenerateSourceCode();
    }

    private static void AddDomainEvent(CodeBuilder code, string eventName)
    {
        code.AppendLine();
        code.AppendLine($@"public async Task Send{eventName}DomainEventAsync({eventName} domainEvent)");
        code.StartBlock();
        code.AppendLine(
            $@"await Messenger.SendMessageAsync(new string[] {{ ""{DefaultMessagingProvider}"" }}, domainEvent);");
        code.EndBlock();
    }
}