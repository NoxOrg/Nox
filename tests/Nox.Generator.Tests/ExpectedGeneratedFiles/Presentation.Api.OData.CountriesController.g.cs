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
    
    /// <summary>
    /// Returns a list of countries for a given continent.
    /// </summary>
    protected readonly GetCountriesByContinentQueryBase _getCountriesByContinent;
    
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
    [HttpGet("/api/v1/Countries/{key}/CountryLocalNames/{relatedKey}")]
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
    
    public virtual async Task<ActionResult> PostToCountryLocalNames([FromRoute] System.String key, [FromBody] CountryLocalNameUpsertDto countryLocalName)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateCountryLocalNamesForCountryCommand(new CountryKeyDto(key), countryLocalName, etag));
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
    
    [HttpDelete("/api/v1/Countries/{key}/CountryLocalNames/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteCountryLocalNameNonConventional(System.String key, System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteCountryLocalNamesForCountryCommand(new CountryKeyDto(key), new CountryLocalNameKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    protected async Task<CountryLocalNameDto?> TryGetCountryLocalNames(System.String key, CountryLocalNameKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault();
        return parent?.CountryLocalNames.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
    
    /// <summary>
    /// Returns a list of countries for a given continent.
    /// </summary>
    [HttpGet("GetCountriesByContinent")]
    public async Task<IResult> GetCountriesByContinentAsync(Text continentName)
    {
        var result = await _getCountriesByContinent.ExecuteAsync(continentName);
        return Results.Ok(result);
    }
}
