using Nox.Types;

namespace Nox.Presentation.Api;

public interface IHttpLanguageProvider
{
    CultureCode GetLanguage();
}