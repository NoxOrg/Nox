using System.Collections.Concurrent;
using Microsoft.Extensions.Localization;
using Nox.Localization.DbContext;

namespace Nox.Localization.Localizers;

public class SqlStringLocalizerFactory: IStringLocalizerFactory
{
    private const string _globalSourceName = "GLOBAL";

    private readonly INoxLocalizationDbContextFactory _contextFactory;

    private static readonly ConcurrentDictionary<string, IStringLocalizer> _resourceLocalizations = new ();

    public SqlStringLocalizerFactory(INoxLocalizationDbContextFactory contextFactory)
    {
        _contextFactory = contextFactory;
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

        var dbContext = _contextFactory.CreateContext();
        
        sqlStringLocalizer = new SqlStringLocalizer(resourceName, dbContext);

        return _resourceLocalizations.GetOrAdd(resourceName, sqlStringLocalizer);
    }
}