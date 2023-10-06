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

public partial class TestEntityTwoRelationshipsOneToOnesController : TestEntityTwoRelationshipsOneToOnesControllerBase
{
    public TestEntityTwoRelationshipsOneToOnesController(IMediator mediator):base(mediator)
    {}
}
public abstract partial class TestEntityTwoRelationshipsOneToOnesControllerBase : ODataController
{
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public TestEntityTwoRelationshipsOneToOnesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityTwoRelationshipsOneToOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOnesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<TestEntityTwoRelationshipsOneToOneDto>> Get([FromRoute] System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsOneToOneDto>> Post([FromBody]TestEntityTwoRelationshipsOneToOneCreateDto testEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateTestEntityTwoRelationshipsOneToOneCommand(testEntityTwoRelationshipsOneToOne));
        
        var item = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsOneToOneDto>> Put([FromRoute] System.String key, [FromBody] TestEntityTwoRelationshipsOneToOneUpdateDto testEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityTwoRelationshipsOneToOneCommand(key, testEntityTwoRelationshipsOneToOne, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<TestEntityTwoRelationshipsOneToOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityTwoRelationshipsOneToOneDto> testEntityTwoRelationshipsOneToOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in testEntityTwoRelationshipsOneToOne.GetChangedPropertyNames())
        {
            if(testEntityTwoRelationshipsOneToOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityTwoRelationshipsOneToOneCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityTwoRelationshipsOneToOneByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestRelationshipOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(new TestEntityTwoRelationshipsOneToOneKeyDto(key), new SecondTestEntityTwoRelationshipsOneToOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestRelationshipOne([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipOne).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"SecondTestEntityTwoRelationshipsOneToOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestRelationshipOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(new TestEntityTwoRelationshipsOneToOneKeyDto(key), new SecondTestEntityTwoRelationshipsOneToOneKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestRelationshipOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipOneCommand(new TestEntityTwoRelationshipsOneToOneKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> CreateRefToTestRelationshipTwo([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsOneToOneKeyDto(key), new SecondTestEntityTwoRelationshipsOneToOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestRelationshipTwo([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityTwoRelationshipsOneToOneByIdQuery(key))).Select(x => x.TestRelationshipTwo).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"SecondTestEntityTwoRelationshipsOneToOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestRelationshipTwo([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsOneToOneKeyDto(key), new SecondTestEntityTwoRelationshipsOneToOneKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestRelationshipTwo([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityTwoRelationshipsOneToOneToTestRelationshipTwoCommand(new TestEntityTwoRelationshipsOneToOneKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
