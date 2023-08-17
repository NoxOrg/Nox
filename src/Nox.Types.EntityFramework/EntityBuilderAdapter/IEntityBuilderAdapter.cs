using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nox.Types.EntityFramework.EntityBuilderAdapter
{
    public interface IEntityBuilderAdapter
    {
        public PropertyBuilder Property(string propertyName);

        public ReferenceNavigationBuilder HasOne(string? navigationName);

        public void Ignore(string propertyName);

        public KeyBuilder HasKey(params string[] propertyNames);

        public void OwnsOne(
            Type ownedType,
            string navigationName,
            Action<OwnedNavigationBuilder> buildAction);

        public object OwnsOne(
            Type ownedType,
            string navigationName);

        public void OwnsMany(
            Type ownedType,
            string navigationName,
            Action<OwnedNavigationBuilder> buildAction);
    }
}
