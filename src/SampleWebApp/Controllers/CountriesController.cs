using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using SampleWebApp.Application.Queries;

namespace SampleWebApp.Presentation.Api.OData;

/// <summary>
/// Extending a OData controller example with additional queries (Action) and commands (Functions)
/// </summary>
public partial class CountriesController
{
    [HttpGet("GetCountriesIManage")]
    public async Task<IResult> GetCountriesIManage()
    {
        var result = await _mediator.Send(new GetCountriesIManageQuery());
        return Results.Ok(result);
    }
}