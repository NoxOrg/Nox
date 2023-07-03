using Microsoft.AspNetCore.Builder;
using Nox.Monitoring;

namespace Nox;

public static class MiddlewareExtension
{
    public static void UseNox(this IApplicationBuilder builder)
    {
        builder.UseMonitoring(ServiceCollectionExtension.Solution);
    }
}