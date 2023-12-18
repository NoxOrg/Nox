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
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace TestWebApp.Presentation.Api.OData;

public abstract partial class TestEntityOwnedRelationshipOneOrManiesControllerBase : ODataController
{
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecEntityOwnedRelOneOrManyDto>>> GetSecEntityOwnedRelOneOrManies([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipOneOrManyByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.SecEntityOwnedRelOneOrManies);
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityOwnedRelationshipOneOrManies/{key}/SecEntityOwnedRelOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult<SecEntityOwnedRelOneOrManyDto>> GetSecEntityOwnedRelOneOrManiesNonConventional(System.String key, System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var child = await TryGetSecEntityOwnedRelOneOrManies(key, new SecEntityOwnedRelOneOrManyKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToSecEntityOwnedRelOneOrManies([FromRoute] System.String key, [FromBody] SecEntityOwnedRelOneOrManyUpsertDto secEntityOwnedRelOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), secEntityOwnedRelOneOrMany, _cultureCode, etag));
        
        var child = await TryGetSecEntityOwnedRelOneOrManies(key, createdKey);
        return Created(child);
    }
    
    public virtual async Task<ActionResult<SecEntityOwnedRelOneOrManyDto>> PutToSecEntityOwnedRelOneOrManies(System.String key, [FromBody] SecEntityOwnedRelOneOrManyUpsertDto secEntityOwnedRelOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), secEntityOwnedRelOneOrMany, _cultureCode, etag));
        
        var child = await TryGetSecEntityOwnedRelOneOrManies(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToSecEntityOwnedRelOneOrManies(System.String key, [FromBody] Delta<SecEntityOwnedRelOneOrManyUpsertDto> secEntityOwnedRelOneOrMany)
    {
        if (!ModelState.IsValid || secEntityOwnedRelOneOrMany is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in secEntityOwnedRelOneOrMany.GetChangedPropertyNames())
        {
            if(secEntityOwnedRelOneOrMany.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        if(!updateProperties.ContainsKey("Id") || updateProperties["Id"] == null)
        {
            throw new Nox.Exceptions.BadRequestException("Id is required.");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), new SecEntityOwnedRelOneOrManyKeyDto(updateProperties["Id"]), updateProperties, _cultureCode, etag));
        
        var child = await TryGetSecEntityOwnedRelOneOrManies(key, updated!);
        
        return Ok(child);
    }
    
    [HttpDelete("/api/v1/TestEntityOwnedRelationshipOneOrManies/{key}/SecEntityOwnedRelOneOrManies/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteSecEntityOwnedRelOneOrManyNonConventional(System.String key, System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new DeleteSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), new SecEntityOwnedRelOneOrManyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    protected async Task<SecEntityOwnedRelOneOrManyDto?> TryGetSecEntityOwnedRelOneOrManies(System.String key, SecEntityOwnedRelOneOrManyKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetTestEntityOwnedRelationshipOneOrManyByIdQuery(key))).SingleOrDefault();
        return parent?.SecEntityOwnedRelOneOrManies.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
}
