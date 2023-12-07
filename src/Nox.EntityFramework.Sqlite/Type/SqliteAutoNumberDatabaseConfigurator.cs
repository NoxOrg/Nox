using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.Configurations;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.Sqlite.Type;

public class SqliteAutoNumberDatabaseConfigurator : AutoNumberDatabaseConfigurator, ISqliteNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override void ConfigureEntityProperty(
        NoxCodeGenConventions noxSolutionCodeGeneratorState,
        NoxTypeDatabaseConfiguration property,
        Entity entity,
        bool isKey,
        ModelBuilder modelBuilder, 
        EntityTypeBuilder entityTypeBuilder)
    {

        // If a normal attribute or key then it should be auto-incremented.
        // Otherwise If it's a foreign key of entity id type or relationship it shouldn't be auto-incremented.
        var shouldAutoincrement = isKey || entity.Attributes.Any(x => x.Name.Equals(property.Name, StringComparison.OrdinalIgnoreCase) && x.Type == property.Type);

        if (shouldAutoincrement)
        {
            entityTypeBuilder
                .Property(property.Name).ValueGeneratedOnAdd();

        }

        base.ConfigureEntityProperty(noxSolutionCodeGeneratorState, property, entity, isKey, modelBuilder, entityTypeBuilder);
    }
}