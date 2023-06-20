using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Solution;
using System;
using System.Collections.Generic;
using System.Text;

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

        var code = new CodeBuilder();

        var className = $"{command.Name}CommandHandlerBase";

        code.AppendLine($"// Generated");
        code.AppendLine();
        code.AppendLine($"using Nox.Types;");
        code.AppendLine($"using System.Collections.Generic;");
        code.AppendLine($"using {solutionNameSpace}.Domain;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Application;");

        GenerateDocs(code, command.Description);

        code.AppendLine($"public abstract partial class {className}");
        code.AppendLine($"{{");

        code.Indent();

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

        // Add params
        code.AppendLine($@"public abstract Task<INoxCommandResult> ExecuteAsync({command.Name}{CommandSuffix} command);");

        // Add Events
        if (command.EmitEvents != null)
        {
            foreach (var domainEvent in command.EmitEvents)
            {
                AddDomainEvent(code, domainEvent);
            }
        }

        code.UnIndent();

        code.AppendLine($"}}");

        context.AddSource($"{className}.cs", SourceText.From(code.ToString(), Encoding.UTF8));
    }

    private static void AddDomainEvent(CodeBuilder code, string eventName)
    {
        code.AppendLine();
        code.AppendLine($@"public async Task Send{eventName}DomainEventAsync({eventName}DomainEvent domainEvent)");
        code.AppendLine($@"{{");
        code.Indent();
        code.AppendLine($@"await Messenger.SendMessageAsync(new string[] {{ ""{DefaultMessagingProvider}"" }}, domainEvent);");
        code.UnIndent();
        code.AppendLine($@"}}");
    }
}
