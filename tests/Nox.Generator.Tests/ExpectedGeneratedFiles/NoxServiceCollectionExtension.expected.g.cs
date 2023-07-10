// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using Nox;
using Nox.Types.EntityFramework.Abstractions;
using SampleWebApp.Infrastructure.Persistence;

public static class NoxServiceCollectionExtension
{
    public static IServiceCollection AddNox(this IServiceCollection services)
    {
        services.AddNoxLib();
        return services;
    }
}
