
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Nox.Infrastructure.Persistence
{
    /// <summary>
    /// Marker interface to identify the application's DbContext.
    /// </summary>
    public interface IAppDbContext 
    {
        EntityEntry Remove(object entity);
    }
}
