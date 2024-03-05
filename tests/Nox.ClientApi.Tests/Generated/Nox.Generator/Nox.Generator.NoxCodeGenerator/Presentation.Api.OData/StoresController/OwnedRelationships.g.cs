// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class StoresControllerBase
{
            
    [HttpDelete("Stores/{key}/EmailAddress")]
    public async Task<IActionResult> DeleteStoreOwnedEmailAddress([FromRoute] System.Guid key)
    {
        await Task.CompletedTask;
        return NoContent();
    }
}
