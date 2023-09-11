using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;


namespace ClientApi.Presentation.Api.OData;

/// <summary>
/// Example of extending a controller with additional end points
/// </summary>
public partial class CountriesController 
{

    [HttpGet("api/Countries/CountriesWithDebt")]
    public async Task<ActionResult<IEnumerable<Application.Dto.CountryDto>>> CountriesWithDebt()
    {
        // Simulate some work
        await Task.Delay(1);
        return new List<Application.Dto.CountryDto>() {
            new Application.Dto.CountryDto()
            {
                Id = 1
            }
        };
    }
}
