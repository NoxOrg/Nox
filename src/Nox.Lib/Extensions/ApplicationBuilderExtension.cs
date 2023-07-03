using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Nox.Logging;

namespace Nox;

public static class ApplicationBuilderExtension
{
    public static WebApplicationBuilder AddNox(this WebApplicationBuilder appBuilder)
    {
        appBuilder.Logging.AddLogging(appBuilder.Configuration, ServiceCollectionExtension.Solution);
        return appBuilder;
    }
}