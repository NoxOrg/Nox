// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nox.Extensions;

using TestWebApp.Application.Dto;

using ApplicationCommandsNameSpace = TestWebApp.Application.Commands;

namespace TestWebApp.Presentation.Api.OData;

public abstract partial class TestEntityOwnedRelationshipOneOrManiesControllerBase
{
    [HttpDelete("/api/v1/TestEntityOwnedRelationshipOneOrManies/{key}/SecEntityOwnedRelOneOrManies/{relatedKey}")]
    public virtual async Task<IActionResult> DeleteTestEntityOwnedRelationshipOneOrManyOwnedSecEntityOwnedRelOneOrManyNonConventional([FromRoute] System.String key, [FromRoute] System.String relatedKey)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteSecEntityOwnedRelOneOrManiesForTestEntityOwnedRelationshipOneOrManyCommand(new TestEntityOwnedRelationshipOneOrManyKeyDto(key), new SecEntityOwnedRelOneOrManyKeyDto(relatedKey), etag));
        return NoContent();
    }
}
