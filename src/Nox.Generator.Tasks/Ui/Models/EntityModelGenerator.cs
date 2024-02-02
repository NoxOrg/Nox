using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types.Extensions;
using System.Linq;

namespace Nox.Generator.Tasks.Ui.Pages;

internal class EntityModelGenerator : INoxFileGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Ui;

    public void Generate(
      NoxCodeGenConventions codeGeneratorState,
      GeneratorConfig config,
      System.Action<string> log,
      string absoluteOutputPath
      )
    {
        if (codeGeneratorState.Solution.Domain is null)
        {
            return;
        }

        var templateName = @"Tasks.Ui.Models.EntityModel";
        var entities = codeGeneratorState.Solution.Domain.Entities
            .Where(e => !e.IsOwnedEntity);

        foreach (var entity in entities)
        {
            var componentsInfo = entity.Attributes
               .ToDictionary(r => r.Name, key => new {
                   ComponentType = key.Type.GetComponents(key).FirstOrDefault().Value
               });

            new TaskTemplateFileBuilder(codeGeneratorState, absoluteOutputPath)
                .WithClassName($"{entity.Name}Model")
                .WithFileNamePrefix($"Ui.Models")
                .WithObject("entity", entity)
                .WithObject("componentsInfo", componentsInfo)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}