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
using SampleWebApp.Application;
using SampleWebApp.Application.Dto;
using SampleWebApp.Application.Queries;
using SampleWebApp.Application.Commands;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public abstract partial class CountriesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CountryLocalNameDto>>> GetCountryLocalNames([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.CountryLocalNames);
    }
    
    [EnableQuery]
    [HttpGet("api/Countries/{key}/CountryLocalNames/{relatedKey}")]
    public virtual async Task<ActionResult<CountryLocalNameDto>> GetCountryLocalNamesNonConventional(System.String key, System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var child = await TryGetCountryLocalNames(key, new CountryLocalNameKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToCountryLocalNames([FromRoute] System.String key, [FromBody] CountryLocalNameCreateDto countryLocalName)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateCountryLocalNameForCountryCommand(new CountryKeyDto(key), countryLocalName, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetCountryLocalNames(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    [HttpDelete("api/Countries/{key}/CountryLocalNames/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteCountryLocalNameNonConventional(System.String key, System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteCountryLocalNameForCountryCommand(new CountryKeyDto(key), new CountryLocalNameKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    private async Task<CountryLocalNameDto?> TryGetCountryLocalNames(System.String key, CountryLocalNameKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault();
        return parent?.CountryLocalNames.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
}
