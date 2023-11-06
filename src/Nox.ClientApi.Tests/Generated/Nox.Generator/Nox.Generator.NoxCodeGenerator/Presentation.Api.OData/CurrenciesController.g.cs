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

public abstract partial class CurrenciesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToStoreLicenseDefault([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCurrencyToStoreLicenseDefaultCommand(new CurrencyKeyDto(key), new StoreLicenseKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToStoreLicenseDefault([FromRoute] System.String key, [FromBody] StoreLicenseCreateDto storeLicense)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        storeLicense.DefaultCurrencyId = key;
        var createdKey = await _mediator.Send(new CreateStoreLicenseCommand(storeLicense, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetStoreLicenseByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToStoreLicenseDefault([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).Select(x => x.StoreLicenseDefault).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"StoreLicenses/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToStoreLicenseDefault([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCurrencyToStoreLicenseDefaultCommand(new CurrencyKeyDto(key), new StoreLicenseKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToStoreLicenseDefault([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCurrencyToStoreLicenseDefaultCommand(new CurrencyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> CreateRefToStoreLicenseSoldIn([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCurrencyToStoreLicenseSoldInCommand(new CurrencyKeyDto(key), new StoreLicenseKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToStoreLicenseSoldIn([FromRoute] System.String key, [FromBody] StoreLicenseCreateDto storeLicense)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        storeLicense.SoldInCurrencyId = key;
        var createdKey = await _mediator.Send(new CreateStoreLicenseCommand(storeLicense, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetStoreLicenseByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToStoreLicenseSoldIn([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).Select(x => x.StoreLicenseSoldIn).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"StoreLicenses/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToStoreLicenseSoldIn([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCurrencyToStoreLicenseSoldInCommand(new CurrencyKeyDto(key), new StoreLicenseKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToStoreLicenseSoldIn([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCurrencyToStoreLicenseSoldInCommand(new CurrencyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
