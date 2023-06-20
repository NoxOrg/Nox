using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Solution;
using System.Linq;
using System.Text;

namespace Nox.Generator;

internal static class ODataApiGenerator
{
    public static void Generate(SourceProductionContext context, string solutionNameSpace, NoxSolution solution)
    {
        if (solution.Domain is null ||
            !solution.Domain.Entities.Any())
        {
            return;
        }

        var code = new CodeBuilder();

        foreach (var entity in solution.Domain.Entities)
        {
            var entityName = entity.Name;
            var pluralName = entity.PluralName;
            var variableName = entity.Name.ToLower();
            var dbContextName = $"{solution.Name}DbContext";
            var controllerName = $"{pluralName}Controller";
            var persistenceNotSpecified = entity.Persistence == null;

            context.CancellationToken.ThrowIfCancellationRequested();
            code.AppendLine($"// Generated");
            code.AppendLine();

            // Namespace
            code.AppendLine($"using System.Linq;");
            code.AppendLine($"using System.Web.Http;");
            code.AppendLine($"using Microsoft.AspNet.OData;");
            code.AppendLine($"using SampleService.Domain;");
            code.AppendLine($"using System.Threading.Tasks;"); 
            code.AppendLine($"using System.Net;");
            code.AppendLine($"using Microsoft.EntityFrameworkCore;");
            code.AppendLine();
            code.AppendLine($"namespace {solutionNameSpace}.Presentation.Api.OData;");
            code.AppendLine();

            code.AppendLine($"public class {controllerName} : ODataController");

            // Class
            code.StartBlock();
                // db context
                code.AppendLine($"{dbContextName} _databaseContext = new {dbContextName}();\r\n");

                // Constructor
                // Method Get
                code.AppendLine($"public {controllerName}({dbContextName} databaseContext)");

                // Method content
                code.StartBlock();
                    code.AppendLine($"_databaseContext = databaseContext;");

                // End method
                code.EndBlock();
                code.AppendLine();

            
                if (persistenceNotSpecified ||
                    entity.Persistence.Read.IsEnabled)
                {
                    // Method Get
                    code.AppendLine($"[EnableQuery]");
                    code.AppendLine($"public IQueryable<{entityName}> Get()");

                    // Method content
                    code.StartBlock();
                        code.AppendLine($"return _databaseContext.{pluralName};");

                    // End method
                    code.EndBlock();
                    code.AppendLine();
            
                    // Method Get
                    code.AppendLine($"[EnableQuery]");
                    code.AppendLine($"public SingleResult<{entityName}> Get([FromODataUri] int key)");

                    // Method content
                    code.StartBlock();
                        code.AppendLine($"IQueryable<{entityName}> result = _databaseContext.{pluralName}.Where(p => p.Id == key);");
                        code.AppendLine($"return SingleResult.Create(result);");

                    // End method
                    code.EndBlock();
                    code.AppendLine();
                }
            
                if (persistenceNotSpecified || 
                    entity.Persistence.Create.IsEnabled)
                {
                    // Method Post
                    code.AppendLine($"public async Task<IHttpActionResult> Post({entityName} {variableName})");

                    // Method content
                    code.StartBlock();
                        code.AppendLine($"if (!ModelState.IsValid)");
                        code.StartBlock();
                            code.AppendLine($"return BadRequest(ModelState);");
                        code.EndBlock();
                        code.AppendLine();
                        code.AppendLine($"_databaseContext.{pluralName}.Add({variableName});");
                        code.AppendLine($"await _databaseContext.SaveChangesAsync();");
                        code.AppendLine($"return Created({variableName});");

                    // End method
                    code.EndBlock();
                    code.AppendLine();
                }
            
                if (persistenceNotSpecified || 
                    entity.Persistence.Update.IsEnabled)
                {
                    // Method Patch
                    code.AppendLine($"public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<{entityName}> {variableName})");

                    // Method content
                    code.StartBlock();
                        code.AppendLine($"if (!ModelState.IsValid)");
                        code.StartBlock();
                            code.AppendLine($"return BadRequest(ModelState);");
                        code.EndBlock();
                        code.AppendLine();
                        code.AppendLine($"var entity = await _databaseContext.{pluralName}.FindAsync(key);");
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

                    // Method Put
                    code.AppendLine($"public async Task<IHttpActionResult> Put([FromODataUri] int key, {entityName} update)");

                    // Method content
                    code.StartBlock();
                        code.AppendLine($"if (!ModelState.IsValid)");
                        code.StartBlock();
                            code.AppendLine($"return BadRequest(ModelState);");
                        code.EndBlock();
                        code.AppendLine();
                        code.AppendLine($"if (key != update.Id)");
                        code.StartBlock();
                            code.AppendLine($"return BadRequest();");
                        code.EndBlock();
                        code.AppendLine($"_databaseContext.Entry(update).State = EntityState.Modified;");
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
                        code.AppendLine($"return Updated(update);");

                    // End method
                    code.EndBlock();
                    code.AppendLine();
                
                    // Method Exists
                    code.AppendLine($"private bool {entityName}Exists(int key)");

                    // Method content
                    code.StartBlock();
                        code.AppendLine($"return _databaseContext.{pluralName}.Any(p => p.Id == key);");

                    // End method
                    code.EndBlock();
                    code.AppendLine();
                }
            
                if (persistenceNotSpecified || 
                    entity.Persistence.Delete.IsEnabled)
                {
                    // Method Delete
                    code.AppendLine($"public async Task<IHttpActionResult> Delete([FromODataUri] int key)");

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
                        code.AppendLine($"return StatusCode(HttpStatusCode.NoContent);");

                    // End method
                    code.EndBlock();
                    code.AppendLine();
                }
                
                // Method Dispose
                code.AppendLine($"protected override void Dispose(bool disposing)");

                // Method content
                code.StartBlock();
                    code.AppendLine($"_databaseContext.Dispose();");
                    code.AppendLine($"base.Dispose(disposing);");

                // End method
                code.EndBlock();
            // End class
            code.EndBlock();

            context.AddSource($"Controllers/{pluralName}Controller.cs", SourceText.From(code.ToString(), Encoding.UTF8));
            code = new CodeBuilder();
        }
    }
}
