// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Nox.Lib;
using ClientApi.Application.Dto;

namespace ClientApi.Presentation.Api.OData;

internal static class ODataServiceCollectionExtensions
{
    public static void AddNoxOdata(this IServiceCollection services)
    {
        services.AddNoxOdata(null);
    }
    public static void AddNoxOdata(this IServiceCollection services, Action<ODataModelBuilder>? configure)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();

        builder.EntityType<CountryDto>().HasKey(e => new { e.Id });
        builder.EntityType<CountryLocalNameDto>().HasKey(e => new { e.Id });
        builder.EntityType<CountryBarCodeDto>().HasKey(e => new { });
        builder.EntityType<RatingProgramDto>().HasKey(e => new { e.StoreId, e.Id });
        builder.EntityType<CountryQualityOfLifeIndexDto>().HasKey(e => new { e.CountryId, e.Id });
        builder.EntityType<StoreDto>().HasKey(e => new { e.Id });
        builder.EntityType<WorkplaceDto>().HasKey(e => new { e.Id });
        builder.EntityType<StoreOwnerDto>().HasKey(e => new { e.Id });
        builder.EntityType<StoreLicenseDto>().HasKey(e => new { e.Id });
        builder.EntityType<EmailAddressDto>().HasKey(e => new { });

        builder.EntitySet<CountryDto>("Countries");
        builder.EntityType<CountryDto>().ContainsMany(e => e.CountryShortNames).AutoExpand = true;
        builder.EntityType<CountryDto>().ContainsOptional(e => e.CountryBarCode).AutoExpand = true;
        builder.EntityType<CountryDto>().ContainsMany(e => e.PhysicalWorkplaces);

        builder.EntityType<CountryDto>();
        builder.EntityType<CountryDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CountryDto>().Ignore(e => e.Etag);
        builder.EntitySet<CountryLocalNameDto>("CountryLocalNames");

        builder.EntityType<CountryLocalNameDto>();

        builder.EntityType<CountryBarCodeDto>();
        builder.EntitySet<RatingProgramDto>("RatingPrograms");

        builder.EntityType<RatingProgramDto>();
        builder.EntitySet<CountryQualityOfLifeIndexDto>("CountryQualityOfLifeIndices");

        builder.EntityType<CountryQualityOfLifeIndexDto>();
        builder.EntitySet<StoreDto>("Stores");
        builder.EntityType<StoreDto>().ContainsOptional(e => e.VerifiedEmails).AutoExpand = true;
        builder.EntityType<StoreDto>().ContainsOptional(e => e.Ownership);
        builder.EntityType<StoreDto>().ContainsOptional(e => e.License);

        builder.EntityType<StoreDto>();
        builder.EntityType<StoreDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<StoreDto>().Ignore(e => e.Etag);
        builder.EntitySet<WorkplaceDto>("Workplaces");
        builder.EntityType<WorkplaceDto>().ContainsOptional(e => e.BelongsToCountry);

        builder.EntityType<WorkplaceDto>();
        builder.EntitySet<StoreOwnerDto>("StoreOwners");
        builder.EntityType<StoreOwnerDto>().ContainsMany(e => e.Stores);

        builder.EntityType<StoreOwnerDto>();
        builder.EntityType<StoreOwnerDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<StoreOwnerDto>().Ignore(e => e.Etag);
        builder.EntitySet<StoreLicenseDto>("StoreLicenses");
        builder.EntityType<StoreLicenseDto>().ContainsRequired(e => e.StoreWithLicense);

        builder.EntityType<StoreLicenseDto>();
        builder.EntityType<StoreLicenseDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<StoreLicenseDto>().Ignore(e => e.Etag);

        builder.EntityType<EmailAddressDto>();

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
                    var routeOptions = options.AddRouteComponents("api", builder.GetEdmModel(),
                        service => service
                            .AddSingleton<IODataSerializerProvider, NoxODataSerializerProvider>())
                        .RouteOptions;
                    routeOptions.EnableKeyInParenthesis = false;
                }
            );
    }
}
