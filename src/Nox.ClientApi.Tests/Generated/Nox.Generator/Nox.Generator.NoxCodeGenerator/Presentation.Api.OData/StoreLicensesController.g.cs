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
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToStore([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Select(x => x.Store).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"Stores/{related.Id}", UriKind.Relative);
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
        var related = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Where(x => x.Store != null);
        if (!related.Any())
        {
            return SingleResult.Create<StoreDto>(Enumerable.Empty<StoreDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.Store!));
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
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateStoreCommand(related.Id, store, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
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
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToDefaultCurrency([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Select(x => x.DefaultCurrency).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"Currencies/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToDefaultCurrency([FromRoute] System.Int64 key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefStoreLicenseToDefaultCurrencyCommand(new StoreLicenseKeyDto(key), new CurrencyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToDefaultCurrency([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefStoreLicenseToDefaultCurrencyCommand(new StoreLicenseKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
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
        var related = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Where(x => x.DefaultCurrency != null);
        if (!related.Any())
        {
            return SingleResult.Create<CurrencyDto>(Enumerable.Empty<CurrencyDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.DefaultCurrency!));
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
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCurrencyCommand(related.Id, currency, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
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
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteCurrencyByIdCommand(new List<CurrencyKeyDto> { new CurrencyKeyDto(related.Id) }, etag));
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    public virtual async Task<ActionResult> CreateRefToSoldInCurrency([FromRoute] System.Int64 key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefStoreLicenseToSoldInCurrencyCommand(new StoreLicenseKeyDto(key), new CurrencyKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToSoldInCurrency([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Select(x => x.SoldInCurrency).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"Currencies/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToSoldInCurrency([FromRoute] System.Int64 key, [FromRoute] System.String relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefStoreLicenseToSoldInCurrencyCommand(new StoreLicenseKeyDto(key), new CurrencyKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToSoldInCurrency([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefStoreLicenseToSoldInCurrencyCommand(new StoreLicenseKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
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
        var related = (await _mediator.Send(new GetStoreLicenseByIdQuery(key))).Where(x => x.SoldInCurrency != null);
        if (!related.Any())
        {
            return SingleResult.Create<CurrencyDto>(Enumerable.Empty<CurrencyDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.SoldInCurrency!));
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
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCurrencyCommand(related.Id, currency, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
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
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteCurrencyByIdCommand(new List<CurrencyKeyDto> { new CurrencyKeyDto(related.Id) }, etag));
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
    
    #endregion
    
}
