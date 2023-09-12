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
            code.AppendLine("using Nox.Extensions;");

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

            code.AppendLine(@$"public partial class {controllerName} : {controllerName}Base
            {{
                public {controllerName}(IMediator mediator, {dbContextName} databaseContext):base(databaseContext, mediator)
                {{}}
            }}");

            code.AppendLine($"public abstract class {controllerName}Base : ODataController");

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
            AddConstructor(code, $"{controllerName}Base", constructorParameters);

            code.AppendLine();

            if (entity.Persistence is null ||
                entity.Persistence.Read.IsEnabled)
            {
                GenerateGet(entity, code, codeGeneratorState.Solution);
            }

            if (entity.Persistence is null ||
                entity.Persistence.Create.IsEnabled)
            {
                GeneratePost(entity, code);
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

            GenerateOwnedEntities(codeGeneratorState.Solution, code, entity);

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
        code.AppendLine($"public virtual async Task<ActionResult> Delete({PrimaryKeysFromRoute(entity, solution)})");

        // Method content
        code.StartBlock();
        if (!entity.IsOwnedEntity)
        {
            code.AppendLine("var etag = Request.GetDecodedEtagHeader();");
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
        code.AppendLine($"public virtual async Task<ActionResult<{entity.Name}Dto>> Put({PrimaryKeysFromRoute(entity, solution)}, [FromBody] {entity.Name}UpdateDto {entity.Name.ToLowerFirstChar()})");

        // Method content
        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"return BadRequest(ModelState);");
        code.EndBlock();
        code.AppendLine();

        if (!entity.IsOwnedEntity)
        {
            code.AppendLine("var etag = Request.GetDecodedEtagHeader();");
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
        code.AppendLine();
        code.AppendLine($"var item = await _mediator.Send(new Get{entity.Name}ByIdQuery({PrimaryKeysQuery(entity, "updated.key", true)}));");
        code.AppendLine();

        code.AppendLine($"return Ok(item);");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GeneratePatch(Entity entity, string entityName, string pluralName, CodeBuilder code, NoxSolution solution)
    {
        // Method Patch
        code.AppendLine($"public virtual async Task<ActionResult<{entity.Name}Dto>> Patch({PrimaryKeysFromRoute(entity, solution)}, [FromBody] Delta<{entityName}UpdateDto> {entity.Name.ToLowerFirstChar()})");

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
            code.AppendLine("var etag = Request.GetDecodedEtagHeader();");
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
        code.AppendLine($"var item = await _mediator.Send(new Get{entity.Name}ByIdQuery({PrimaryKeysQuery(entity, "updated.key", true)}));");
        code.AppendLine($"return Ok(item);");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GeneratePost(Entity entity, CodeBuilder code)
    {
        // Method Post
        code.AppendLine($"public virtual async Task<ActionResult<{entity.Name}Dto>> Post([FromBody]{entity.Name}CreateDto {entity.Name.ToLowerFirstChar()})");

        // Method content
        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"return BadRequest(ModelState);");
        code.EndBlock();
        code.AppendLine($"var createdKey = await _mediator.Send(new Create{entity.Name}Command({entity.Name.ToLowerFirstChar()}));");
        code.AppendLine();
        code.AppendLine($"var item = await _mediator.Send(new Get{entity.Name}ByIdQuery({PrimaryKeysQuery(entity, "createdKey.key", true)}));");
        code.AppendLine();
        
        code.AppendLine($"return Created(item);");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateOwnedEntities(NoxSolution solution, CodeBuilder code, Entity entity)
    {
        if (entity.OwnedRelationships != null && entity.OwnedRelationships.Count() > 0)
        {
            code.AppendLine();
            code.AppendLine($"#region Owned Relationships");
            code.AppendLine();
            foreach (var relationship in entity.OwnedRelationships)
            {
                // Owned single entitities are returned with parent
                if (relationship.WithSingleEntity())
                {
                    continue;
                }

                var child = relationship.Related.Entity;

                if (child.Persistence is null || child.Persistence.Read.IsEnabled)
                {
                    GenerateChildrenGet(solution, child, entity, code);
                    GenerateChildrenGetById(solution, child, entity, code);
                }

                if (child.Persistence is null || child.Persistence.Create.IsEnabled)
                {
                    GenerateChildrenPost(solution, child, entity, code);
                }

                if (child.Persistence is null || child.Persistence.Update.IsEnabled)
                {
                    GenerateChildrenPut(solution, child, entity, code);
                    GenerateChildrenPatch(solution, child, entity, code);
                }

                if (child.Persistence is null || child.Persistence.Delete.IsEnabled)
                {
                    GenerateChildrenDelete(solution, child, entity, code);
                }

                GeneratePrivateChildrenGetById(solution, child, entity, code);
            }
            code.AppendLine($"#endregion");
            code.AppendLine();
        }
    }

    private static void GeneratePrivateChildrenGetById(NoxSolution solution, Entity child, Entity parent, CodeBuilder code)
    {
        code.AppendLine($"private async Task<{child.Name}Dto?> TryGet{child.Name}({PrimaryKeysFromRoute(parent, solution, attributePrefix: "")}, {child.Name}KeyDto childKeyDto)");

        code.StartBlock();
        code.AppendLine($"var parent = await _mediator.Send(new Get{parent.Name}ByIdQuery({PrimaryKeysQuery(parent)}));");

        var param = string.Join(" && ", child.Keys.Select(k => $"x.{k.Name} == childKeyDto.key{k.Name}"));
        code.AppendLine($"return parent?.{child.PluralName}.SingleOrDefault(x => {param});");

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateChildrenGetById(NoxSolution solution, Entity child, Entity parent, CodeBuilder code)
    {
        code.AppendLine($"[EnableQuery]");
        code.AppendLine($"[HttpGet(\"api/{parent.PluralName}/{PrimaryKeysAttribute(parent)}/{child.PluralName}/{PrimaryKeysAttribute(child, "relatedKey")}\")]");
        code.AppendLine($"public virtual async Task<ActionResult<{child.Name}Dto>> Get{child.Name}NonConventional(" +
            $"{PrimaryKeysFromRoute(parent, solution, attributePrefix: "")}, " +
            $"{PrimaryKeysFromRoute(child, solution, "relatedKey", "")})");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"return BadRequest(ModelState);");
        code.EndBlock();

        code.AppendLine($"var child = await TryGet{child.Name}(" +
            $"{PrimaryKeysQuery(parent)}, " +
            $"new {child.Name}KeyDto({PrimaryKeysQuery(child, "relatedKey")}));");
        code.AppendLine($"if (child == null)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"return Ok(child);");

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateChildrenGet(NoxSolution solution, Entity child, Entity parent, CodeBuilder code)
    {
        code.AppendLine($"[EnableQuery]");
        code.AppendLine($"public virtual async Task<ActionResult<IQueryable<{child.Name}Dto>>> Get{child.PluralName}({PrimaryKeysFromRoute(parent, solution)})");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"return BadRequest(ModelState);");
        code.EndBlock();

        code.AppendLine($"var item = await _mediator.Send(new Get{parent.Name}ByIdQuery({PrimaryKeysQuery(parent)}));");
        code.AppendLine();
        code.AppendLine($"if (item is null)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"return Ok(item.{child.PluralName});");

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateChildrenPost(NoxSolution solution, Entity child, Entity parent, CodeBuilder code)
    {
        code.AppendLine($"public virtual async Task<ActionResult> PostTo{child.PluralName}({PrimaryKeysFromRoute(parent, solution)}, [FromBody] {child.Name}CreateDto {child.Name.ToLowerFirstChar()})");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"return BadRequest(ModelState);");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine("var etag = Request.GetDecodedEtagHeader();");
        code.AppendLine($"var createdKey = await _mediator.Send(new Add{child.Name}Command(" +
            $"new {parent.Name}KeyDto({PrimaryKeysQuery(parent)}), {child.Name.ToLowerFirstChar()}, etag));");
        code.AppendLine($"if (createdKey == null)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"var child = await TryGet{child.Name}({PrimaryKeysQuery(parent)}, createdKey);");
        code.AppendLine($"if (child == null)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"return Created(child);");

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateChildrenPut(NoxSolution solution, Entity child, Entity parent, CodeBuilder code)
    {
        code.AppendLine($"[HttpPut(\"api/{parent.PluralName}/{PrimaryKeysAttribute(parent)}/{child.PluralName}/{PrimaryKeysAttribute(child, "relatedKey")}\")]");
        code.AppendLine($"public virtual async Task<ActionResult<{child.Name}Dto>> PutTo{child.PluralName}NonConventional(" +
            $"{PrimaryKeysFromRoute(parent, solution, attributePrefix: "")}, " +
            $"{PrimaryKeysFromRoute(child, solution, "relatedKey", "")}, " +
            $"[FromBody] {child.Name}UpdateDto {child.Name.ToLowerFirstChar()})");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"return BadRequest(ModelState);");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine("var etag = Request.GetDecodedEtagHeader();");
        code.AppendLine($"var updatedKey = await _mediator.Send(new Update{child.Name}Command(" +
            $"new {parent.Name}KeyDto({PrimaryKeysQuery(parent)}), " +
            $"new {child.Name}KeyDto({PrimaryKeysQuery(child, "relatedKey")}), " +
            $"{child.Name.ToLowerFirstChar()}, etag));");
        code.AppendLine($"if (updatedKey == null)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"var child = await TryGet{child.Name}({PrimaryKeysQuery(parent)}, updatedKey);");
        code.AppendLine($"if (child == null)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"return Ok(child);");

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateChildrenPatch(NoxSolution solution, Entity child, Entity parent, CodeBuilder code)
    {
        // Method Patch
        code.AppendLine($"[HttpPatch(\"api/{parent.PluralName}/{PrimaryKeysAttribute(parent)}/{child.PluralName}/{PrimaryKeysAttribute(child, "relatedKey")}\")]");
        code.AppendLine($"public virtual async Task<ActionResult> PatchTo{child.PluralName}NonConventional(" +
            $"{PrimaryKeysFromRoute(parent, solution, attributePrefix: "")}, " +
            $"{PrimaryKeysFromRoute(child, solution, "relatedKey", "")}, " +
            $"[FromBody] Delta<{child.Name}UpdateDto> {child.Name.ToLowerFirstChar()})");

        // Method content
        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"return BadRequest(ModelState);");
        code.EndBlock();
        code.AppendLine(@$"var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in {child.Name.ToLowerFirstChar()}.GetChangedPropertyNames())
        {{
            if({child.Name.ToLowerFirstChar()}.TryGetPropertyValue(propertyName, out dynamic value))
            {{
                updateProperties[propertyName] = value;                
            }}           
        }}");
        code.AppendLine();
        code.AppendLine("var etag = Request.GetDecodedEtagHeader();");
        code.AppendLine($"var updated = await _mediator.Send(new PartialUpdate{child.Name}Command(" +
            $"new {parent.Name}KeyDto({PrimaryKeysQuery(parent)}), " +
            $"new {child.Name}KeyDto({PrimaryKeysQuery(child, "relatedKey")}), " +
            $"updateProperties, etag));");
        code.AppendLine();

        code.AppendLine($"if (updated is null)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine($"var child = await TryGet{child.Name}({PrimaryKeysQuery(parent)}, updated);");
        code.AppendLine($"if (child == null)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"return Ok(child);");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateChildrenDelete(NoxSolution solution, Entity child, Entity parent, CodeBuilder code)
    {
        code.AppendLine($"[HttpDelete(\"api/{parent.PluralName}/{PrimaryKeysAttribute(parent)}/{child.PluralName}/{PrimaryKeysAttribute(child, "relatedKey")}\")]");
        code.AppendLine($"public virtual async Task<ActionResult> Delete{child.Name}NonConventional(" +
            $"{PrimaryKeysFromRoute(parent, solution, attributePrefix: "")}, " +
            $"{PrimaryKeysFromRoute(child, solution, "relatedKey", "")})");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"return BadRequest(ModelState);");
        code.EndBlock();

        code.AppendLine($"var result = await _mediator.Send(new Delete{child.Name}Command(" +
            $"new {parent.Name}KeyDto({PrimaryKeysQuery(parent)}), " +
            $"new {child.Name}KeyDto({PrimaryKeysQuery(child, "relatedKey")})));");

        code.AppendLine($"if (!result)");
        code.StartBlock();
        code.AppendLine($"return NotFound();");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"return NoContent();");

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateGet(Entity entity, CodeBuilder code, NoxSolution solution)
    {
        // Method Get
        code.AppendLine($"[EnableQuery]");
        code.AppendLine($"public virtual async Task<ActionResult<IQueryable<{entity.Name}Dto>>> Get()");

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

    private static string PrimaryKeysFromRoute(Entity entity, NoxSolution solution, string keyPrefix = "key", string attributePrefix = "[FromRoute]")
    {
        if (entity.Keys.Count() > 1)
            return string.Join(", ", entity.Keys.Select(k => $"{attributePrefix} {solution.GetSinglePrimitiveTypeForKey(k)} {keyPrefix}{k.Name}"))
                .Trim();
        else if (entity.Keys is not null)
            return $"{attributePrefix} {solution.GetSinglePrimitiveTypeForKey(entity.Keys[0])} {keyPrefix}"
                .Trim();

        return "";
    }

    private static string PrimaryKeysQuery(Entity entity, string prefix = "key", bool withKeyName = false)
    {
        if (entity.Keys.Count() > 1)
            return string.Join(", ", entity.Keys.Select(k => $"{prefix}{k.Name}"));
        else if (entity.Keys is not null)
            return withKeyName ? $"{prefix}{entity.Keys[0].Name}" : $"{prefix}";

        return "";
    }

    private static string PrimaryKeysAttribute(Entity entity, string prefix = "key")
    {
        if (entity.Keys.Count() > 1)
            return string.Join(",", entity.Keys.Select(k => $"{k.Name}={{{prefix}{k.Name}}}"));
        else if (entity.Keys is not null)
            return $"{{{prefix}}}";

        return "";
    }
}