using Nox.Types;

namespace Nox.Abstractions.Infrastructure.Persistence
{
    public interface INoxDatabaseProvider
    {
        string ToDatabaseColumnType<T, TO>(TO options) where T : INoxType where TO : class; //TODO TO INoxOptions?
    }
}