using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Generator._Common;
using Nox.Solution;
using System;
using System.Collections.Generic;
using System.Text;

using static Nox.Generator._Common.BaseGenerator;

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
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Domain;");

        GenerateDocs(code, command.Description);

        code.AppendLine($"public partial class {className}");
        code.AppendLine($"{{");

        code.Indent();

        // Add Db Context
        var dbContextName = $"{solutionNameSpace}DbContext";
        AddProperty(code, dbContextName, "DbContext", "Represents the DB context.");

        // Add Messanger
        AddProperty(code, "INoxMessenger", "Messenger", "Represents the DB context.");

        // Add constructor
        AddConstructor(code, className, new Dictionary<string, string> {
                { dbContextName, "DbContext" },
                { "INoxMessenger", "Messenger" }
            });

        // Add params
        code.AppendLine($@"public abstract Task<INoxCommandResult> ExecuteAsync({command.Name}{NamingConstants.CommandSuffix} command);");

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
        code.AppendLine($@"await Messenger.SendMessageAsync(new string[] {{ ""{NamingConstants.DefaultMessagingProvider}"" }}, domainEvent);");
        code.UnIndent();
        code.AppendLine($@"}}");
    }
}
