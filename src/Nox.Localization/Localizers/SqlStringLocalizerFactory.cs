using System.Collections.Concurrent;
using Microsoft.Extensions.Localization;
using Nox.Localization.DbContext;

namespace Nox.Localization.Localizers;

public class SqlStringLocalizerFactory: IStringLocalizerFactory
{
    private const string _globalSourceName = "GLOBAL";

    private readonly NoxLocalizationDbContext _dbContext;

    private static readonly ConcurrentDictionary<string, IStringLocalizer> _resourceLocalizations = new ();

    public SqlStringLocalizerFactory(NoxLocalizationDbContext dbContext)
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