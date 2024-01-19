
namespace Nox.Application.Repositories
{
    /// <summary>
    /// Opted by define The read model in our application layer, since is not in any way related to the domain model.
    /// </summary>
    public interface IReadOnlyRepository
    {
        IQueryable<T> Query<T>() where T : class;
    }
}