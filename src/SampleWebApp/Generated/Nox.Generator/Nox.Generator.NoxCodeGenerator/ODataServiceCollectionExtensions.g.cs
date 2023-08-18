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
        builder.EntityType<AllNoxTypeDto>().HasKey(e => new { e.Id, e.TextId });
        builder.EntityType<CurrencyCashBalanceDto>().HasKey(e => new { e.StoreId, e.CurrencyId });
        builder.EntityType<CountryLocalNamesDto>().HasKey(e => new { e.Id });


        builder.EntitySet<CountryDto>("Countries");
        builder.EntityType<CountryKeyDto>();

        builder.EntitySet<CurrencyDto>("Currencies");
        builder.EntityType<CurrencyKeyDto>();

        builder.EntitySet<StoreDto>("Stores");
        builder.EntityType<StoreKeyDto>();

        builder.EntitySet<StoreSecurityPasswordsDto>("StoreSecurityPasswords");
        builder.EntityType<StoreSecurityPasswordsKeyDto>();

        builder.EntitySet<AllNoxTypeDto>("AllNoxTypes");
        builder.EntityType<AllNoxTypeKeyDto>();

        builder.EntitySet<CurrencyCashBalanceDto>("CurrencyCashBalances");
        builder.EntityType<CurrencyCashBalanceKeyDto>();

        builder.EntitySet<CountryLocalNamesDto>("CountryLocalNames");
        builder.EntityType<CountryLocalNamesKeyDto>();

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
