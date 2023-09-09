using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;

namespace ClientApi.Presentation.Api.OData;

/// <summary>
/// Example of extending a controller with additional end points
/// </summary>
public partial class CountriesController
{
    /// <summary>
    /// Example o a OData Function with query enable
    /// <seealso cref="ClientApi.Tests.StartupFixture"/> how to add nox and configure a OData End point
    /// </summary>
    /// <returns>Prefer using Nox Solution Entity Definition (yaml) to register custom function</returns>
    [EnableQuery]
    [HttpGet("api/CountriesWithDebt")]
    public ActionResult<IQueryable<Application.Dto.CountryDto>> CountriesWithDebt()
    {                
        return Ok(new List<Application.Dto.CountryDto>() {
            new Application.Dto.CountryDto()
            {
                Id = 1
            }
        });
    }

    /// <summary>
    /// Example of a non OData end point. Prefer using Odata EndPoints 
    /// And  Nox Solution Entity Definition (yaml) to register custom function
    /// </summary>
    /// <returns></returns>
    [HttpGet("api/[controller]/[action]")]
    public ActionResult<IQueryable<Application.Dto.CountryDto>> CountriesWithDebt2()
    {
        return Ok(new List<Application.Dto.CountryDto>() {
            new Application.Dto.CountryDto()
            {
                Id = 1
            }
        });
    }
}
