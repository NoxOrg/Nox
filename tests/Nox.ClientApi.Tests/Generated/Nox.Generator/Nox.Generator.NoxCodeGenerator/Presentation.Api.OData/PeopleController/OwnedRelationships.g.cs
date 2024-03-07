// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nox.Extensions;

using ClientApi.Application.Dto;

using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class PeopleControllerBase
{
            
    [HttpDelete("People/{key}/UserContactSelection")]
    public async Task<IActionResult> DeletePersonOwnedUserContactSelection([FromRoute] System.Guid key)
    {
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllUserContactSelectionForPersonCommand(new PersonKeyDto(key), etag));
        return NoContent();
    }
}
