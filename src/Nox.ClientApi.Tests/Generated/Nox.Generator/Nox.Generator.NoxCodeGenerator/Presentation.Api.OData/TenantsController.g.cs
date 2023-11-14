// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using System.Net.Http.Headers;
using Nox.Application;
using Nox.Extensions;
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;
using Nox.Types;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class TenantsControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToWorkplaces([FromRoute] System.Guid key, [FromRoute] System.UInt32 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTenantToWorkplacesCommand(new TenantKeyDto(key), new WorkplaceKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToWorkplaces([FromRoute] System.Guid key, [FromBody] WorkplaceCreateDto workplace)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        workplace.TenantsId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateWorkplaceCommand(workplace, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetWorkplaceByIdQuery(_cultureCode, createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToWorkplaces([FromRoute] System.Guid key)
    {
        var related = (await _mediator.Send(new GetTenantByIdQuery(key))).Select(x => x.Workplaces).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"Workplaces/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToWorkplaces([FromRoute] System.Guid key, [FromRoute] System.UInt32 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTenantToWorkplacesCommand(new TenantKeyDto(key), new WorkplaceKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToWorkplaces([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTenantToWorkplacesCommand(new TenantKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/Tenants/{key}/Workplaces/{relatedKey}")]
    public virtual async Task<ActionResult<WorkplaceDto>> PutToWorkplacesNonConventional(System.Guid key, System.UInt32 relatedKey, [FromBody] WorkplaceUpdateDto workplace)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetTenantByIdQuery(key))).Select(x => x.Workplaces).SingleOrDefault()?.Any(x => x.Id == relatedKey);
        if (related == null || related == false)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateWorkplaceCommand(relatedKey, workplace, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
