using Nox;

using ClientApi.Infrastructure.Persistence;
using ClientApi.Application.Dto;
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
        services.AddNox((oDataModelBuilder) => {
            //Example register a custom odata function
            oDataModelBuilder.Function("countriesWithDebt").ReturnsCollectionFromEntitySet<CountryDto>("Countries");
            oDataModelBuilder.ConfigureHouseDto();
        })
        .AddEndpointsApiExplorer()
        .AddSwaggerGen(); 
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();
        
        app.UseNox();

        app.UseSwagger();

        var clientApiDbContext = app.ApplicationServices.GetRequiredService<ClientApiDbContext>();
        clientApiDbContext!.Database.EnsureDeleted();
        clientApiDbContext!.Database.EnsureCreated();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}