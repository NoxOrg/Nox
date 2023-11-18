// Generated

#nullable enable
using Microsoft.AspNetCore.Mvc;

using DtoNameSpace = SampleWebApp.Application.Dto;
using ApplicationQueriesNameSpace = SampleWebApp.Application.Queries;

namespace SampleWebApp.Presentation.Api.OData;

public abstract partial class CountriesControllerBase
{
    [HttpGet("/api/v1/Countries/CountryContinents")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.CountryContinentDto>>> GetContinentsNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetCountriesContinentsQuery(_cultureCode));                        
        return Ok(result);        
    }
}
