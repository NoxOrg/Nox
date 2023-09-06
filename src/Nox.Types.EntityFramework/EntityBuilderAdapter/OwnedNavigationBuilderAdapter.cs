using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nox.Types.EntityFramework.EntityBuilderAdapter
{
    public class OwnedNavigationBuilderAdapter : IEntityBuilder
    {
        public OwnedNavigationBuilderAdapter(OwnedNavigationBuilder ownedNavigationBuilder)
        {
            OwnedNavigationBuilder = ownedNavigationBuilder;
        }

        public OwnedNavigationBuilder? OwnedNavigationBuilder { get; set; }

        public PropertyBuilder Property(string propertyName)
        {
            return OwnedNavigationBuilder!.Property(propertyName!);
        }

        public ReferenceNavigationBuilder HasOne(string? navigationName)
        {
            return OwnedNavigationBuilder!.HasOne(navigationName!);
        }

        public ReferenceNavigationBuilder HasOne(string relatedTypeName, string? navigationName)
        {
            return OwnedNavigationBuilder!.HasOne(relatedTypeName, navigationName!);
        }
        public CollectionNavigationBuilder HasMany(string navigationName)
        {
            // TODO: fix owned entity many to many realtionships
            throw new NotImplementedException("HasMany is not supported for Owned navigation. Will be implemented later.");
        }

        public IEntityBuilder Ignore(string propertyName)
        {
            return new OwnedNavigationBuilderAdapter(OwnedNavigationBuilder!.Ignore(propertyName!));
        }

        public KeyBuilder HasKey(params string[] propertyNames)
        {
            return OwnedNavigationBuilder!.HasKey(propertyNames);
        }

        public IEntityBuilder ToTable(string tableName)
        {
            OwnedNavigationBuilder!.ToTable(tableName);
            return this;
        }

        public void OwnsOne(
            Type ownedType,
            string navigationName,
            Action<OwnedNavigationBuilder> buildAction)
        {
            OwnedNavigationBuilder!.OwnsOne(ownedType, navigationName, buildAction);
        }

        public IEntityBuilder OwnsOne(
            Type ownedType,
            string navigationName)
        {
            return new OwnedNavigationBuilderAdapter(OwnedNavigationBuilder!.OwnsOne(ownedType, navigationName));
        }

        public void OwnsMany(
            Type ownedType,
            string navigationName,
            Action<OwnedNavigationBuilder> buildAction)
        {
            OwnedNavigationBuilder!.OwnsMany(ownedType, navigationName, buildAction);
        }
        
       
        public IndexBuilder HasUniqueAttributeConstraint(string[] propertyNames, string constraintName)
        {
            return OwnedNavigationBuilder!.HasIndex(propertyNames).HasDatabaseName(constraintName).IsUnique();
        }
    }
}
