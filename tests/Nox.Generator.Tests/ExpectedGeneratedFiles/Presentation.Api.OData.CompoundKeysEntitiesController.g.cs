// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Nox.Application;
using SampleWebApp.Application;
using SampleWebApp.Application.Dto;
using SampleWebApp.Application.Queries;
using SampleWebApp.Application.Commands;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public partial class CompoundKeysEntitiesController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public CompoundKeysEntitiesController(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<CompoundKeysEntityDto>>> Get()
    {
        var result = await _mediator.Send(new GetCompoundKeysEntitiesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<ActionResult<CompoundKeysEntityDto>> Get([FromRoute] System.String keyId1, [FromRoute] System.String keyId2)
    {
        var item = await _mediator.Send(new GetCompoundKeysEntityByIdQuery(keyId1, keyId2));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult<CompoundKeysEntityDto>> Post([FromBody]CompoundKeysEntityCreateDto compoundKeysEntity)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateCompoundKeysEntityCommand(compoundKeysEntity));
        
        var item = await _mediator.Send(new GetCompoundKeysEntityByIdQuery(createdKey.keyId1, createdKey.keyId2));
        
        return Created(item);
    }
    
    public async Task<ActionResult<CompoundKeysEntityDto>> Put([FromRoute] System.String keyId1, [FromRoute] System.String keyId2, [FromBody] CompoundKeysEntityUpdateDto compoundKeysEntity)
    {
        
        var updated = await _mediator.Send(new UpdateCompoundKeysEntityCommand(keyId1, keyId2, compoundKeysEntity));
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = await _mediator.Send(new GetCompoundKeysEntityByIdQuery(updated.keyId1, updated.keyId2));
        
        return Ok(item);
    }
    
    public async Task<ActionResult<CompoundKeysEntityDto>> Patch([FromRoute] System.String keyId1, [FromRoute] System.String keyId2, [FromBody] Delta<CompoundKeysEntityUpdateDto> compoundKeysEntity)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in compoundKeysEntity.GetChangedPropertyNames())
        {
            if(compoundKeysEntity.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var updated = await _mediator.Send(new PartialUpdateCompoundKeysEntityCommand(keyId1, keyId2, updateProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = await _mediator.Send(new GetCompoundKeysEntityByIdQuery(updated.keyId1, updated.keyId2));
        return Ok(item);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.String keyId1, [FromRoute] System.String keyId2)
    {
        var result = await _mediator.Send(new DeleteCompoundKeysEntityByIdCommand(keyId1, keyId2));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
