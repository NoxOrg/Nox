// Generated#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.OData.Query;

using Microsoft.AspNetCore.Mvc;
using Nox.Application.Dto;

using DtoNameSpace = ClientApi.Application.Dto;
using ApplicationQueriesNameSpace = ClientApi.Application.Queries;
using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class StoresControllerBase
{
    [HttpGet("/api/v1/Stores/Statuses")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.StoreStatusDto>>> GetStatusesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetStoresStatusesQuery(_cultureCode));                        
        return Ok(result);        
    } 
}
