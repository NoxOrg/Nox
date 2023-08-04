using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using System.Collections.Concurrent;

namespace Nox.Localization;
public class SqlStringLocalizerFactory : IStringLocalizerFactory
{
    private const string _globalSourceName = "GLOBAL";

    private readonly NoxDbContext _dbContext;

    private static readonly ConcurrentDictionary<string, IStringLocalizer> _resourceLocalizations = new ();

    public SqlStringLocalizerFactory(NoxDbContext dbContext)
    {
         _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    public IStringLocalizer Create(Type resourceSource)
    {
        return Create(resourceSource.FullName ?? _globalSourceName);
    }

    public IStringLocalizer Create(string baseName, string location)
    {
        return Create(baseName + location);        
    }

    private IStringLocalizer Create(string resourceName)
    {
        if (_resourceLocalizations.TryGetValue(resourceName, out var sqlStringLocalizer))
        {
            return sqlStringLocalizer;
        }

        sqlStringLocalizer = new SqlStringLocalizer(resourceName, _dbContext);

        return _resourceLocalizations.GetOrAdd(resourceName, sqlStringLocalizer);
    }
}
