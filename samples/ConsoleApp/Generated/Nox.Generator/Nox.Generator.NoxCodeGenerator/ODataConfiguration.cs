// Generated

using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using System.Web.Http;
using SampleService.Domain;

namespace SampleService.Presentation.Api.OData;

public partial class ODataConfiguration
{
    public static void Register(HttpConfiguration config)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();
        
        builder.EntitySet<Country>("Countries");
        builder.EntitySet<Currency>("Currencies");
        builder.EntitySet<CountryLocalNames>("CountryLocalNames");
        builder.EntitySet<CurrencyCashBalance>("CurrencyCashBalances");
        
        config.MapODataServiceRoute(
            routeName: "api",
            routePrefix: null,
            model: builder.GetEdmModel());
    }
}
