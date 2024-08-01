// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nox.Extensions;

using TestWebApp.Application.Dto;

using ApplicationCommandsNameSpace = TestWebApp.Application.Commands;

namespace TestWebApp.Presentation.Api.OData;

public abstract partial class TestEntityOwnedRelationshipZeroOrManiesControllerBase
{
            
    [HttpDelete("/api/v1/TestEntityOwnedRelationshipZeroOrManies/{key}/SecEntityOwnedRelZeroOrManies")]
    public virtual async Task<IActionResult> DeleteTestEntityOwnedRelationshipZeroOrManyAllOwnedSecEntityOwnedRelZeroOrManiesNonConventional([FromRoute] System.String key)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(new TestEntityOwnedRelationshipZeroOrManyKeyDto(key), etag));
        return NoContent();
    }
    [HttpDelete("/api/v1/TestEntityOwnedRelationshipZeroOrManies/{key}/SecEntityOwnedRelZeroOrManies/{relatedKey}")]
    public virtual async Task<IActionResult> DeleteTestEntityOwnedRelationshipZeroOrManyOwnedSecEntityOwnedRelZeroOrManyNonConventional([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(new TestEntityOwnedRelationshipZeroOrManyKeyDto(key), new SecEntityOwnedRelZeroOrManyKeyDto(relatedKey), etag));
        return NoContent();
    }
}
