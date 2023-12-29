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
using Nox.Application.Dto;
using Nox.Extensions;
using Nox.Exceptions;
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
    
    #endregion
    
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToStoreOwner([FromRoute] System.Guid key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefStoreToStoreOwnerCommand(new StoreKeyDto(key), new StoreOwnerKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToStoreOwner([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetStoreByIdQuery(key))).Include(x => x.StoreOwner).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Store", $"{key.ToString()}");
        }
        
        if (entity.StoreOwner is null)
        {
            return Ok();
        }
        var references = new System.Uri($"StoreOwners/{entity.StoreOwner.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToStoreOwner([FromRoute] System.Guid key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefStoreToStoreOwnerCommand(new StoreKeyDto(key), new StoreOwnerKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToStoreOwner([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefStoreToStoreOwnerCommand(new StoreKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToStoreOwner([FromRoute] System.Guid key, [FromBody] StoreOwnerCreateDto storeOwner)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        storeOwner.StoresId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateStoreOwnerCommand(storeOwner, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetStoreOwnerByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<StoreOwnerDto>> GetStoreOwner(System.Guid key)
    {
        var query = await _mediator.Send(new GetStoreByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<StoreOwnerDto>(Enumerable.Empty<StoreOwnerDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.StoreOwner != null).Select(x => x.StoreOwner!));
    }
    
    public virtual async Task<ActionResult<StoreOwnerDto>> PutToStoreOwner(System.Guid key, [FromBody] StoreOwnerUpdateDto storeOwner)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Select(x => x.StoreOwner).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("StoreOwner", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateStoreOwnerCommand(related.Id, storeOwner, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetStoreOwnerByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<StoreOwnerDto>> PatchToStoreOwner(System.Guid key, [FromBody] Delta<StoreOwnerPartialUpdateDto> storeOwner)
    {
        if (!ModelState.IsValid || storeOwner is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Select(x => x.StoreOwner).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("StoreOwner", String.Empty);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in storeOwner.GetChangedPropertyNames())
        {
            if(storeOwner.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateStoreOwnerCommand(related.Id, updateProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetStoreOwnerByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/Stores/{key}/StoreOwner")]
    public virtual async Task<ActionResult> DeleteToStoreOwner([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Select(x => x.StoreOwner).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Store", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteStoreOwnerByIdCommand(new List<StoreOwnerKeyDto> { new StoreOwnerKeyDto(related.Id) }, etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToStoreLicense([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefStoreToStoreLicenseCommand(new StoreKeyDto(key), new StoreLicenseKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToStoreLicense([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetStoreByIdQuery(key))).Include(x => x.StoreLicense).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Store", $"{key.ToString()}");
        }
        
        if (entity.StoreLicense is null)
        {
            return Ok();
        }
        var references = new System.Uri($"StoreLicenses/{entity.StoreLicense.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToStoreLicense([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefStoreToStoreLicenseCommand(new StoreKeyDto(key), new StoreLicenseKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToStoreLicense([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefStoreToStoreLicenseCommand(new StoreKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToStoreLicense([FromRoute] System.Guid key, [FromBody] StoreLicenseCreateDto storeLicense)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        storeLicense.StoreId = key;
        var createdKey = await _mediator.Send(new CreateStoreLicenseCommand(storeLicense, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetStoreLicenseByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<StoreLicenseDto>> GetStoreLicense(System.Guid key)
    {
        var query = await _mediator.Send(new GetStoreByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<StoreLicenseDto>(Enumerable.Empty<StoreLicenseDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.StoreLicense != null).Select(x => x.StoreLicense!));
    }
    
    public virtual async Task<ActionResult<StoreLicenseDto>> PutToStoreLicense(System.Guid key, [FromBody] StoreLicenseUpdateDto storeLicense)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Select(x => x.StoreLicense).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("StoreLicense", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateStoreLicenseCommand(related.Id, storeLicense, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetStoreLicenseByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<StoreLicenseDto>> PatchToStoreLicense(System.Guid key, [FromBody] Delta<StoreLicensePartialUpdateDto> storeLicense)
    {
        if (!ModelState.IsValid || storeLicense is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Select(x => x.StoreLicense).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("StoreLicense", String.Empty);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in storeLicense.GetChangedPropertyNames())
        {
            if(storeLicense.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateStoreLicenseCommand(related.Id, updateProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetStoreLicenseByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/Stores/{key}/StoreLicense")]
    public virtual async Task<ActionResult> DeleteToStoreLicense([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Select(x => x.StoreLicense).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Store", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteStoreLicenseByIdCommand(new List<StoreLicenseKeyDto> { new StoreLicenseKeyDto(related.Id) }, etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToClients([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefStoreToClientsCommand(new StoreKeyDto(key), new ClientKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/v1/Stores/{key}/Clients/$ref")]
    public virtual async Task<ActionResult> UpdateRefToClientsNonConventional([FromRoute] System.Guid key, [FromBody] ReferencesDto<System.Guid> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new ClientKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefStoreToClientsCommand(new StoreKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToClients([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetStoreByIdQuery(key))).Include(x => x.Clients).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Store", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.Clients)
        {
            references.Add(new System.Uri($"Clients/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToClients([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefStoreToClientsCommand(new StoreKeyDto(key), new ClientKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToClients([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefStoreToClientsCommand(new StoreKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToClients([FromRoute] System.Guid key, [FromBody] ClientCreateDto client)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        client.StoresId = new List<System.Guid> { key };
        var createdKey = await _mediator.Send(new CreateClientCommand(client, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetClientByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<ClientDto>>> GetClients(System.Guid key)
    {
        var query = await _mediator.Send(new GetStoreByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("Store", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.Clients).SelectMany(x => x.Clients));
    }
    
    [EnableQuery]
    [HttpGet("/api/v1/Stores/{key}/Clients/{relatedKey}")]
    public virtual async Task<SingleResult<ClientDto>> GetClientsNonConventional(System.Guid key, System.Guid relatedKey)
    {
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).SelectMany(x => x.Clients).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<ClientDto>(Enumerable.Empty<ClientDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/v1/Stores/{key}/Clients/{relatedKey}")]
    public virtual async Task<ActionResult<ClientDto>> PutToClientsNonConventional(System.Guid key, System.Guid relatedKey, [FromBody] ClientUpdateDto client)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).SelectMany(x => x.Clients).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Clients", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateClientCommand(relatedKey, client, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetClientByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/v1/Stores/{key}/Clients/{relatedKey}")]
    public virtual async Task<ActionResult<ClientDto>> PatchtoClientsNonConventional(System.Guid key, System.Guid relatedKey, [FromBody] Delta<ClientPartialUpdateDto> client)
    {
        if (!ModelState.IsValid || client is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).SelectMany(x => x.Clients).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Clients", $"{relatedKey.ToString()}");
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in client.GetChangedPropertyNames())
        {
            if(client.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateClientCommand(relatedKey, updateProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetClientByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/Stores/{key}/Clients/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToClients([FromRoute] System.Guid key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).SelectMany(x => x.Clients).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("Clients", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteClientByIdCommand(new List<ClientKeyDto> { new ClientKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/v1/Stores/{key}/Clients")]
    public virtual async Task<ActionResult> DeleteToClients([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreByIdQuery(key))).Select(x => x.Clients).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Store", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeleteClientByIdCommand(related.Select(item => new ClientKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    #endregion
    
}
