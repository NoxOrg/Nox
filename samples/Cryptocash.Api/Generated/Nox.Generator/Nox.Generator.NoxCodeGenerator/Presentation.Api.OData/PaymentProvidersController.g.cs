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
using Cryptocash.Application;
using Cryptocash.Application.Dto;
using Cryptocash.Application.Queries;
using Cryptocash.Application.Commands;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Nox.Types;

namespace Cryptocash.Presentation.Api.OData;

public abstract partial class PaymentProvidersControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToPaymentDetails([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefPaymentProviderToPaymentDetailsCommand(new PaymentProviderKeyDto(key), new PaymentDetailKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    [HttpPut("/api/PaymentProviders/{key}/PaymentDetails/$ref")]
    public virtual async Task<ActionResult> UpdateRefToPaymentDetailsNonConventional([FromRoute] System.Guid key, [FromBody] ReferencesDto<System.Int64> referencesDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var relatedKeysDto = referencesDto.References.Select(x => new PaymentDetailKeyDto(x)).ToList();
        var updatedRef = await _mediator.Send(new UpdateRefPaymentProviderToPaymentDetailsCommand(new PaymentProviderKeyDto(key), relatedKeysDto));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToPaymentDetails([FromRoute] System.Guid key)
    {
        var entity = (await _mediator.Send(new GetPaymentProviderByIdQuery(key))).Include(x => x.PaymentDetails).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("PaymentProvider", $"{key.ToString()}");
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in entity.PaymentDetails)
        {
            references.Add(new System.Uri($"PaymentDetails/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> DeleteRefToPaymentDetails([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefPaymentProviderToPaymentDetailsCommand(new PaymentProviderKeyDto(key), new PaymentDetailKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> DeleteRefToPaymentDetails([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefPaymentProviderToPaymentDetailsCommand(new PaymentProviderKeyDto(key)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToPaymentDetails([FromRoute] System.Guid key, [FromBody] PaymentDetailCreateDto paymentDetail)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        paymentDetail.PaymentProviderId = key;
        var createdKey = await _mediator.Send(new CreatePaymentDetailCommand(paymentDetail, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetPaymentDetailByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<PaymentDetailDto>>> GetPaymentDetails(System.Guid key)
    {
        var query = await _mediator.Send(new GetPaymentProviderByIdQuery(key));
        if (!query.Any())
        {
            throw new EntityNotFoundException("PaymentProvider", $"{key.ToString()}");
        }
        return Ok(query.Include(x => x.PaymentDetails).SelectMany(x => x.PaymentDetails));
    }
    
    [EnableQuery]
    [HttpGet("/api/PaymentProviders/{key}/PaymentDetails/{relatedKey}")]
    public virtual async Task<SingleResult<PaymentDetailDto>> GetPaymentDetailsNonConventional(System.Guid key, System.Int64 relatedKey)
    {
        var related = (await _mediator.Send(new GetPaymentProviderByIdQuery(key))).SelectMany(x => x.PaymentDetails).Where(x => x.Id == relatedKey);
        if (!related.Any())
        {
            return SingleResult.Create<PaymentDetailDto>(Enumerable.Empty<PaymentDetailDto>().AsQueryable());
        }
        return SingleResult.Create(related);
    }
    
    [HttpPut("/api/PaymentProviders/{key}/PaymentDetails/{relatedKey}")]
    public virtual async Task<ActionResult<PaymentDetailDto>> PutToPaymentDetailsNonConventional(System.Guid key, System.Int64 relatedKey, [FromBody] PaymentDetailUpdateDto paymentDetail)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetPaymentProviderByIdQuery(key))).SelectMany(x => x.PaymentDetails).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("PaymentDetails", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdatePaymentDetailCommand(relatedKey, paymentDetail, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetPaymentDetailByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpPatch("/api/PaymentProviders/{key}/PaymentDetails/{relatedKey}")]
    public virtual async Task<ActionResult<PaymentDetailDto>> PatchtoPaymentDetailsNonConventional(System.Guid key, System.Int64 relatedKey, [FromBody] Delta<PaymentDetailPartialUpdateDto> paymentDetail)
    {
        if (!ModelState.IsValid || paymentDetail is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetPaymentProviderByIdQuery(key))).SelectMany(x => x.PaymentDetails).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("PaymentDetails", $"{relatedKey.ToString()}");
        }
        
        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<PaymentDetailPartialUpdateDto>(paymentDetail);
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdatePaymentDetailCommand(relatedKey, updatedProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetPaymentDetailByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    [HttpDelete("/api/PaymentProviders/{key}/PaymentDetails/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteToPaymentDetails([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetPaymentProviderByIdQuery(key))).SelectMany(x => x.PaymentDetails).Any(x => x.Id == relatedKey);
        if (!related)
        {
            throw new EntityNotFoundException("PaymentDetails", $"{relatedKey.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeletePaymentDetailByIdCommand(new List<PaymentDetailKeyDto> { new PaymentDetailKeyDto(relatedKey) }, etag));
        
        return NoContent();
    }
    
    [HttpDelete("/api/PaymentProviders/{key}/PaymentDetails")]
    public virtual async Task<ActionResult> DeleteToPaymentDetails([FromRoute] System.Guid key)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetPaymentProviderByIdQuery(key))).Select(x => x.PaymentDetails).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("PaymentProvider", $"{key.ToString()}");
        }
        
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new DeletePaymentDetailByIdCommand(related.Select(item => new PaymentDetailKeyDto(item.Id)), etag));
        return NoContent();
    }
    
    #endregion
    
}
