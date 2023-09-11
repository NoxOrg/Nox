using ClientApi.Infrastructure.Persistence;
using ClientApi.Application.Dto;
using Nox;
using ClientApi.Tests.Application.Dto;

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
        services.AddNox((oDataBuilder) => {
            //Example register a custom odata function
            oDataBuilder.Function("countriesWithDebt").ReturnsCollectionFromEntitySet<CountryDto>("Countries");
            //example registering custom dto in Odata
            oDataBuilder.EntitySet<HouseDto>("Houses");
            oDataBuilder.EntityType<HouseDto>().HasKey(e => new { e.Id });
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        
        app.UseNox();
    
        var clientApiDbContext = app.ApplicationServices.GetRequiredService<ClientApiDbContext>();
        clientApiDbContext!.Database.EnsureDeleted();
        clientApiDbContext!.Database.EnsureCreated();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}