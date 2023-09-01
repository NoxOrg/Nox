using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Nox.Types.EntityFramework.EntityBuilderAdapter
{
    public class EntityBuilderAdapter : IEntityBuilder
    {
        public EntityBuilderAdapter(EntityTypeBuilder entityTypeBuilder)
        {
            EntityTypeBuilder = entityTypeBuilder;
        }

        public EntityTypeBuilder EntityTypeBuilder { get; set; }

        public PropertyBuilder Property(string propertyName)
        {
            return EntityTypeBuilder.Property(propertyName);
        }

        public ReferenceNavigationBuilder HasOne(string? navigationName)
        {
            return EntityTypeBuilder.HasOne(navigationName);
        }

        public ReferenceNavigationBuilder HasOne(string relatedTypeName, string? navigationName)
        {
            return EntityTypeBuilder.HasOne(relatedTypeName, navigationName);
        }

        public IEntityBuilder Ignore(string propertyName)
        {
            return new EntityBuilderAdapter(EntityTypeBuilder.Ignore(propertyName));
        }

        public IEntityBuilder ToTable(string tableName)
        {
            EntityTypeBuilder.ToTable(tableName);
            return this;
        }

        public KeyBuilder HasKey(params string[] propertyNames)
        {
            return EntityTypeBuilder.HasKey(propertyNames);
        }

        public void OwnsOne(
            Type ownedType,
            string navigationName,
            Action<OwnedNavigationBuilder> buildAction)
        {
            EntityTypeBuilder.OwnsOne(ownedType, navigationName, buildAction);
        }

        public IEntityBuilder OwnsOne(
            Type ownedType,
            string navigationName)
        {
            return new OwnedNavigationBuilderAdapter(EntityTypeBuilder.OwnsOne(ownedType, navigationName));
        }

        public void OwnsMany(
            Type ownedType,
            string navigationName,
            Action<OwnedNavigationBuilder> buildAction)
        {
            EntityTypeBuilder.OwnsMany(ownedType, navigationName, buildAction);
        }
        
        public IndexBuilder HasUniqueAttributeConstraint(string[] propertyNames, string constraintName)
        {
            return EntityTypeBuilder.HasIndex(propertyNames).HasDatabaseName(constraintName).IsUnique();
        }
    }
}
