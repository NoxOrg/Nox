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
using Nox.Application.Dto;
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
    
    public virtual async Task<ActionResult> CreateRefToVendingMachines([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefLandLordToVendingMachinesCommand(new LandLordKeyDto(key), new VendingMachineKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/LandLords/{key}/VendingMachines/$ref")]
    public virtual async Task<ActionResult> UpdateRefToVendingMachinesNonConventional([FromRoute] System.Guid key, [FromBody] ReferencesDto<System.Guid> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new VendingMachineKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefLandLordToVendingMachinesCommand(new LandLordKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToVendingMachines([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetLandLordByIdQuery(key))).Include(x => x.VendingMachines).SingleOrDefault();
        if (entity is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.VendingMachines)
        {
            references.Add(new System.Uri($"VendingMachines/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToVendingMachines([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefLandLordToVendingMachinesCommand(new LandLordKeyDto(key), new VendingMachineKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToVendingMachines([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefLandLordToVendingMachinesCommand(new LandLordKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToVendingMachines([FromRoute] System.Guid key, [FromBody] VendingMachineCreateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        vendingMachine.LandLordId = key;
        var createdKey = await _mediator.Send(new CreateVendingMachineCommand(vendingMachine, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetVendingMachineByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<VendingMachineDto>>> GetVendingMachines(System.Guid key)
    {
        var query = await _mediator.Send(new GetLandLordByIdQuery(key));
        if (!query.Any())
        {
            return NotFound();
        }
        return Ok(query.Include(x => x.VendingMachines).SelectMany(x => x.VendingMachines));
    }
    
    [EnableQuery]
    [HttpGet("/api/LandLords/{key}/VendingMachines/{relatedKey}")]
    public virtual async Task<SingleResult<VendingMachineDto>> GetVendingMachinesNonConventional(System.Guid key, System.Guid relatedKey)
    {
        var related = (await _mediator.Send(new GetLandLordByIdQuery(key))).SelectMany(x => x.VendingMachines).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<VendingMachineDto>(Enumerable.Empty<VendingMachineDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/LandLords/{key}/VendingMachines/{relatedKey}")]
    public virtual async Task<ActionResult<VendingMachineDto>> PutToVendingMachinesNonConventional(System.Guid key, System.Guid relatedKey, [FromBody] VendingMachineUpdateDto vendingMachine)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
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
        
        var updatedItem = (await _mediator.Send(new GetVendingMachineByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/LandLords/{key}/VendingMachines/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToVendingMachines([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetLandLordByIdQuery(key))).SelectMany(x => x.VendingMachines).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteVendingMachineByIdCommand(new List<VendingMachineKeyDto> { new VendingMachineKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/LandLords/{key}/VendingMachines")]
    public virtual async Task<ActionResult> DeleteToVendingMachines([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetLandLordByIdQuery(key))).Select(x => x.VendingMachines).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteVendingMachineByIdCommand(related.Select(item => new VendingMachineKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    #endregion
    
}
