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

public abstract partial class CountriesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CountryLocalNameDto>>> GetCountryShortNames([FromRoute] System.Int64 key)
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
        
        return Ok(item.CountryShortNames);
    }
    
    [EnableQuery]
    [HttpGet("api/Countries/{key}/CountryShortNames/{relatedKey}")]
    public virtual async Task<ActionResult<CountryLocalNameDto>> GetCountryShortNamesNonConventional(System.Int64 key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var child = await TryGetCountryShortNames(key, new CountryLocalNameKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToCountryShortNames([FromRoute] System.Int64 key, [FromBody] CountryLocalNameCreateDto countryLocalName)
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
        
        var child = await TryGetCountryShortNames(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    [HttpPut("api/Countries/{key}/CountryShortNames/{relatedKey}")]
    public virtual async Task<ActionResult<CountryLocalNameDto>> PutToCountryLocalNamesNonConventional(System.Int64 key, System.Int64 relatedKey, [FromBody] CountryLocalNameUpdateDto countryLocalName)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateCountryLocalNameForCountryCommand(new CountryKeyDto(key), new CountryLocalNameKeyDto(relatedKey), countryLocalName, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetCountryShortNames(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpPatch("api/Countries/{key}/CountryShortNames/{relatedKey}")]
    public virtual async Task<ActionResult> PatchToCountryLocalNamesNonConventional(System.Int64 key, System.Int64 relatedKey, [FromBody] Delta<CountryLocalNameDto> countryLocalName)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in countryLocalName.GetChangedPropertyNames())
        {
            if(countryLocalName.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCountryLocalNameForCountryCommand(new CountryKeyDto(key), new CountryLocalNameKeyDto(relatedKey), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetCountryShortNames(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("api/Countries/{key}/CountryShortNames/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteCountryLocalNameNonConventional(System.Int64 key, System.Int64 relatedKey)
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
    
    private async Task<CountryLocalNameDto?> TryGetCountryShortNames(System.Int64 key, CountryLocalNameKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault();
        return parent?.CountryShortNames.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<CountryBarCodeDto>> GetCountryBarCode([FromRoute] System.Int64 key)
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
        
        return Ok(item.CountryBarCode);
    }
    
    public virtual async Task<ActionResult> PostToCountryBarCode([FromRoute] System.Int64 key, [FromBody] CountryBarCodeCreateDto countryBarCode)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateCountryBarCodeForCountryCommand(new CountryKeyDto(key), countryBarCode, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault()?.CountryBarCode;
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    public virtual async Task<ActionResult<CountryBarCodeDto>> PutToCountryBarCode(System.Int64 key, [FromBody] CountryBarCodeUpdateDto countryBarCode)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateCountryBarCodeForCountryCommand(new CountryKeyDto(key), countryBarCode, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault()?.CountryBarCode;
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToCountryBarCode(System.Int64 key, [FromBody] Delta<CountryBarCodeDto> countryBarCode)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in countryBarCode.GetChangedPropertyNames())
        {
            if(countryBarCode.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCountryBarCodeForCountryCommand(new CountryKeyDto(key), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = (await _mediator.Send(new GetCountryByIdQuery(key))).SingleOrDefault()?.CountryBarCode;
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("api/Countries/{key}/CountryBarCode")]
    public virtual async Task<ActionResult> DeleteCountryBarCodeNonConventional(System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteCountryBarCodeForCountryCommand(new CountryKeyDto(key)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToPhysicalWorkplaces([FromRoute] System.Int64 key, [FromRoute] System.UInt32 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCountryToPhysicalWorkplacesCommand(new CountryKeyDto(key), new WorkplaceKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToPhysicalWorkplaces([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetCountryByIdQuery(key))).Select(x => x.PhysicalWorkplaces).SingleOrDefault();
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
    
    public async Task<ActionResult> DeleteRefToPhysicalWorkplaces([FromRoute] System.Int64 key, [FromRoute] System.UInt32 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCountryToPhysicalWorkplacesCommand(new CountryKeyDto(key), new WorkplaceKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToPhysicalWorkplaces([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefCountryToPhysicalWorkplacesCommand(new CountryKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}