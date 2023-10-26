using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.EntityBuilderAdapter;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.Postgres;

public class PostgresAutoNumberDatabaseConfigurator: AutoNumberDatabaseConfigurator, IPostgresNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;
    
    public override void ConfigureEntityProperty(NoxCodeGenConventions noxSolutionCodeGeneratorState, IEntityBuilder builder,
        NoxSimpleTypeDefinition property, Entity entity, bool isKey)
    {
        
        // If a normal attribute or key then it should be auto-incremented.
        // Otherwise If it's a foreign key of entity id type or relationship it shouldn't be auto-incremented.
        var shouldAutoincrement = entity.Attributes.Any(x => x.Name.Equals(property.Name, StringComparison.OrdinalIgnoreCase) && x.Type == property.Type);

        var typeOptions = property.AutoNumberTypeOptions ??= new AutoNumberTypeOptions();
        if (isKey || shouldAutoincrement)
        {
            builder
                .Property(property.Name).ValueGeneratedOnAdd().Metadata.SetIdentityIncrementBy(typeOptions.IncrementsBy);
            builder
                .Property(property.Name).ValueGeneratedOnAdd().Metadata.SetIdentityStartValue(typeOptions.StartsAt);
        }
       
        base.ConfigureEntityProperty(noxSolutionCodeGeneratorState, builder, property, entity, isKey);
    }
}