﻿// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Nox.Application;
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;
using Nox.Types;

namespace ClientApi.Presentation.Api.OData;

public partial class StoresController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public StoresController(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    #region Owned Relationships
    
    #endregion
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<StoreDto>>> Get()
    {
        var result = await _mediator.Send(new GetStoresQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<ActionResult<StoreDto>> Get([FromRoute] System.UInt32 key)
    {
        var item = await _mediator.Send(new GetStoreByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public async Task<ActionResult<StoreDto>> Post([FromBody]StoreCreateDto store)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateStoreCommand(store));
        
        var item = await _mediator.Send(new GetStoreByIdQuery(createdKey.keyId));
        
        return Created(item);
    }
    
    public async Task<ActionResult<StoreDto>> Put([FromRoute] System.UInt32 key, [FromBody] StoreUpdateDto store)
    {
        
        var updated = await _mediator.Send(new UpdateStoreCommand(key, store));
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = await _mediator.Send(new GetStoreByIdQuery(updated.keyId));
        
        return Ok(item);
    }
    
    public async Task<ActionResult<StoreDto>> Patch([FromRoute] System.UInt32 key, [FromBody] Delta<StoreUpdateDto> store)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in store.GetChangedPropertyNames())
        {
            if(store.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var updated = await _mediator.Send(new PartialUpdateStoreCommand(key, updateProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = await _mediator.Send(new GetStoreByIdQuery(updated.keyId));
        return Ok(item);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.UInt32 key)
    {
        var result = await _mediator.Send(new DeleteStoreByIdCommand(key));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
