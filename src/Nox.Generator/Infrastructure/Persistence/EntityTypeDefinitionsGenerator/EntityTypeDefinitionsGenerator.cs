using Humanizer;
using Microsoft.CodeAnalysis;
using Nox.Solution;
using Nox.Types;
using System;
using System.Linq;
using Nox.Generator.Common;

namespace Nox.Generator.Infrastructure.Persistence.ModelConfigGenerator;

// TODO: check and handle composite keys in this and Entity generators.
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

        var code = new CodeBuilder($"Infrastructure/Persistence/EntityTypeConfiguration/{entity.Name}Configuration.g.cs", context);

        code.AppendLine($"using Microsoft.EntityFrameworkCore.Metadata.Builders;");
        code.AppendLine($"using Microsoft.EntityFrameworkCore;");
        code.AppendLine($"using Nox.Types;");
        code.AppendLine($"using Nox.Abstractions.Infrastructure.Persistence;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Domain;");
        code.AppendLine();
        code.AppendLine($"public partial class {entity.Name}Configuration : IEntityTypeConfiguration<{entity.Name}>");

        code.StartBlock();

            // db context
            code.AppendLine($"INoxDatabaseProvider _dbProvider {{ get; set; }}");
            code.AppendLine();

            // Constructor
            code.AppendLine($"public {entity.Name}Configuration(INoxDatabaseProvider dbProvider)");

            // Method content
            code.StartBlock();
                code.AppendLine($"_dbProvider = dbProvider;");

            // End method
            code.EndBlock();
            code.AppendLine();

            // Method configure
            code.AppendLine($"public void Configure(EntityTypeBuilder<{entity.Name}> builder)");
            code.StartBlock();

                if (entity.Keys.Count > 1)
                {
                    var keyString = string.Empty;

                    foreach (var key in entity.Keys)
                    {
#pragma warning disable S1643 // Strings should not be concatenated using '+' in a loop
                        keyString += $"e.{key.Name}, ";
#pragma warning restore S1643 // Strings should not be concatenated using '+' in a loop
                    }

                    code.AppendLine($"builder.HasKey(e => new {{ {keyString.TrimEnd().TrimEnd(',')} }});");
                    code.AppendLine();

                    foreach (var key in entity.Keys)
                    {
                        var keyClassName = $"{entity.Name}{key.Name}";
                        var keyName = key.Name;
                
                        code.AppendLine($"builder.Property(e => e.{keyName}).IsRequired(true).HasConversion(v => v.Value, v => {keyClassName}.From(v));");
                    }
                }
                else
                {
                    var key = entity.Keys.First();
                    var keyClassName = $"{entity.Name}{key.Name}";
                    var keyName = key.Name;

                    code.AppendLine($"builder.HasKey(e => e.{keyName});");
                    code.AppendLine();

                    code.AppendLine($"builder.Property(e => e.{keyName}).IsRequired(true).ValueGeneratedOnAdd().HasConversion(v => v.Value, v => {keyClassName}.From(v));");
                }
                
                if (entity.Attributes != null &&
                    entity.Attributes.Any())
                {
                    foreach (var attribute in entity.Attributes)
                    {
                        context.CancellationToken.ThrowIfCancellationRequested();

                        code.AppendLine();

                        code.AppendIndented("");

                        GetAttributeTypeConfiguration(code, attribute);

                        code.Append($";");

                        code.AppendLine();
                    }
                }
                
                if (entity.Relationships != null &&
                    entity.Relationships.Any())
                {
                    foreach (var relationship in entity.Relationships)
                    {
                        context.CancellationToken.ThrowIfCancellationRequested();

                        code.AppendLine();

                        code.AppendIndented("");

                        GetRelationshipConfiguration(code, relationship);

                        code.Append($";");

                        code.AppendLine();
                    }
                }

            code.EndBlock();

        code.EndBlock();

        code.GenerateSourceCode();
    }

    private static void GetRelationshipConfiguration(CodeBuilder code, EntityRelationship relationship)
    {
        if (relationship.Relationship == EntityRelationshipType.ZeroOrMany || relationship.Relationship == EntityRelationshipType.OneOrMany)
        {
            code.Append($"builder.HasMany(x => x.{relationship.Entity.Pluralize()}).WithMany()");
        }

        if (relationship.Relationship == EntityRelationshipType.ZeroOrOne || relationship.Relationship == EntityRelationshipType.ExactlyOne)
        {
            code.Append($"builder.HasOne(x => x.{relationship.Entity}).WithMany()");
        }
    }

    public static void GetAttributeTypeConfiguration(CodeBuilder code, NoxSimpleTypeDefinition attribute)
    {
        if (IsCompoundType(attribute.Type))
        {
            code.Append($"builder.OwnsOne(e => e.{attribute.Name}).Ignore(p => p.Value);");
            return;
        }

        code.Append($"builder.Property(e => e.{attribute.Name})");
        code.Append($".IsRequired({attribute.IsRequired.ToString().ToLower()})");
        
        //TODO Open Close Principle, how to add a Nox.Type without updating this code?
        if (attribute.Type == NoxType.Text)
        {
            AppendTextTypeConfiguration(code, attribute.TextTypeOptions ?? new TextTypeOptions());
        }
        else if (attribute.Type == NoxType.Number)
        {
            AppendNumberTypeConfiguration(code, attribute.NumberTypeOptions ?? new NumberTypeOptions());
        }
    }

    public static bool IsCompoundType(Enum value)
    {
        var fi = value.GetType().GetField(value.ToString());
        var attributes = (CompoundTypeAttribute[])
            fi.GetCustomAttributes(typeof(CompoundTypeAttribute), false);
        return (attributes != null && attributes.Length > 0);
    }

    private static void AppendNumberTypeConfiguration(CodeBuilder code, NumberTypeOptions options)
    {
        code.Append($".HasColumnType(_dbProvider.ToDatabaseColumnType<Number,NumberTypeOptions>(new NumberTypeOptions() {{ MinValue = {options.MinValue}, MaxValue = {options.MaxValue}, DecimalDigits = {options.DecimalDigits} }}))");
    }

    private static void AppendTextTypeConfiguration(CodeBuilder code, TextTypeOptions options)
    {
        var isUniCode = options.IsUnicode ? "true" : "false";

        code.Append($".IsUnicode({isUniCode})");

        code.Append($".HasMaxLength({options.MaxLength})");

        code.Append($".HasColumnType(_dbProvider.ToDatabaseColumnType<Text,TextTypeOptions>(new TextTypeOptions() {{ MinLength = {options.MinLength}, MaxLength = {options.MaxLength}, IsUnicode = {isUniCode}, Casing = {options.Casing.GetType().Name}.{options.Casing} }}))");
    }
}
