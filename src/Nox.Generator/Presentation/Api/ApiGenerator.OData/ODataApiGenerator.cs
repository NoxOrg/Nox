using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Solution;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.ModelBinding;
using System.Web.Http;

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

            code.AppendLine($"public class {pluralName}Controller : ODataController");

            // Class
            code.StartBlock();
                // Db context
                code.AppendLine($"ProductsContext db = new ProductsContext();\r\n");
            
                // Method Get
                code.AppendLine($"[EnableQuery]");
                code.AppendLine($"public IQueryable<{entityName}> Get()");

                // Method content
                code.StartBlock();
                    code.AppendLine($"return db.{pluralName};");

                // End method
                code.EndBlock();
                code.AppendLine();
            
                // Method Get
                code.AppendLine($"[EnableQuery]");
                code.AppendLine($"public SingleResult<{entityName}> Get([FromODataUri] int key)");

                // Method content
                code.StartBlock();
                    code.AppendLine($"IQueryable<{entityName}> result = db.{pluralName}.Where(p => p.Id == key);");
                    code.AppendLine($"return SingleResult.Create(result);");

                // End method
                code.EndBlock();
                code.AppendLine();
            
                // Method Post
                code.AppendLine($"public async Task<IHttpActionResult> Post({entityName} {variableName})");

                // Method content
                code.StartBlock();
                    code.AppendLine($"if (!ModelState.IsValid)");
                    code.StartBlock();
                        code.AppendLine($"return BadRequest(ModelState);");
                    code.EndBlock();
                    code.AppendLine();
                    code.AppendLine($"db.{pluralName}.Add({variableName});");
                    code.AppendLine($"await db.SaveChangesAsync();");
                    code.AppendLine($"return Created({variableName});");

                // End method
                code.EndBlock();
                code.AppendLine();
            
                // Method Patch
                code.AppendLine($"public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<{entityName}> {variableName})");

                // Method content
                code.StartBlock();
                    code.AppendLine($"if (!ModelState.IsValid)");
                    code.StartBlock();
                        code.AppendLine($"return BadRequest(ModelState);");
                    code.EndBlock();
                    code.AppendLine();
                    code.AppendLine($"var entity = await db.{pluralName}.FindAsync(key);");
                    code.AppendLine($"if (entity == null)");
                    code.StartBlock();
                        code.AppendLine($"return NotFound();");
                    code.EndBlock();
                    code.AppendLine($"{variableName}.Patch(entity);");
                    code.AppendLine($"try");
                    code.StartBlock();
                        code.AppendLine($"await db.SaveChangesAsync();");
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
            
                // Method Patch
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
                    code.AppendLine($"db.Entry(update).State = EntityState.Modified;");
                    code.AppendLine($"try");
                    code.StartBlock();
                        code.AppendLine($"await db.SaveChangesAsync();");
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
            
                // Method Delete
                code.AppendLine($"public async Task<IHttpActionResult> Delete([FromODataUri] int key)");

                // Method content
                code.StartBlock();
                    code.AppendLine($"var {variableName} = await db.{pluralName}.FindAsync(key);");
                    code.AppendLine($"if ({variableName} == null)");
                    code.StartBlock();
                        code.AppendLine($"return NotFound();");
                    code.EndBlock();
                    code.AppendLine();
                    code.AppendLine($"db.{pluralName}.Remove({variableName});");
                    code.AppendLine($"await db.SaveChangesAsync();");
                    code.AppendLine($"return StatusCode(HttpStatusCode.NoContent);");

                // End method
                code.EndBlock();
                code.AppendLine();
                
                // Method Exists
                code.AppendLine($"private bool {entityName}Exists(int key)");

                // Method content
                code.StartBlock();
                    code.AppendLine($"return db.{pluralName}.Any(p => p.Id == key);");

                // End method
                code.EndBlock();
                code.AppendLine();
                
                // Method Dispose
                code.AppendLine($"protected override void Dispose(bool disposing)");

                // Method content
                code.StartBlock();
                    code.AppendLine($"db.Dispose();");
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
