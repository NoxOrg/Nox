// Generated

using System.Collections.Generic;
#nullable enable
using Microsoft.AspNetCore.Mvc;
using Nox.Application.Dto;

using DtoNameSpace = ClientApi.Application.Dto;
using ApplicationQueriesNameSpace = ClientApi.Application.Queries;
using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class WorkplacesControllerBase
{
    [HttpGet("/api/v1/Workplaces/WorkplaceOwnerships")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.WorkplaceOwnershipDto>>> GetOwnershipsNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetWorkplacesOwnershipsQuery(_cultureCode));                        
        return Ok(result);        
    } 
}
