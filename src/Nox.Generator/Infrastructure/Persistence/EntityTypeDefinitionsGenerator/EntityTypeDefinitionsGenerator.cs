using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using Nox.Solution;
using Nox.Types;
using System.Linq;
using System.Text;

namespace Nox.Generator.Infrastructure.Persistence.ModelConfigGenerator;

internal class EntityTypeDefinitionsGenerator
{

    public static void Generate(SourceProductionContext context, string solutionNameSpace, NoxSolution solution)
    {
        context.CancellationToken.ThrowIfCancellationRequested();

        if (solution.Domain == null)
            return;

        foreach (var entity in solution.Domain.Entities)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            GenerateEntityConfiguration(context, solutionNameSpace, entity);
        }
    }

    private static void GenerateEntityConfiguration(SourceProductionContext context, string solutionNameSpace, Entity entity)
    { 

        if (entity.Attributes is null)
            return;

        var code = new CodeBuilder($"Infrastructure/Persistence/EntityTypeConfiguration/{entity.Name}Configuration.g.cs",context);

        code.AppendLine($"using Nox.Types.EntityFramework;");
        code.AppendLine($"using Microsoft.EntityFrameworkCore.Metadata.Builders;");
        code.AppendLine($"using Microsoft.EntityFrameworkCore;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Domain;");
        code.AppendLine();
        code.AppendLine($"public partial class {entity.Name}Configuration : IEntityTypeConfiguration<{entity.Name}>");
        
        code.StartBlock();

        code.AppendLine($"public void Configure(EntityTypeBuilder<{entity.Name}> builder)");
        code.StartBlock();

        var key = entity.Keys.First();
        var keyClassName = $"{entity.Name}{key.Name}";
        var keyName = key.Name;

        code.AppendLine($"builder.HasKey(e => e.{keyName});"); // TODO: Multi Key entities
        code.AppendLine();

        code.AppendLine($"builder.Property(e => e.{keyName}).IsRequired().ValueGeneratedOnAdd().HasConversion(v => v.Value, v => {keyClassName}.From(v));");

        foreach (var attribute in entity.Attributes)
        {
            code.AppendLine();

            code.AppendIndented("");

            GetAttributeTypeConfiguration(code,attribute);

            code.Append($";");
        
            code.AppendLine();

        }

        code.EndBlock();

        code.EndBlock();

        /*

class CountryConfiguration : IEntityTypeConfiguration<Country>
{
public void Configure(EntityTypeBuilder<Country> builder)
{
    builder.HasKey(e => e.Id);

    // Configure Single-value ValueObjects

    // Configure Multi-value ValueObjects
    builder.OwnsOne(e => e.LatLong).Ignore(p => p.Value);
}
}
        */

        code.GenerateSourceCode();


    }

    public static void GetAttributeTypeConfiguration(CodeBuilder code, NoxSimpleTypeDefinition attribute)
    {
        // if simple type
        code.Append($"builder.Property(e => e.{attribute.Name})");
        // else 
        // builder.OwnsOne(e => e.LatLong).Ignore(p => p.Value);

        //attribute.Type;

        if (attribute.IsRequired)
            code.Append($".IsRequired()");

        if (attribute.Type == NoxType.Text)
        {
            AppendTextTypeConfiguration(code, attribute.TextTypeOptions ?? new TextTypeOptions());
        }

        else if (attribute.Type == NoxType.Number)
        {
            AppendNumberTypeConfiguration(code, attribute.NumberTypeOptions ?? new NumberTypeOptions());
        }

    }

    private static void AppendNumberTypeConfiguration(CodeBuilder code, NumberTypeOptions options)
    {
        code.Append($".HasColumnType(_dbDriver.GetDbType<Number>(new NumberTypeOptions() {{ MinValue: {options.MinValue}, MaxValue: {options.MaxValue}, DecimalDigits: {options.DecimalDigits} }})");
    }

    private static void AppendTextTypeConfiguration(CodeBuilder code, TextTypeOptions options)
    {
        var isUniCode = options.IsUnicode ? "true" : "false";

        code.Append($".IsUnicode({isUniCode})");

        code.Append($".HasMaxLength({options.MaxLength})");

        code.Append($".HasColumnType(_dbDriver.GetDbType<Text>(new TextTypeOptions() {{ MinLength: {options.MinLength}, MaxLength: {options.MaxLength}, IsUniCode: {options.IsUnicode}, Casing: {options.Casing} }})");
    }
}

