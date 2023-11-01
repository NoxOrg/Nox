using Microsoft.EntityFrameworkCore;
using Nox.Solution;
using Nox.Types;
using Nox.Types.EntityFramework.EntityBuilderAdapter;
using Nox.Types.EntityFramework.Types;

namespace Nox.EntityFramework.SqlServer;


public class SqlServerAutoNumberDatabaseConfigurator: AutoNumberDatabaseConfigurator, ISqlServerNoxTypeDatabaseConfigurator
{
    public override bool IsDefault => false;

    public override void ConfigureEntityProperty(NoxCodeGenConventions noxSolutionCodeGeneratorState, IEntityBuilder builder,
        NoxSimpleTypeDefinition property, Entity entity, bool isKey)
    {
        
        // If a normal attribute or key then it should be auto-incremented.
        // Otherwise If it's a foreign key of entity id type or relationship it shouldn't be auto-incremented.
        var shouldAutoincrement = entity.Attributes.Any(x => x.Name.Equals(property.Name, StringComparison.OrdinalIgnoreCase) && x.Type == property.Type);

        if (isKey)
        {
            var typeOptions = property.AutoNumberTypeOptions ??= new AutoNumberTypeOptions();
            var metadata = builder
                .Property(property.Name).ValueGeneratedOnAdd()
                .Metadata;
            metadata.SetIdentitySeed(typeOptions.StartsAt);
            metadata.SetIdentityIncrement(typeOptions.IncrementsBy);
        }
        else if (shouldAutoincrement)
        {
            builder
                .Property(property.Name)
                .HasDefaultValueSql($"NEXT VALUE FOR Seq{entity.Name}{property.Name}");
               
        }
        base.ConfigureEntityProperty(noxSolutionCodeGeneratorState, builder, property, entity, isKey);
    }
}