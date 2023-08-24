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

        builder.EntityType<CountryDto>().HasKey(e => new { e.Id });
        builder.EntityType<ClientNuidDto>().HasKey(e => new { e.Id });
        builder.EntityType<OwnedEntityDto>().HasKey(e => new { e.Id });
        builder.EntityType<ClientDatabaseGuidDto>().HasKey(e => new { e.Id });


        builder.EntitySet<CountryDto>("Countries");
        builder.EntityType<CountryKeyDto>();
        builder.EntityType<CountryDto>().ContainsMany(e => e.OwnedEntities).AutoExpand = true;

        builder.EntityType<CountryDto>();
        builder.EntityType<CountryDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<ClientNuidDto>("ClientNuids");
        builder.EntityType<ClientNuidKeyDto>();

        builder.EntityType<ClientNuidDto>();
        builder.EntityType<ClientNuidDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntityType<OwnedEntityDto>();

        builder.EntitySet<ClientDatabaseGuidDto>("ClientDatabaseGuids");
        builder.EntityType<ClientDatabaseGuidKeyDto>();

        builder.EntityType<ClientDatabaseGuidDto>();

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
