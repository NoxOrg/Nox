using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nox.Types.EntityFramework.EntityBuilderAdapter
{
    // Should be extended when needed
    public interface IEntityBuilder
    {
        public PropertyBuilder Property(string propertyName);

        public ReferenceNavigationBuilder HasOne(string? navigationName);

        public ReferenceNavigationBuilder HasOne(string relatedTypeName, string? navigationName);

        public CollectionNavigationBuilder HasMany(string navigationName);

        public IEntityBuilder Ignore(string propertyName);

        public KeyBuilder HasKey(params string[] propertyNames);

        public IEntityBuilder ToTable(string tableName);        

        public void OwnsOne(
            Type ownedType,
            string navigationName,
            Action<OwnedNavigationBuilder> buildAction);

        public IEntityBuilder OwnsOne(
            Type ownedType,
            string navigationName);

        public void OwnsMany(
            Type ownedType,
            string navigationName,
            Action<OwnedNavigationBuilder> buildAction);
    }
}
