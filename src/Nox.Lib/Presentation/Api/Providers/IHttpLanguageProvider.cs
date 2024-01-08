using Nox.Types;

namespace Nox.Presentation.Api.Providers;

public interface IHttpLanguageProvider
{
    CultureCode GetLanguage();
}