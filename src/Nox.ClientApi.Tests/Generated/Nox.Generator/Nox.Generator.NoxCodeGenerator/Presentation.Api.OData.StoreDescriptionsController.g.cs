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
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;
using Nox.Types;

namespace ClientApi.Presentation.Api.OData;

public partial class StoreDescriptionsController : StoreDescriptionsControllerBase
{
    public StoreDescriptionsController(IMediator mediator, DtoDbContext databaseContext):base(databaseContext, mediator)
    {}
}
public abstract class StoreDescriptionsControllerBase : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public StoreDescriptionsControllerBase(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<StoreDescriptionDto>>> Get()
    {
        var result = await _mediator.Send(new GetStoreDescriptionsQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<StoreDescriptionDto>> Get([FromRoute] System.Guid keyStoreId, [FromRoute] System.Int64 keyId)
    {
        var query = await _mediator.Send(new GetStoreDescriptionByIdQuery(keyStoreId, keyId));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<StoreDescriptionDto>> Post([FromBody]StoreDescriptionCreateDto storeDescription)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateStoreDescriptionCommand(storeDescription));
        
        var item = (await _mediator.Send(new GetStoreDescriptionByIdQuery(createdKey.keyStoreId, createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<StoreDescriptionDto>> Put([FromRoute] System.Guid keyStoreId, [FromRoute] System.Int64 keyId, [FromBody] StoreDescriptionUpdateDto storeDescription)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateStoreDescriptionCommand(keyStoreId, keyId, storeDescription, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetStoreDescriptionByIdQuery(updated.keyStoreId, updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<StoreDescriptionDto>> Patch([FromRoute] System.Guid keyStoreId, [FromRoute] System.Int64 keyId, [FromBody] Delta<StoreDescriptionDto> storeDescription)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in storeDescription.GetChangedPropertyNames())
        {
            if(storeDescription.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateStoreDescriptionCommand(keyStoreId, keyId, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetStoreDescriptionByIdQuery(updated.keyStoreId, updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.Guid keyStoreId, [FromRoute] System.Int64 keyId)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteStoreDescriptionByIdCommand(keyStoreId, keyId, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
