using Nox.Generator.Common;
using Nox.Solution;
using System.Linq;

namespace Nox.Generator.Tasks.Ui.Components;

internal class EntityServiceGenerator : INoxFileGenerator
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

        var templateName = @"Tasks.Ui.Services.EntityService";
        var entities = codeGeneratorState.Solution.Domain.Entities
            .Where(e => !e.IsOwnedEntity)
            .OrderBy(e => e.PluralName);

        foreach (var entity in entities)
        {
            var attributesByOrder = entity.Attributes
                .Where(a => a.UserInterface?.CanSort == true)
                .Select(a => a.Name);

            var attributesBySearchMainTypeEqual = entity.Attributes
                .Where(a => a.UserInterface?.CanSearch == true && 
                (a.Type == Types.NoxType.AutoNumber 
                || a.Type == Types.NoxType.Number
                || a.Type == Types.NoxType.Guid))                
                .Select(a => a.Name);

            var attributesBySearchMainTypeContains = entity.Attributes
                .Where(a => a.UserInterface?.CanSearch == true &&
                (a.Type != Types.NoxType.AutoNumber
                || a.Type != Types.NoxType.Number
                || a.Type != Types.NoxType.Guid))
                .Select(a => a.Name);

            var attributesBySearchFilterTypeEqual = entity.Attributes
                .Where(a => a.UserInterface?.CanFilter == true &&
                (a.Type == Types.NoxType.AutoNumber
                || a.Type == Types.NoxType.Number
                || a.Type == Types.NoxType.Guid))
                .Select(a => a.Name);

            var attributesBySearchFilterTypeContains = entity.Attributes
                .Where(a => a.UserInterface?.CanFilter == true &&
                (a.Type != Types.NoxType.AutoNumber
                || a.Type != Types.NoxType.Number
                || a.Type != Types.NoxType.Guid))
                .Select(a => a.Name);

            var attributesByViewTypeAlways = entity.Attributes
                .Where(a => a.UserInterface?.ShowInSearchResults == ShowInSearchResultsOption.Always)
                .Select(a => a.Name);

            var attributesByViewTypeNever = entity.Attributes
                .Where(a => a.UserInterface?.ShowInSearchResults == ShowInSearchResultsOption.Never)
                .Select(a => a.Name);

            var attributesByViewTypeOptionalOff = entity.Attributes
                .Where(a => a.UserInterface?.ShowInSearchResults == ShowInSearchResultsOption.OptionalAndOffByDefault)
                .Select(a => a.Name);

            var attributesByViewTypeOptionalOn = entity.Attributes
                .Where(a => a.UserInterface?.ShowInSearchResults == ShowInSearchResultsOption.OptionalAndOnByDefault)
                .Select(a => a.Name);

            new TaskTemplateFileBuilder(codeGeneratorState, absoluteOutputPath)
                .WithClassName($"{entity.PluralName}Service")
                .WithFileNamePrefix($"Ui.Services")
                .WithObject("entity", entity)
                .WithObject("attributesByOrder", attributesByOrder)
                .WithObject("attributesBySearchMainTypeEqual", attributesBySearchMainTypeEqual)
                .WithObject("attributesBySearchMainTypeContains", attributesBySearchMainTypeContains)
                .WithObject("attributesBySearchFilterTypeEqual", attributesBySearchFilterTypeEqual)
                .WithObject("attributesBySearchFilterTypeContains", attributesBySearchFilterTypeContains)
                .WithObject("attributesByViewTypeAlways", attributesByViewTypeAlways)
                .WithObject("attributesByViewTypeNever", attributesByViewTypeNever)
                .WithObject("attributesByViewTypeOptionalOff", attributesByViewTypeOptionalOff)
                .WithObject("attributesByViewTypeOptionalOn", attributesByViewTypeOptionalOn)
                .GenerateSourceCodeFromResource(templateName);
        }
    }
}