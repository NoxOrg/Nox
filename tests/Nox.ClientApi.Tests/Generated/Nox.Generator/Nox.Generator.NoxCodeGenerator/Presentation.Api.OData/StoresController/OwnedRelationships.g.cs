// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nox.Extensions;

using ClientApi.Application.Dto;

using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class StoresControllerBase
{
            
    [HttpDelete("Stores/{key}/EmailAddress")]
    public async Task<IActionResult> DeleteStoreOwnedEmailAddress([FromRoute] System.Guid key)
    {
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllEmailAddressForStoreCommand(new StoreKeyDto(key), etag));
        return NoContent();
    }
}
