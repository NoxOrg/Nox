// Generated

#nullable enable
using Microsoft.AspNetCore.Mvc;

using DtoNameSpace = ClientApi.Application.Dto;
using ApplicationQueriesNameSpace = ClientApi.Application.Queries;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class CountriesControllerBase
{
    [HttpGet("api/Countries/Continents")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.CountryContinentDto>>> GetContinentsNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetCountriesContinentsQuery());                        
        return Ok(result);        
    }
}
