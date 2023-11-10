using Nox.Solution;
using Nox.Types.EntityFramework.EntityBuilderAdapter;
using Nox.Solution.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Infrastructure;
using System.Diagnostics;

namespace Nox.Types.EntityFramework.Configurations;

public sealed class NoxDtoDatabaseConfigurator : INoxDtoDatabaseConfigurator
{
    private NoxCodeGenConventions _codeGenConventions { get; }
    private INoxClientAssemblyProvider _clientAssemblyProvider { get; }

    public NoxDtoDatabaseConfigurator(NoxCodeGenConventions codeGenConventions,INoxClientAssemblyProvider clientAssemblyProvider)
    {
        _codeGenConventions = codeGenConventions;
        _clientAssemblyProvider = clientAssemblyProvider;
    }
    public void ConfigureDto(IEntityBuilder builder, Entity entity)
    {
        ConfigureKeys(builder, entity);

        ConfigureAttributes(builder, entity);

        ConfigureRelationships(builder, entity);

        ConfigureOwnedRelations(builder, entity);
    }

    public void ConfigureLocalizedDto(IEntityBuilder builder, Entity entity)
    {
        var localizedEntity = entity.ShallowCopy(NoxCodeGenConventions.GetEntityNameForLocalizedType(entity.Name));

        ConfigureKeys(builder, localizedEntity);
    }

    private void ConfigureAttributes(IEntityBuilder builder, Entity entity)
    {
        foreach (var attribute in entity.Attributes!)
        {
            // TODO inject configuration per attribute or use NoxType metadata to it

            if (attribute.Type == NoxType.VatNumber)
            {
                var compoundDtoType = _clientAssemblyProvider.ClientAssembly.GetType(_codeGenConventions.GetEntityDtoTypeFullName("VatNumberDto"));

                builder.OwnsOne(compoundDtoType!, attribute.Name)
                    .Property(nameof(VatNumber.CountryCode))
                    .HasConversion(new EnumToStringConverter<CountryCode>());
            }

            if (attribute.Type == NoxType.StreetAddress)
            {
                var compoundDtoType = _clientAssemblyProvider.ClientAssembly.GetType(_codeGenConventions.GetEntityDtoTypeFullName("StreetAddressDto")); 

                builder.OwnsOne(compoundDtoType!, attribute.Name)
                    .Property(nameof(StreetAddress.CountryId))
                    .HasConversion(new EnumToStringConverter<CountryCode>());
            }
        }
    }

    private void ConfigureRelationships(IEntityBuilder builder, Entity entity)
    {
        foreach (var relationshipToCreate in entity.Relationships)
        {
            var navigationPropertyName = entity.GetRelationshipPublicName(relationshipToCreate);
            var reversedNavigationPropertyName = relationshipToCreate.Related.Entity.GetRelationshipPublicName(
                relationshipToCreate.Related.EntityRelationship);
            // ManyToMany
            // Currently, configured bi-directionally, shouldn't cause any issues.
            if (relationshipToCreate.WithMultiEntity &&
                relationshipToCreate.Related.EntityRelationship.WithMultiEntity)
            {
                if (relationshipToCreate.ShouldGenerateForeignKeyOnThisSide())
                {
                    builder
                    .HasMany(navigationPropertyName)
                    .WithMany(reversedNavigationPropertyName)
                    .UsingEntity(x => x.ToTable(relationshipToCreate.Name));
                }
            }
            // OneToOne and OneToMany, setup should be done only on foreign key side
            else if (relationshipToCreate.ShouldGenerateForeignKeyOnThisSide() &&
                relationshipToCreate.WithSingleEntity())
            {
                //One to Many
                if (relationshipToCreate.Related.EntityRelationship.WithMultiEntity)
                {
                    builder
                        .HasOne($"{_codeGenConventions.DtoNameSpace}.{relationshipToCreate.Entity}Dto", navigationPropertyName)
                        .WithMany(reversedNavigationPropertyName)
                        .HasForeignKey($"{navigationPropertyName}Id");
                }
                //One to One
                else
                {
                    builder
                        .HasOne($"{_codeGenConventions.DtoNameSpace}.{relationshipToCreate.Entity}Dto", navigationPropertyName)
                        .WithOne(reversedNavigationPropertyName)
                        .HasForeignKey($"{_codeGenConventions.DtoNameSpace}.{entity.Name}Dto", $"{navigationPropertyName}Id");
                }
            }
        }
    }

    private void ConfigureOwnedRelations(IEntityBuilder builder, Entity entity)
    {
        var keyNames = entity.Keys!.Select(x => x.Name);

        //#pragma warning disable S3267 // Loops should be simplified with "LINQ" expressions
        foreach (var ownedRelationship in entity.OwnedRelationships)
        //#pragma warning restore S3267 // Loops should be simplified with "LINQ" expressions
        {
            var relatedEntityDtoType = _clientAssemblyProvider.ClientAssembly.GetType(_codeGenConventions.GetEntityDtoTypeFullName(ownedRelationship.Related.Entity.Name + "Dto")); 

            if (ownedRelationship.WithSingleEntity())
            {
                builder.OwnsOne(relatedEntityDtoType!,
                    ownedRelationship.Name,
                    owned =>
                    {
                        owned.WithOwner().HasForeignKey($"{entity.Name}Id");
                    });
                return;
            }

            builder.OwnsMany(relatedEntityDtoType!,
                ownedRelationship.Name,
                owned =>
                {
                    owned.WithOwner().HasForeignKey($"{entity.Name}Id");
                    owned.HasKey(string.Join(",", keyNames));
                    owned.ToTable(ownedRelationship.Related.Entity.Name);
                });
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