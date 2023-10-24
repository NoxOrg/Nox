using Nox;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Application.Dto;
using ClientApi.Tests.Application.Dto;
using Microsoft.AspNetCore.Hosting;
using System;

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
        },
        (odataOptions) =>
        {
            //Example register a custom odata function
            odataOptions.Function("countriesWithDebt").ReturnsCollectionFromEntitySet<CountryDto>("Countries");
            odataOptions.ConfigureHouseDto();
        })
        .AddEndpointsApiExplorer();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();

        app.UseNox(false);

        // Ensure a new / clean db for each test
        var appDbContext = app.ApplicationServices.GetRequiredService<AppDbContext>();
        appDbContext!.Database.EnsureDeleted();
        appDbContext!.Database.EnsureCreated();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}