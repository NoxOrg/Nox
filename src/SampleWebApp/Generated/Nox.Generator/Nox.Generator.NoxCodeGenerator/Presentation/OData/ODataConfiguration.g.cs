// Generated

#nullable enable

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using SampleService.Domain;

namespace SampleService.Presentation.Api.OData;

public partial class ODataConfiguration
{
    public static void Register(IServiceCollection services)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();
        
        builder.EntitySet<Country>("Countries");
        builder.EntitySet<Currency>("Currencies");
        builder.EntitySet<CountryLocalNames>("CountryLocalNames");
        builder.EntitySet<CurrencyCashBalance>("CurrencyCashBalances");
        
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
