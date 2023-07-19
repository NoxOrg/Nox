using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Nox.Logging;
using Nox.Solution;

namespace Nox;

public static class ApplicationBuilderExtension
{
    public static WebApplicationBuilder AddNoxApp(this WebApplicationBuilder appBuilder)
    {
        using var serviceProvider = appBuilder.Services.BuildServiceProvider();
        NoxSolution noxSolution = (serviceProvider.GetRequiredService(typeof(NoxSolution)) as NoxSolution)!;
        appBuilder.Logging.AddLogging(appBuilder.Configuration, noxSolution);
        return appBuilder;
    }
}