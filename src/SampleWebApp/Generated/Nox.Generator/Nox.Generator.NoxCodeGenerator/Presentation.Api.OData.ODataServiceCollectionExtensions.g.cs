// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Nox.Lib;
using SampleWebApp.Application.Dto;

namespace SampleWebApp.Presentation.Api.OData;

public static class ODataServiceCollectionExtensions
{
    public static void AddNoxOdata(this IServiceCollection services)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();

        builder.EntityType<CountryDto>().HasKey(e => new { e.Id });
        builder.EntityType<CurrencyDto>().HasKey(e => new { e.Id });
        builder.EntityType<StoreDto>().HasKey(e => new { e.Id });
        builder.EntityType<StoreSecurityPasswordsDto>().HasKey(e => new { e.Id });
        builder.EntityType<StoreOwnerDto>().HasKey(e => new { e.Id });
        builder.EntityType<AllNoxTypeDto>().HasKey(e => new { e.Id, e.TextId });
        builder.EntityType<CurrencyCashBalanceDto>().HasKey(e => new { e.StoreId, e.CurrencyId });
        builder.EntityType<CountryLocalNameDto>().HasKey(e => new { e.Id });


        builder.EntitySet<CountryDto>("Countries");
        builder.EntityType<CountryDto>().ContainsMany(e => e.CountryLocalNames).AutoExpand = true;

        builder.EntityType<CountryDto>();
        builder.EntityType<CountryKeyDto>();
        builder.EntityType<CountryDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CountryDto>().Ignore(e => e.Etag);

        builder.EntitySet<CurrencyDto>("Currencies");

        builder.EntityType<CurrencyDto>();
        builder.EntityType<CurrencyKeyDto>();
        builder.EntityType<CurrencyDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CurrencyDto>().Ignore(e => e.Etag);

        builder.EntitySet<StoreDto>("Stores");

        builder.EntityType<StoreDto>();
        builder.EntityType<StoreKeyDto>();
        builder.EntityType<StoreDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<StoreDto>().Ignore(e => e.Etag);

        builder.EntitySet<StoreSecurityPasswordsDto>("StoreSecurityPasswords");

        builder.EntityType<StoreSecurityPasswordsDto>();
        builder.EntityType<StoreSecurityPasswordsKeyDto>();
        builder.EntityType<StoreSecurityPasswordsDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<StoreSecurityPasswordsDto>().Ignore(e => e.Etag);

        builder.EntitySet<StoreOwnerDto>("StoreOwners");

        builder.EntityType<StoreOwnerDto>();
        builder.EntityType<StoreOwnerKeyDto>();
        builder.EntityType<StoreOwnerDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<StoreOwnerDto>().Ignore(e => e.Etag);

        builder.EntitySet<AllNoxTypeDto>("AllNoxTypes");

        builder.EntityType<AllNoxTypeDto>();
        builder.EntityType<AllNoxTypeKeyDto>();
        builder.EntityType<AllNoxTypeDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<AllNoxTypeDto>().Ignore(e => e.Etag);

        builder.EntitySet<CurrencyCashBalanceDto>("CurrencyCashBalances");

        builder.EntityType<CurrencyCashBalanceDto>();
        builder.EntityType<CurrencyCashBalanceKeyDto>();
        builder.EntityType<CurrencyCashBalanceDto>().Ignore(e => e.DeletedAtUtc);
        builder.EntityType<CurrencyCashBalanceDto>().Ignore(e => e.Etag);

        builder.EntityType<CountryLocalNameDto>();
        builder.EntityType<CountryLocalNameKeyDto>();

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
