// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nox.Extensions;

using TestWebApp.Application.Dto;

using ApplicationCommandsNameSpace = TestWebApp.Application.Commands;

namespace TestWebApp.Presentation.Api.OData;

public abstract partial class TestEntityOwnedRelationshipZeroOrOnesControllerBase
{
            
    [HttpDelete("/api/v1/TestEntityOwnedRelationshipZeroOrOnes/{key}/SecondTestEntityOwnedRelationshipZeroOrOne")]
    public virtual async Task<IActionResult> DeleteTestEntityOwnedRelationshipZeroOrOneOwnedSecondTestEntityOwnedRelationshipZeroOrOne([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllSecondTestEntityOwnedRelationshipZeroOrOneForTestEntityOwnedRelationshipZeroOrOneCommand(new TestEntityOwnedRelationshipZeroOrOneKeyDto(key), etag));
        return NoContent();
    }
}
