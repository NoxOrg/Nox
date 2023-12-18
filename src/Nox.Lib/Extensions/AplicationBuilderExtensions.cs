using Microsoft.AspNetCore.Builder;

namespace Nox
{
    public static class ApplicationBuilderBuilderExtensions
    {
        /// <summary>
        /// Uses Nox Default Features
        /// </summary>
        public static IApplicationBuilder UseNox(this IApplicationBuilder builder, Action<INoxUseOptions>? configure = null)
        {
            NoxUseOptions configurator = new();
            configure?.Invoke(configurator);
            configurator.Configure(builder);

            return builder;
        }
    }
}