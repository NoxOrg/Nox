// Generated

using System.Collections.Generic;
#nullable enable
using Microsoft.AspNetCore.Mvc;
using Nox.Application.Dto;

using DtoNameSpace = ClientApi.Application.Dto;
using ApplicationQueriesNameSpace = ClientApi.Application.Queries;
using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class PeopleControllerBase
{
    [HttpGet("/api/v1/People/PersonStatuses")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.PersonStatusDto>>> GetStatusesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetPeopleStatusesQuery(_cultureCode));                        
        return Ok(result);        
    }
    [HttpGet("/api/v1/People/PersonPreferredLoginMethods")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.PersonPreferredLoginMethodDto>>> GetPreferredLoginMethodsNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetPeoplePreferredLoginMethodsQuery(_cultureCode));                        
        return Ok(result);        
    } 
}
