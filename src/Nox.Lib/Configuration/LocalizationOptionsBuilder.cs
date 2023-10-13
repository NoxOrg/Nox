using Microsoft.Extensions.Configuration;

namespace Nox.Configuration;

public class LocalizationOptionsBuilder
{
    public IConfigurationRoot Configuration { get; }

    public LocalizationOptionsBuilder(IConfigurationRoot configuration)
    {
        Configuration = configuration;
    }
}