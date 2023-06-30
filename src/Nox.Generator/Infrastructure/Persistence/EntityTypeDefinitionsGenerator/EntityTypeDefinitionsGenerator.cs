using System;
using System.Linq;
using Humanizer;
using Microsoft.CodeAnalysis;
using Nox.Generator.Common;
using Nox.Generator.Infrastructure.Persistence.DatabaseConfiguration;
using Nox.Solution;

namespace Nox.Generator.Infrastructure.Persistence.EntityTypeDefinitionsGenerator;

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

        var code = new CodeBuilder($"{entity.Name}Configuration.g.cs", context);

        code.AppendLine($"using Microsoft.EntityFrameworkCore.Metadata.Builders;");
        code.AppendLine($"using Microsoft.EntityFrameworkCore;");
        code.AppendLine($"using Nox.Types;");
        code.AppendLine($"using Nox.Abstractions.Infrastructure.Persistence;");
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Domain;");
        code.AppendLine();
        code.AppendLine($"public partial class {entity.Name}Configuration : IEntityTypeConfiguration<{entity.Name}>");

        code.StartBlock();

            // Constructor
            code.AppendLine($"public {entity.Name}Configuration()");

            // Method content
            code.StartBlock();

            // End method
            code.EndBlock();
            code.AppendLine();

            // Method configure
            code.AppendLine($"public void Configure(EntityTypeBuilder<{entity.Name}> builder)");
            code.StartBlock();

                if (entity.Keys is { Count: > 1 })
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
        //TODO input database provider
        string databaseProvider = "sqLite";
        if (!DatabaseAttributeConfigurationInstances.Map.TryGetValue(databaseProvider, out var databaseConfiguration))
        {
            throw new Exception($"Could not find database configuration for provider {databaseProvider}");
        }

        var config = databaseConfiguration.GetConfig(attribute);

        if (!config.IsSingleProperty)
        {
            code.Append($"builder.OwnsOne(e => e.{attribute.Name}).Ignore(p => p.Value);");
            return;
        }

        code.Append($"builder.Property(e => e.{attribute.Name})");
        code.Append($".IsRequired({code.From(attribute.IsRequired)})");
        code.Append($".IsUnicode({code.From(config.IsUnicode)})");

        if (config.HasColumnType != null)
        {
            code.Append($".HasColumnType({config.HasColumnType})");
        }
        if (config.HasMaxLength != null)
        {
            code.Append($".HasMaxLength({config.HasMaxLength})");
        }
        if (config.HasConversionTypeFullName != null)
        {
            code.Append($".HasConversion<{config.HasConversionTypeFullName}>()");
        }
        code.Append($";");
    }
}
