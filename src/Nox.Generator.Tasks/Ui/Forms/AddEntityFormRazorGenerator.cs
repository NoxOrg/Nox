using Nox.Generator.Common;
using Nox.Solution;
using Nox.Types;
using Nox.Types.Extensions;
using System.Linq;

namespace Nox.Generator.Tasks.Ui.Forms;

internal class AddEntityFormRazorGenerator : INoxFileGenerator
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

        var templateName = @"Tasks.Ui.Forms.AddEntityFormRazor";
        var entities = codeGeneratorState.Solution.Domain.Entities
            .Where(e => !e.IsOwnedEntity && e.Persistence.Create.IsEnabled);

        foreach (var entity in entities)
        {
            var componentsInfo = entity.Attributes
               .ToDictionary(r => r.Name, key => new {
                   ComponentType = key.Type.GetComponents(key).FirstOrDefault().Value
               });

            var attributesWithTypeOptions = entity.Attributes.Where(a => HasTypeOptions(a)).Select(a => a.Name);

            new TaskTemplateFileBuilder(codeGeneratorState, absoluteOutputPath)
                .WithFileExtension("razor")
                .WithClassName($"Add{entity.Name}Form")
                .WithFileNamePrefix($"Ui.Forms.Add")
                .WithObject("entity", entity)
                .WithObject("componentsInfo", componentsInfo)
                .WithObject("attributesWithTypeOptions", attributesWithTypeOptions)
                .GenerateSourceCodeFromResource(templateName);
        }
    }

    private bool HasTypeOptions(NoxSimpleTypeDefinition attribute)
    {
        var typeOptionsName = $"{attribute.Type}TypeOptions";
        var propertyInfo = typeof(NoxSimpleTypeDefinition).GetProperty(typeOptionsName);
        if (propertyInfo is null) return false;

        object propertyValue = propertyInfo.GetValue(attribute);
        return propertyValue is not null;
    }
}