using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Nox.Types.EntityFramework.EntityBuilderAdapter
{
    public class EntityBuilderAdapter : IEntityBuilder
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

        public ReferenceNavigationBuilder HasOne(string relatedTypeName, string? navigationName)
        {
            if (EntityTypeBuilder != null)
            {
                return EntityTypeBuilder.HasOne(relatedTypeName, navigationName);
            }
            else
            {
                return OwnedNavigationBuilder!.HasOne(relatedTypeName, navigationName!);
            }
        }

        public IEntityBuilder Ignore(string propertyName)
        {
            if (EntityTypeBuilder != null)
            {
                return new EntityBuilderAdapter(EntityTypeBuilder.Ignore(propertyName));
            }
            else
            {
                return new EntityBuilderAdapter(OwnedNavigationBuilder!.Ignore(propertyName!));
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

        public IEntityBuilder OwnsOne(
            Type ownedType,
            string navigationName)
        {
            if (EntityTypeBuilder != null)
            {
                return new EntityBuilderAdapter(EntityTypeBuilder.OwnsOne(ownedType, navigationName));
            }
            else
            {
                return new EntityBuilderAdapter(OwnedNavigationBuilder!.OwnsOne(ownedType, navigationName));
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
