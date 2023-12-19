using Microsoft.EntityFrameworkCore.Diagnostics;
using Nox.Presentation.Api;
using Nox.Presentation.Api.Providers;
using System.Data.Common;

namespace Nox.Infrastructure.Persistence;

public class LangParamDbCommandInterceptor : DbCommandInterceptor
{
    private readonly IHttpLanguageProvider _languageProvider;

    public LangParamDbCommandInterceptor(IHttpLanguageProvider languageProvider)
    {
        _languageProvider = languageProvider;
    }

    public override InterceptionResult<DbDataReader> ReaderExecuting(
        DbCommand command,
        CommandEventData eventData,
        InterceptionResult<DbDataReader> result)
    {
        if (command.CommandText.Contains("##LANG##"))
        {
            var lang = _languageProvider.GetLanguage();

            var query = command.CommandText;
            var newQuery = query.Replace("##LANG##", $"{lang.Value}");

            command.CommandText = newQuery;
        }

        return result;
    }
}
