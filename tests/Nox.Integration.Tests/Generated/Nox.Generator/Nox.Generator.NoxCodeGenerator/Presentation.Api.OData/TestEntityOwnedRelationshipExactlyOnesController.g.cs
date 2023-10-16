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
using TestWebApp.Application;
using TestWebApp.Application.Dto;
using TestWebApp.Application.Queries;
using TestWebApp.Application.Commands;
using TestWebApp.Domain;
using TestWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace TestWebApp.Presentation.Api.OData;

public partial class TestEntityOwnedRelationshipExactlyOnesController : TestEntityOwnedRelationshipExactlyOnesControllerBase
{
    public TestEntityOwnedRelationshipExactlyOnesController(IMediator mediator):base(mediator)
    {}
}
public abstract partial class TestEntityOwnedRelationshipExactlyOnesControllerBase : ODataController
{
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public TestEntityOwnedRelationshipExactlyOnesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityOwnedRelationshipExactlyOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOnesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<TestEntityOwnedRelationshipExactlyOneDto>> Get([FromRoute] System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(key));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<TestEntityOwnedRelationshipExactlyOneDto>> Post([FromBody]TestEntityOwnedRelationshipExactlyOneCreateDto testEntityOwnedRelationshipExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateTestEntityOwnedRelationshipExactlyOneCommand(testEntityOwnedRelationshipExactlyOne));
        
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<TestEntityOwnedRelationshipExactlyOneDto>> Put([FromRoute] System.String key, [FromBody] TestEntityOwnedRelationshipExactlyOneUpdateDto testEntityOwnedRelationshipExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityOwnedRelationshipExactlyOneCommand(key, testEntityOwnedRelationshipExactlyOne, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<TestEntityOwnedRelationshipExactlyOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityOwnedRelationshipExactlyOneDto> testEntityOwnedRelationshipExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in testEntityOwnedRelationshipExactlyOne.GetChangedPropertyNames())
        {
            if(testEntityOwnedRelationshipExactlyOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityOwnedRelationshipExactlyOneCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityOwnedRelationshipExactlyOneByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<SecondTestEntityOwnedRelationshipExactlyOneDto>> GetSecondTestEntityOwnedRelationshipExactlyOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.SecondTestEntityOwnedRelationshipExactlyOne);
    }
    
    public virtual async Task<ActionResult> PostToSecondTestEntityOwnedRelationshipExactlyOne([FromRoute] System.String key, [FromBody] SecondTestEntityOwnedRelationshipExactlyOneCreateDto secondTestEntityOwnedRelationshipExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(new TestEntityOwnedRelationshipExactlyOneKeyDto(key), secondTestEntityOwnedRelationshipExactlyOne, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(key))).SingleOrDefault()?.SecondTestEntityOwnedRelationshipExactlyOne;
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    public virtual async Task<ActionResult<SecondTestEntityOwnedRelationshipExactlyOneDto>> PutToSecondTestEntityOwnedRelationshipExactlyOne(System.String key, [FromBody] SecondTestEntityOwnedRelationshipExactlyOneUpdateDto secondTestEntityOwnedRelationshipExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(new TestEntityOwnedRelationshipExactlyOneKeyDto(key), secondTestEntityOwnedRelationshipExactlyOne, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(key))).SingleOrDefault()?.SecondTestEntityOwnedRelationshipExactlyOne;
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToSecondTestEntityOwnedRelationshipExactlyOne(System.String key, [FromBody] Delta<SecondTestEntityOwnedRelationshipExactlyOneDto> secondTestEntityOwnedRelationshipExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in secondTestEntityOwnedRelationshipExactlyOne.GetChangedPropertyNames())
        {
            if(secondTestEntityOwnedRelationshipExactlyOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(new TestEntityOwnedRelationshipExactlyOneKeyDto(key), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = (await _mediator.Send(new GetTestEntityOwnedRelationshipExactlyOneByIdQuery(key))).SingleOrDefault()?.SecondTestEntityOwnedRelationshipExactlyOne;
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("api/TestEntityOwnedRelationshipExactlyOnes/{key}/SecondTestEntityOwnedRelationshipExactlyOne")]
    public virtual async Task<ActionResult> DeleteSecondTestEntityOwnedRelationshipExactlyOneNonConventional(System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteSecondTestEntityOwnedRelationshipExactlyOneForTestEntityOwnedRelationshipExactlyOneCommand(new TestEntityOwnedRelationshipExactlyOneKeyDto(key)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
