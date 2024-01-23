using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Nox.Solution;
using Nox.Solution.Extensions;
using Nox.Types.EntityFramework.Abstractions;
using System.Reflection;


namespace Nox.Types.EntityFramework.Configurations;

public sealed class NoxDtoDatabaseConfigurator : INoxDtoDatabaseConfigurator
{
    private readonly NoxCodeGenConventions _codeGenConventions;
    private readonly IEntityDtoSqlQueryBuilderProvider _sqlQueryBuilderProvider;

    public NoxDtoDatabaseConfigurator(
        NoxCodeGenConventions codeGenConventions,
        IEntityDtoSqlQueryBuilderProvider sqlQueryBuilderProvider)
    {
        _codeGenConventions = codeGenConventions;
        _sqlQueryBuilderProvider = sqlQueryBuilderProvider;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="builder"></param>
    /// <param name="entity"></param>
    /// <param name="clientAssembly">The Client Assembly where entity is generated.</param>
    public void ConfigureDto(EntityTypeBuilder builder, Entity entity, Assembly clientAssembly)
    {
        ConfigureTableName(builder, entity);

        ConfigureKeys(builder, keys: entity.GetKeys());

        ConfigureAttributes(builder, entity, clientAssembly);

        ConfigureRelationships(builder, entity);

        ConfigureOwnedRelationships(builder, entity);

        ConfigureSqlQuery(builder, entity);
    }

    private void ConfigureTableName(EntityTypeBuilder builder, Entity entity)
    {
        builder.ToTable(_codeGenConventions.Solution.Domain!.GetEntityByName(entity.Name).Persistence.TableName);
    }

    public void ConfigureLocalizedDto(EntityTypeBuilder builder, Entity entity)
    {
        ConfigureKeys(builder, keys: entity.GetKeys());
    }

    private static void ConfigureKeys(EntityTypeBuilder builder, IReadOnlyList<NoxSimpleTypeDefinition> keys)
    {
        foreach (var key in keys)
        {
            builder.HasKey(key.Name);
        }
    }

    private void ConfigureAttributes(EntityTypeBuilder builder, Entity entity, Assembly clientAssembly)
    {
        foreach (var attribute in entity.Attributes!)
        {
            // TODO inject configuration per attribute or use NoxType metadata to it

            if (attribute.Type == NoxType.VatNumber)
            {
                var compoundDtoType = clientAssembly.GetType(_codeGenConventions.GetEntityDtoTypeFullName("VatNumberDto"));

                builder.OwnsOne(compoundDtoType!, attribute.Name)
                    .Property(nameof(VatNumber.CountryCode))
                    .HasConversion(new EnumToStringConverter<CountryCode>());
            }

            if (attribute.Type == NoxType.StreetAddress)
            {
                var compoundDtoType = clientAssembly.GetType(_codeGenConventions.GetEntityDtoTypeFullName("StreetAddressDto"));

                builder.OwnsOne(compoundDtoType!, attribute.Name)
                    .Property(nameof(StreetAddress.CountryId))
                    .HasConversion(new EnumToStringConverter<CountryCode>());
            }
        }
    }

    private void ConfigureRelationships(EntityTypeBuilder builder, Entity entity)
    {
        foreach (var relationshipToCreate in entity.Relationships)
        {
            if (!relationshipToCreate.ConfigureThisSide())
                continue;

            ConfigureRelationship(builder, entity, relationshipToCreate);
        }
    }

    private void ConfigureRelationship(EntityTypeBuilder builder, Entity entity, EntityRelationship relationship)
    {
        var navigationPropertyName = entity.GetNavigationPropertyName(relationship);
        var reversedNavigationPropertyName = relationship.GetNavigationPropertyName(relationship.Related.EntityRelationship);

        // ManyToMany Currently, configured bi-directionally, shouldn't cause any issues.
        if (relationship.WithMultiEntity &&
            relationship.Related.EntityRelationship.WithMultiEntity)
        {
            if (relationship.IsSelfReferencingRelationshipTo(relationship.Related.EntityRelationship))
            {
                var entityNamespace = _codeGenConventions.GetEntityDtoTypeFullName($"{entity.Name}Dto");

                builder
                    .HasMany(navigationPropertyName)
                    .WithMany()
                    .UsingEntity(
                        relationship.Name,
                        l => l.HasOne(entityNamespace).WithMany().HasForeignKey($"{relationship.Name}Id"),
                        r => r.HasOne(entityNamespace).WithMany().HasForeignKey($"{entity.Name}Id"));
            }
            else
            {
                builder
                    .HasMany(navigationPropertyName)
                    .WithMany(reversedNavigationPropertyName)
                    .UsingEntity(x => x.ToTable(relationship.Name));
            }
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

    private void ConfigureOwnedRelationships(EntityTypeBuilder builder, Entity entity)
    {
        foreach (var relationshipToCreate in entity.OwnedRelationships)
        {
            ConfigureOwnedRelationship(builder, entity, relationshipToCreate);
        }
    }

    private void ConfigureOwnedRelationship(EntityTypeBuilder builder, Entity entity, EntityRelationship relationship)
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

    private void ConfigureSqlQuery(EntityTypeBuilder builder, Entity entity)
    {
        if (entity.RequiresCustomSqlStatement())
        {
            var sqlQueryBuilder = _sqlQueryBuilderProvider.GetBuilder(entity.Name);
            builder.ToSqlQuery(sqlQueryBuilder.Build());
        }
    }
}