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

public partial class TestEntityZeroOrOneToExactlyOnesController : TestEntityZeroOrOneToExactlyOnesControllerBase
{
    public TestEntityZeroOrOneToExactlyOnesController(IMediator mediator):base(mediator)
    {}
}
public abstract partial class TestEntityZeroOrOneToExactlyOnesControllerBase : ODataController
{
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public TestEntityZeroOrOneToExactlyOnesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityZeroOrOneToExactlyOneDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOnesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<TestEntityZeroOrOneToExactlyOneDto>> Get([FromRoute] System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(key));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<TestEntityZeroOrOneToExactlyOneDto>> Post([FromBody]TestEntityZeroOrOneToExactlyOneCreateDto testEntityZeroOrOneToExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateTestEntityZeroOrOneToExactlyOneCommand(testEntityZeroOrOneToExactlyOne));
        
        var item = (await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<TestEntityZeroOrOneToExactlyOneDto>> Put([FromRoute] System.String key, [FromBody] TestEntityZeroOrOneToExactlyOneUpdateDto testEntityZeroOrOneToExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityZeroOrOneToExactlyOneCommand(key, testEntityZeroOrOneToExactlyOne, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<TestEntityZeroOrOneToExactlyOneDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityZeroOrOneToExactlyOneDto> testEntityZeroOrOneToExactlyOne)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in testEntityZeroOrOneToExactlyOne.GetChangedPropertyNames())
        {
            if(testEntityZeroOrOneToExactlyOne.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityZeroOrOneToExactlyOneCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityZeroOrOneToExactlyOneByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(new TestEntityZeroOrOneToExactlyOneKeyDto(key), new TestEntityExactlyOneToZeroOrOneKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetTestEntityZeroOrOneToExactlyOneByIdQuery(key))).Select(x => x.TestEntityExactlyOneToZeroOrOne).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"TestEntityExactlyOneToZeroOrOnes/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(new TestEntityZeroOrOneToExactlyOneKeyDto(key), new TestEntityExactlyOneToZeroOrOneKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityExactlyOneToZeroOrOne([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefTestEntityZeroOrOneToExactlyOneToTestEntityExactlyOneToZeroOrOneCommand(new TestEntityZeroOrOneToExactlyOneKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
