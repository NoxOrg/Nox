using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace Nox;

public static class ApplicationBuilderBuilderExtensions
{
    /// <summary>
    /// Uses Nox Default Features
    /// </summary>
    public static IApplicationBuilder UseNox(this IApplicationBuilder builder, IHostEnvironment env, Action<INoxUseOptions>? configure = null)
    {
        NoxUseOptions configurator = new();

        configure?.Invoke(configurator);
        configurator.Configure(builder, env);

        return builder;
    }
}