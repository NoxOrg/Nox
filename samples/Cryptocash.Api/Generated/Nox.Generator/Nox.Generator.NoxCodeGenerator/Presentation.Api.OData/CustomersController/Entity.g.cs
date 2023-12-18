// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using System;
using System.Net.Http.Headers;
using Cryptocash.Application;
using Cryptocash.Application.Dto;
using Cryptocash.Application.Queries;
using Cryptocash.Application.Commands;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;

namespace Cryptocash.Presentation.Api.OData;

public partial class CustomersController : CustomersControllerBase
{
    public CustomersController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class CustomersControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public CustomersControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<CustomerDto>>> Get()
    {
        var result = await _mediator.Send(new GetCustomersQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<CustomerDto>> Get([FromRoute] System.Guid key)
    {
        var result = await _mediator.Send(new GetCustomerByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<CustomerDto>> Post([FromBody] CustomerCreateDto customer)
    {
        if(customer is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateCustomerCommand(customer, _cultureCode));

        var item = (await _mediator.Send(new GetCustomerByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<CustomerDto>> Put([FromRoute] System.Guid key, [FromBody] CustomerUpdateDto customer)
    {
        if(customer is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateCustomerCommand(key, customer, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("Customer", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetCustomerByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<CustomerDto>> Patch([FromRoute] System.Guid key, [FromBody] Delta<CustomerPartialUpdateDto> customer)
    {
        if(customer is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<CustomerPartialUpdateDto>(customer);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateCustomerCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("Customer", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetCustomerByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Guid key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteCustomerByIdCommand(new List<CustomerKeyDto> { new CustomerKeyDto(key) }, etag));

        if (!result)
        {
            throw new EntityNotFoundException("Customer", $"{key.ToString()}");
        }

        return NoContent();
    }
}