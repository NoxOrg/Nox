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

public abstract partial class WorkplacesControllerBase : ODataController
{
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToBelongsToCountry([FromRoute] System.UInt32 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefWorkplaceToBelongsToCountryCommand(new WorkplaceKeyDto(key), new CountryKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToBelongsToCountry([FromRoute] System.UInt32 key, [FromBody] CountryCreateDto country)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        country.PhysicalWorkplacesId = new List<System.UInt32> { key };
        var createdKey = await _mediator.Send(new CreateCountryCommand(country, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCountryByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToBelongsToCountry([FromRoute] System.UInt32 key)
    {
        var related = (await _mediator.Send(new GetWorkplaceByIdQuery(_cultureCode, key))).Select(x => x.BelongsToCountry).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"Countries/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToBelongsToCountry([FromRoute] System.UInt32 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefWorkplaceToBelongsToCountryCommand(new WorkplaceKeyDto(key), new CountryKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToBelongsToCountry([FromRoute] System.UInt32 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefWorkplaceToBelongsToCountryCommand(new WorkplaceKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
