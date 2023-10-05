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

public partial class SecondTestEntityOneOrManiesController : SecondTestEntityOneOrManiesControllerBase
{
    public SecondTestEntityOneOrManiesController(IMediator mediator):base(mediator)
    {}
}
public abstract partial class SecondTestEntityOneOrManiesControllerBase : ODataController
{
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public SecondTestEntityOneOrManiesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<SecondTestEntityOneOrManyDto>>> Get()
    {
        var result = await _mediator.Send(new GetSecondTestEntityOneOrManiesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<SecondTestEntityOneOrManyDto>> Get([FromRoute] System.String key)
    {
        var query = await _mediator.Send(new GetSecondTestEntityOneOrManyByIdQuery(key));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<SecondTestEntityOneOrManyDto>> Post([FromBody]SecondTestEntityOneOrManyCreateDto secondTestEntityOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateSecondTestEntityOneOrManyCommand(secondTestEntityOneOrMany));
        
        var item = (await _mediator.Send(new GetSecondTestEntityOneOrManyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<SecondTestEntityOneOrManyDto>> Put([FromRoute] System.String key, [FromBody] SecondTestEntityOneOrManyUpdateDto secondTestEntityOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateSecondTestEntityOneOrManyCommand(key, secondTestEntityOneOrMany, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetSecondTestEntityOneOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<SecondTestEntityOneOrManyDto>> Patch([FromRoute] System.String key, [FromBody] Delta<SecondTestEntityOneOrManyDto> secondTestEntityOneOrMany)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in secondTestEntityOneOrMany.GetChangedPropertyNames())
        {
            if(secondTestEntityOneOrMany.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateSecondTestEntityOneOrManyCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetSecondTestEntityOneOrManyByIdQuery(updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteSecondTestEntityOneOrManyByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToTestEntityOneOrManyRelationship([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommand(new SecondTestEntityOneOrManyKeyDto(key), new TestEntityOneOrManyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToTestEntityOneOrManyRelationship([FromRoute] System.String key)
    {
        var related = (await _mediator.Send(new GetSecondTestEntityOneOrManyByIdQuery(key))).Select(x => x.TestEntityOneOrManyRelationship).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"TestEntityOneOrManies/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityOneOrManyRelationship([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommand(new SecondTestEntityOneOrManyKeyDto(key), new TestEntityOneOrManyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToTestEntityOneOrManyRelationship([FromRoute] System.String key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefSecondTestEntityOneOrManyToTestEntityOneOrManyRelationshipCommand(new SecondTestEntityOneOrManyKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}
