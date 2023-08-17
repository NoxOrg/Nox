using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nox.Types.EntityFramework.EntityBuilderAdapter
{
    public class EntityBuilderAdapter : IEntityBuilderAdapter
    {
        public EntityBuilderAdapter(EntityTypeBuilder entityTypeBuilder)
        {
            EntityTypeBuilder = entityTypeBuilder;
        }

        public EntityBuilderAdapter(OwnedNavigationBuilder ownedNavigationBuilder)
        {
            OwnedNavigationBuilder = ownedNavigationBuilder;
        }

        public EntityTypeBuilder? EntityTypeBuilder { get; set; }
        public OwnedNavigationBuilder? OwnedNavigationBuilder { get; set; }

        public PropertyBuilder Property(string propertyName)
        {
            if (EntityTypeBuilder != null)
            {
                return EntityTypeBuilder.Property(propertyName);
            }
            else
            {
                return OwnedNavigationBuilder!.Property(propertyName!);
            }
        }

        public ReferenceNavigationBuilder HasOne(string? navigationName)
        {
            if (EntityTypeBuilder != null)
            {
                return EntityTypeBuilder.HasOne(navigationName);
            }
            else
            {
                return OwnedNavigationBuilder!.HasOne(navigationName!);
            }
        }

        public void Ignore(string propertyName)
        {
            if (EntityTypeBuilder != null)
            {
                EntityTypeBuilder.Ignore(propertyName);
            }
            else
            {
                OwnedNavigationBuilder!.Ignore(propertyName!);
            }
        }

        public KeyBuilder HasKey(params string[] propertyNames)
        {
            if (EntityTypeBuilder != null)
            {
                return EntityTypeBuilder.HasKey(propertyNames);
            }
            else
            {
                return OwnedNavigationBuilder!.HasKey(propertyNames);
            }
        }

        public void OwnsOne(
            Type ownedType,
            string navigationName,
            Action<OwnedNavigationBuilder> buildAction)
        {
            if (EntityTypeBuilder != null)
            {
                EntityTypeBuilder.OwnsOne(ownedType, navigationName, buildAction);
            }
            else
            {
                OwnedNavigationBuilder!.OwnsOne(ownedType, navigationName, buildAction);
            }
        }

        public object OwnsOne(
            Type ownedType,
            string navigationName)
        {
            if (EntityTypeBuilder != null)
            {
                return EntityTypeBuilder.OwnsOne(ownedType, navigationName);
            }
            else
            {
                return OwnedNavigationBuilder!.OwnsOne(ownedType, navigationName);
            }
        }

        public void OwnsMany(
            Type ownedType,
            string navigationName,
            Action<OwnedNavigationBuilder> buildAction)
        {
            if (EntityTypeBuilder != null)
            {
                EntityTypeBuilder.OwnsMany(ownedType, navigationName, buildAction);
            }
            else
            {
                OwnedNavigationBuilder!.OwnsMany(ownedType, navigationName, buildAction);
            }
        }
    }
}
