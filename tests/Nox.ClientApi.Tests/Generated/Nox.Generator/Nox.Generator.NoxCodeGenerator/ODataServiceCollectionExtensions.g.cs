// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Nox.Lib;
using ClientApi.Application.Dto;

namespace ClientApi.Presentation.Api.OData;

public static class ODataServiceCollectionExtensions
{
    public static void AddNoxOdata(this IServiceCollection services)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();

        builder.EntityType<ClientDatabaseNumberDto>().HasKey(e => new { e.Id });
        builder.EntityType<ClientNuidDto>().HasKey(e => new { e.Id });


        builder.EntitySet<ClientDatabaseNumberDto>("ClientDatabaseNumbers");
        builder.EntityType<ClientDatabaseNumberKeyDto>();
        builder.EntityType<ClientDatabaseNumberDto>().Ignore(e => e.Deleted);

        builder.EntitySet<ClientNuidDto>("ClientNuids");
        builder.EntityType<ClientNuidKeyDto>();
        builder.EntityType<ClientNuidDto>().Ignore(e => e.Deleted);

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
                    var routeOptions = options.AddRouteComponents("api", builder.GetEdmModel(), service => service.AddSingleton<IODataSerializerProvider, NoxODataSerializerProvider>()).RouteOptions;
                    routeOptions.EnableKeyInParenthesis = false;
                }
            );
    }
}
