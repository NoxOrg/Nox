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

public abstract partial class StoreLicensesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToStoreWithLicense([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefStoreLicenseToStoreWithLicenseCommand(new StoreLicenseKeyDto(key), new StoreKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToStoreWithLicense([FromRoute] System.Int64 key, [FromBody] StoreCreateDto store)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        store.LicenseId = key;
        var createdKey = await _mediator.Send(new CreateStoreCommand(store, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetStoreByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToStoreWithLicense([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Select(x => x.StoreWithLicense).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"Stores/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToStoreWithLicense([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefStoreLicenseToStoreWithLicenseCommand(new StoreLicenseKeyDto(key), new StoreKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToStoreWithLicense([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefStoreLicenseToStoreWithLicenseCommand(new StoreLicenseKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
