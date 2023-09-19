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
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<StoreDto>>> Get()
    {
        var result = await _mediator.Send(new GetStoresQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<StoreDto>> Get([FromRoute] System.Guid key)
    {
        var query = await _mediator.Send(new GetStoreByIdQuery(key));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<StoreDto>> Post([FromBody]StoreCreateDto store)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateStoreCommand(store));
        
        var item = (await _mediator.Send(new GetStoreByIdQuery(createdKey.keyId))).SingleOrDefault();
        
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
        
        var item = (await _mediator.Send(new GetStoreByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<StoreDto>> Patch([FromRoute] System.Guid key, [FromBody] Delta<StoreDto> store)
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
        var item = (await _mediator.Send(new GetStoreByIdQuery(updated.keyId))).SingleOrDefault();
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
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<EmailAddressDto>> GetVerifiedEmails([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = (await _mediator.Send(new GetStoreByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.VerifiedEmails);
    }
    
    public virtual async Task<ActionResult> PostToVerifiedEmails([FromRoute] System.Guid key, [FromBody] EmailAddressCreateDto emailAddress)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateEmailAddressForStoreCommand(new StoreKeyDto(key), emailAddress, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = (await _mediator.Send(new GetStoreByIdQuery(key))).SingleOrDefault()?.VerifiedEmails;
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    public virtual async Task<ActionResult<EmailAddressDto>> PutToVerifiedEmails(System.Guid key, [FromBody] EmailAddressUpdateDto emailAddress)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateEmailAddressForStoreCommand(new StoreKeyDto(key), emailAddress, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = (await _mediator.Send(new GetStoreByIdQuery(key))).SingleOrDefault()?.VerifiedEmails;
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PatchToVerifiedEmails(System.Guid key, [FromBody] Delta<EmailAddressDto> emailAddress)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in emailAddress.GetChangedPropertyNames())
        {
            if(emailAddress.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateEmailAddressForStoreCommand(new StoreKeyDto(key), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = (await _mediator.Send(new GetStoreByIdQuery(key))).SingleOrDefault()?.VerifiedEmails;
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("api/Stores/{key}/VerifiedEmails")]
    public virtual async Task<ActionResult> DeleteEmailAddressNonConventional(System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteEmailAddressForStoreCommand(new StoreKeyDto(key)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
    
    #region Relationships
    
    public async Task<ActionResult> CreateRefToOwnership([FromRoute] System.Guid key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefStoreToOwnershipCommand(new StoreKeyDto(key), new StoreOwnerKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToOwnership([FromRoute] System.Guid key)
    {
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Select(x => x.Ownership).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"StoreOwners/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    #endregion
    
}
