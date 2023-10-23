﻿// Generated

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

public abstract partial class StoresControllerBase : ODataController
{
    
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
    
    public async Task<ActionResult> DeleteRefToOwnership([FromRoute] System.Guid key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefStoreToOwnershipCommand(new StoreKeyDto(key), new StoreOwnerKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToOwnership([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefStoreToOwnershipCommand(new StoreKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> CreateRefToLicense([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefStoreToLicenseCommand(new StoreKeyDto(key), new StoreLicenseKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToLicense([FromRoute] System.Guid key)
    {
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Select(x => x.License).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"StoreLicenses/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToLicense([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefStoreToLicenseCommand(new StoreKeyDto(key), new StoreLicenseKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToLicense([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefStoreToLicenseCommand(new StoreKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #endregion
    
}