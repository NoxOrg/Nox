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
using Cryptocash.Application;
using Cryptocash.Application.Dto;
using Cryptocash.Application.Queries;
using Cryptocash.Application.Commands;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Nox.Types;

namespace Cryptocash.Presentation.Api.OData;

public abstract partial class LandLordsControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToVendingMachines([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefLandLordToVendingMachinesCommand(new LandLordKeyDto(key), new VendingMachineKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToVendingMachines([FromRoute] System.Int64 key, [FromBody] VendingMachineCreateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        vendingMachine.LandLordId = key;
        var createdKey = await _mediator.Send(new CreateVendingMachineCommand(vendingMachine, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetVendingMachineByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToVendingMachines([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetLandLordByIdQuery(key))).Select(x => x.VendingMachines).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"VendingMachines/{item.Id}", UriKind.Relative));
        }
        
        vendingMachine.LandLordId = key;
        var createdKey = await _mediator.Send(new CreateVendingMachineCommand(vendingMachine, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetVendingMachineByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<VendingMachineDto>>> GetVendingMachines(System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetLandLordByIdQuery(key))).SelectMany(x => x.VendingMachines);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/LandLords/{key}/VendingMachines/{relatedKey}")]
    public virtual async Task<SingleResult<VendingMachineDto>> GetVendingMachinesNonConventional(System.Int64 key, System.Guid relatedKey)
    {
        var related = (await _mediator.Send(new GetLandLordByIdQuery(key))).SelectMany(x => x.VendingMachines).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<VendingMachineDto>(Enumerable.Empty<VendingMachineDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    public async Task<ActionResult> DeleteRefToVendingMachines([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefLandLordToVendingMachinesCommand(new LandLordKeyDto(key), new VendingMachineKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToVendingMachines([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefLandLordToVendingMachinesCommand(new LandLordKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/LandLords/{key}/VendingMachines/{relatedKey}")]
    public async Task<ActionResult> DeleteToVendingMachines([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetLandLordByIdQuery(key))).SelectMany(x => x.VendingMachines).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteVendingMachineByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/LandLords/{key}/VendingMachines")]
    public async Task<ActionResult> DeleteToVendingMachines([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetLandLordByIdQuery(key))).Select(x => x.VendingMachines).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        foreach(var item in related)
        {
            await _mediator.Send(new DeleteVendingMachineByIdCommand(item.Id, etag));
        }
        return NoContent();
    }
    
    [HttpPut("/api/v1/LandLords/{key}/VendingMachines/{relatedKey}")]
    public virtual async Task<ActionResult<VendingMachineDto>> PutToVendingMachinesNonConventional(System.Int64 key, System.Guid relatedKey, [FromBody] VendingMachineUpdateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetLandLordByIdQuery(key))).SelectMany(x => x.VendingMachines).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateVendingMachineCommand(relatedKey, vendingMachine, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
