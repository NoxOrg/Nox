// Generated

#nullable enable
{{~ for namespace in namespaces}}
using {{ namespace ~}};
{{- end }}

public static class NoxWebApplicationBuilderExtension
{
    public static IServiceCollection AddNox(this IServiceCollection services)
    {
        return services.AddNox(null);
    }

    public static IServiceCollection AddNox(this IServiceCollection services, Action<ODataModelBuilder>? configureOData)
    {
        services.AddNoxLib(Assembly.GetExecutingAssembly());
        services.AddNoxOdata(configureOData);
        services.AddSingleton(typeof(INoxClientAssemblyProvider), s => new NoxClientAssemblyProvider(Assembly.GetExecutingAssembly()));
        services.AddSingleton<DbContextOptions<{{ dbContext }}>>();
        services.AddSingleton<INoxDatabaseConfigurator, {{ dbProvider }}>();
        services.AddSingleton<INoxDatabaseProvider, {{ dbProvider }}>();
        services.AddDbContext<{{ dbContext }}>();
        services.AddDbContext<DtoDbContext>();
        return services;
    }
}
