﻿// Generated

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

public abstract partial class WorkplacesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToCountry([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefWorkplaceToCountryCommand(new WorkplaceKeyDto(key), new CountryKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToCountry([FromRoute] System.Int64 key, [FromBody] CountryCreateDto country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        country.WorkplacesId = new List<System.Int64> { key };
        var createdKey = await _mediator.Send(new CreateCountryCommand(country, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCountryByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToCountry([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(_cultureCode, key))).Select(x => x.Country).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"Countries/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CountryDto>> GetCountry(System.Int64 key)
    {
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(_cultureCode, key))).Where(x => x.Country != null);
        if (!related.Any())
        {
            return SingleResult.Create<CountryDto>(Enumerable.Empty<CountryDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.Country!));
    }
    
    public async Task<ActionResult> DeleteRefToCountry([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefWorkplaceToCountryCommand(new WorkplaceKeyDto(key), new CountryKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToCountry([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefWorkplaceToCountryCommand(new WorkplaceKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/Workplaces/{key}/Country")]
    public async Task<ActionResult> DeleteToCountry([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(_cultureCode, key))).Select(x => x.Country).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteCountryByIdCommand(related.Id, etag));
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    public virtual async Task<ActionResult<CountryDto>> PutToCountry(System.Int64 key, [FromBody] CountryUpdateDto country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(_cultureCode, key))).Select(x => x.Country).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCountryCommand(related.Id, country, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    public async Task<ActionResult> CreateRefToTenants([FromRoute] System.Int64 key, [FromRoute] System.UInt32 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefWorkplaceToTenantsCommand(new WorkplaceKeyDto(key), new TenantKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToTenants([FromRoute] System.Int64 key, [FromBody] TenantCreateDto tenant)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        tenant.WorkplacesId = new List<System.Int64> { key };
        var createdKey = await _mediator.Send(new CreateTenantCommand(tenant, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetTenantByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToTenants([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(_cultureCode, key))).Select(x => x.Tenants).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"Tenants/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TenantDto>>> GetTenants(System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetWorkplaceByIdQuery(_cultureCode, key))).SelectMany(x => x.Tenants);
        if (!entity.Any())
        {
            return NotFound();
        }
        return Ok(entity);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/Workplaces/{key}/Tenants/{relatedKey}")]
    public virtual async Task<SingleResult<TenantDto>> GetTenantsNonConventional(System.Int64 key, System.UInt32 relatedKey)
    {
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(_cultureCode, key))).SelectMany(x => x.Tenants).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<TenantDto>(Enumerable.Empty<TenantDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    public async Task<ActionResult> DeleteRefToTenants([FromRoute] System.Int64 key, [FromRoute] System.UInt32 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefWorkplaceToTenantsCommand(new WorkplaceKeyDto(key), new TenantKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTenants([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefWorkplaceToTenantsCommand(new WorkplaceKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/Workplaces/{key}/Tenants/{relatedKey}")]
    public async Task<ActionResult> DeleteToTenants([FromRoute] System.Int64 key, [FromRoute] System.UInt32 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(_cultureCode, key))).SelectMany(x => x.Tenants).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteTenantByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/Workplaces/{key}/Tenants")]
    public async Task<ActionResult> DeleteToTenants([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(_cultureCode, key))).Select(x => x.Tenants).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        foreach(var item in related)
        {
            await _mediator.Send(new DeleteTenantByIdCommand(item.Id, etag));
        }
        return NoContent();
    }
    
    [HttpPut("/api/v1/Workplaces/{key}/Tenants/{relatedKey}")]
    public virtual async Task<ActionResult<TenantDto>> PutToTenantsNonConventional(System.Int64 key, System.UInt32 relatedKey, [FromBody] TenantUpdateDto tenant)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(_cultureCode, key))).SelectMany(x => x.Tenants).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTenantCommand(relatedKey, tenant, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
