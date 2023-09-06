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
        builder.EntityType<CountryLocalNameDto>().HasKey(e => new { e.Id });
        builder.EntityType<StoreDto>().HasKey(e => new { e.Id });
        builder.EntityType<WorkplaceDto>().HasKey(e => new { e.Id });
        builder.EntityType<StoreOwnerDto>().HasKey(e => new { e.Id });
        builder.EntityType<EmailAddressDto>().HasKey(e => new { e.Id });


        builder.EntitySet<CountryDto>("Countries");
        builder.EntityType<CountryDto>().ContainsMany(e => e.CountryLocalNames).AutoExpand = true;

        builder.EntityType<CountryDto>();
        builder.EntityType<CountryKeyDto>();
        builder.EntityType<CountryDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntityType<CountryLocalNameDto>();
        builder.EntityType<CountryLocalNameKeyDto>();

        builder.EntitySet<StoreDto>("Stores");
        builder.EntityType<StoreDto>().ContainsOptional(e => e.EmailAddress).AutoExpand = true;

        builder.EntityType<StoreDto>();
        builder.EntityType<StoreKeyDto>();
        builder.EntityType<StoreDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntitySet<WorkplaceDto>("Workplaces");

        builder.EntityType<WorkplaceDto>();
        builder.EntityType<WorkplaceKeyDto>();

        builder.EntitySet<StoreOwnerDto>("StoreOwners");

        builder.EntityType<StoreOwnerDto>();
        builder.EntityType<StoreOwnerKeyDto>();
        builder.EntityType<StoreOwnerDto>().Ignore(e => e.DeletedAtUtc);

        builder.EntityType<EmailAddressDto>();
        builder.EntityType<EmailAddressKeyDto>();

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
