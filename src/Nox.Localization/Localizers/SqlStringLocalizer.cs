using System.Collections.Concurrent;
using System.Globalization;
using Microsoft.Extensions.Localization;
using Nox.Localization.DbContext;
using Nox.Localization.Models;

namespace Nox.Localization.Localizers;

public class SqlStringLocalizer: IStringLocalizer
{
    private readonly string _resourceKey;

    private readonly NoxLocalizationDbContext _dbContext;

    private static readonly ConcurrentDictionary<string, string> _localizations = new ();

    public SqlStringLocalizer(string resourceName, NoxLocalizationDbContext dbContext)
    {
        _resourceKey = resourceName;
        _dbContext = dbContext;
    }

    public LocalizedString this[string name]
    {
        get
        {
            bool notSucceed;
            var text = GetText(name, out notSucceed);

            return new LocalizedString(name, text, notSucceed, nameof(NoxLocalizationDbContext));
        }
    }

    public LocalizedString this[string name, params object[] arguments]
    {
        get
        {
            var localizedString = this[name];
            return new LocalizedString(name, 
                string.Format(localizedString.Value, arguments), 
                localizedString.ResourceNotFound, 
                localizedString.SearchedLocation);
        }
    }

    public IEnumerable<LocalizedString> GetAllStrings(bool includeParentCultures)
    {
        var culture = CultureInfo.CurrentCulture;

        return _dbContext.Translations.Where(t =>
            t.CultureCode == culture.Name || t.CultureCode == culture.TwoLetterISOLanguageName
        ).Select(t => new LocalizedString(t.Key, t.Text, false, nameof(NoxLocalizationDbContext)));
    }

    private string GetText(string key, out bool notSucceed)
    {

        notSucceed = false;

        var culture = CultureInfo.CurrentCulture;

        if (_localizations.TryGetValue($"{_resourceKey}.{key}.{culture}", out var text))
        {
            return text;
        }

        var translation = _dbContext.Translations.SingleOrDefault(t =>
            t.Key == key && t.ResourceKey == _resourceKey
            && (
                t.CultureCode == culture.Name
                || t.CultureCode == culture.TwoLetterISOLanguageName
            )
        );

        if (translation == null)
        {
            notSucceed = true;

            // no translation for culture record exists on db. Add it.
            translation = new Translation()
            {
                CultureCode = culture.Name,
                Key = key,
                Text = key,
                ResourceKey = _resourceKey,
                Validated = false,
                LastUpdatedUtc = DateTime.UtcNow,
            };

            lock (_dbContext)
            {
                _dbContext.Translations.Add(translation);
                _dbContext.SaveChanges();
            }
        }

        _localizations.TryAdd($"{_resourceKey}.{key}.{culture}", translation.Text);

        return translation.Text;

    }
}