// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
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

public partial class StoresController : StoresControllerBase
            {
                public StoresController(IMediator mediator, DtoDbContext databaseContext):base(databaseContext, mediator)
                {}
            }
public abstract class StoresControllerBase : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public StoresControllerBase(
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
    public virtual async Task<ActionResult<IQueryable<StoreDto>>> Get()
    {
        var result = await _mediator.Send(new GetStoresQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<ActionResult<StoreDto>> Get([FromRoute] System.Guid key)
    {
        var item = await _mediator.Send(new GetStoreByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<StoreDto>> Post([FromBody]StoreCreateDto store)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateStoreCommand(store));
        
        var item = await _mediator.Send(new GetStoreByIdQuery(createdKey.keyId));
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<StoreDto>> Put([FromRoute] System.Guid key, [FromBody] StoreUpdateDto store)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateStoreCommand(key, store, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = await _mediator.Send(new GetStoreByIdQuery(updated.keyId));
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<StoreDto>> Patch([FromRoute] System.Guid key, [FromBody] Delta<StoreUpdateDto> store)
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
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateStoreCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = await _mediator.Send(new GetStoreByIdQuery(updated.keyId));
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.Guid key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteStoreByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
}
