using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nox.Solution;


/// <summary>
/// All Files in this Folder will move to Nox.Types.EntityFramework, it has a EF dependency and its for EF setup
/// It here just for the sake of review and accelerate development
/// </summary>
namespace Nox.Types.EntityFramework.Sqlite.ToMoveEF
{
    public interface INoxDatabaseConfiguration
    {
        void ConfigureEntityProperty<TEntity, TProperty>(NoxSolution noxSolution,
            string propertyName,
            EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, TProperty>> property) where TEntity : class where TProperty : class;
    }

    public interface INoxTypeDatabaseConfiguration
    {
        void ConfigureEntityProperty<TEntity, TProperty>(NoxSolution noxSolution,
            string propertyName,
            EntityTypeBuilder<TEntity> builder,
            Expression<Func<TEntity, TProperty>> property) where TEntity : class where TProperty : class;
    }
}