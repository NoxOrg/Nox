// Generated

using System.Collections.Generic;
#nullable enable
using Microsoft.AspNetCore.Mvc;
using Nox.Application.Dto;

using DtoNameSpace = ClientApi.Application.Dto;
using ApplicationQueriesNameSpace = ClientApi.Application.Queries;
using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class CountriesControllerBase
{
    [HttpGet("/api/v1/Countries/CountryContinents")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.CountryContinentDto>>> GetContinentsNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetCountriesContinentsQuery(_cultureCode));                        
        return Ok(result);        
    }
    [HttpGet("/api/v1/Countries/CountryContinentsLocalized")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.CountryContinentLocalizedDto>>> GetContinentsLocalizedNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetCountriesContinentsTranslationsQuery());                        
        return Ok(result);        
    }

    [HttpDelete("/api/v1/Countries/CountryContinentsLocalized/{cultureCode}")]
    public virtual async Task<ActionResult> DeleteContinentsLocalizedNonConventional([FromRoute] System.String cultureCode)
    {            
        var result = await _mediator.Send(new ApplicationCommandsNameSpace.DeleteCountriesContinentsTranslationsCommand(Nox.Types.CultureCode.From(cultureCode)));                        
        return NoContent();     
    }

    [HttpPut("/api/v1/Countries/CountryContinentsLocalized")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.CountryContinentLocalizedDto>>> PutContinentsLocalizedNonConventional([FromBody] EnumerationLocalizedList<DtoNameSpace.CountryContinentLocalizedDto> countryContinentLocalizedDtos)
    {            
        var result = await _mediator.Send(new ApplicationCommandsNameSpace.UpsertCountriesContinentsTranslationsCommand(countryContinentLocalizedDtos.Items));                        
        return Ok(result);       
    } 
}
