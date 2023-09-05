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
    
    public async Task<ActionResult> Post([FromBody]CompoundKeysEntityCreateDto compoundkeysentity)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateCompoundKeysEntityCommand(compoundkeysentity));
        
        return Created(createdKey);
    }
    
    public async Task<ActionResult> Put([FromRoute] System.String keyId1, [FromRoute] System.String keyId2, [FromBody] CompoundKeysEntityUpdateDto compoundKeysEntity)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var ifMatchValue = Request.Headers.IfMatch.FirstOrDefault();
        System.Guid? etag = System.Guid.TryParse(ifMatchValue, out System.Guid parsedValue) ? parsedValue : null; 
        var updated = await _mediator.Send(new UpdateCompoundKeysEntityCommand(keyId1, keyId2, compoundKeysEntity, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Patch([FromRoute] System.String keyId1, [FromRoute] System.String keyId2, [FromBody] Delta<CompoundKeysEntityUpdateDto> compoundKeysEntity)
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
        
        var ifMatchValue = Request.Headers.IfMatch.FirstOrDefault();
        System.Guid? etag = System.Guid.TryParse(ifMatchValue, out System.Guid parsedValue) ? parsedValue : null; 
        var updated = await _mediator.Send(new PartialUpdateCompoundKeysEntityCommand(keyId1, keyId2, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.String keyId1, [FromRoute] System.String keyId2)
    {
        var ifMatchValue = Request.Headers.IfMatch.FirstOrDefault();
        System.Guid? etag = System.Guid.TryParse(ifMatchValue, out System.Guid parsedValue) ? parsedValue : null; 
        var result = await _mediator.Send(new DeleteCompoundKeysEntityByIdCommand(keyId1, keyId2, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
