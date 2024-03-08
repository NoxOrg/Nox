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
    public virtual async Task<IActionResult> DeleteTestEntityOwnedRelationshipZeroOrManyOwnedSecEntityOwnedRelZeroOrManies([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllSecEntityOwnedRelZeroOrManiesForTestEntityOwnedRelationshipZeroOrManyCommand(new TestEntityOwnedRelationshipZeroOrManyKeyDto(key), etag));
        return NoContent();
    }
}
