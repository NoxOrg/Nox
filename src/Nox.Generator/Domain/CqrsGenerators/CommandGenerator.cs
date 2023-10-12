using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Nox.Generator.Application.Commands;
using Nox.Generator.Common;
using Nox.Solution;

using static Nox.Generator.Common.BaseGenerator;
using static Nox.Generator.Common.NamingConstants;

namespace Nox.Generator.Domain.CqrsGenerators;

internal class CommandGenerator : ApplicationGeneratorBase
{
    protected override void DoGenerate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, IEnumerable<Entity> entities)
    {
#pragma warning disable S3267 // Loops should be simplified with "LINQ" expressions
        foreach (var entity in entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();
            if (entity.Commands == null || !entity.Commands.Any()) continue;
            foreach (var cmd in entity.Commands)
            {
                context.CancellationToken.ThrowIfCancellationRequested();
                GenerateCommand(context, codeGeneratorState, cmd);
            }
        }
#pragma warning restore S3267 // Loops should be simplified with "LINQ" expressions
    }

    private static void GenerateCommand(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, DomainCommand cmd)
    {
        var className = cmd.Name.EnsureEndsWith("CommandHandlerBase");

        var code = new CodeBuilder($"{className}.g.cs", context);

        code.AppendLine($"using Nox.Types;");
        code.AppendLine($"using System.Collections.Generic;");
        //NOTE: this must point to Nox abstractions
        code.AppendLine($"using Nox.Abstractions;");
        code.AppendLine($"using {codeGeneratorState.DomainNameSpace};");
        code.AppendLine($"using {codeGeneratorState.RootNameSpace}.Application.DataTransferObjects;");
        code.AppendLine($"using {codeGeneratorState.RootNameSpace}.Infrastructure.Persistence;");
        code.AppendLine();
        code.AppendLine($"namespace {codeGeneratorState.ApplicationNameSpace};");

        GenerateDocs(code, cmd.Description!);

        code.AppendLine($"public abstract partial class {className}");
        code.StartBlock();

        // Add Db Context
        var dbContextName = $"{codeGeneratorState.RootNameSpace}{DbContextName}";
        AddField(code, dbContextName, DbContextName, "Represents the DB context.");

        // Add Messanger
        AddField(code, "INoxMessenger", "Messenger", "Represents the Nox messenger.");

        // Add constructor
        AddConstructor(code, className, new Dictionary<string, string>
        {
            { dbContextName, DbContextName },
            { "INoxMessenger", "Messenger" }
        });

        // Add params
        var typeDefinition = GenerateTypeDefinition(context, codeGeneratorState, cmd, generateDto: true);

        GenerateDocs(code, $"Executes {cmd.Name}");
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
        GenerateDocs(code, $"Sends {eventName}");
        code.AppendLine($@"public async Task Send{eventName}DomainEventAsync({eventName} domainEvent)");
        code.StartBlock();
        code.AppendLine(
            $@"await _messenger.SendMessageAsync(new string[] {{ ""{DefaultMessagingProvider}"" }}, domainEvent);");
        code.EndBlock();
    }
}