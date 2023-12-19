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

public partial class EmployeesController : EmployeesControllerBase
{
    public EmployeesController(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class EmployeesControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public EmployeesControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<EmployeeDto>>> Get()
    {
        var result = await _mediator.Send(new GetEmployeesQuery());
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<EmployeeDto>> Get([FromRoute] System.Guid key)
    {
        var result = await _mediator.Send(new GetEmployeeByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<EmployeeDto>> Post([FromBody] EmployeeCreateDto employee)
    {
        if(employee is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new CreateEmployeeCommand(employee, _cultureCode));

        var item = (await _mediator.Send(new GetEmployeeByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<EmployeeDto>> Put([FromRoute] System.Guid key, [FromBody] EmployeeUpdateDto employee)
    {
        if(employee is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateEmployeeCommand(key, employee, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("Employee", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetEmployeeByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<EmployeeDto>> Patch([FromRoute] System.Guid key, [FromBody] Delta<EmployeePartialUpdateDto> employee)
    {
        if(employee is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<EmployeePartialUpdateDto>(employee);

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateEmployeeCommand(key, updatedProperties, _cultureCode, etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("Employee", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetEmployeeByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Guid key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteEmployeeByIdCommand(new List<EmployeeKeyDto> { new EmployeeKeyDto(key) }, etag));

        if (!result)
        {
            throw new EntityNotFoundException("Employee", $"{key.ToString()}");
        }

        return NoContent();
    }
}