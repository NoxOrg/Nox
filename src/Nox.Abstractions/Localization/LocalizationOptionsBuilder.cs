using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Nox.Abstractions.Localization;

public class LocalizationOptionsBuilder
{
    public IConfigurationRoot Configuration { get; }

    public LocalizationOptionsBuilder(IConfigurationRoot configuration)
    {
        Configuration = configuration;
    }
}