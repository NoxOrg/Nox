using Microsoft.CodeAnalysis;
using Nox.Generator._Common;
using Nox.Solution;
using System;
using System.Collections.Generic;
using System.Linq;

using static Nox.Generator._Common.BaseGenerator;

namespace Nox.Generator.Presentation.Rest;

/// <summary>
/// Generates a basic controller per entity with endpoints executing Queries and Commands.
/// </summary>
internal class ControllerGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace, Entity entity)
    {
        if (entity is null)
        {
            throw new ArgumentNullException(nameof(entity));
        }

        var className = $"{entity.Name}Controller";

        var code = new CodeBuilder($"Presentation/Rest/{className}.cs", context);

        IReadOnlyCollection<DomainQuery> queries = entity.Queries ?? new List<DomainQuery>();
        IReadOnlyCollection<DomainCommand> commands = entity.Commands ?? new List<DomainCommand>();

        if (!queries.Any() && !commands.Any())
        {
            // Nothing to genearate.
            return;
        }

        code.AppendLine($"using Nox.Types;");
        code.AppendLine($"using Microsoft.AspNetCore.Mvc;");
        code.AppendLine($"using {solutionNameSpace}.Application;");
        code.AppendLine($"using {solutionNameSpace}.Domain;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Presentation.Api;");

        GenerateDocs(code, $"Controller for {entity.Name} entity. {entity.Description}");

        code.AppendLine($"[ApiController]");
        // TODO: configure routs
        //code.AppendLine($"[Route("[controller]")]\");
        code.AppendLine($"public partial class {className} : ControllerBase");

        code.StartBlock();

        var constructorParameters = new Dictionary<string, string>();
        foreach (var query in queries)
        {
            var queryType = $"{query.Name}Query";
            AddProperty(code, queryType, query.Name, query.Description);
            constructorParameters.Add(queryType, query.Name);
        }

        foreach (var command in commands)
        {
            var commandType = $"{command.Name}CommandHandlerBase";
            AddProperty(code, commandType, command.Name, command.Description);
            constructorParameters.Add(commandType, command.Name);
        }

        // Add constructor
        AddConstructor(code, className, constructorParameters);

        // Generate GET request mapping for Queries
        foreach (var query in queries)
        {
            code.AppendLine();
            code.AppendLine("[HttpGet]");
            code.AppendLine($"public async Task<IResult> Get{query.Name}Async({GetParametersString(query.RequestInput)})");
            code.StartBlock();
            code.AppendLine($"var result = await {query.Name}Query.ExecuteAsync({GetParametersExecuteString(query.RequestInput)});");
            // TODO: Extend to NotFound and other codes
            code.AppendLine(@"return Results.Ok(result);");
            code.EndBlock();
        }

        // Generate POST request mapping for Command Handlers
        foreach (var command in commands)
        {
            code.AppendLine();
            code.AppendLine("[HttpPost]");
            code.AppendLine($"public async Task<IResult> Post{command.Name}({command.Name}{NamingConstants.CommandSuffix} command)");
            code.StartBlock();
            code.AppendLine($"var result = await {command.Name}.ExecuteAsync(command);");
            code.AppendLine(@"return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);");
            code.EndBlock();
        }

        code.EndBlock();

        code.GenerateSourceCode();
    }
}
