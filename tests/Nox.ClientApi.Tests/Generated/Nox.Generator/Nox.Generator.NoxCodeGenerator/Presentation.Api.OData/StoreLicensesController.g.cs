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

public abstract partial class StoreLicensesControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToStore([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefStoreLicenseToStoreCommand(new StoreLicenseKeyDto(key), new StoreKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToStore([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Include(x => x.Store).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("StoreLicense", $"{key.ToString()}");
        }
        
        if (entity.Store is null)
        {
            return Ok();
        }
        var references = new System.Uri($"Stores/{entity.Store.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToStore([FromRoute] System.Int64 key, [FromBody] StoreCreateDto store)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        store.StoreLicenseId = key;
        var createdKey = await _mediator.Send(new CreateStoreCommand(store, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetStoreByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<StoreDto>> GetStore(System.Int64 key)
    {
        var query = await _mediator.Send(new GetStoreLicenseByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<StoreDto>(Enumerable.Empty<StoreDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.Store != null).Select(x => x.Store!));
    }
    
    public virtual async Task<ActionResult<StoreDto>> PutToStore(System.Int64 key, [FromBody] StoreUpdateDto store)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Select(x => x.Store).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Store", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateStoreCommand(related.Id, store, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetStoreByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<StoreDto>> PatchToStore(System.Int64 key, [FromBody] Delta<StorePartialUpdateDto> store)
    {
        if (!ModelState.IsValid || store is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Select(x => x.Store).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Store", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<StorePartialUpdateDto>(store);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateStoreCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetStoreByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult> CreateRefToDefaultCurrency([FromRoute] System.Int64 key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefStoreLicenseToDefaultCurrencyCommand(new StoreLicenseKeyDto(key), new CurrencyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToDefaultCurrency([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Include(x => x.DefaultCurrency).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("StoreLicense", $"{key.ToString()}");
        }
        
        if (entity.DefaultCurrency is null)
        {
            return Ok();
        }
        var references = new System.Uri($"Currencies/{entity.DefaultCurrency.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToDefaultCurrency([FromRoute] System.Int64 key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefStoreLicenseToDefaultCurrencyCommand(new StoreLicenseKeyDto(key), new CurrencyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToDefaultCurrency([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefStoreLicenseToDefaultCurrencyCommand(new StoreLicenseKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToDefaultCurrency([FromRoute] System.Int64 key, [FromBody] CurrencyCreateDto currency)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        currency.StoreLicenseDefaultId = new List<System.Int64> { key };
        var createdKey = await _mediator.Send(new CreateCurrencyCommand(currency, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCurrencyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CurrencyDto>> GetDefaultCurrency(System.Int64 key)
    {
        var query = await _mediator.Send(new GetStoreLicenseByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<CurrencyDto>(Enumerable.Empty<CurrencyDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.DefaultCurrency != null).Select(x => x.DefaultCurrency!));
    }
    
    public virtual async Task<ActionResult<CurrencyDto>> PutToDefaultCurrency(System.Int64 key, [FromBody] CurrencyUpdateDto currency)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Select(x => x.DefaultCurrency).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("DefaultCurrency", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCurrencyCommand(related.Id, currency, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCurrencyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<CurrencyDto>> PatchToDefaultCurrency(System.Int64 key, [FromBody] Delta<CurrencyPartialUpdateDto> currency)
    {
        if (!ModelState.IsValid || currency is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Select(x => x.DefaultCurrency).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("DefaultCurrency", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CurrencyPartialUpdateDto>(currency);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCurrencyCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCurrencyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/StoreLicenses/{key}/DefaultCurrency")]
    public virtual async Task<ActionResult> DeleteToDefaultCurrency([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Select(x => x.DefaultCurrency).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("StoreLicense", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteCurrencyByIdCommand(new List<CurrencyKeyDto> { new CurrencyKeyDto(related.Id) }, etag));
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToSoldInCurrency([FromRoute] System.Int64 key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefStoreLicenseToSoldInCurrencyCommand(new StoreLicenseKeyDto(key), new CurrencyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToSoldInCurrency([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Include(x => x.SoldInCurrency).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("StoreLicense", $"{key.ToString()}");
        }
        
        if (entity.SoldInCurrency is null)
        {
            return Ok();
        }
        var references = new System.Uri($"Currencies/{entity.SoldInCurrency.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToSoldInCurrency([FromRoute] System.Int64 key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefStoreLicenseToSoldInCurrencyCommand(new StoreLicenseKeyDto(key), new CurrencyKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToSoldInCurrency([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefStoreLicenseToSoldInCurrencyCommand(new StoreLicenseKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToSoldInCurrency([FromRoute] System.Int64 key, [FromBody] CurrencyCreateDto currency)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        currency.StoreLicenseSoldInId = new List<System.Int64> { key };
        var createdKey = await _mediator.Send(new CreateCurrencyCommand(currency, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCurrencyByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CurrencyDto>> GetSoldInCurrency(System.Int64 key)
    {
        var query = await _mediator.Send(new GetStoreLicenseByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<CurrencyDto>(Enumerable.Empty<CurrencyDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.SoldInCurrency != null).Select(x => x.SoldInCurrency!));
    }
    
    public virtual async Task<ActionResult<CurrencyDto>> PutToSoldInCurrency(System.Int64 key, [FromBody] CurrencyUpdateDto currency)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Select(x => x.SoldInCurrency).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("SoldInCurrency", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCurrencyCommand(related.Id, currency, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCurrencyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<CurrencyDto>> PatchToSoldInCurrency(System.Int64 key, [FromBody] Delta<CurrencyPartialUpdateDto> currency)
    {
        if (!ModelState.IsValid || currency is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Select(x => x.SoldInCurrency).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("SoldInCurrency", String.Empty);
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CurrencyPartialUpdateDto>(currency);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCurrencyCommand(related.Id, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCurrencyByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/v1/StoreLicenses/{key}/SoldInCurrency")]
    public virtual async Task<ActionResult> DeleteToSoldInCurrency([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Select(x => x.SoldInCurrency).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("StoreLicense", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteCurrencyByIdCommand(new List<CurrencyKeyDto> { new CurrencyKeyDto(related.Id) }, etag));
        return NoContent();
    }
    
    #endregion
    
}
