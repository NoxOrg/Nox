// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nox.Extensions;

using Cryptocash.Application.Dto;

using ApplicationCommandsNameSpace = Cryptocash.Application.Commands;

namespace Cryptocash.Presentation.Api.OData;

public abstract partial class EmployeesControllerBase
{
            
    [HttpDelete("/api/Employees/{key}/EmployeePhoneNumbers")]
    public virtual async Task<IActionResult> DeleteEmployeeAllOwnedEmployeePhoneNumbersNonConventional([FromRoute] System.Guid key)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllEmployeePhoneNumbersForEmployeeCommand(new EmployeeKeyDto(key), etag));
        return NoContent();
    }
    [HttpDelete("/api/Employees/{key}/EmployeePhoneNumbers/{relatedKey}")]
    public virtual async Task<IActionResult> DeleteEmployeeOwnedEmployeePhoneNumberNonConventional([FromRoute] System.Guid key, [FromRoute] System.Int64 relatedKey)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteEmployeePhoneNumbersForEmployeeCommand(new EmployeeKeyDto(key), new EmployeePhoneNumberKeyDto(relatedKey), etag));
        return NoContent();
    }
}
