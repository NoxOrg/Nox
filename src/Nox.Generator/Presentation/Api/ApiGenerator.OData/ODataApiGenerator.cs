using Microsoft.CodeAnalysis;
using Nox.Solution;
using System.Linq;
using Nox.Generator.Common;

namespace Nox.Generator;

internal static class ODataApiGenerator
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
            var dbContextName = $"{solution.Name}DbContext";
            var controllerName = $"{pluralName}Controller";
            // TODO: fix composite key
            var keyType = entityName + "Id";
            var keyUnderlyingType = entity.Keys?.FirstOrDefault()?.Type;
            var parsingLogic = $"var parsedKey = {keyType}.From({keyUnderlyingType}.From(key));";
            if (!keyUnderlyingType.HasValue)
            {
                parsingLogic = $"var parsedKey = {keyType}.From(key);";
            }

            var code = new CodeBuilder($"{pluralName}Controller.g.cs",context);

            // Namespace
            code.AppendLine($"using Microsoft.AspNetCore.Mvc;");
            code.AppendLine($"using Microsoft.AspNetCore.OData.Deltas;");
            code.AppendLine($"using Microsoft.AspNetCore.OData.Query;");
            code.AppendLine($"using Microsoft.AspNetCore.OData.Routing.Controllers;");
            code.AppendLine($"using Microsoft.EntityFrameworkCore;");
            code.AppendLine($"using SampleWebApp.Domain;");
            code.AppendLine($"using SampleWebApp.Infrastructure.Persistence;");
            code.AppendLine($"using System.Net;");
            code.AppendLine($"using Nox.Types;");
            code.AppendLine();
            code.AppendLine($"namespace {solutionNameSpace}.Presentation.Api.OData;");
            code.AppendLine();

            code.AppendLine($"public class {controllerName} : ODataController");

            // Class
            code.StartBlock();
                // db context
                code.AppendLine($"{dbContextName} _databaseContext;\r\n");

                // Constructor
                code.AppendLine($"public {controllerName}({dbContextName} databaseContext)");

                // Method content
                code.StartBlock();
                    code.AppendLine($"_databaseContext = databaseContext;");

                // End method
                code.EndBlock();
                code.AppendLine();

            
                if (entity.Persistence is null ||
                    entity.Persistence.Read.IsEnabled)
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
                        code.AppendLine(parsingLogic);
                        code.AppendLine($"var item = _databaseContext.{pluralName}.SingleOrDefault(d => d.Id.Equals(parsedKey));");
                        code.AppendLine();
                        code.AppendLine($"if (item == null)");
                        code.StartBlock();
                            code.AppendLine($"return NotFound();");
                        code.EndBlock();
                        code.AppendLine($"return Ok(item);");

                    // End method
                    code.EndBlock();
                    code.AppendLine();
                }
            
                if (entity.Persistence is null || 
                    entity.Persistence.Create.IsEnabled)
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
            
                if (entity.Persistence is null || 
                    entity.Persistence.Update.IsEnabled)
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
                        code.AppendLine(parsingLogic);
                        code.AppendLine($"if (parsedKey != updated{entityName}.Id)");
                        code.StartBlock();
                            code.AppendLine($"return BadRequest();");
                        code.EndBlock();
                        code.AppendLine($"_databaseContext.Entry(updated{entityName}).State = EntityState.Modified;");
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
                        code.AppendLine($"return Updated(updated{entityName});");

                    // End method
                    code.EndBlock();
                    code.AppendLine();
                
                    // Method Patch
                    code.AppendLine($"public async Task<ActionResult> Patch([FromRoute] string key, [FromBody] Delta<{entityName}> {variableName})");

                    // Method content
                    code.StartBlock();
                        code.AppendLine($"if (!ModelState.IsValid)");
                        code.StartBlock();
                            code.AppendLine($"return BadRequest(ModelState);");
                        code.EndBlock();
                        code.AppendLine();
                        code.AppendLine(parsingLogic);
                        code.AppendLine($"var entity = await _databaseContext.{entity.PluralName}.FindAsync(parsedKey);");
                        code.AppendLine($"if (entity == null)");
                        code.StartBlock();
                            code.AppendLine($"return NotFound();");
                        code.EndBlock();
                        code.AppendLine($"{variableName}.Patch(entity);");
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
                        code.AppendLine($"return Updated(entity);");

                    // End method
                    code.EndBlock();
                    code.AppendLine();
                
                    // Method Exists
                    code.AppendLine($"private bool {entityName}Exists(string key)");

                    // Method content
                    code.StartBlock();
                        code.AppendLine(parsingLogic);
                        code.AppendLine($"return _databaseContext.{pluralName}.Any(p => p.Id == parsedKey);");

                    // End method
                    code.EndBlock();
                    code.AppendLine();
                }
            
                if (entity.Persistence is null || 
                    entity.Persistence.Delete.IsEnabled)
                {
                    // Method Delete
                    code.AppendLine($"public async Task<ActionResult> Delete([FromRoute] string key)");

                    // Method content
                    code.StartBlock();
                        code.AppendLine(parsingLogic);
                        code.AppendLine($"var {variableName} = await _databaseContext.{pluralName}.FindAsync(parsedKey);");
                        code.AppendLine($"if ({variableName} == null)");
                        code.StartBlock();
                            code.AppendLine($"return NotFound();");
                        code.EndBlock();
                        code.AppendLine();
                        code.AppendLine($"_databaseContext.{pluralName}.Remove({variableName});");
                        code.AppendLine($"await _databaseContext.SaveChangesAsync();");
                        code.AppendLine($"return StatusCode((int)HttpStatusCode.NoContent);");

                    // End method
                    code.EndBlock();
                }
            // End class
            code.EndBlock();

            code.GenerateSourceCode();
        }
    }
}
