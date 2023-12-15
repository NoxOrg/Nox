using Nox;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Application.Dto;
using ClientApi.Tests.Application.Dto;
using Microsoft.AspNetCore.Hosting;
using System;
using Nox.Configuration;

namespace ClientApi.Tests;

public class StartupFixture
{
    public StartupFixture(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {        
        services.AddNox(
            null,
        (noxOptions) =>
        {
            // No Transactional Outbox in tests
            noxOptions.WithoutMessagingTransactionalOutbox();
#if RELEASE
            noxOptions.WithoutNoxLogging();
#endif
        },
        (odataOptions) =>
        {
            //Example register a custom odata function
            odataOptions.Function("countriesWithDebt").ReturnsCollectionFromEntitySet<CountryDto>("Countries");
            odataOptions.ConfigureHouseDto();
        })
#if RELEASE
        .AddLogging(configure => configure.SetMinimumLevel(LogLevel.Error))
#endif
        .AddEndpointsApiExplorer();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseNox(options => options.UseRequestLogging(false));

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}