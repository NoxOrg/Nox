// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Net.Http.Headers;
using Nox.Application;
using Cryptocash.Application;
using Cryptocash.Application.Dto;
using Cryptocash.Application.Queries;
using Cryptocash.Application.Commands;
using Cryptocash.Domain;
using Cryptocash.Infrastructure.Persistence;
using Nox.Types;

namespace Cryptocash.Presentation.Api.OData;

public partial class EmployeesController : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public EmployeesController(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public async  Task<ActionResult<IQueryable<EmployeeDto>>> Get()
    {
        var result = await _mediator.Send(new GetEmployeesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<ActionResult<EmployeeDto>> Get([FromRoute] System.Int64 key)
    {
        var item = await _mediator.Send(new GetEmployeeByIdQuery(key));
        
        if (item == null)
        {
            return NotFound();
        }
        
        return Ok(item);
    }
    
    [EnableQuery]
    public async Task<ActionResult<IQueryable<EmployeePhoneNumberDto>>> GetEmployeePhoneNumbers([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = await _mediator.Send(new GetEmployeeByIdQuery(key));
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.EmployeePhoneNumbers);
    }
    
    public async Task<ActionResult> PostToEmployeePhoneNumbers([FromRoute] System.Int64 key, [FromBody] EmployeePhoneNumberCreateDto employeePhoneNumber)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdKey = await _mediator.Send(new AddEmployeePhoneNumberCommand(new EmployeeKeyDto(key), employeePhoneNumber));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        return Created(new EmployeePhoneNumberDto { Id = createdKey.keyId });
    }
    
    public async Task<ActionResult> PutToEmployeePhoneNumbers([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey, [FromBody] EmployeePhoneNumberUpdateDto employeePhoneNumber)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updatedKey = await _mediator.Send(new UpdateEmployeePhoneNumberCommand(new EmployeeKeyDto(key), new EmployeePhoneNumberKeyDto(relatedKey), employeePhoneNumber));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        return Updated(new EmployeePhoneNumberDto { Id = updatedKey.keyId });
    }
    
    public async Task<ActionResult> PatchToEmployeePhoneNumbers([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey, [FromBody] Delta<EmployeePhoneNumberUpdateDto> employeePhoneNumber)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in employeePhoneNumber.GetChangedPropertyNames())
        {
            if(employeePhoneNumber.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var updated = await _mediator.Send(new PartialUpdateEmployeePhoneNumberCommand(new EmployeeKeyDto(key), updateProperties));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(new EmployeePhoneNumberDto { Id = updated.keyId });
    }
    
    public async Task<ActionResult> Post([FromBody]EmployeeCreateDto employee)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateEmployeeCommand(employee));
        
        return Created(createdKey);
    }
    
    public async Task<ActionResult> Put([FromRoute] System.Int64 key, [FromBody] EmployeeUpdateDto employee)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateEmployeeCommand(key, employee, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Patch([FromRoute] System.Int64 key, [FromBody] Delta<EmployeeUpdateDto> employee)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var updateProperties = new Dictionary<string, dynamic>();
        
        foreach (var propertyName in employee.GetChangedPropertyNames())
        {
            if(employee.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updateProperties[propertyName] = value;                
            }           
        }
        
        var etag = GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateEmployeeCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        return Updated(updated);
    }
    
    public async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var etag = GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteEmployeeByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    private System.Guid? GetDecodedEtagHeader()
    {
        var ifMatchValue = Request.Headers.IfMatch.FirstOrDefault();
        string? rawEtag = ifMatchValue;
        if (EntityTagHeaderValue.TryParse(ifMatchValue, out var encodedEtag))
        {
            rawEtag = encodedEtag.Tag.Trim('"');
        }
        
        return System.Guid.TryParse(rawEtag, out var etag) ? etag : null;
    }
}
