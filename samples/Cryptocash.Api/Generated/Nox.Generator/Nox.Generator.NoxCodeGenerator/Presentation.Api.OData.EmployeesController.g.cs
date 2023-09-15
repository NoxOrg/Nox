// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
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

public partial class EmployeesController : EmployeesControllerBase
            {
                public EmployeesController(IMediator mediator, DtoDbContext databaseContext):base(databaseContext, mediator)
                {}
            }
public abstract class EmployeesControllerBase : ODataController
{
    
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;
    
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    
    public EmployeesControllerBase(
        DtoDbContext databaseContext,
        IMediator mediator
    )
    {
        _databaseContext = databaseContext;
        _mediator = mediator;
    }
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<EmployeeDto>>> Get()
    {
        var result = await _mediator.Send(new GetEmployeesQuery());
        return Ok(result);
    }
    
    [EnableQuery]
    public async Task<SingleResult<EmployeeDto>> Get([FromRoute] System.Int64 key)
    {
        var query = await _mediator.Send(new GetEmployeeByIdQuery(key));
        return SingleResult.Create(query);
    }
    
    public virtual async Task<ActionResult<EmployeeDto>> Post([FromBody]EmployeeCreateDto employee)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var createdKey = await _mediator.Send(new CreateEmployeeCommand(employee));
        
        var item = (await _mediator.Send(new GetEmployeeByIdQuery(createdKey.keyId))).SingleOrDefault();
        
        return Created(item);
    }
    
    public virtual async Task<ActionResult<EmployeeDto>> Put([FromRoute] System.Int64 key, [FromBody] EmployeeUpdateDto employee)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new UpdateEmployeeCommand(key, employee, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        
        var item = (await _mediator.Send(new GetEmployeeByIdQuery(updated.keyId))).SingleOrDefault();
        
        return Ok(item);
    }
    
    public virtual async Task<ActionResult<EmployeeDto>> Patch([FromRoute] System.Int64 key, [FromBody] Delta<EmployeeDto> employee)
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
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateEmployeeCommand(key, updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetEmployeeByIdQuery(updated.keyId))).SingleOrDefault();
        return Ok(item);
    }
    
    public virtual async Task<ActionResult> Delete([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteEmployeeByIdCommand(key, etag));
        
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    #region Owned Relationships
    
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<EmployeePhoneNumberDto>>> GetEmployeeContactPhoneNumbers([FromRoute] System.Int64 key)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var item = (await _mediator.Send(new GetEmployeeByIdQuery(key))).SingleOrDefault();
        
        if (item is null)
        {
            return NotFound();
        }
        
        return Ok(item.EmployeeContactPhoneNumbers);
    }
    
    [EnableQuery]
    [HttpGet("api/Employees/{key}/EmployeeContactPhoneNumbers/{relatedKey}")]
    public virtual async Task<ActionResult<EmployeePhoneNumberDto>> GetEmployeeContactPhoneNumbersNonConventional(System.Int64 key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var child = await TryGetEmployeeContactPhoneNumbers(key, new EmployeePhoneNumberKeyDto(relatedKey));
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    public virtual async Task<ActionResult> PostToEmployeeContactPhoneNumbers([FromRoute] System.Int64 key, [FromBody] EmployeePhoneNumberCreateDto employeePhoneNumber)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateEmployeePhoneNumberForEmployeeCommand(new EmployeeKeyDto(key), employeePhoneNumber, etag));
        if (createdKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetEmployeeContactPhoneNumbers(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Created(child);
    }
    
    [HttpPut("api/Employees/{key}/EmployeeContactPhoneNumbers/{relatedKey}")]
    public virtual async Task<ActionResult<EmployeePhoneNumberDto>> PutToEmployeePhoneNumbersNonConventional(System.Int64 key, System.Int64 relatedKey, [FromBody] EmployeePhoneNumberUpdateDto employeePhoneNumber)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateEmployeePhoneNumberForEmployeeCommand(new EmployeeKeyDto(key), new EmployeePhoneNumberKeyDto(relatedKey), employeePhoneNumber, etag));
        if (updatedKey == null)
        {
            return NotFound();
        }
        
        var child = await TryGetEmployeeContactPhoneNumbers(key, updatedKey);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpPatch("api/Employees/{key}/EmployeeContactPhoneNumbers/{relatedKey}")]
    public virtual async Task<ActionResult> PatchToEmployeePhoneNumbersNonConventional(System.Int64 key, System.Int64 relatedKey, [FromBody] Delta<EmployeePhoneNumberDto> employeePhoneNumber)
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
        
        var etag = Request.GetDecodedEtagHeader();
        var updated = await _mediator.Send(new PartialUpdateEmployeePhoneNumberForEmployeeCommand(new EmployeeKeyDto(key), new EmployeePhoneNumberKeyDto(relatedKey), updateProperties, etag));
        
        if (updated is null)
        {
            return NotFound();
        }
        var child = await TryGetEmployeeContactPhoneNumbers(key, updated);
        if (child == null)
        {
            return NotFound();
        }
        
        return Ok(child);
    }
    
    [HttpDelete("api/Employees/{key}/EmployeeContactPhoneNumbers/{relatedKey}")]
    public virtual async Task<ActionResult> DeleteEmployeePhoneNumberNonConventional(System.Int64 key, System.Int64 relatedKey)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var result = await _mediator.Send(new DeleteEmployeePhoneNumberForEmployeeCommand(new EmployeeKeyDto(key), new EmployeePhoneNumberKeyDto(relatedKey)));
        if (!result)
        {
            return NotFound();
        }
        
        return NoContent();
    }
    
    private async Task<EmployeePhoneNumberDto?> TryGetEmployeeContactPhoneNumbers(System.Int64 key, EmployeePhoneNumberKeyDto childKeyDto)
    {
        var parent = (await _mediator.Send(new GetEmployeeByIdQuery(key))).SingleOrDefault();
        return parent?.EmployeeContactPhoneNumbers.SingleOrDefault(x => x.Id == childKeyDto.keyId);
    }
    
    #endregion
    
}
