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
using Cryptocash.Application;
using Cryptocash.Application.Dto;
using Cryptocash.Application.Queries;
using Cryptocash.Application.Commands;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Nox.Types;

namespace Cryptocash.Presentation.Api.OData;

public abstract partial class PaymentDetailsControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToCustomer([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefPaymentDetailToCustomerCommand(new PaymentDetailKeyDto(key), new CustomerKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToCustomer([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetPaymentDetailByIdQuery(key))).Select(x => x.Customer).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"Customers/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToCustomer([FromRoute] System.Int64 key, [FromBody] CustomerCreateDto customer)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        customer.PaymentDetailsId = new List<System.Int64> { key };
        var createdKey = await _mediator.Send(new CreateCustomerCommand(customer, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetCustomerByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<CustomerDto>> GetCustomer(System.Int64 key)
    {
        var related = (await _mediator.Send(new GetPaymentDetailByIdQuery(key))).Where(x => x.Customer != null);
        if (!related.Any())
        {
            return SingleResult.Create<CustomerDto>(Enumerable.Empty<CustomerDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.Customer!));
    }
    
    public virtual async Task<ActionResult<CustomerDto>> PutToCustomer(System.Int64 key, [FromBody] CustomerUpdateDto customer)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetPaymentDetailByIdQuery(key))).Select(x => x.Customer).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCustomerCommand(related.Id, customer, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    public virtual async Task<ActionResult> CreateRefToPaymentProvider([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefPaymentDetailToPaymentProviderCommand(new PaymentDetailKeyDto(key), new PaymentProviderKeyDto(relatedKey)));
        if (!createdRef)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    public async Task<ActionResult> GetRefToPaymentProvider([FromRoute] System.Int64 key)
    {
        var related = (await _mediator.Send(new GetPaymentDetailByIdQuery(key))).Select(x => x.PaymentProvider).SingleOrDefault();
        if (related is null)
        {
            return NotFound();
        }
        
        var references = new System.Uri($"PaymentProviders/{related.Id}", UriKind.Relative);
        return Ok(references);
    }
    
    public virtual async Task<ActionResult> PostToPaymentProvider([FromRoute] System.Int64 key, [FromBody] PaymentProviderCreateDto paymentProvider)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        paymentProvider.PaymentDetailsId = new List<System.Int64> { key };
        var createdKey = await _mediator.Send(new CreatePaymentProviderCommand(paymentProvider, _cultureCode));
        
        var createdItem = (await _mediator.Send(new GetPaymentProviderByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(createdItem);
    }
    
    [EnableQuery]
    public virtual async Task<SingleResult<PaymentProviderDto>> GetPaymentProvider(System.Int64 key)
    {
        var related = (await _mediator.Send(new GetPaymentDetailByIdQuery(key))).Where(x => x.PaymentProvider != null);
        if (!related.Any())
        {
            return SingleResult.Create<PaymentProviderDto>(Enumerable.Empty<PaymentProviderDto>().AsQueryable());
        }
        return SingleResult.Create(related.Select(x => x.PaymentProvider!));
    }
    
    public virtual async Task<ActionResult<PaymentProviderDto>> PutToPaymentProvider(System.Int64 key, [FromBody] PaymentProviderUpdateDto paymentProvider)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetPaymentDetailByIdQuery(key))).Select(x => x.PaymentProvider).SingleOrDefault();
        if (related == null)
        {
            return NotFound();
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdatePaymentProviderCommand(related.Id, paymentProvider, _cultureCode, etag));
        if (updated == null)
        {
            return NotFound();
        }
        
        return Ok();
    }
    
    #endregion
    
}
