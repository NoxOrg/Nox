using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.Types;
using Nox.Types.EntityFramework.Configurations;

namespace Nox.EntityFramework.SqlServer.Types;


public class SqlServerGuidDatabaseConfigurator : GuidDatabaseConfigurator, ISqlServerNoxTypeDatabaseConfigurator
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
        base.ConfigureEntityProperty(noxSolutionCodeGeneratorState, property, entity, isKey, modelBuilder, entityTypeBuilder);
        if (isKey)
        {
            //In Nox Guid key is generated at the appication level
            // Enable importing and outbox pattern for Created events
            // See also: https://www.youtube.com/watch?v=n17U7ntLMt4
            entityTypeBuilder
                .HasKey(property.Name)
                .IsClustered(false);
        }
    }
}