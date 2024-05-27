// Generated
#nullable enable

using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Nox.Lib;
using CryptocashIntegration.Application.Dto;
using DtoNameSpace = CryptocashIntegration.Application.Dto;

namespace CryptocashIntegration.Presentation.Api.OData;

internal static class ODataServiceCollectionExtensions
{
    public static void AddNoxOdata(this IServiceCollection services)
    {
        services.AddNoxOdata(null);
    }
    public static void AddNoxOdata(this IServiceCollection services, Action<ODataModelBuilder>? configure)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();
        
        // Odata requires/likes complex type to be registered before entity types and sets
        builder.ComplexType<CountryQueryToTablePartialUpdateDto>();
        builder.ComplexType<CountryJsonToTablePartialUpdateDto>();

        builder.EntitySet<CountryQueryToTableDto>("CountryQueryToTables");
		builder.EntityType<CountryQueryToTableDto>().HasKey(e => new { e.Id });

        builder.EntitySet<CountryJsonToTableDto>("CountryJsonToTables");
		builder.EntityType<CountryJsonToTableDto>().HasKey(e => new { e.Id });

       
        if(configure != null) configure(builder);

        services.AddControllers()
            .AddOData(options =>
                {
                    options.Select()
                        .EnableQueryFeatures(null)
                        .Filter()
                        .OrderBy()
                        .Count()
                        .Expand()
                        .SkipToken()
                        .SetMaxTop(100);
                    var routeOptions = options.AddRouteComponents(Nox.Presentation.Api.OData.ODataApi.GetRoutePrefix("/api"), builder.GetEdmModel(),
                        service => service
                            .AddSingleton<IODataSerializerProvider, NoxODataSerializerProvider>())
                        .RouteOptions;
                    routeOptions.EnableKeyInParenthesis = false;
                }
            );
    }
}
