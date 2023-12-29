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

public abstract partial class PaymentDetailsControllerBase : ODataController
{
    
    #region Relationships
    
    public virtual async Task<ActionResult> CreateRefToCustomer([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefPaymentDetailToCustomerCommand(new PaymentDetailKeyDto(key), new CustomerKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToCustomer([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetPaymentDetailByIdQuery(key))).Include(x => x.Customer).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("PaymentDetail", $"{key.ToString()}");
        }
        
        if (entity.Customer is null)
        {
            return Ok();
        }
        var references = new System.Uri($"Customers/{entity.Customer.Id}", UriKind.Relative);
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
        var query = await _mediator.Send(new GetPaymentDetailByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<CustomerDto>(Enumerable.Empty<CustomerDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.Customer != null).Select(x => x.Customer!));
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
            throw new EntityNotFoundException("Customer", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateCustomerCommand(related.Id, customer, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCustomerByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<CustomerDto>> PatchToCustomer(System.Int64 key, [FromBody] Delta<CustomerPartialUpdateDto> customer)
    {
        if (!ModelState.IsValid || customer is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetPaymentDetailByIdQuery(key))).Select(x => x.Customer).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("Customer", String.Empty);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in customer.GetChangedPropertyNames())
        {
            if(customer.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateCustomerCommand(related.Id, updateProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetCustomerByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult> CreateRefToPaymentProvider([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var createdRef = await _mediator.Send(new CreateRefPaymentDetailToPaymentProviderCommand(new PaymentDetailKeyDto(key), new PaymentProviderKeyDto(relatedKey)));
        
        return NoContent();
    }
    
    public virtual async Task<ActionResult> GetRefToPaymentProvider([FromRoute] System.Int64 key)
    {
        var entity = (await _mediator.Send(new GetPaymentDetailByIdQuery(key))).Include(x => x.PaymentProvider).SingleOrDefault();
        if (entity is null)
        {
            throw new EntityNotFoundException("PaymentDetail", $"{key.ToString()}");
        }
        
        if (entity.PaymentProvider is null)
        {
            return Ok();
        }
        var references = new System.Uri($"PaymentProviders/{entity.PaymentProvider.Id}", UriKind.Relative);
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
        var query = await _mediator.Send(new GetPaymentDetailByIdQuery(key));
        if (!query.Any())
        {
            return SingleResult.Create<PaymentProviderDto>(Enumerable.Empty<PaymentProviderDto>().AsQueryable());
        }
        return SingleResult.Create(query.Where(x => x.PaymentProvider != null).Select(x => x.PaymentProvider!));
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
            throw new EntityNotFoundException("PaymentProvider", String.Empty);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdatePaymentProviderCommand(related.Id, paymentProvider, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetPaymentProviderByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    public virtual async Task<ActionResult<PaymentProviderDto>> PatchToPaymentProvider(System.Int64 key, [FromBody] Delta<PaymentProviderPartialUpdateDto> paymentProvider)
    {
        if (!ModelState.IsValid || paymentProvider is null)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var related = (await _mediator.Send(new GetPaymentDetailByIdQuery(key))).Select(x => x.PaymentProvider).SingleOrDefault();
        if (related == null)
        {
            throw new EntityNotFoundException("PaymentProvider", String.Empty);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in paymentProvider.GetChangedPropertyNames())
        {
            if(paymentProvider.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdatePaymentProviderCommand(related.Id, updateProperties, _cultureCode, etag));
        
        var updatedItem = (await _mediator.Send(new GetPaymentProviderByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(updatedItem);
    }
    
    #endregion
    
}
