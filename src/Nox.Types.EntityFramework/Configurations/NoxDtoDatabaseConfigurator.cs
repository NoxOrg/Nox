using Nox.Solution;
using Nox.Types.EntityFramework.EntityBuilderAdapter;
using Nox.Solution.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nox.Types.EntityFramework.Abstractions;

namespace Nox.Types.EntityFramework.Configurations;

public class NoxDtoDatabaseConfigurator : INoxDtoDatabaseConfigurator
{
    public void ConfigureDto(NoxSolutionCodeGeneratorState codeGeneratorState, IEntityBuilder builder, Entity entity)
    {
        ConfigureKeys(builder, entity);

        ConfigureAttributes(codeGeneratorState, builder, entity);

        ConfigureRelationships(codeGeneratorState, builder, entity);

        ConfigureOwnedRelations(codeGeneratorState, builder, entity);
    }

    private static void ConfigureAttributes(NoxSolutionCodeGeneratorState codeGeneratorState, IEntityBuilder builder, Entity entity)
    {
        foreach (var attribute in entity.Attributes!)
        {
            // TODO inject configuration per attribute or use NoxType metadata to it

            if (attribute.Type == NoxType.VatNumber)
            {
                var compoundDtoType = codeGeneratorState.GetEntityDtoType("VatNumberDto")!;

                builder.OwnsOne(compoundDtoType, attribute.Name)
                    .Property(nameof(VatNumber.CountryCode))
                    .HasConversion(new EnumToStringConverter<CountryCode>());
            }

            if (attribute.Type == NoxType.StreetAddress)
            {
                var compoundDtoType = codeGeneratorState.GetEntityDtoType("StreetAddressDto")!;

                builder.OwnsOne(compoundDtoType, attribute.Name)
                    .Property(nameof(StreetAddress.CountryId))
                    .HasConversion(new EnumToStringConverter<CountryCode>());
            }
        }
    }

    private static void ConfigureRelationships(NoxSolutionCodeGeneratorState codeGeneratorState, IEntityBuilder builder, Entity entity)
    {
        if (entity.Relationships == null)
        {
            return;
        }

        foreach (var relationshipToCreate in entity.Relationships)
        {
            // One to ?? (// Many to Many are setup by EF)
            if (relationshipToCreate.ShouldGenerateForeignKeyOnThisSide() && relationshipToCreate.WithSingleEntity())
            {
                //One to Many
                if (relationshipToCreate.IsManyRelationshipOnOtherSide())
                {
                    builder
                        .HasOne($"{codeGeneratorState.DtoNameSpace}.{relationshipToCreate.Entity}Dto", relationshipToCreate.Entity)
                        .WithMany(entity.PluralName)
                        .HasForeignKey($"{relationshipToCreate.Entity}Id");
                }
                else //One to One
                {
                    builder
                        .HasOne($"{codeGeneratorState.DtoNameSpace}.{relationshipToCreate.Entity}Dto", relationshipToCreate.Entity)
                        .WithOne(entity.Name)
                        .HasForeignKey($"{codeGeneratorState.DtoNameSpace}.{entity.Name}Dto", $"{relationshipToCreate.Entity}Id");
                }
            }

            if (!relationshipToCreate.ShouldUseRelationshipNameAsNavigation())
            {
                builder.Ignore(relationshipToCreate.Name);
            }
        }
    }

    private static void ConfigureOwnedRelations(NoxSolutionCodeGeneratorState codeGeneratorState, IEntityBuilder builder, Entity entity)
    {
        if (entity.OwnedRelationships != null)
        {
            var keyNames = entity.Keys!.Select(x => x.Name);

            //#pragma warning disable S3267 // Loops should be simplified with "LINQ" expressions
            foreach (var ownedRelationship in entity.OwnedRelationships)
            //#pragma warning restore S3267 // Loops should be simplified with "LINQ" expressions
            {
                var relatedEntityDtoType = codeGeneratorState.GetEntityDtoType(ownedRelationship.Related.Entity.Name + "Dto")!;

                if (ownedRelationship.WithSingleEntity())
                {
                    builder.OwnsOne(relatedEntityDtoType,
                        ownedRelationship.Related.Entity.Name,
                        owned =>
                        {
                            owned.WithOwner().HasForeignKey($"{entity.Name}Id");                           
                        });
                    return;
                }
                
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

    private static void ConfigureKeys(IEntityBuilder builder, Entity entity)
    {
        foreach (var key in entity.Keys!)
        {
            builder.HasKey(key.Name);
        }
    }
}