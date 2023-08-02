using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OData;
using Nox.Lib;

namespace Nox
{
    public static class ApplicationBuilderBuilderExtensions
    {
        public static void UseNox(this IApplicationBuilder builder)
        {
#if DEBUG
            builder.UseODataRouteDebug();
#endif
            builder.UseMiddleware<NoxExceptionHanderMiddleware>();
        }
    }
}