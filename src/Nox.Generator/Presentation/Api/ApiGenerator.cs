using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types.Extensions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static Nox.Generator.Common.BaseGenerator;

namespace Nox.Generator.Presentation.Api;

internal class ApiGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Presentation;

    public void Generate(SourceProductionContext context, NoxSolutionCodeGeneratorState codeGeneratorState, GeneratorConfig config)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        foreach (var entity in codeGeneratorState.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            if (codeGeneratorState.Solution.Domain.Entities.Any(e => e.OwnedRelationships != null && e.OwnedRelationships.Any(r => r.Entity.Equals(entity.Name))))
            {
                continue;
            }

            var entityName = entity.Name;
            var pluralName = entity.PluralName;
            var variableName = entity.Name.ToLower();
            var dbContextName = $"ODataDbContext";
            var controllerName = $"{pluralName}Controller";
            var keyName = entity.Keys.FirstOrDefault().Name;
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

            var code = new CodeBuilder($"Controllers.{pluralName}Controller.g.cs", context);

            // Namespace
            code.AppendLine($"using Microsoft.AspNetCore.Mvc;");
            code.AppendLine($"using Microsoft.AspNetCore.OData.Deltas;");
            code.AppendLine($"using Microsoft.AspNetCore.OData.Query;");
            code.AppendLine($"using Microsoft.AspNetCore.OData.Routing.Controllers;");
            code.AppendLine($"using Microsoft.EntityFrameworkCore;");
            code.AppendLine($"using AutoMapper;");
            code.AppendLine("using MediatR;");
            code.AppendLine("using Nox.Application;");

            code.AppendLine($"using {codeGeneratorState.ApplicationNameSpace};");
            code.AppendLine($"using {codeGeneratorState.ApplicationNameSpace}.Dto;");
            code.AppendLine($"using {codeGeneratorState.ApplicationNameSpace}.Queries;");
            code.AppendLine($"using {codeGeneratorState.ApplicationNameSpace}.Commands;");
            code.AppendLine($"using {codeGeneratorState.DataTransferObjectsNameSpace};");
            code.AppendLine($"using {codeGeneratorState.DomainNameSpace};");
            code.AppendLine($"using {codeGeneratorState.PersistenceNameSpace};");

            code.AppendLine($"using Nox.Types;");
            code.AppendLine();
            code.AppendLine($"namespace {codeGeneratorState.ODataNameSpace};");
            code.AppendLine();

            code.AppendLine($"public partial class {controllerName} : ODataController");

            // Class
            code.StartBlock();

            // db context
            AddField(code, dbContextName, "databaseContext", "The OData DbContext for CRUD operations");

            AddField(code, "IMapper", "mapper", "The Automapper");
            AddField(code, "IMediator", "mediator", "The Mediator");

            var constructorParameters = new Dictionary<string, string>
                {
                    { dbContextName, "databaseContext" },
                    { "IMapper", "mapper" },
                    { "IMediator", "mediator" }
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
                GenerateGet(entity, code);

                if (entity.OwnedRelationships != null)
                {
                    foreach (var relationship in entity.OwnedRelationships)
                    {
                        GenerateChildrenGet(relationship.Entity, relationship.Name, entity.PluralName, code);
                    }
                }
            }

            if (entity.Persistence is null ||
                entity.Persistence.Create.IsEnabled)
            {
                GeneratePost(entityName, variableName, code);
            }

            if (entity.Persistence is null ||
                entity.Persistence.Update.IsEnabled)
            {
                GeneratePut(entity, code);

                GeneratePatch(entity, entityName, pluralName, variableName, code);
            }

            if (entity.Persistence is null ||
                entity.Persistence.Delete.IsEnabled)
            {
                GenerateDelete(entity, entityName, code);
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
                var typeDefinition = GenerateTypeDefinition(context, codeGeneratorState, command);

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

    private static void GenerateDelete(Entity entity, string entityName, CodeBuilder code)
    {
        // Method Delete
        code.AppendLine($"public async Task<ActionResult> Delete([FromRoute] {entity.KeysFlattenComponentsType[entity.Keys![0].Name]} key)");

        // Method content
        code.StartBlock();
        code.AppendLine($"var result = await _mediator.Send(new Delete{entityName}ByIdCommand(key));");

        code.AppendLine($"if (!result)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"return NoContent();");

        // End method
        code.EndBlock();
    }

    private static void GeneratePut(Entity entity, CodeBuilder code)
    {
        // TODO Composite Keys
        if (entity.Keys is { Count: > 1 })
        {
            //TODO Support to multiples keys, best pratctices?
            Debug.WriteLine("Put for composite keys Not implemented...");
            return;
        }

        // Method Put
        code.AppendLine($"public async Task<ActionResult> Put([FromRoute] {entity.KeysFlattenComponentsType.First().Value} key, [FromBody] {entity.Name}Dto updated{entity.Name})");

        // Method content
        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"return BadRequest(ModelState);");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"if (key != updated{entity.Name}.Id)");
        code.StartBlock();
        code.AppendLine($"return BadRequest();");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"_databaseContext.Entry(updated{entity.Name}).State = EntityState.Modified;");
        code.AppendLine();
        code.AppendLine($"try");
        code.StartBlock();
        code.AppendLine($"await _databaseContext.SaveChangesAsync();");
        code.EndBlock();
        code.AppendLine($"catch (DbUpdateConcurrencyException)");
        code.StartBlock();
        code.AppendLine($"if (!{entity.Name}Exists(key))");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine($"else");
        code.StartBlock();
        code.AppendLine($"throw;");
        code.EndBlock();
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"return Updated(updated{entity.Name});");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GeneratePatch(Entity entity, string entityName, string pluralName, string variableName, CodeBuilder code)
    {
        // TODO Composite Keys
        if (entity.Keys is { Count: > 1 })
        {
            Debug.WriteLine("Patch for composite keys Not implemented...");
            return;
        }
        // Method Patch
        code.AppendLine($"public async Task<ActionResult> Patch([FromRoute] {entity.KeysFlattenComponentsType.First().Value} key, [FromBody] Delta<{entityName}Dto> {variableName})");

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
        code.AppendLine($"private bool {entityName}Exists({entity.KeysFlattenComponentsType[entity.Keys![0].Name]} key)");

        // Method content
        code.StartBlock();
        code.AppendLine($"return _databaseContext.{pluralName}.Any(p => p.{entity.Keys![0].Name} == key);");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GeneratePost(string entityName, string variableName, CodeBuilder code)
    {
        // Method Post
        code.AppendLine($"public async Task<ActionResult> Post([FromBody]{entityName}CreateDto {variableName})");

        // Method content
        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"return BadRequest(ModelState);");
        code.EndBlock();
        code.AppendLine($"var createdKey = await _mediator.Send(new Create{entityName}Command({variableName}));");

        code.AppendLine();
        code.AppendLine($"return Created(createdKey);");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateGet(Entity entity, CodeBuilder code)
    {
        // Method Get
        code.AppendLine($"[EnableQuery]");
        code.AppendLine($"public async  Task<ActionResult<IQueryable<{entity.Name}Dto>>> Get()");

        // Method content
        code.StartBlock();
        code.AppendLine($"var result = await _mediator.Send(new Get{entity.PluralName}Query());");
        code.AppendLine($"return Ok(result);");

        // End method
        code.EndBlock();
        code.AppendLine();

        // TODO Composite Keys
        if (entity.Keys is { Count: > 1 })
        {
            Debug.WriteLine($"Get for composite keys Not implemented, Entity - {entity.Name}...");
            return;
        }

        if (entity.Keys!.Count > 1)
        {
            Debug.WriteLine($"Get for composite keys Not implemented, Entity - {entity.Name}...");
            return;
        }

        // We do not support Compound types as primary keys, this is validated on the schema
        // Method Get
        code.AppendLine($"public async Task<ActionResult<{entity.Name}Dto>> Get([FromRoute] {entity.KeysFlattenComponentsType[entity.Keys[0].Name]} key)");

        // Method content
        code.StartBlock();
        code.AppendLine($"var item = await _mediator.Send(new Get{entity.Name}ByIdQuery(key));");
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

    private static void GenerateChildrenGet(string childEntity, string childEntityPlural, string pluralName, CodeBuilder code)
    {
        // Method Get
        code.AppendLine($"[EnableQuery]");
        code.AppendLine($"public ActionResult<IQueryable<{childEntity}>> Get{childEntityPlural}([FromRoute] string key)");

        // Method content
        code.StartBlock();
        code.AppendLine($"return Ok(_databaseContext.{pluralName}.Where(d => d.Id.Equals(key)).SelectMany(m => m.{childEntityPlural}));");

        // End method
        code.EndBlock();
        code.AppendLine();
    }
}