// generated
using SampleWebApp.Presentation.Api.OData;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

namespace SampleWebApp.Examples2;

public partial class ODataConfiguration
{
    public static void Register(IServiceCollection services)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();

        builder.EntitySet<TenantWorkplace>("TenantWorkplaces");
        builder.EntitySet<TenantWorkplaceContact>("TenantWorkplaceContacts");
        builder.EntitySet<Country>("Countries");

        services.AddControllers()
            .AddOData(options =>
            {
                options
                    .EnableQueryFeatures(null)
                    .Select()
                    .Filter()
                    .OrderBy()
                    .Expand()
                    .SkipToken()
                    .SetMaxTop(100);

                var routeOptions = options.AddRouteComponents("api", builder.GetEdmModel()).RouteOptions;
                routeOptions.EnableKeyInParenthesis = false;
            }
            );
    }
}
