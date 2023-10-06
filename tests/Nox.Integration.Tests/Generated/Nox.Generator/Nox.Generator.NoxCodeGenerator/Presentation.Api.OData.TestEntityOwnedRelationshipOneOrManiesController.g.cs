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
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace TestWebApp.Presentation.Api.OData;

public partial class TestEntityOwnedRelationshipOneOrManiesController : TestEntityOwnedRelationshipOneOrManiesControllerBase
{
    public TestEntityOwnedRelationshipOneOrManiesController(IMediator mediator):base(mediator)
    {}
}
public abstract partial class TestEntityOwnedRelationshipOneOrManiesControllerBase : ODataController
{
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public TestEntityOwnedRelationshipOneOrManiesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityOwnedRelationshipOneOrManyDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityOwnedRelationshipOneOrManiesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<TestEntityOwnedRelationshipOneOrManyDto>> Get([FromRoute] System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityOwnedRelationshipOneOrManyByIdQuery(key));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<TestEntityOwnedRelationshipOneOrManyDto>> Post([FromBody]TestEntityOwnedRelationshipOneOrManyCreateDto testEntityOwnedRelationshipOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateTestEntityOwnedRelationshipOneOrManyCommand(testEntityOwnedRelationshipOneOrMany));
        
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipOneOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<TestEntityOwnedRelationshipOneOrManyDto>> Put([FromRoute] System.String key, [FromBody] TestEntityOwnedRelationshipOneOrManyUpdateDto testEntityOwnedRelationshipOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityOwnedRelationshipOneOrManyCommand(key, testEntityOwnedRelationshipOneOrMany, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipOneOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<TestEntityOwnedRelationshipOneOrManyDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityOwnedRelationshipOneOrManyDto> testEntityOwnedRelationshipOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in testEntityOwnedRelationshipOneOrMany.GetChangedPropertyNames())
        {
            if(testEntityOwnedRelationshipOneOrMany.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityOwnedRelationshipOneOrManyCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipOneOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityOwnedRelationshipOneOrManyByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityOwnedRelationshipOneOrManyDto>>> GetSecondTestEntityOwnedRelationshipOneOrMany([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipOneOrManyByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.SecondTestEntityOwnedRelationshipOneOrMany);
    }
    
    [EnableQuery]
    [HttpGet("api/TestEntityOwnedRelationshipOneOrManies/{key}/SecondTestEntityOwnedRelationshipOneOrMany/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityOwnedRelationshipOneOrManyDto>> GetSecondTestEntityOwnedRelationshipOneOrManyNonConventional(System.String key, System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var child = await TryGetSecondTestEntityOwnedRelationshipOneOrMany(key, new SecondTestEntityOwnedRelationshipOneOrManyKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToSecondTestEntityOwnedRelationshipOneOrMany([FromRoute] System.String key, [FromBody] SecondTestEntityOwnedRelationshipOneOrManyCreateDto secondTestEntityOwnedRelationshipOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), secondTestEntityOwnedRelationshipOneOrMany, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetSecondTestEntityOwnedRelationshipOneOrMany(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    [HttpPut("api/TestEntityOwnedRelationshipOneOrManies/{key}/SecondTestEntityOwnedRelationshipOneOrMany/{relatedKey}")]
    public virtual async Task<ActionResult<SecondTestEntityOwnedRelationshipOneOrManyDto>> PutToSecondTestEntityOwnedRelationshipOneOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] SecondTestEntityOwnedRelationshipOneOrManyUpdateDto secondTestEntityOwnedRelationshipOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), new SecondTestEntityOwnedRelationshipOneOrManyKeyDto(relatedKey), secondTestEntityOwnedRelationshipOneOrMany, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetSecondTestEntityOwnedRelationshipOneOrMany(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpPatch("api/TestEntityOwnedRelationshipOneOrManies/{key}/SecondTestEntityOwnedRelationshipOneOrMany/{relatedKey}")]
    public virtual async Task<ActionResult> PatchToSecondTestEntityOwnedRelationshipOneOrManiesNonConventional(System.String key, System.String relatedKey, [FromBody] Delta<SecondTestEntityOwnedRelationshipOneOrManyDto> secondTestEntityOwnedRelationshipOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in secondTestEntityOwnedRelationshipOneOrMany.GetChangedPropertyNames())
        {
            if(secondTestEntityOwnedRelationshipOneOrMany.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), new SecondTestEntityOwnedRelationshipOneOrManyKeyDto(relatedKey), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetSecondTestEntityOwnedRelationshipOneOrMany(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("api/TestEntityOwnedRelationshipOneOrManies/{key}/SecondTestEntityOwnedRelationshipOneOrMany/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteSecondTestEntityOwnedRelationshipOneOrManyNonConventional(System.String key, System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteSecondTestEntityOwnedRelationshipOneOrManyForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), new SecondTestEntityOwnedRelationshipOneOrManyKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    private async Task<SecondTestEntityOwnedRelationshipOneOrManyDto?> TryGetSecondTestEntityOwnedRelationshipOneOrMany(System.String key, SecondTestEntityOwnedRelationshipOneOrManyKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetTestEntityOwnedRelationshipOneOrManyByIdQuery(key))).SingleOrDefault();
        return parent?.SecondTestEntityOwnedRelationshipOneOrMany.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
}
