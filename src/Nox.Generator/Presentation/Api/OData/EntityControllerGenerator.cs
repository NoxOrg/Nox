using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Solution;
using Nox.Solution.Extensions;
using System.Collections.Generic;
using System.Linq;
using static Nox.Generator.Common.BaseGenerator;

namespace Nox.Generator.Presentation.Api.OData;

internal class EntityControllerGenerator : EntityControllerGeneratorBase
{
    public override void Generate(
    SourceProductionContext context,
    NoxCodeGenConventions codeGenConventions,
    GeneratorConfig config, System.Action<string> log,
    string? projectRootPath)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGenConventions.Solution.Domain is null)
        {
            return;
        }

        foreach (var entity in codeGenConventions.Solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            if (codeGenConventions.Solution.Domain.Entities.Any(e => e.OwnedRelationships != null && e.OwnedRelationships.Any(r => r.Entity.Equals(entity.Name))))
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

            var code = new CodeBuilder($"Presentation.Api.OData/{pluralName}Controller.g.cs", context);

            // Namespace
            code.AppendLine($"using Microsoft.AspNetCore.Mvc;");
            code.AppendLine($"using Microsoft.AspNetCore.OData.Deltas;");
            code.AppendLine($"using Microsoft.AspNetCore.OData.Query;");
            code.AppendLine($"using Microsoft.AspNetCore.OData.Results;");
            code.AppendLine($"using Microsoft.AspNetCore.OData.Routing.Controllers;");
            code.AppendLine($"using Microsoft.EntityFrameworkCore;");
            code.AppendLine("using MediatR;");
            code.AppendLine("using System;");
            code.AppendLine("using System.Net.Http.Headers;");
            code.AppendLine("using Nox.Application;");
            code.AppendLine("using Nox.Application.Dto;");
            code.AppendLine("using Nox.Extensions;");
            code.AppendLine("using Nox.Exceptions;");

            code.AppendLine($"using {codeGenConventions.ApplicationNameSpace};");
            code.AppendLine($"using {codeGenConventions.ApplicationNameSpace}.Dto;");
            code.AppendLine($"using {codeGenConventions.ApplicationNameSpace}.Queries;");
            code.AppendLine($"using {codeGenConventions.ApplicationNameSpace}.Commands;");
            //code.AppendLine($"using {codeGenConventions.DataTransferObjectsNameSpace};");
            code.AppendLine($"using {codeGenConventions.DomainNameSpace};");
            code.AppendLine($"using {codeGenConventions.PersistenceNameSpace};");

            code.AppendLine($"using Nox.Types;");
            code.AppendLine();
            code.AppendLine($"namespace {codeGenConventions.ODataNameSpace};");
            code.AppendLine();

            code.AppendLine($"public abstract partial class {controllerName}Base : ODataController");

            // Class
            code.StartBlock();

            foreach (var query in queries)
            {
                var queryType = $"{query.Name}QueryBase";
                AddField(code, queryType, query.Name, query.Description);
            }
            // TODO Rethink Custom Commands and Queris
            //foreach (var command in commands)
            //{
            //    var commandType = $"{command.Name}CommandHandlerBase";
            //    AddField(code, commandType, command.Name, command.Description);
            //    constructorParameters.Add(commandType, command.Name);
            //}

            GenerateOwnedRelationships(codeGenConventions.Solution, code, entity);
            GenerateRelationships(codeGenConventions.Solution, code, entity);

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
            //    var typeDefinition = GenerateTypeDefinition(context, codeGenConventions, command);

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

    private static void GenerateOwnedRelationships(NoxSolution solution, CodeBuilder code, Entity entity)
    {
        if (entity.OwnedRelationships?.Any() == true)
        {
            code.AppendLine();
            code.AppendLine($"#region Owned Relationships");
            code.AppendLine();
            foreach (var relationship in entity.OwnedRelationships)
            {
                if (!relationship.ApiGenerateRelatedEndpoint)
                    continue;

                var child = relationship.Related.Entity;

                if (CanRead(entity) && CanRead(child))
                {
                    GenerateChildrenGet(solution, relationship, entity, code);

                    if (!relationship.WithSingleEntity())
                        GenerateChildrenGetById(solution, relationship, child, entity, code);
                }

                if (CanCreate(entity) && CanCreate(child))
                {
                    GenerateChildrenPost(solution, relationship, entity, code);
                }

                if (CanUpdate(entity) && CanUpdate(child))
                {
                    GenerateChildrenPut(solution, relationship, entity, code);
                    GenerateChildrenPatch(solution, relationship, entity, code);
                }

                if (CanDelete(entity) && CanDelete(child))
                {
                    GenerateChildrenDelete(solution, relationship, entity, code);
                }

                if (!relationship.WithSingleEntity())
                    GeneratePrivateChildrenGetById(solution, relationship, child, entity, code);
            }
            code.AppendLine($"#endregion");
            code.AppendLine();
        }
    }

    private static void GeneratePrivateChildrenGetById(NoxSolution solution, EntityRelationship relationship, Entity child, Entity parent, CodeBuilder code)
    {
        var navigationName = parent.GetNavigationPropertyName(relationship);
        code.AppendLine($"protected async Task<{child.Name}Dto?> TryGet{navigationName}({GetPrimaryKeysRoute(parent, solution, attributePrefix: "")}, {child.Name}KeyDto childKeyDto)");

        code.StartBlock();
        code.AppendLine($"var parent = (await _mediator.Send(new Get{parent.Name}ByIdQuery({GetPrimaryKeysQuery(parent)}))).SingleOrDefault();");

        var param = string.Join(" && ", child.Keys.Select(k => $"x.{k.Name} == childKeyDto.key{k.Name}"));
        code.AppendLine($"return parent?.{navigationName}.SingleOrDefault(x => {param});");

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateChildrenGetById(NoxSolution solution, EntityRelationship relationship, Entity child, Entity parent, CodeBuilder code)
    {
        var navigationName = parent.GetNavigationPropertyName(relationship);

        code.AppendLine($"[EnableQuery]");
        code.AppendLine($"[HttpGet(\"{solution.Presentation.ApiConfiguration.ApiRoutePrefix}/{parent.PluralName}/{PrimaryKeysAttribute(parent)}/{navigationName}/{PrimaryKeysAttribute(child, "relatedKey")}\")]");
        code.AppendLine($"public virtual async Task<ActionResult<{child.Name}Dto>> Get{navigationName}NonConventional(" +
            $"{GetPrimaryKeysRoute(parent, solution, attributePrefix: "")}, " +
            $"{GetPrimaryKeysRoute(child, solution, "relatedKey", "")})");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"throw new Nox.Exceptions.BadRequestException(ModelState);");
        code.EndBlock();

        code.AppendLine($"var child = await TryGet{navigationName}(" +
            $"{GetPrimaryKeysQuery(parent)}, " +
            $"new {child.Name}KeyDto({GetPrimaryKeysQuery(child, "relatedKey")}));");
        code.AppendLine($"if (child is null)");
        code.StartBlock();
        code.AppendLine($"throw new EntityNotFoundException(\"{child.Name}\", $\"{GetPrimaryKeysToString(child, "relatedKey")}\");");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"return Ok(child);");

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateChildrenGet(NoxSolution solution, EntityRelationship relationship, Entity parent, CodeBuilder code)
    {
        var child = relationship.Related.Entity;
        var isSingleRelationship = relationship.WithSingleEntity();
        var navigationName = parent.GetNavigationPropertyName(relationship);

        code.AppendLine($"[EnableQuery]");
        if (isSingleRelationship)
            code.AppendLine($"public virtual async Task<ActionResult<{child.Name}Dto>> Get{navigationName}({GetPrimaryKeysRoute(parent, solution)})");
        else
            code.AppendLine($"public virtual async Task<ActionResult<IQueryable<{child.Name}Dto>>> Get{navigationName}({GetPrimaryKeysRoute(parent, solution)})");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"throw new Nox.Exceptions.BadRequestException(ModelState);");
        code.EndBlock();

        code.AppendLine($"var item = (await _mediator.Send(new Get{parent.Name}ByIdQuery({GetPrimaryKeysQuery(parent)}))).SingleOrDefault();");
        code.AppendLine();
        code.AppendLine($"if (item is null)");
        code.StartBlock();
        code.AppendLine($"throw new EntityNotFoundException(\"{parent.Name}\", $\"{GetPrimaryKeysToString(parent)}\");");
        code.EndBlock();
        code.AppendLine();

        code.AppendLine($"return Ok(item.{navigationName});");

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateChildrenPost(NoxSolution solution, EntityRelationship relationship, Entity parent, CodeBuilder code)
    {
        var child = relationship.Related.Entity;
        var isSingleRelationship = relationship.WithSingleEntity();
        var navigationName = parent.GetNavigationPropertyName(relationship);

        code.AppendLine($"public virtual async Task<ActionResult> PostTo{navigationName}({GetPrimaryKeysRoute(parent, solution)}, [FromBody] {child.Name}UpsertDto {child.Name.ToLowerFirstChar()})");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"throw new Nox.Exceptions.BadRequestException(ModelState);");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine("var etag = Request.GetDecodedEtagHeader();");
        code.AppendLine($"var createdKey = await _mediator.Send(new Create{navigationName}For{parent.Name}Command(" +
            $"new {parent.Name}KeyDto({GetPrimaryKeysQuery(parent)}), {child.Name.ToLowerFirstChar()}, _cultureCode, etag));");
        code.AppendLine();

        if (isSingleRelationship)
            code.AppendLine($"var child = (await _mediator.Send(new Get{parent.Name}ByIdQuery({GetPrimaryKeysQuery(parent)})))" +
                $".SingleOrDefault()?" +
                $".{navigationName};");
        else
            code.AppendLine($"var child = await TryGet{navigationName}({GetPrimaryKeysQuery(parent)}, createdKey);");
        code.AppendLine($"return Created(child);");

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateChildrenPut(NoxSolution solution, EntityRelationship relationship, Entity parent, CodeBuilder code)
    {
        var isSingleRelationship = relationship.WithSingleEntity();
        var child = relationship.Related.Entity;
        var childType = isSingleRelationship ? $"{child.Name}UpsertDto" : $"EntityDtoCollection<{child.Name}UpsertDto>";
        var childName = isSingleRelationship ? child.Name.ToLowerFirstChar() : child.PluralName.ToLowerFirstChar();
        var navigationName = parent.GetNavigationPropertyName(relationship);

        code.AppendLine($"public virtual async Task<ActionResult<{child.Name}Dto>> PutTo{navigationName}(" +
            $"{GetPrimaryKeysRoute(parent, solution, attributePrefix: "")}, " +
            $"[FromBody] {childType} {childName})");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"throw new Nox.Exceptions.BadRequestException(ModelState);");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine("var etag = Request.GetDecodedEtagHeader();");

        if (isSingleRelationship)
        {
            code.AppendLine($"var updatedKey = await _mediator.Send(new Update{navigationName}For{parent.Name}Command(" +
                $"new {parent.Name}KeyDto({GetPrimaryKeysQuery(parent)}), " +
                $"{childName}, _cultureCode, etag));");

            code.AppendLine();
            code.AppendLine($"var child = (await _mediator.Send(new Get{parent.Name}ByIdQuery({GetPrimaryKeysQuery(parent)})))" +
                $".SingleOrDefault()?" +
                $".{navigationName};");

            code.AppendLine();
            code.AppendLine($"return Ok(child);");
        }
        else
        {
            code.AppendLine($"var updatedKeys = await _mediator.Send(new Update{navigationName}For{parent.Name}Command(" +
                $"new {parent.Name}KeyDto({GetPrimaryKeysQuery(parent)}), " +
                $"{childName}.Values!, _cultureCode, etag));");

            code.AppendLine();
            code.AppendLine($"var children = (await _mediator.Send(new Get{parent.Name}ByIdQuery({GetPrimaryKeysQuery(parent)})))" +
                $".SingleOrDefault()" +
                $"?.{navigationName}" +
                $"?.Where(e => updatedKeys.Any(k => {string.Join(" && ", child.Keys.Select(k => $"e.{k.Name} == k.key{k.Name}"))}));");

            code.AppendLine();
            code.AppendLine($"return Ok(children);");
        }

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateChildrenPatch(NoxSolution solution, EntityRelationship relationship, Entity parent, CodeBuilder code)
    {
        var child = relationship.Related.Entity;
        var isSingleRelationship = relationship.WithSingleEntity();
        var navigationName = parent.GetNavigationPropertyName(relationship);

        // Method Patch
        code.AppendLine($"public virtual async Task<ActionResult> PatchTo{navigationName}(" +
            $"{GetPrimaryKeysRoute(parent, solution, attributePrefix: "")}, " +
            $"[FromBody] Delta<{child.Name}UpsertDto> {child.Name.ToLowerFirstChar()})");

        // Method content
        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid || {child.Name.ToLowerFirstChar()} is null)");
        code.StartBlock();
        code.AppendLine($"throw new Nox.Exceptions.BadRequestException(ModelState);");
        code.EndBlock();
        code.AppendLine($"var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<{child.Name}UpsertDto>({child.Name.ToLowerFirstChar()});");
        code.AppendLine();

        if (child.Keys.Any())
        {
            code.AppendLine($"if(!updatedProperties.ContainsKey(\"{child.Keys[0].Name}\") || updatedProperties[\"{child.Keys[0].Name}\"] == null)");
            code.StartBlock();
            code.AppendLine($"throw new Nox.Exceptions.BadRequestException(\"{child.Keys[0].Name} is required.\");");
            code.EndBlock();
        }
        code.AppendLine();
        code.AppendLine("var etag = Request.GetDecodedEtagHeader();");

        if (isSingleRelationship)
            code.AppendLine($"var updated = await _mediator.Send(new PartialUpdate{navigationName}For{parent.Name}Command(" +
                $"new {parent.Name}KeyDto({GetPrimaryKeysQuery(parent)}), " +
                $"updatedProperties, _cultureCode, etag));");
        else
            code.AppendLine($"var updated = await _mediator.Send(new PartialUpdate{navigationName}For{parent.Name}Command(" +
                $"new {parent.Name}KeyDto({GetPrimaryKeysQuery(parent)}), " +
                $"new {child.Name}KeyDto(updatedProperties[\"{child.Keys[0].Name}\"]), " +
                $"updatedProperties, _cultureCode, etag));");
        code.AppendLine();

        if (isSingleRelationship)
            code.AppendLine($"var child = (await _mediator.Send(new Get{parent.Name}ByIdQuery({GetPrimaryKeysQuery(parent)})))" +
                $".SingleOrDefault()?" +
                $".{navigationName};");
        else
            code.AppendLine($"var child = await TryGet{navigationName}({GetPrimaryKeysQuery(parent)}, updated!);");

        code.AppendLine();
        code.AppendLine($"return Ok(child);");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateChildrenDelete(NoxSolution solution, EntityRelationship relationship, Entity parent, CodeBuilder code)
    {
        var child = relationship.Related.Entity;
        var isSingleRelationship = relationship.WithSingleEntity();
        var navigationName = parent.GetNavigationPropertyName(relationship);

        if (isSingleRelationship)
        {
            code.AppendLine($"[HttpDelete(\"{solution.Presentation.ApiConfiguration.ApiRoutePrefix}/{parent.PluralName}/{PrimaryKeysAttribute(parent)}/{navigationName}\")]");
            code.AppendLine($"public virtual async Task<ActionResult> Delete{child.Name}NonConventional(" +
                $"{GetPrimaryKeysRoute(parent, solution, attributePrefix: "")})");
        }
        else
        {
            code.AppendLine($"[HttpDelete(\"{solution.Presentation.ApiConfiguration.ApiRoutePrefix}/{parent.PluralName}/{PrimaryKeysAttribute(parent)}/{navigationName}/{PrimaryKeysAttribute(child, "relatedKey")}\")]");
            code.AppendLine($"public virtual async Task<ActionResult> Delete{child.Name}NonConventional(" +
                $"{GetPrimaryKeysRoute(parent, solution, attributePrefix: "")}, " +
                $"{GetPrimaryKeysRoute(child, solution, "relatedKey", "")})");
        }

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"throw new Nox.Exceptions.BadRequestException(ModelState);");
        code.EndBlock();

        if (isSingleRelationship)
            code.AppendLine($"var result = await _mediator.Send(new Delete{navigationName}For{parent.Name}Command(" +
                $"new {parent.Name}KeyDto({GetPrimaryKeysQuery(parent)})));");
        else
            code.AppendLine($"var result = await _mediator.Send(new Delete{navigationName}For{parent.Name}Command(" +
                $"new {parent.Name}KeyDto({GetPrimaryKeysQuery(parent)}), " +
                $"new {child.Name}KeyDto({GetPrimaryKeysQuery(child, "relatedKey")})));");

        code.AppendLine();
        code.AppendLine($"return NoContent();");

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateRelationships(NoxSolution solution, CodeBuilder code, Entity entity)
    {
        if (entity.Relationships?.Any() == true)
        {
            code.AppendLine();
            code.AppendLine($"#region Relationships");
            code.AppendLine();

            foreach (var relationship in entity.Relationships)
            {

                bool hideEndPointFromSwagger = !relationship.ApiGenerateReferenceEndpoint || !CanCreate(entity);
                GenerateCreateRefTo(entity, relationship, code, solution, hideEndPointFromSwagger);

                hideEndPointFromSwagger = !relationship.ApiGenerateReferenceEndpoint || !CanUpdate(entity);
                GenerateUpdateAllRefTo(entity, relationship, code, solution, hideEndPointFromSwagger);

                hideEndPointFromSwagger = !relationship.ApiGenerateReferenceEndpoint || !CanRead(entity);
                GenerateGetRefTo(entity, relationship, code, solution, hideEndPointFromSwagger);

                hideEndPointFromSwagger = !relationship.ApiGenerateReferenceEndpoint || !CanDelete(entity);
                GenerateDeleteRefTo(entity, relationship, code, solution, hideEndPointFromSwagger);
                GenerateDeleteAllRefTo(entity, relationship, code, solution, hideEndPointFromSwagger);

                hideEndPointFromSwagger = !relationship.ApiGenerateRelatedEndpoint || !CanCreate(entity);
                GenerateRelatedPost(solution, relationship, entity, code, hideEndPointFromSwagger);

                hideEndPointFromSwagger = !relationship.ApiGenerateRelatedEndpoint || !CanRead(entity);
                GenerateRelatedGet(solution, relationship, entity, code, hideEndPointFromSwagger);
                GenerateRelatedGetById(solution, relationship, entity, code, hideEndPointFromSwagger);

                hideEndPointFromSwagger = !relationship.ApiGenerateRelatedEndpoint || !CanUpdate(entity);
                GenerateRelatedPut(solution, relationship, entity, code, hideEndPointFromSwagger);
                GenerateRelatedPatch(solution, relationship, entity, code, hideEndPointFromSwagger);

                hideEndPointFromSwagger = !relationship.ApiGenerateRelatedEndpoint || !CanDelete(entity);
                GenerateRelatedDelete(solution, relationship, entity, code, hideEndPointFromSwagger);
                GenerateRelatedDeleteAll(solution, relationship, entity, code, hideEndPointFromSwagger);
            }
            code.AppendLine($"#endregion");
            code.AppendLine();
        }
    }

    private static void GenerateCreateRefTo(Entity entity, EntityRelationship relationship, CodeBuilder code, NoxSolution solution, bool hideEndPointFromSwagger)
    {
        var relatedEntity = relationship.Related.Entity;
        if (hideEndPointFromSwagger)
            code.AppendLine("[ApiExplorerSettings(IgnoreApi = true)]");
        code.AppendLine($"public virtual async Task<ActionResult> CreateRefTo{entity.GetNavigationPropertyName(relationship)}" +
            $"({GetPrimaryKeysRoute(entity, solution)}, {GetPrimaryKeysRoute(relatedEntity, solution, "relatedKey")})");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"throw new Nox.Exceptions.BadRequestException(ModelState);");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"var createdRef = await _mediator.Send(new CreateRef{entity.Name}To{entity.GetNavigationPropertyName(relationship)}Command(" +
            $"new {entity.Name}KeyDto({GetPrimaryKeysQuery(entity)}), new {relatedEntity.Name}KeyDto({GetPrimaryKeysQuery(relatedEntity, "relatedKey")})));");
        code.AppendLine();

        code.AppendLine($"return NoContent();");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateUpdateAllRefTo(Entity entity, EntityRelationship relationship, CodeBuilder code, NoxSolution solution, bool hideEndPointFromSwagger)
    {
        var relatedEntity = relationship.Related.Entity;

        if (relationship.WithSingleEntity || relatedEntity.Keys.Count() > 1)
            return;

        var navigationName = entity.GetNavigationPropertyName(relationship);
        if (hideEndPointFromSwagger)
            code.AppendLine("[ApiExplorerSettings(IgnoreApi = true)]");
        code.AppendLine($"[HttpPut(\"{solution.Presentation.ApiConfiguration.ApiRoutePrefix}/{entity.PluralName}/{PrimaryKeysAttribute(entity)}/{navigationName}/$ref\")]");
        code.AppendLine($"public virtual async Task<ActionResult> UpdateRefTo{navigationName}NonConventional" +
            $"({GetPrimaryKeysRoute(entity, solution)}, " +
            $"[FromBody] ReferencesDto<{solution.GetSinglePrimitiveTypeForKey(relatedEntity.Keys[0])}> referencesDto)");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"throw new Nox.Exceptions.BadRequestException(ModelState);");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"var relatedKeysDto = referencesDto.References.Select(x => new {relatedEntity.Name}KeyDto(x)).ToList();");
        code.AppendLine($"var updatedRef = await _mediator.Send(new UpdateRef{entity.Name}To{navigationName}Command(" +
            $"new {entity.Name}KeyDto({GetPrimaryKeysQuery(entity)}), relatedKeysDto));");
        code.AppendLine();

        code.AppendLine($"return NoContent();");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateDeleteRefTo(Entity entity, EntityRelationship relationship, CodeBuilder code, NoxSolution solution, bool hideEndPointFromSwagger)
    {
        if (relationship.Relationship == EntityRelationshipType.ExactlyOne)
            return;

        var relatedEntity = relationship.Related.Entity;
        var navigationName = entity.GetNavigationPropertyName(relationship);
        if (hideEndPointFromSwagger)
            code.AppendLine("[ApiExplorerSettings(IgnoreApi = true)]");
        code.AppendLine($"public virtual async Task<ActionResult> DeleteRefTo{navigationName}" +
            $"({GetPrimaryKeysRoute(entity, solution)}, {GetPrimaryKeysRoute(relatedEntity, solution, "relatedKey")})");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"throw new Nox.Exceptions.BadRequestException(ModelState);");
        code.EndBlock();
        code.AppendLine();
        code.AppendLine($"var deletedRef = await _mediator.Send(new DeleteRef{entity.Name}To{navigationName}Command(" +
            $"new {entity.Name}KeyDto({GetPrimaryKeysQuery(entity)}), new {relatedEntity.Name}KeyDto({GetPrimaryKeysQuery(relatedEntity, "relatedKey")})));");
        code.AppendLine();

        code.AppendLine($"return NoContent();");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateDeleteAllRefTo(Entity entity, EntityRelationship relationship, CodeBuilder code, NoxSolution solution, bool hideEndPointFromSwagger)
    {
        if (relationship.Relationship == EntityRelationshipType.ExactlyOne ||
            relationship.Relationship == EntityRelationshipType.OneOrMany)
            return;

        var navigationName = entity.GetNavigationPropertyName(relationship);
        if (hideEndPointFromSwagger)
            code.AppendLine("[ApiExplorerSettings(IgnoreApi = true)]");
        code.AppendLine($"public virtual async Task<ActionResult> DeleteRefTo{navigationName}({GetPrimaryKeysRoute(entity, solution)})");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"throw new Nox.Exceptions.BadRequestException(ModelState);");
        code.EndBlock();
        code.AppendLine();

        code.AppendLine($"var deletedAllRef = await _mediator.Send(new DeleteAllRef{entity.Name}To{navigationName}Command(" +
            $"new {entity.Name}KeyDto({GetPrimaryKeysQuery(entity)})));");
        code.AppendLine();

        code.AppendLine($"return NoContent();");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateGetRefTo(Entity entity, EntityRelationship relationship, CodeBuilder code, NoxSolution solution, bool hideEndPointFromSwagger)
    {
        var relatedEntity = relationship.Related.Entity;
        var navigationName = entity.GetNavigationPropertyName(relationship);
        if (hideEndPointFromSwagger)
            code.AppendLine("[ApiExplorerSettings(IgnoreApi = true)]");
        code.AppendLine($"public virtual async Task<ActionResult> GetRefTo{navigationName}" +
            $"({GetPrimaryKeysRoute(entity, solution)})");

        code.StartBlock();
        code.AppendLine($"var entity = (await _mediator.Send(new Get{entity.Name}ByIdQuery({GetPrimaryKeysQuery(entity)})))" +
            $".Include(x => x.{navigationName}).SingleOrDefault();");
        code.AppendLine($"if (entity is null)");
        code.StartBlock();
        code.AppendLine($"throw new EntityNotFoundException(\"{entity.Name}\", $\"{GetPrimaryKeysToString(entity)}\");");
        code.EndBlock();
        code.AppendLine();

        if (relationship.WithSingleEntity())
        {
            code.AppendLine(@$"if (entity.{navigationName} is null)
        {{
            return Ok();
        }}");
            code.AppendLine($"var references = new System.Uri(" +
                    $"$\"{relatedEntity.PluralName}/{PrimaryKeysAttribute(relatedEntity, $"entity.{navigationName}.", true)}\", UriKind.Relative);");
        }
        else
        {
            code.AppendLine($"IList<System.Uri> references = new List<System.Uri>();");
            code.AppendLine($"foreach (var item in entity.{navigationName})");
            code.StartBlock();
            code.AppendLine($"references.Add(new System.Uri(" +
                    $"$\"{relatedEntity.PluralName}/{PrimaryKeysAttribute(relatedEntity, "item.", true)}\", UriKind.Relative));");
            code.EndBlock();
        }

        code.AppendLine($"return Ok(references);");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateRelatedGet(NoxSolution solution, EntityRelationship relationship, Entity entity, CodeBuilder code, bool hideEndPointFromSwagger)
    {
        var relatedEntity = relationship.Related.Entity;
        var navigationName = entity.GetNavigationPropertyName(relationship);
        var isSingleRelationship = relationship.WithSingleEntity();
        if (hideEndPointFromSwagger)
            code.AppendLine("[ApiExplorerSettings(IgnoreApi = true)]");
        code.AppendLine($"[EnableQuery]");
        if (isSingleRelationship)
        {
            code.AppendLine($"public virtual async Task<SingleResult<{relatedEntity.Name}Dto>> Get{navigationName}(" +
                $"{GetPrimaryKeysRoute(entity, solution, attributePrefix: "")})");
            code.StartBlock();
            code.AppendLine($"var query = await _mediator.Send(new Get{entity.Name}ByIdQuery({GetPrimaryKeysQuery(entity)}));");
            code.AppendLine($"if (!query.Any())");
            code.StartBlock();
            code.AppendLine($"return SingleResult.Create<{relatedEntity.Name}Dto>(Enumerable.Empty<{relatedEntity.Name}Dto>().AsQueryable());");
            code.EndBlock();
            code.AppendLine($"return SingleResult.Create(query.Where(x => x.{navigationName} != null).Select(x => x.{navigationName}!));");
        }
        else
        {
            code.AppendLine($"public virtual async Task<ActionResult<IQueryable<{relatedEntity.Name}Dto>>> Get{navigationName}(" +
                $"{GetPrimaryKeysRoute(entity, solution, attributePrefix: "")})");
            code.StartBlock();
            code.AppendLine($"var query = await _mediator.Send(new Get{entity.Name}ByIdQuery({GetPrimaryKeysQuery(entity)}));");
            code.AppendLine($"if (!query.Any())");
            code.StartBlock();
            code.AppendLine($"throw new EntityNotFoundException(\"{entity.Name}\", $\"{GetPrimaryKeysToString(entity)}\");");
            code.EndBlock();
            code.AppendLine($"return Ok(query.Include(x => x.{navigationName}).SelectMany(x => x.{navigationName}));");
        }

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateRelatedGetById(NoxSolution solution, EntityRelationship relationship, Entity entity, CodeBuilder code, bool hideEndPointFromSwagger)
    {
        if (relationship.WithSingleEntity)
            return;

        var relatedEntity = relationship.Related.Entity;
        var navigationName = entity.GetNavigationPropertyName(relationship);
        if (hideEndPointFromSwagger)
            code.AppendLine("[ApiExplorerSettings(IgnoreApi = true)]");
        code.AppendLine($"[EnableQuery]");
        code.AppendLine($"[HttpGet(\"{solution.Presentation.ApiConfiguration.ApiRoutePrefix}/{entity.PluralName}/{PrimaryKeysAttribute(entity)}/{navigationName}/{PrimaryKeysAttribute(relatedEntity, "relatedKey")}\")]");
        code.AppendLine($"public virtual async Task<SingleResult<{relatedEntity.Name}Dto>> Get{navigationName}NonConventional(" +
            $"{GetPrimaryKeysRoute(entity, solution, attributePrefix: "")}, " +
            $"{GetPrimaryKeysRoute(relatedEntity, solution, "relatedKey", "")})");
        code.StartBlock();

        var param = string.Join(" && ", relatedEntity.Keys.Select(k => $"x.{k.Name} == relatedKey{(relatedEntity.Keys.Count > 1 ? k.Name : "")}"));
        code.AppendLine($"var related = (await _mediator.Send(new Get{entity.Name}ByIdQuery({GetPrimaryKeysQuery(entity)})))" +
            $".SelectMany(x => x.{navigationName}).Where(x => {param});");
        code.AppendLine($"if (!related.Any())");
        code.StartBlock();
        code.AppendLine($"return SingleResult.Create<{relatedEntity.Name}Dto>(Enumerable.Empty<{relatedEntity.Name}Dto>().AsQueryable());");
        code.EndBlock();
        code.AppendLine($"return SingleResult.Create(related);");


        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateRelatedPost(NoxSolution solution, EntityRelationship relationship, Entity entity, CodeBuilder code, bool hideEndPointFromSwagger)
    {
        var relatedEntity = relationship.Related.Entity;
        var reversedRelationship = relationship.Related.EntityRelationship;
        var reversednavigationName = relationship.Related.Entity.GetNavigationPropertyName(reversedRelationship);

        //Only Single Keys entities are supported
        if (entity.HasCompositeKey || relatedEntity.HasCompositeKey)
            return;
        if (hideEndPointFromSwagger)
            code.AppendLine("[ApiExplorerSettings(IgnoreApi = true)]");
        code.AppendLine($"public virtual async Task<ActionResult> PostTo{entity.GetNavigationPropertyName(relationship)}" +
            $"({GetPrimaryKeysRoute(entity, solution)}, [FromBody] {relatedEntity.Name}CreateDto {relatedEntity.Name.ToLowerFirstChar()})");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"throw new Nox.Exceptions.BadRequestException(ModelState);");
        code.EndBlock();
        code.AppendLine();

        if (reversedRelationship.WithSingleEntity())
            code.AppendLine($"{relatedEntity.Name.ToLowerFirstChar()}.{reversednavigationName}Id = key;");
        else
            code.AppendLine($"{relatedEntity.Name.ToLowerFirstChar()}.{reversednavigationName}Id = " +
                $"new List<{solution.GetSinglePrimitiveTypeForKey(entity.Keys[0])}> {{ key }};");
        code.AppendLine($"var createdKey = await _mediator.Send(new Create{relatedEntity.Name}Command({relatedEntity.Name.ToLowerFirstChar()}, _cultureCode));");
        code.AppendLine();
        code.AppendLine($"var createdItem = (await _mediator.Send(new Get{relatedEntity.Name}ByIdQuery(createdKey.key{relatedEntity.Keys[0].Name}))).SingleOrDefault();");
        code.AppendLine();
        code.AppendLine($"return Created(createdItem);");

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateRelatedPut(NoxSolution solution, EntityRelationship relationship, Entity entity, CodeBuilder code, bool hideEndPointFromSwagger)
    {
        var relatedEntity = relationship.Related.Entity;
        var navigationName = entity.GetNavigationPropertyName(relationship);
        var isSingleRelationship = relationship.WithSingleEntity();
        if (hideEndPointFromSwagger)
            code.AppendLine("[ApiExplorerSettings(IgnoreApi = true)]");
        if (isSingleRelationship)
        {
            code.AppendLine($"public virtual async Task<ActionResult<{relatedEntity.Name}Dto>> PutTo{navigationName}(" +
                $"{GetPrimaryKeysRoute(entity, solution, attributePrefix: "")}, " +
                $"[FromBody] {relatedEntity.Name}UpdateDto {relatedEntity.Name.ToLowerFirstChar()})");
        }
        else
        {
            code.AppendLine($"[HttpPut(\"{solution.Presentation.ApiConfiguration.ApiRoutePrefix}/{entity.PluralName}/{PrimaryKeysAttribute(entity)}/{navigationName}/{PrimaryKeysAttribute(relatedEntity, "relatedKey")}\")]");
            code.AppendLine($"public virtual async Task<ActionResult<{relatedEntity.Name}Dto>> PutTo{navigationName}NonConventional(" +
                $"{GetPrimaryKeysRoute(entity, solution, attributePrefix: "")}, " +
                $"{GetPrimaryKeysRoute(relatedEntity, solution, "relatedKey", "")}, " +
                $"[FromBody] {relatedEntity.Name}UpdateDto {relatedEntity.Name.ToLowerFirstChar()})");
        }

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"throw new Nox.Exceptions.BadRequestException(ModelState);");
        code.EndBlock();
        code.AppendLine();

        if (isSingleRelationship)
        {
            code.AppendLine($"var related = (await _mediator.Send(new Get{entity.Name}ByIdQuery({GetPrimaryKeysQuery(entity)})))" +
                $".Select(x => x.{navigationName}).SingleOrDefault();");
            code.AppendLine($"if (related == null)");
            code.StartBlock();
            code.AppendLine($"throw new EntityNotFoundException(\"{navigationName}\", String.Empty);");
            code.EndBlock();
        }
        else
        {
            var param = string.Join(" && ", relatedEntity.Keys.Select(k => $"x.{k.Name} == relatedKey{(relatedEntity.Keys.Count > 1 ? k.Name : "")}"));
            code.AppendLine($"var related = (await _mediator.Send(new Get{entity.Name}ByIdQuery({GetPrimaryKeysQuery(entity)})))" +
                $".SelectMany(x => x.{navigationName}).Any(x => {param});");
            code.AppendLine($"if (!related)");
            code.StartBlock();
            code.AppendLine($"throw new EntityNotFoundException(\"{navigationName}\", $\"{GetPrimaryKeysToString(relatedEntity, "relatedKey")}\");");
            code.EndBlock();
        }
        code.AppendLine();
        code.AppendLine("var etag = Request.GetDecodedEtagHeader();");
        var relatedKeyQuery = isSingleRelationship ?
            $"{GetPrimaryKeysQuery(relatedEntity, "related.", true)}" :
            $"{GetPrimaryKeysQuery(relatedEntity, "relatedKey")}";
        code.AppendLine($"var updated = await _mediator.Send(new Update{relatedEntity.Name}Command({relatedKeyQuery}, " +
            $"{relatedEntity.Name.ToLowerFirstChar()}, _cultureCode, etag));");
        code.AppendLine();
        code.AppendLine($"var updatedItem = (await _mediator.Send(new Get{relatedEntity.Name}ByIdQuery(updated.key{relatedEntity.Keys[0].Name}))).SingleOrDefault();");
        code.AppendLine();
        code.AppendLine($"return Ok(updatedItem);");

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateRelatedPatch(NoxSolution solution, EntityRelationship relationship, Entity entity, CodeBuilder code, bool hideEndPointFromSwagger)
    {
        var relatedEntity = relationship.Related.Entity;
        var navigationName = entity.GetNavigationPropertyName(relationship);
        var isSingleRelationship = relationship.WithSingleEntity();
        if (hideEndPointFromSwagger)
            code.AppendLine("[ApiExplorerSettings(IgnoreApi = true)]");
        if (isSingleRelationship)
        {
            code.AppendLine($"public virtual async Task<ActionResult<{relatedEntity.Name}Dto>> PatchTo{navigationName}(" +
                $"{GetPrimaryKeysRoute(entity, solution, attributePrefix: "")}, " +
                $"[FromBody] Delta<{relatedEntity.Name}PartialUpdateDto> {relatedEntity.Name.ToLowerFirstChar()})");
        }
        else
        {
            code.AppendLine($"[HttpPatch(\"{solution.Presentation.ApiConfiguration.ApiRoutePrefix}/{entity.PluralName}/{PrimaryKeysAttribute(entity)}/{navigationName}/{PrimaryKeysAttribute(relatedEntity, "relatedKey")}\")]");
            code.AppendLine($"public virtual async Task<ActionResult<{relatedEntity.Name}Dto>> Patchto{navigationName}NonConventional(" +
                $"{GetPrimaryKeysRoute(entity, solution, attributePrefix: "")}, " +
                $"{GetPrimaryKeysRoute(relatedEntity, solution, "relatedKey", "")}, " +
                $"[FromBody] Delta<{relatedEntity.Name}PartialUpdateDto> {relatedEntity.Name.ToLowerFirstChar()})");
        }

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid || {relatedEntity.Name.ToLowerFirstChar()} is null)");
        code.StartBlock();
        code.AppendLine($"throw new Nox.Exceptions.BadRequestException(ModelState);");
        code.EndBlock();
        code.AppendLine();

        if (isSingleRelationship)
        {
            code.AppendLine($"var related = (await _mediator.Send(new Get{entity.Name}ByIdQuery({GetPrimaryKeysQuery(entity)})))" +
                $".Select(x => x.{navigationName}).SingleOrDefault();");
            code.AppendLine($"if (related == null)");
            code.StartBlock();
            code.AppendLine($"throw new EntityNotFoundException(\"{navigationName}\", String.Empty);");
            code.EndBlock();
        }
        else
        {
            var param = string.Join(" && ", relatedEntity.Keys.Select(k => $"x.{k.Name} == relatedKey{(relatedEntity.Keys.Count > 1 ? k.Name : "")}"));
            code.AppendLine($"var related = (await _mediator.Send(new Get{entity.Name}ByIdQuery({GetPrimaryKeysQuery(entity)})))" +
                $".SelectMany(x => x.{navigationName}).Any(x => {param});");
            code.AppendLine($"if (!related)");
            code.StartBlock();
            code.AppendLine($"throw new EntityNotFoundException(\"{navigationName}\", $\"{GetPrimaryKeysToString(relatedEntity, "relatedKey")}\");");
            code.EndBlock();
        }

        code.AppendLine();
        code.AppendLine($"var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<{relatedEntity.Name}PartialUpdateDto>({relatedEntity.Name.ToLowerFirstChar()});");
        code.AppendLine();
        code.AppendLine("var etag = Request.GetDecodedEtagHeader();");
        var relatedKeyQuery = isSingleRelationship ?
            $"{GetPrimaryKeysQuery(relatedEntity, "related.", true)}" :
            $"{GetPrimaryKeysQuery(relatedEntity, "relatedKey")}";
        code.AppendLine($"var updated = await _mediator.Send(new PartialUpdate{relatedEntity.Name}Command({relatedKeyQuery}, " +
            $"updatedProperties, _cultureCode, etag));");
        code.AppendLine();
        code.AppendLine($"var updatedItem = (await _mediator.Send(new Get{relatedEntity.Name}ByIdQuery(updated.key{relatedEntity.Keys[0].Name}))).SingleOrDefault();");
        code.AppendLine();
        code.AppendLine($"return Ok(updatedItem);");

        // End method
        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateRelatedDelete(NoxSolution solution, EntityRelationship relationship, Entity entity, CodeBuilder code, bool hideEndPointFromSwagger)
    {
        if (relationship.WithSingleEntity)
            return;

        var relatedEntity = relationship.Related.Entity;
        var navigationName = entity.GetNavigationPropertyName(relationship);
        if (hideEndPointFromSwagger)
            code.AppendLine("[ApiExplorerSettings(IgnoreApi = true)]");
        code.AppendLine($"[HttpDelete(\"{solution.Presentation.ApiConfiguration.ApiRoutePrefix}/{entity.PluralName}/{PrimaryKeysAttribute(entity)}/{navigationName}/{PrimaryKeysAttribute(relatedEntity, "relatedKey")}\")]");
        code.AppendLine($"public virtual async Task<ActionResult> DeleteTo{navigationName}" +
            $"({GetPrimaryKeysRoute(entity, solution)}, {GetPrimaryKeysRoute(relatedEntity, solution, "relatedKey")})");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"throw new Nox.Exceptions.BadRequestException(ModelState);");
        code.EndBlock();
        code.AppendLine();

        var param = string.Join(" && ", relatedEntity.Keys.Select(k => $"x.{k.Name} == relatedKey{(relatedEntity.Keys.Count > 1 ? k.Name : "")}"));
        code.AppendLine($"var related = (await _mediator.Send(new Get{entity.Name}ByIdQuery({GetPrimaryKeysQuery(entity)})))" +
            $".SelectMany(x => x.{navigationName})" +
            $".Any(x => {param});");
        code.AppendLine($"if (!related)");
        code.StartBlock();
        code.AppendLine($"throw new EntityNotFoundException(\"{navigationName}\", $\"{GetPrimaryKeysToString(relatedEntity, "relatedKey")}\");");
        code.EndBlock();
        code.AppendLine();
        var relatedKeyQuery = $"{GetPrimaryKeysQuery(relatedEntity, "relatedKey")}";
        code.AppendLine($"var etag = Request.GetDecodedEtagHeader();");
        code.AppendLine($"var deleted = await _mediator.Send(new Delete{relatedEntity.Name}ByIdCommand(" +
            $"new List<{relatedEntity.Name}KeyDto> {{ new {relatedEntity.Name}KeyDto({relatedKeyQuery}) }}, " +
            $"etag));");
        code.AppendLine();
        code.AppendLine($"return NoContent();");

        code.EndBlock();
        code.AppendLine();
    }

    private static void GenerateRelatedDeleteAll(NoxSolution solution, EntityRelationship relationship, Entity entity, CodeBuilder code, bool hideEndPointFromSwagger)
    {
        if (relationship.Relationship == EntityRelationshipType.ExactlyOne ||
            relationship.Relationship == EntityRelationshipType.OneOrMany)
            return;

        var relatedEntity = relationship.Related.Entity;
        var navigationName = entity.GetNavigationPropertyName(relationship);
        if (hideEndPointFromSwagger)
            code.AppendLine("[ApiExplorerSettings(IgnoreApi = true)]");
        code.AppendLine($"[HttpDelete(\"{solution.Presentation.ApiConfiguration.ApiRoutePrefix}/{entity.PluralName}/{PrimaryKeysAttribute(entity)}/{navigationName}\")]");
        code.AppendLine($"public virtual async Task<ActionResult> DeleteTo{navigationName}({GetPrimaryKeysRoute(entity, solution)})");

        code.StartBlock();
        code.AppendLine($"if (!ModelState.IsValid)");
        code.StartBlock();
        code.AppendLine($"throw new Nox.Exceptions.BadRequestException(ModelState);");
        code.EndBlock();
        code.AppendLine();

        code.AppendLine($"var related = (await _mediator.Send(new Get{entity.Name}ByIdQuery({GetPrimaryKeysQuery(entity)})))" +
            $".Select(x => x.{navigationName}).SingleOrDefault();");
        code.AppendLine($"if (related == null)");
        code.StartBlock();
        code.AppendLine($"throw new EntityNotFoundException(\"{entity.Name}\", $\"{GetPrimaryKeysToString(entity)}\");");
        code.EndBlock();
        code.AppendLine();

        code.AppendLine($"var etag = Request.GetDecodedEtagHeader();");
        if (relationship.WithSingleEntity)
        {
            code.AppendLine($"var deleted = await _mediator.Send(new Delete{relatedEntity.Name}ByIdCommand(" +
                $"new List<{relatedEntity.Name}KeyDto> {{ new {relatedEntity.Name}KeyDto({GetPrimaryKeysQuery(relatedEntity, "related.", true)}) }}, " +
                $"etag));");
        }
        else
            code.AppendLine($"await _mediator.Send(new Delete{relatedEntity.Name}ByIdCommand(" +
                $"related.Select(item => new {relatedEntity.Name}KeyDto({GetPrimaryKeysQuery(relatedEntity, "item.", true)})), " +
                $"etag));");

        code.AppendLine($"return NoContent();");
        code.EndBlock();
        code.AppendLine();
    }

    private static string PrimaryKeysAttribute(Entity entity, string prefix = "key", bool withKeyName = false)
    {
        if (entity.Keys.Count() > 1)
            return string.Join(",", entity.Keys.Select(k => $"{k.Name}={{{prefix}{k.Name}}}"));
        else if (entity.Keys is not null)
            return withKeyName ? $"{{{prefix}{entity.Keys[0].Name}}}" : $"{{{prefix}}}";

        return "";
    }

    private static bool CanRead(Entity entity) => entity.Persistence?.Read?.IsEnabled ?? true;

    private static bool CanCreate(Entity entity) => entity.Persistence?.Create?.IsEnabled ?? true;

    private static bool CanUpdate(Entity entity) => entity.Persistence?.Update?.IsEnabled ?? true;

    private static bool CanDelete(Entity entity) => entity.Persistence?.Delete?.IsEnabled ?? true;
}