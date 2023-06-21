using Microsoft.CodeAnalysis;
using Nox.Solution;
using System;
using System.Collections.Generic;

using static Nox.Generator._Common.BaseGenerator;
using static Nox.Generator._Common.NamingConstants;

namespace Nox.Generator;

internal class CommandsGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace, DomainCommand command)
    {
        if (command is null)
        {
            throw new ArgumentNullException(nameof(command));
        }

        context.CancellationToken.ThrowIfCancellationRequested();

        var className = $"{command.Name}CommandHandlerBase";

        var code = new CodeBuilder($"Application/Commands/{className}.cs", context);

        code.AppendLine($"using Nox.Types;");
        code.AppendLine($"using System.Collections.Generic;");
        code.AppendLine($"using Nox.Core.Interfaces.Messaging;");
        code.AppendLine($"using Nox.Core.Interfaces.Entity.Commands;");
        code.AppendLine($"using {solutionNameSpace}.Domain;");
        code.AppendLine($"using {solutionNameSpace}.Application.DataTransferObjects;");
        code.AppendLine($"using SampleService.Infrastructure.Persistence;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Application;");

        GenerateDocs(code, command.Description);

        code.AppendLine($"public abstract partial class {className}");
        code.StartBlock();

        // Add Db Context
        var dbContextName = $"{solutionNameSpace}{DbContextName}";
        AddProperty(code, dbContextName, DbContextName, "Represents the DB context.");

        // Add Messanger
        AddProperty(code, "INoxMessenger", "Messenger", "Represents the Nox messanger.");

        // Add constructor
        AddConstructor(code, className, new Dictionary<string, string> {
                { dbContextName, DbContextName },
                { "INoxMessenger", "Messenger" }
        });

        var typeDefinition = GenerateTypeDefinition(context, solutionNameSpace, command);

        // Add params
        code.AppendLine($@"public abstract Task<INoxCommandResult> ExecuteAsync({typeDefinition} command);");

        // Add Events
        if (command.EmitEvents != null)
        {
            foreach (var domainEvent in command.EmitEvents)
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
        code.AppendLine($@"public async Task Send{eventName}DomainEventAsync({eventName}DomainEvent domainEvent)");
        code.StartBlock();
        code.AppendLine($@"await Messenger.SendMessageAsync(new string[] {{ ""{DefaultMessagingProvider}"" }}, domainEvent);");
        code.EndBlock();
    }
}
