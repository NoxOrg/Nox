// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MediatR;
using Nox.Application;
using SampleWebApp.Application;
using SampleWebApp.Application.Dto;
using SampleWebApp.Application.Queries;
using SampleWebApp.Application.Commands;
using SampleWebApp.Application.DataTransferObjects;
using SampleWebApp.Domain;
using SampleWebApp.Infrastructure.Persistence;
using Nox.Types;

namespace SampleWebApp.Presentation.Api.OData;

public partial class CompoundKeysEntitiesController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly ODataDbContext _databaseContext;
    
    /// <summary>
    /// The Automapper.
    /// </summary>
    protected readonly IMapper _mapper;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public CompoundKeysEntitiesController(
        ODataDbContext databaseContext,
        IMapper mapper,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mapper = mapper;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<CompoundKeysEntityDto>>> Get()
    {
        var result = await _mediator.Send(new GetCompoundKeysEntitiesQuery());
        return Ok(result);
    }
    
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
        
        var updated = await _mediator.Send(new UpdateCompoundKeysEntityCommand(keyId1, keyId2, compoundKeysEntity));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(compoundKeysEntity);
    }
    
    public async Task<ActionResult> Patch([FromRoute] System.String keyId1, [FromRoute] System.String keyId2, [FromBody] Delta<CompoundKeysEntityUpdateDto> compoundKeysEntity)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        var deletedProperties = new List<string>();

        foreach (var propertyName in compoundKeysEntity.GetChangedPropertyNames())
        {
            if(compoundKeysEntity.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }
            else
            {
                deletedProperties.Add(propertyName);
            }
        }
        
        var updated = await _mediator.Send(new PartialUpdateCompoundKeysEntityCommand(keyId1, keyId2, updateProperties, deletedProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(compoundKeysEntity);
    }
    
    private bool CompoundKeysEntityExists(System.String key)
    {
        return _databaseContext.CompoundKeysEntities.Any(p => p.Id1 == key);
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
