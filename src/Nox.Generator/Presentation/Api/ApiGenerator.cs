using Microsoft.CodeAnalysis;
using Nox.Solution;
using System.Linq;
using Nox.Generator.Common;
using System.Collections.Generic;

using static Nox.Generator.Common.BaseGenerator;
using System.Collections;

namespace Nox.Generator.Presentation.Api;

internal static class ApiGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace, NoxSolution solution)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (solution.Domain is null ||
            !solution.Domain.Entities.Any())
        {
            return;
        }

        foreach (var entity in solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var entityName = entity.Name;
            var pluralName = entity.PluralName;
            var variableName = entity.Name.ToLower();
            var dbContextName = $"ODataDbContext";
            var controllerName = $"{pluralName}Controller";
            // TODO: fix composite key
            //var keyType = entityName + "Id";
            //var keyUnderlyingType = entity.Keys?.FirstOrDefault()?.Type;
            // TODO Evaluate how to generate a Named ID Type
            //if (!keyUnderlyingType.HasValue)
            //{
            //    parsingLogic = $"var parsedKey = {keyType}.From(key);";
            //}

            IReadOnlyCollection<DomainQuery> queries = entity.Queries ?? new List<DomainQuery>();
            IReadOnlyCollection<DomainCommand> commands = entity.Commands ?? new List<DomainCommand>();

            var code = new CodeBuilder($"{pluralName}Controller.g.cs", context);

            // Namespace
            code.AppendLine($"using Microsoft.AspNetCore.Mvc;");
            code.AppendLine($"using Microsoft.AspNetCore.OData.Deltas;");
            code.AppendLine($"using Microsoft.AspNetCore.OData.Query;");
            code.AppendLine($"using Microsoft.AspNetCore.OData.Routing.Controllers;");
            code.AppendLine($"using Microsoft.EntityFrameworkCore;");

            code.AppendLine($"using {solutionNameSpace}.Application;");
            code.AppendLine($"using {solutionNameSpace}.Application.DataTransferObjects;");
            code.AppendLine($"using {solutionNameSpace}.Domain;");
            code.AppendLine($"using {solutionNameSpace}.Infrastructure.Persistence;");

            code.AppendLine($"using Nox.Types;");
            code.AppendLine();
            code.AppendLine($"namespace {solutionNameSpace}.Presentation.Api.OData;");
            code.AppendLine();

            code.AppendLine($"public partial class {controllerName} : ODataController");

            // Class
            code.StartBlock();

            // db context
            AddField(code, dbContextName, "databaseContext", "The OData DbContext for CRUD operations");

            var constructorParameters = new Dictionary<string, string>
                {
                    { dbContextName, "databaseContext" }
                };

            foreach (var query in queries)
            {
                var queryType = $"{query.Name}QueryBase";
                AddField(code, queryType, query.Name, query.Description);
                constructorParameters.Add(queryType, query.Name);
            }

            foreach (var command in commands)
            {
                var commandType = $"{command.Name}CommandHandlerBase";
                AddField(code, commandType, command.Name, command.Description);
                constructorParameters.Add(commandType, command.Name);
            }

            // Add constructor
            AddConstructor(code, controllerName, constructorParameters);

            code.AppendLine();

            if (entity.Persistence is null ||
                entity.Persistence.Read.IsEnabled)
            {
                GenerateGet(entityName, pluralName, code);
            }

            if (entity.Persistence is null ||
                entity.Persistence.Create.IsEnabled)
            {
                GeneratePost(entityName, pluralName, variableName, code);
            }

            if (entity.Persistence is null ||
                entity.Persistence.Update.IsEnabled)
            {
                GeneratePut(entityName, code);

                GeneratePatch(entity, entityName, pluralName, variableName, code);
            }

            if (entity.Persistence is null ||
                entity.Persistence.Delete.IsEnabled)
            {
                GenerateDelete(pluralName, variableName, code);
            }

            // Generate GET request mapping for Queries
            foreach (var query in queries)
            {
                GenerateDocs(code, query.Description);
                code.AppendLine($"[HttpGet(\"{query.Name}\")]");
                code.AppendLine($"public async Task<IResult> {query.Name}Async({GetParametersString(query.RequestInput)})");
                code.StartBlock();
                code.AppendLine($"var result = await {query.Name.ToLowerFirstCharAndAddUnderscore()}.ExecuteAsync({GetParametersExecuteString(query.RequestInput)});");
                // TODO: Extend to NotFound and other codes
                code.AppendLine(@"return Results.Ok(result);");
                code.EndBlock();
            }

            // Generate POST request mapping for Command Handlers
            foreach (var command in commands)
            {
                var typeDefinition = GenerateTypeDefinition(context, solutionNameSpace, command);

                GenerateDocs(code, command.Description);
                code.AppendLine($"[HttpPost(\"{command.Name}\")]");
                code.AppendLine($"public async Task<IResult> {command.Name}Async({typeDefinition} command)");
                code.StartBlock();
                code.AppendLine($"var result = await {command.Name.ToLowerFirstCharAndAddUnderscore()}.ExecuteAsync(command);");
                code.AppendLine(@"return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);");
                code.EndBlock();
            }

            // End class
            code.EndBlock();

            code.GenerateSourceCode();
        }
    }

    private static void GenerateDelete(string pluralName, string variableName, CodeBuilder code)
    {
        // Method Delete
        code.AppendLine($"public async Task<ActionResult> Delete([FromRoute] string key)");

        // Method content
        code.StartBlock();
        code.AppendLine($"var {variableName} = await _databaseContext.{pluralName}.FindAsync(key);");
        code.AppendLine($"if ({variableName} == null)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"_databaseContext.{pluralName}.Remove({variableName});");
        code.AppendLine($"await _databaseContext.SaveChangesAsync();");
        code.AppendLine($"return NoContent();");

        // End method
        code.EndBlock();
    }

    private static void GeneratePut(string entityName, CodeBuilder code)
    {
        // Method Put
        code.AppendLine($"public async Task<ActionResult> Put([FromRoute] string key, [FromBody] {entityName} updated{entityName})");

        // Method content
        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"return BadRequest(ModelState);");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"if (key != updated{entityName}.Id)");
        code.StartBlock();
        code.AppendLine($"return BadRequest();");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"_databaseContext.Entry(updated{entityName}).State = EntityState.Modified;");
        code.AppendLine();
        code.AppendLine($"try");
        code.StartBlock();
        code.AppendLine($"await _databaseContext.SaveChangesAsync();");
        code.EndBlock();
        code.AppendLine($"catch (DbUpdateConcurrencyException)");
        code.StartBlock();
        code.AppendLine($"if (!{entityName}Exists(key))");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine($"else");
        code.StartBlock();
        code.AppendLine($"throw;");
        code.EndBlock();
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"return Updated(updated{entityName});");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GeneratePatch(Entity entity, string entityName, string pluralName, string variableName, CodeBuilder code)
    {
        // Method Patch
        code.AppendLine($"public async Task<ActionResult> Patch([FromRoute] string key, [FromBody] Delta<{entityName}> {variableName})");

        // Method content
        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"return BadRequest(ModelState);");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"var entity = await _databaseContext.{entity.PluralName}.FindAsync(key);");
        code.AppendLine();
        code.AppendLine($"if (entity == null)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"{variableName}.Patch(entity);");
        code.AppendLine();
        code.AppendLine($"try");
        code.StartBlock();
        code.AppendLine($"await _databaseContext.SaveChangesAsync();");
        code.EndBlock();
        code.AppendLine($"catch (DbUpdateConcurrencyException)");
        code.StartBlock();
        code.AppendLine($"if (!{entityName}Exists(key))");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine($"else");
        code.StartBlock();
        code.AppendLine($"throw;");
        code.EndBlock();
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"return Updated(entity);");

        // End method
        code.EndBlock();
        code.AppendLine();

        // Method Exists
        code.AppendLine($"private bool {entityName}Exists(string key)");

        // Method content
        code.StartBlock();
        code.AppendLine($"return _databaseContext.{pluralName}.Any(p => p.Id == key);");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GeneratePost(string entityName, string pluralName, string variableName, CodeBuilder code)
    {
        // Method Post
        code.AppendLine($"public async Task<ActionResult> Post({entityName} {variableName})");

        // Method content
        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"return BadRequest(ModelState);");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"_databaseContext.{pluralName}.Add({variableName});");
        code.AppendLine();
        code.AppendLine($"await _databaseContext.SaveChangesAsync();");
        code.AppendLine();
        code.AppendLine($"return Created({variableName});");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateGet(string entityName, string pluralName, CodeBuilder code)
    {
        // Method Get
        code.AppendLine($"[EnableQuery]");
        code.AppendLine($"public ActionResult<IQueryable<{entityName}>> Get()");

        // Method content
        code.StartBlock();
        code.AppendLine($"return Ok(_databaseContext.{pluralName});");

        // End method
        code.EndBlock();
        code.AppendLine();

        // Method Get
        code.AppendLine($"[EnableQuery]");
        code.AppendLine($"public ActionResult<{entityName}> Get([FromRoute] string key)");

        // Method content
        code.StartBlock();
        code.AppendLine($"var item = _databaseContext.{pluralName}.SingleOrDefault(d => d.Id.Equals(key));");
        code.AppendLine();
        code.AppendLine($"if (item == null)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"return Ok(item);");

        // End method
        code.EndBlock();
        code.AppendLine();
    }
}
