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
    
    public async Task<ActionResult> CreateRefToPaymentDetails([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefPaymentProviderToPaymentDetailsCommand(new PaymentProviderKeyDto(key), new PaymentDetailKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> PostToPaymentDetails([FromRoute] System.Int64 key, [FromBody] PaymentDetailCreateDto paymentDetail)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        paymentDetail.PaymentProviderId = key;
        var createdKey = await _mediator.Send(new CreatePaymentDetailCommand(paymentDetail, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetPaymentDetailByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    public async Task<ActionResult> GetRefToPaymentDetails([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetPaymentProviderByIdQuery(key))).Select(x => x.PaymentDetails).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        IList<System.Uri> references = new List<System.Uri>();
        foreach (var item in related)
        {
            references.Add(new System.Uri($"PaymentDetails/{item.Id}", UriKind.Relative));
        }
        return Ok(references);
    }
    
    public async Task<ActionResult> DeleteRefToPaymentDetails([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedRef = await _mediator.Send(new DeleteRefPaymentProviderToPaymentDetailsCommand(new PaymentProviderKeyDto(key), new PaymentDetailKeyDto(relatedKey)));
        if (!deletedRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> DeleteRefToPaymentDetails([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var deletedAllRef = await _mediator.Send(new DeleteAllRefPaymentProviderToPaymentDetailsCommand(new PaymentProviderKeyDto(key)));
        if (!deletedAllRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("api/PaymentProviders/{key}/PaymentDetails/{relatedKey}")]
    public async Task<ActionResult> DeleteToPaymentDetails([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetPaymentProviderByIdQuery(key))).SelectMany(x => x.PaymentDetails).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var deleted = await _mediator.Send(new DeletePaymentDetailByIdCommand(relatedKey, etag));
        if (!deleted)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    [HttpDelete("api/PaymentProviders/{key}/PaymentDetails")]
    public async Task<ActionResult> DeleteToPaymentDetails([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetPaymentProviderByIdQuery(key))).Select(x => x.PaymentDetails).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        foreach(var item in related)
        {
            await _mediator.Send(new DeletePaymentDetailByIdCommand(item.Id, etag));
        }
        return NoContent();
    }
    
    [HttpPut("api/PaymentProviders/{key}/PaymentDetails/{relatedKey}")]
    public virtual async Task<ActionResult<PaymentDetailDto>> PutToPaymentDetailsNonConventional(System.Int64 key, System.Int64 relatedKey, [FromBody] PaymentDetailUpdateDto paymentDetail)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var related = (await _mediator.Send(new GetPaymentProviderByIdQuery(key))).SelectMany(x => x.PaymentDetails).Any(x => x.Id == relatedKey);
        if (!related)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdatePaymentDetailCommand(relatedKey, paymentDetail, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
