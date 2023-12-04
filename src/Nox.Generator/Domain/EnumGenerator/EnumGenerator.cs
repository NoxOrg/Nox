using Microsoft.CodeAnalysis;

using Nox.Generator.Common;
using Nox.Solution;

using System.Linq;

namespace Nox.Generator.Domain.EnumGenerator;
internal class EnumGenerator : INoxCodeGenerator
{
    public NoxGeneratorKind GeneratorKind => NoxGeneratorKind.Domain;

    public void Generate(
        SourceProductionContext context,
        NoxCodeGenConventions codeGeneratorState,
        GeneratorConfig config,
        System.Action<string> log,
        string? projectRootPath
     )
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGeneratorState.Solution.Domain == null)
            return;

        foreach (var entity in codeGeneratorState.Solution.Domain.Entities.Where(x => x.Attributes.Any(x => x.Type == Types.NoxType.Enumeration)))
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            var enumAttributes = entity.Attributes.Where(attribute => attribute.Type == Types.NoxType.Enumeration
                    && attribute.EnumerationTypeOptions?.Values?.Any() == true)
                .Select(attribute => new
                {
                    Description = attribute.Description,
                    Name = attribute.Name,
                    Values = attribute.EnumerationTypeOptions!.Values.Select(value => new
                    {
                        Name = value.Name,
                        SanitizedName = codeGeneratorState.GetEnumPropertyName(value.Name),
                        Id = value.Id
                    })
                });

            new TemplateCodeBuilder(context, codeGeneratorState)
                    .WithClassName($"{entity.Name}Enums")
                    .WithFileNamePrefix($"Domain")
                    .WithObject("entity", entity)
                    .WithObject("enumAttributes", enumAttributes)
                    .GenerateSourceCodeFromResource("Domain.EnumGenerator.Enum");
        }
    }
}
