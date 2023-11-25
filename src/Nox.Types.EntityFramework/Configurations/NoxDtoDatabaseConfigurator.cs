using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nox.Infrastructure;
using Nox.Solution;
using Nox.Solution.Extensions;
using Nox.Types.EntityFramework.Abstractions;
using Nox.Types.EntityFramework.EntityBuilderAdapter;

namespace Nox.Types.EntityFramework.Configurations;

public sealed class NoxDtoDatabaseConfigurator : INoxDtoDatabaseConfigurator
{
    private readonly NoxCodeGenConventions _codeGenConventions;
    private readonly INoxClientAssemblyProvider _clientAssemblyProvider;

    public NoxDtoDatabaseConfigurator(NoxCodeGenConventions codeGenConventions, INoxClientAssemblyProvider clientAssemblyProvider)
    {
        _codeGenConventions = codeGenConventions;
        _clientAssemblyProvider = clientAssemblyProvider;
    }

    public void ConfigureDto(IEntityBuilder builder, Entity entity)
    {
        ConfigureKeys(builder, entity);

        ConfigureAttributes(builder, entity);

        ConfigureRelationships(builder, entity);

        ConfigureOwnedRelationships(builder, entity);
    }

    public void ConfigureLocalizedDto(IEntityBuilder builder, Entity entity)
    {
        var localizedEntity = entity.ShallowCopy(NoxCodeGenConventions.GetEntityNameForLocalizedType(entity.Name));

        ConfigureKeys(builder, localizedEntity);
    }

    private static void ConfigureKeys(IEntityBuilder builder, Entity entity)
    {
        foreach (var key in entity.GetKeys())
        {
            builder.HasKey(key.Name);
        }
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
            if (!relationshipToCreate.ConfigureThisSide())
                continue;

            ConfigureRelationship(builder, entity, relationshipToCreate);
        }
    }

    private void ConfigureRelationship(IEntityBuilder builder, Entity entity, EntityRelationship relationship)
    {
        var navigationPropertyName = entity.GetNavigationPropertyName(relationship);
        var reversedNavigationPropertyName = relationship.Related.Entity.GetNavigationPropertyName(relationship.Related.EntityRelationship);

        // ManyToMany Currently, configured bi-directionally, shouldn't cause any issues.
        if (relationship.WithMultiEntity &&
            relationship.Related.EntityRelationship.WithMultiEntity)
        {
            builder
                .HasMany(navigationPropertyName)
                .WithMany(reversedNavigationPropertyName)
                .UsingEntity(x => x.ToTable(relationship.Name));
        }
        // OneToOne and OneToMany, setup should be done only on foreign key side
        else if (relationship.WithSingleEntity())
        {
            //One to Many
            if (relationship.Related.EntityRelationship.WithMultiEntity)
            {
                builder
                    .HasOne($"{_codeGenConventions.DtoNameSpace}.{relationship.Entity}Dto", navigationPropertyName)
                    .WithMany(reversedNavigationPropertyName)
                    .HasForeignKey($"{navigationPropertyName}Id");
            }
            //One to One
            else
            {
                builder
                    .HasOne($"{_codeGenConventions.DtoNameSpace}.{relationship.Entity}Dto", navigationPropertyName)
                    .WithOne(reversedNavigationPropertyName)
                    .HasForeignKey($"{_codeGenConventions.DtoNameSpace}.{entity.Name}Dto", $"{navigationPropertyName}Id");
            }
        }
    }

    private void ConfigureOwnedRelationships(IEntityBuilder builder, Entity entity)
    {
        foreach (var relationshipToCreate in entity.OwnedRelationships)
        {
            ConfigureOwnedRelationship(builder, entity, relationshipToCreate);
        }
    }

    private void ConfigureOwnedRelationship(IEntityBuilder builder, Entity entity, EntityRelationship relationship)
    {
        var relatedEntityTypeName = _codeGenConventions.GetEntityDtoTypeFullName(relationship.Related.Entity.Name + "Dto");
        var navigationPropertyName = entity.GetNavigationPropertyName(relationship);

        //One to Many
        if (relationship.WithMultiEntity())
        {
            builder
                .HasMany(navigationPropertyName)
                .WithOne()
                .HasForeignKey($"{entity.Name}Id");
        }
        else //One to One
        {
            builder
                .HasOne(relatedEntityTypeName, navigationPropertyName)
                .WithOne()
                .HasForeignKey(relatedEntityTypeName, relationship.Related.Entity.GetKeys().Select(key => key.Name).ToArray());
        }
    }
}