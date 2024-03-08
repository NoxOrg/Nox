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
    public virtual async Task<IActionResult> DeleteEmployeeOwnedEmployeePhoneNumbers([FromRoute] System.Guid key)
    {
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllEmployeePhoneNumbersForEmployeeCommand(new EmployeeKeyDto(key), etag));
        return NoContent();
    }
}
