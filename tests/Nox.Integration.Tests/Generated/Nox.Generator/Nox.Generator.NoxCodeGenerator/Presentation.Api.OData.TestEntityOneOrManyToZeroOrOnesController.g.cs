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

public partial class TestEntityOneOrManyToZeroOrOnesController : TestEntityOneOrManyToZeroOrOnesControllerBase
{
    public TestEntityOneOrManyToZeroOrOnesController(IMediator mediator):base(mediator)
    {}
}
public abstract partial class TestEntityOneOrManyToZeroOrOnesControllerBase : ODataController
{
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public TestEntityOneOrManyToZeroOrOnesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityOneOrManyToZeroOrOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOnesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<TestEntityOneOrManyToZeroOrOneDto>> Get([FromRoute] System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(key));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<TestEntityOneOrManyToZeroOrOneDto>> Post([FromBody]TestEntityOneOrManyToZeroOrOneCreateDto testEntityOneOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateTestEntityOneOrManyToZeroOrOneCommand(testEntityOneOrManyToZeroOrOne));
        
        var item = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<TestEntityOneOrManyToZeroOrOneDto>> Put([FromRoute] System.String key, [FromBody] TestEntityOneOrManyToZeroOrOneUpdateDto testEntityOneOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityOneOrManyToZeroOrOneCommand(key, testEntityOneOrManyToZeroOrOne, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<TestEntityOneOrManyToZeroOrOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityOneOrManyToZeroOrOneDto> testEntityOneOrManyToZeroOrOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in testEntityOneOrManyToZeroOrOne.GetChangedPropertyNames())
        {
            if(testEntityOneOrManyToZeroOrOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityOneOrManyToZeroOrOneCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityOneOrManyToZeroOrOneByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityZeroOrOneToOneOrMany([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommand(new TestEntityOneOrManyToZeroOrOneKeyDto(key), new TestEntityZeroOrOneToOneOrManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestEntityZeroOrOneToOneOrMany([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityOneOrManyToZeroOrOneByIdQuery(key))).Select(x => x.TestEntityZeroOrOneToOneOrMany).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"TestEntityZeroOrOneToOneOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityZeroOrOneToOneOrMany([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommand(new TestEntityOneOrManyToZeroOrOneKeyDto(key), new TestEntityZeroOrOneToOneOrManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityZeroOrOneToOneOrMany([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityOneOrManyToZeroOrOneToTestEntityZeroOrOneToOneOrManyCommand(new TestEntityOneOrManyToZeroOrOneKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
