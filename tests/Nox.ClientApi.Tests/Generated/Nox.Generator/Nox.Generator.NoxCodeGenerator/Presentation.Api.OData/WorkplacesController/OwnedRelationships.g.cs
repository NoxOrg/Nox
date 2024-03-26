// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nox.Extensions;

using ClientApi.Application.Dto;

using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class WorkplacesControllerBase
{
            
    [HttpDelete("/api/v1/Workplaces/{key}/WorkplaceAddresses")]
    public virtual async Task<IActionResult> DeleteWorkplaceAllOwnedWorkplaceAddressesNonConventional([FromRoute] System.Int64 key)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllWorkplaceAddressesForWorkplaceCommand(new WorkplaceKeyDto(key), etag));
        return NoContent();
    }
    [HttpDelete("/api/v1/Workplaces/{key}/WorkplaceAddresses/{relatedKey}")]
    public virtual async Task<IActionResult> DeleteWorkplaceOwnedWorkplaceAddressNonConventional([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteWorkplaceAddressesForWorkplaceCommand(new WorkplaceKeyDto(key), new WorkplaceAddressKeyDto(relatedKey), etag));
        return NoContent();
    }
}
