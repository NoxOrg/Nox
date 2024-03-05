// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class PeopleControllerBase
{
            
    [HttpDelete("People/{key}/UserContactSelection")]
    public async Task<IActionResult> DeletePersonOwnedUserContactSelection([FromRoute] System.Guid key)
    {
        await Task.CompletedTask;
        return NoContent();
    }
}
