using Nox.Solution;
using Nox.Types.EntityFramework.EntityBuilderAdapter;
using Nox.Solution.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Nox.Types.EntityFramework.Abstractions;

public class NoxDtoDatabaseConfigurator : INoxDtoDatabaseConfigurator
{
    public void ConfigureDto(NoxSolutionCodeGeneratorState codeGeneratorState, IEntityBuilder builder, Entity entity)
    {
        foreach (var key in entity.Keys!)
        {
            builder.HasKey(key.Name);
        }

        var keyNames = entity.Keys.Select(x => x.Name);

       

        if (entity.OwnedRelationships != null)
        {
            //#pragma warning disable S3267 // Loops should be simplified with "LINQ" expressions
            foreach (var ownedRelationship in entity.OwnedRelationships)
            //#pragma warning restore S3267 // Loops should be simplified with "LINQ" expressions
            {
                if (ownedRelationship.WithSingleEntity())
                {
                    throw new NotImplementedException("Owned Entity ExactlyOne or ZeroOrOne not implemented");
                }
                var relatedEntityDtoType = codeGeneratorState.GetEntityDtoType(ownedRelationship.Related.Entity.Name + "Dto")!;
                builder.OwnsMany(relatedEntityDtoType,
                    ownedRelationship.Related.Entity.PluralName,
                    owned =>
                {
                    owned.WithOwner().HasForeignKey($"{entity.Name}Id");
                    owned.HasKey(string.Join(",", keyNames));
                    owned.ToTable(ownedRelationship.Related.Entity.Name);
                });

            }
        }
    }
}