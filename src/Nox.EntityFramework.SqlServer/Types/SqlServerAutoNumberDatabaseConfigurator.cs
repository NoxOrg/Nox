using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.Types;
using System.IO.Pipes;

namespace Nox.EntityFramework.SqlServer.Types;


public class SqlServerAutoNumberDatabaseConfigurator : AutoNumberDatabaseConfigurator, ISqlServerNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        AttributeConfiguration property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder,
        EntityTypeBuilder builder)
    {

        // If a normal attribute or key then it should be auto-incremented.
        // Otherwise If it's a foreign key of entity id type or relationship it shouldn't be auto-incremented.
        var shouldAutoincrement = entity.Attributes.Any(x => x.Name.Equals(property.Name, StringComparison.OrdinalIgnoreCase) && x.Type == property.Type);

        if (isKey)
        {
            var typeOptions = property.AutoNumberTypeOptions ?? new AutoNumberTypeOptions();
            var metadata = builder
                .Property(property.Name).ValueGeneratedOnAdd()
                .Metadata;
            metadata.SetIdentitySeed(typeOptions.StartsAt);
            metadata.SetIdentityIncrement(typeOptions.IncrementsBy);
        }
        else if (shouldAutoincrement)
        {
            ConfigureSequence(modelBuilder, entity, property, property.AutoNumberTypeOptions ?? new AutoNumberTypeOptions());

            builder
                .Property(property.Name)
                .HasDefaultValueSql($"NEXT VALUE FOR Seq{entity.Name}{property.Name}");

        }
        base.ConfigureEntityProperty(noxSolutionCodeGeneratorState, property, entity, isKey, modelBuilder, builder);
    }
    private void ConfigureSequence(ModelBuilder modelBuilder, Entity entity, AttributeConfiguration property, AutoNumberTypeOptions typeOptions)
    {
        var seqName = $"Seq{entity.Name}{property.Name}";

        modelBuilder.HasSequence<long>(seqName)
            .StartsAt(typeOptions.StartsAt)
            .IncrementsBy(typeOptions.IncrementsBy);
    }
}