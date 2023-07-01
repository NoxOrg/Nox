using Humanizer;
using Microsoft.CodeAnalysis;
using Nox.Solution;
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

    private static readonly string[] _entityConfigurationUsings = new[]
    {
        "using Microsoft.EntityFrameworkCore.Metadata.Builders;",
        "using Microsoft.EntityFrameworkCore;",
        "using Nox.Types;",
        "using Nox.Solution;",
        "using Nox.Types.EntityFramework.Sqlite.ToMoveEF;"
    };
    private static void GenerateEntityConfiguration(SourceProductionContext context, string solutionNameSpace, Entity entity)
    {

        if (entity.Attributes is null)
            return;

        var code = new CodeBuilder($"{entity.Name}Configuration.g.cs", context); 
        

        code.AppendLines(_entityConfigurationUsings);
        
        // TODO Will be defined Nox.Types.EntityFramework
        code.AppendLine();
        code.AppendLine($"namespace {solutionNameSpace}.Domain;");
        code.AppendLine();
        code.AppendLine($"public partial class {entity.Name}Configuration : IEntityTypeConfiguration<{entity.Name}>");

        code.StartBlock();

            // db context
            code.AppendLine($"INoxDatabaseConfiguration _databaseConfiguration {{ get; set; }}");
            code.AppendLine($"NoxSolution _noxSolution {{ get; set; }}");
            code.AppendLine();

            // Constructor
            code.AppendLine($"public {entity.Name}Configuration(NoxSolution noxSolution, INoxDatabaseConfiguration databaseConfiguration)");

            // Method content
            code.StartBlock();
            code.AppendLine($"_databaseConfiguration = databaseConfiguration;");
            code.AppendLine($"_noxSolution = noxSolution;");

        // End method
            code.EndBlock();
            code.AppendLine();

            // Method configure
            code.AppendLine($"public void Configure(EntityTypeBuilder<{entity.Name}> builder)");
            using(new CodeBlock(code))
            {
            /*
             //This is a sneak peak of what we can do. We can actually invest some more time and this call should be enough
            
            code.Append($"_databaseConfiguration.ConfigureEntity(_noxSolution, builder);");
            return;
            // The NoxSolution + builder has everything that we need to configure a full entity
             */
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
                
                if (entity.Attributes != null && entity.Attributes.Any())
                {
                    foreach (var attribute in entity.Attributes)
                    {
                        context.CancellationToken.ThrowIfCancellationRequested();

                        code.AppendLine();

                        code.AppendIndented("");

                        code.Append(
                            $"_databaseConfiguration.ConfigureEntityProperty(_noxSolution,\"{attribute.Name}\", builder, e => e.{attribute.Name});");

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
            }


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
}
