// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

namespace SampleWebApp.Presentation.Api.OData;

public partial class ODataConfiguration
{
    public static void Register(IServiceCollection services)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();
        
        builder.EntitySet<OCountry>("Countries");
        builder.EntitySet<OCurrency>("Currencies");
        builder.EntitySet<OStore>("Stores");
        builder.EntitySet<OCountryLocalNames>("CountryLocalNames");
        
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
