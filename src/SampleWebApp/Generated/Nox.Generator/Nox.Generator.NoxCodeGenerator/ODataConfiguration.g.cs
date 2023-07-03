// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using SampleWebApp.Domain;
namespace SampleWebApp.Presentation.Api.OData;

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
            .AddOData(options => options
                .Select()
                .Filter()
                .OrderBy()
                .Count()
                .Expand()
                .SkipToken()
                .SetMaxTop(100)
                .AddRouteComponents("api", builder.GetEdmModel())
            );
    }
}
