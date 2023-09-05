using Humanizer;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
using Nox.Types.Extensions;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using static Nox.Generator.Common.BaseGenerator;

namespace Nox.Generator.Presentation.Api.OData;

internal class EntityControllerGenerator : INoxCodeGenerator
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
            var dbContextName = $"DtoDbContext";
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
            //IReadOnlyCollection<DomainCommand> commands = entity.Commands ?? new List<DomainCommand>();

            var code = new CodeBuilder($"Presentation.Api.OData.{pluralName}Controller.g.cs", context);

            // Namespace
            code.AppendLine($"using Microsoft.AspNetCore.Mvc;");
            code.AppendLine($"using Microsoft.AspNetCore.OData.Deltas;");
            code.AppendLine($"using Microsoft.AspNetCore.OData.Query;");
            code.AppendLine($"using Microsoft.AspNetCore.OData.Routing.Controllers;");
            code.AppendLine($"using Microsoft.EntityFrameworkCore;");
            code.AppendLine("using MediatR;");
            code.AppendLine("using System.Net.Http.Headers;");
            code.AppendLine("using Nox.Application;");

            code.AppendLine($"using {codeGeneratorState.ApplicationNameSpace};");
            code.AppendLine($"using {codeGeneratorState.ApplicationNameSpace}.Dto;");
            code.AppendLine($"using {codeGeneratorState.ApplicationNameSpace}.Queries;");
            code.AppendLine($"using {codeGeneratorState.ApplicationNameSpace}.Commands;");
            //code.AppendLine($"using {codeGeneratorState.DataTransferObjectsNameSpace};");
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
            AddField(code, "IMediator", "mediator", "The Mediator");

            var constructorParameters = new Dictionary<string, string>
                {
                    { dbContextName, "databaseContext" },
                    { "IMediator", "mediator" }
                };

            foreach (var query in queries)
            {
                var queryType = $"{query.Name}QueryBase";
                AddField(code, queryType, query.Name, query.Description);
                constructorParameters.Add(queryType, query.Name);
            }
            // TODO Rethink Custom Commands and Queris
            //foreach (var command in commands)
            //{
            //    var commandType = $"{command.Name}CommandHandlerBase";
            //    AddField(code, commandType, command.Name, command.Description);
            //    constructorParameters.Add(commandType, command.Name);
            //}

            // Add constructor
            AddConstructor(code, controllerName, constructorParameters);

            code.AppendLine();

            if (entity.Persistence is null ||
                entity.Persistence.Read.IsEnabled)
            {
                GenerateGet(entity, code, codeGeneratorState.Solution);

                if (entity.OwnedRelationships != null)
                {
                    foreach (var relationship in entity.OwnedRelationships)
                    {
                        // Owned single entitities are returned with parent
                        if (relationship.WithSingleEntity())
                        {
                            continue;
                        }
                        GenerateChildrenPost(codeGeneratorState.Solution, relationship.Related.Entity, entity, code);
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
                GeneratePut(entity, code, codeGeneratorState.Solution);

                GeneratePatch(entity, entityName, pluralName, code, codeGeneratorState.Solution);
            }

            if (entity.Persistence is null ||
                entity.Persistence.Delete.IsEnabled)
            {
                GenerateDelete(entity, entityName, code, codeGeneratorState.Solution);
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

            GeneratePrivateMethods(code);

            // TODO Rethink Custom Commands and Queries
            // Generate POST request mapping for Command Handlers
            //foreach (var command in commands)
            //{
            //    var typeDefinition = GenerateTypeDefinition(context, codeGeneratorState, command);

            //    GenerateDocs(code, command.Description);
            //    code.AppendLine($"[HttpPost(\"{command.Name}\")]");
            //    code.AppendLine($"public async Task<IResult> {command.Name}Async({typeDefinition} command)");
            //    code.StartBlock();
            //    code.AppendLine($"var result = await {command.Name.ToLowerFirstCharAndAddUnderscore()}.ExecuteAsync(command);");
            //    code.AppendLine(@"return result.IsSuccess ? Results.Ok(result) : Results.BadRequest(result);");
            //    code.EndBlock();
            //}

            // End class
            code.EndBlock();

            code.GenerateSourceCode();
        }
    }

    private static void GenerateDelete(Entity entity, string entityName, CodeBuilder code, NoxSolution solution)
    {
        // Method Delete
        code.AppendLine($"public async Task<ActionResult> Delete({PrimaryKeysFromRoute(entity, solution)})");

        // Method content
        code.StartBlock();
        if (!entity.IsOwnedEntity)
        {
            code.AppendLine("var etag = GetDecodedEtagHeader();");
            code.AppendLine($"var result = await _mediator.Send(new Delete{entityName}ByIdCommand({PrimaryKeysQuery(entity)}, etag));");
        }
        else
        {
            code.AppendLine($"var result = await _mediator.Send(new Delete{entityName}ByIdCommand({PrimaryKeysQuery(entity)}));");
        }

        code.AppendLine();
        code.AppendLine($"if (!result)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"return NoContent();");

        // End method
        code.EndBlock();
    }

    private static void GeneratePut(Entity entity, CodeBuilder code, NoxSolution solution)
    {
        // Method Put
        code.AppendLine($"public async Task<ActionResult> Put({PrimaryKeysFromRoute(entity, solution)}, [FromBody] {entity.Name}UpdateDto {entity.Name.ToLowerFirstChar()})");

        // Method content
        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"return BadRequest(ModelState);");
        code.EndBlock();
        code.AppendLine();

        if (!entity.IsOwnedEntity)
        {
            code.AppendLine("var etag = GetDecodedEtagHeader();");
            code.AppendLine($"var updated = await _mediator.Send(new Update{entity.Name}Command({PrimaryKeysQuery(entity)}, {entity.Name.ToLowerFirstChar()}, etag));");
        }
        else
        {
            code.AppendLine($"var updated = await _mediator.Send(new Update{entity.Name}Command({PrimaryKeysQuery(entity)}, {entity.Name.ToLowerFirstChar()}));");
        }

        code.AppendLine();

        code.AppendLine($"if (updated is null)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine($"return Updated(updated);");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GeneratePatch(Entity entity, string entityName, string pluralName, CodeBuilder code, NoxSolution solution)
    {
        // Method Patch
        code.AppendLine($"public async Task<ActionResult> Patch({PrimaryKeysFromRoute(entity, solution)}, [FromBody] Delta<{entityName}UpdateDto> {entity.Name.ToLowerFirstChar()})");

        // Method content
        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"return BadRequest(ModelState);");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine(@$"var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in {entity.Name.ToLowerFirstChar()}.GetChangedPropertyNames())
        {{
            if({entity.Name.ToLowerFirstChar()}.TryGetPropertyValue(propertyName, out dynamic value))
            {{
                updateProperties[propertyName] = value;                
            }}           
        }}");
        code.AppendLine();

        if (!entity.IsOwnedEntity)
        {
            code.AppendLine("var etag = GetDecodedEtagHeader();");
            code.AppendLine($"var updated = await _mediator.Send(new PartialUpdate{entity.Name}Command({PrimaryKeysQuery(entity)}, updateProperties, etag));");
        }
        else
        {
            code.AppendLine($"var updated = await _mediator.Send(new PartialUpdate{entity.Name}Command({PrimaryKeysQuery(entity)}, updateProperties));");
        }

        code.AppendLine();

        code.AppendLine($"if (updated is null)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine($"return Updated(updated);");

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
    private static void GenerateChildrenPost(NoxSolution solution, Entity child, Entity parent, CodeBuilder code)
    {
        code.AppendLine($"public async Task<ActionResult> PostTo{child.PluralName}({PrimaryKeysFromRoute(parent, solution)}, [FromBody] {child.Name}CreateDto {child.Name.ToLowerFirstChar()})");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"return BadRequest(ModelState);");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"var createdKey = await _mediator.Send(new Add{child.Name}Command(" +
            $"new {parent.Name}KeyDto({PrimaryKeysQuery(parent)}), {child.Name.ToLowerFirstChar()}));");
        code.AppendLine($"if (createdKey == null)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine();

        var childDtoParams = string.Join(", ", child.Keys.Select(k => $"{k.Name} = createdKey.key{k.Name}"));
        code.AppendLine($"return Created(new {child.Name}Dto {{ {childDtoParams} }});");

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateGet(Entity entity, CodeBuilder code, NoxSolution solution)
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

        if (entity.Keys is null)
        {
            Debug.WriteLine($"Key(s) should be defined for Get by id query, Entity - {entity.Name}...");
            return;
        }

        // We do not support Compound types as primary keys, this is validated on the schema
        // Method Get
        code.AppendLine($"[EnableQuery]");
        code.AppendLine($"public async Task<ActionResult<{entity.Name}Dto>> Get({PrimaryKeysFromRoute(entity, solution)})");

        // Method content
        code.StartBlock();
        code.AppendLine($"var item = await _mediator.Send(new Get{entity.Name}ByIdQuery({PrimaryKeysQuery(entity)}));");
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

    private static string PrimaryKeysFromRoute(Entity entity, NoxSolution solution)
    {
        if (entity.Keys.Count() > 1)
            return string.Join(", ", entity.Keys.Select(k => $"[FromRoute] {solution.GetSinglePrimitiveTypeForKey(k)} key{k.Name}"));
        else if (entity.Keys is not null)
            return $"[FromRoute] {solution.GetSinglePrimitiveTypeForKey(entity.Keys[0])} key";

        return "";
    }

    private static string PrimaryKeysQuery(Entity entity)
    {
        return entity.Keys.Count() > 1 ?
            string.Join(", ", entity.Keys.Select(k => $"key{k.Name}")) :
            $"key";
    }

    private static void GeneratePrivateMethods(CodeBuilder code)
    {
        // GetDecodedEtagHeader()
        code.AppendLine();
        code.AppendLine("private System.Guid? GetDecodedEtagHeader()");
        code.StartBlock();
        code.AppendLine("var ifMatchValue = Request.Headers.IfMatch.FirstOrDefault();");
        code.AppendLine("string? rawEtag = ifMatchValue;");
        code.AppendLine("if (EntityTagHeaderValue.TryParse(ifMatchValue, out var encodedEtag))");
        code.StartBlock();
        code.AppendLine("rawEtag = encodedEtag.Tag.Trim('\"');");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine("return System.Guid.TryParse(rawEtag, out var etag) ? etag : null;");
        code.EndBlock();
    }
}