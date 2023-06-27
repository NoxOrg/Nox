// generated

using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using SampleWebApp.Domain;

namespace SampleWebApp.Examples;

public partial class ODataConfiguration
{
    public static void Register(IServiceCollection services)
    {
        ODataModelBuilder builder = new ODataConventionModelBuilder();

        builder.EntitySet<Country>("Countries");
        builder.EntitySet<Currency>("Currencies");
        builder.EntitySet<CountryLocalNames>("CountryLocalNames");
        //TODO Solve Composite Keys for Entities, that do not have an Id
        // builder.EntitySet<CurrencyCashBalance>("CurrencyCashBalances");

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
