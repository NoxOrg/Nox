using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Nox.Extensions;

public static class ModelBuilderExtensions
{
    /// <summary>
    /// Applies action to each entity of specified type <typeparamref name="T"/>.
    /// </summary>
    /// <typeparam name="T">Generic type parameter.</typeparam>
    /// <param name="modelBuilder">The modelBuilder to act on.</param>
    /// <param name="action">The action to be executed.</param>
    public static ModelBuilder ForEntitiesOfType<T>(this ModelBuilder modelBuilder, Action<EntityTypeBuilder> action)
    {
        var entities = modelBuilder.Model.GetEntityTypes()
            .Where(e => typeof(T).IsAssignableFrom(e.ClrType)).Select(p => modelBuilder.Entity(p.ClrType));

        foreach (var entity in entities)
        {
            action(entity);
        }

        return modelBuilder;
    }
}
