// Generated
#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.OData.Query;

using Microsoft.AspNetCore.Mvc;
using Nox.Application.Dto;

using DtoNameSpace = ClientApi.Application.Dto;
using ApplicationQueriesNameSpace = ClientApi.Application.Queries;
using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class TenantsControllerBase
{
    [HttpGet("/api/v1/Tenants/TenantStatuses")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.TenantStatusDto>>> GetStatusesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetTenantsStatusesQuery(_cultureCode));                        
        return Ok(result);        
    } 
}
