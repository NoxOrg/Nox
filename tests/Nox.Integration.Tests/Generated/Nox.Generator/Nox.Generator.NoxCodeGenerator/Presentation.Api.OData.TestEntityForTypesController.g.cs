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

public partial class TestEntityForTypesController : TestEntityForTypesControllerBase
{
    public TestEntityForTypesController(IMediator mediator):base(mediator)
    {}
}
public abstract partial class TestEntityForTypesControllerBase : ODataController
{
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public TestEntityForTypesControllerBase(
        IMediator mediator
    )
    {
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<TestEntityForTypesDto>>> Get()
    {
        var result = await _mediator.Send(new GetTestEntityForTypesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<TestEntityForTypesDto>> Get([FromRoute] System.String key)
    {
        var query = await _mediator.Send(new GetTestEntityForTypesByIdQuery(key));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<TestEntityForTypesDto>> Post([FromBody]TestEntityForTypesCreateDto testEntityForTypes)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateTestEntityForTypesCommand(testEntityForTypes));
        
        var item = (await _mediator.Send(new GetTestEntityForTypesByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<TestEntityForTypesDto>> Put([FromRoute] System.String key, [FromBody] TestEntityForTypesUpdateDto testEntityForTypes)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateTestEntityForTypesCommand(key, testEntityForTypes, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetTestEntityForTypesByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<TestEntityForTypesDto>> Patch([FromRoute] System.String key, [FromBody] Delta<TestEntityForTypesDto> testEntityForTypes)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in testEntityForTypes.GetChangedPropertyNames())
        {
            if(testEntityForTypes.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateTestEntityForTypesCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetTestEntityForTypesByIdQuery(updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteTestEntityForTypesByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
