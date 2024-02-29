// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
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

public abstract partial class CurrenciesControllerBase : ODataController
{
    
    #region Relationships
    
    [ApiExplorerSettings(IgnoreApi = true)]
    public virtual async Task<ActionResult> CreateRefToStoreLicenseDefault([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCurrencyToStoreLicenseDefaultCommand(new CurrencyKeyDto(key), new StoreLicenseKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpPut("/api/v1/Currencies/{key}/StoreLicenseDefault/$ref")]
    public virtual async Task<ActionResult> UpdateRefToStoreLicenseDefaultNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.Int64> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new StoreLicenseKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefCurrencyToStoreLicenseDefaultCommand(new CurrencyKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    public virtual async Task<ActionResult> GetRefToStoreLicenseDefault([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetCurrencyByIdQuery(key))).Include(x => x.StoreLicenseDefault).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Currency", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.StoreLicenseDefault)
        {
            references.Add(new System.Uri($"StoreLicenses/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    public virtual async Task<ActionResult> DeleteRefToStoreLicenseDefault([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCurrencyToStoreLicenseDefaultCommand(new CurrencyKeyDto(key), new StoreLicenseKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    public virtual async Task<ActionResult> PostToStoreLicenseDefault([FromRoute] System.String key, [FromBody] StoreLicenseCreateDto storeLicense)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        storeLicense.DefaultCurrencyId = key;
        var createdKey = await _mediator.Send(new CreateStoreLicenseCommand(storeLicense, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetStoreLicenseByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<StoreLicenseDto>>> GetStoreLicenseDefault(System.String key)
    {
        var query = await _mediator.Send(new GetCurrencyByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("Currency", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.StoreLicenseDefault).SelectMany(x => x.StoreLicenseDefault));
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    [EnableQuery]
    [HttpGet("/api/v1/Currencies/{key}/StoreLicenseDefault/{relatedKey}")]
    public virtual async Task<SingleResult<StoreLicenseDto>> GetStoreLicenseDefaultNonConventional(System.String key, System.Int64 relatedKey)
    {
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SelectMany(x => x.StoreLicenseDefault).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<StoreLicenseDto>(Enumerable.Empty<StoreLicenseDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpPut("/api/v1/Currencies/{key}/StoreLicenseDefault/{relatedKey}")]
    public virtual async Task<ActionResult<StoreLicenseDto>> PutToStoreLicenseDefaultNonConventional(System.String key, System.Int64 relatedKey, [FromBody] StoreLicenseUpdateDto storeLicense)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SelectMany(x => x.StoreLicenseDefault).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("StoreLicenseDefault", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateStoreLicenseCommand(relatedKey, storeLicense, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetStoreLicenseByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpPatch("/api/v1/Currencies/{key}/StoreLicenseDefault/{relatedKey}")]
    public virtual async Task<ActionResult<StoreLicenseDto>> PatchtoStoreLicenseDefaultNonConventional(System.String key, System.Int64 relatedKey, [FromBody] Delta<StoreLicensePartialUpdateDto> storeLicense)
    {
        if (!ModelState.IsValid || storeLicense is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SelectMany(x => x.StoreLicenseDefault).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("StoreLicenseDefault", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<StoreLicensePartialUpdateDto>(storeLicense);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateStoreLicenseCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetStoreLicenseByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("/api/v1/Currencies/{key}/StoreLicenseDefault/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToStoreLicenseDefault([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SelectMany(x => x.StoreLicenseDefault).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("StoreLicenseDefault", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteStoreLicenseByIdCommand(new List<StoreLicenseKeyDto> { new StoreLicenseKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    public virtual async Task<ActionResult> CreateRefToStoreLicenseSoldIn([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefCurrencyToStoreLicenseSoldInCommand(new CurrencyKeyDto(key), new StoreLicenseKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpPut("/api/v1/Currencies/{key}/StoreLicenseSoldIn/$ref")]
    public virtual async Task<ActionResult> UpdateRefToStoreLicenseSoldInNonConventional([FromRoute] System.String key, [FromBody] ReferencesDto<System.Int64> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new StoreLicenseKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefCurrencyToStoreLicenseSoldInCommand(new CurrencyKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    public virtual async Task<ActionResult> GetRefToStoreLicenseSoldIn([FromRoute] System.String key)
    {
        var entity = (await _mediator.Send(new GetCurrencyByIdQuery(key))).Include(x => x.StoreLicenseSoldIn).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("Currency", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.StoreLicenseSoldIn)
        {
            references.Add(new System.Uri($"StoreLicenses/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    public virtual async Task<ActionResult> DeleteRefToStoreLicenseSoldIn([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefCurrencyToStoreLicenseSoldInCommand(new CurrencyKeyDto(key), new StoreLicenseKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    public virtual async Task<ActionResult> PostToStoreLicenseSoldIn([FromRoute] System.String key, [FromBody] StoreLicenseCreateDto storeLicense)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        storeLicense.SoldInCurrencyId = key;
        var createdKey = await _mediator.Send(new CreateStoreLicenseCommand(storeLicense, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetStoreLicenseByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<StoreLicenseDto>>> GetStoreLicenseSoldIn(System.String key)
    {
        var query = await _mediator.Send(new GetCurrencyByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("Currency", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.StoreLicenseSoldIn).SelectMany(x => x.StoreLicenseSoldIn));
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    [EnableQuery]
    [HttpGet("/api/v1/Currencies/{key}/StoreLicenseSoldIn/{relatedKey}")]
    public virtual async Task<SingleResult<StoreLicenseDto>> GetStoreLicenseSoldInNonConventional(System.String key, System.Int64 relatedKey)
    {
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SelectMany(x => x.StoreLicenseSoldIn).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<StoreLicenseDto>(Enumerable.Empty<StoreLicenseDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpPut("/api/v1/Currencies/{key}/StoreLicenseSoldIn/{relatedKey}")]
    public virtual async Task<ActionResult<StoreLicenseDto>> PutToStoreLicenseSoldInNonConventional(System.String key, System.Int64 relatedKey, [FromBody] StoreLicenseUpdateDto storeLicense)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SelectMany(x => x.StoreLicenseSoldIn).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("StoreLicenseSoldIn", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateStoreLicenseCommand(relatedKey, storeLicense, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetStoreLicenseByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpPatch("/api/v1/Currencies/{key}/StoreLicenseSoldIn/{relatedKey}")]
    public virtual async Task<ActionResult<StoreLicenseDto>> PatchtoStoreLicenseSoldInNonConventional(System.String key, System.Int64 relatedKey, [FromBody] Delta<StoreLicensePartialUpdateDto> storeLicense)
    {
        if (!ModelState.IsValid || storeLicense is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SelectMany(x => x.StoreLicenseSoldIn).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("StoreLicenseSoldIn", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<StoreLicensePartialUpdateDto>(storeLicense);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateStoreLicenseCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetStoreLicenseByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [ApiExplorerSettings(IgnoreApi = true)]
    [HttpDelete("/api/v1/Currencies/{key}/StoreLicenseSoldIn/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToStoreLicenseSoldIn([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetCurrencyByIdQuery(key))).SelectMany(x => x.StoreLicenseSoldIn).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("StoreLicenseSoldIn", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeleteStoreLicenseByIdCommand(new List<StoreLicenseKeyDto> { new StoreLicenseKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    #endregion
    
}
