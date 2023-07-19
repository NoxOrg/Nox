// generated

using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

namespace SampleWebApp.Examples2;

public partial class ODataConfiguration
{
    public static void Register(IServiceCollection services)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();

        builder.EntitySet<Country>("Countries");
        builder.EntitySet<Currency>("Currencies");
        builder.EntitySet<Store>("Stores");
        builder.EntitySet<CountryLocalNames>("CountryLocalNames");

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
                var routeOptions = options.AddRouteComponents("api", builder.GetEdmModel()).RouteOptions;
                routeOptions.EnableKeyInParenthesis = false;
            }
            );
    }
}
