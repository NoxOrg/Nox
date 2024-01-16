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
        NoxCodeGenConventions codeGenConventions,
        GeneratorConfig config,
        System.Action<string> log,
        string? projectRootPath
     )
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (codeGenConventions.Solution.Domain == null)
            return;

        foreach (var entity in codeGenConventions.Solution.Domain.Entities.Where(x => x.Attributes.Any(x => x.Type == Types.NoxType.Enumeration)))
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
                        SanitizedName = NoxCodeGenConventions.GetEnumPropertyName(value.Name),
                        Id = value.Id
                    })
                });

            new TemplateCodeBuilder(context, codeGenConventions)
                    .WithClassName($"{entity.Name}Enums")
                    .WithFileNamePrefix($"Domain")
                    .WithObject("entity", entity)
                    .WithObject("enumAttributes", enumAttributes)
                    .GenerateSourceCodeFromResource("Domain.EnumGenerator.Enum");
        }
    }
}
