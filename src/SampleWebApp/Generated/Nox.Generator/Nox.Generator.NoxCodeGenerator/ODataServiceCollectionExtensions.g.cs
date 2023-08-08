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

        builder.EntitySet<CountryDto>("Countries");

        builder.EntitySet<CurrencyDto>("Currencies");

        builder.EntitySet<StoreDto>("Stores");

        builder.EntitySet<StoreSecurityPasswordsDto>("StoreSecurityPasswords");

        builder.EntitySet<AllNoxTypeDto>("AllNoxTypes");

        builder.EntitySet<MultipleIdsTypeDto>("MultipleIdsTypes");

        builder.EntitySet<CountryLocalNamesDto>("CountryLocalNames");

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
