// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nox.Extensions;

using Cryptocash.Application.Dto;

using ApplicationCommandsNameSpace = Cryptocash.Application.Commands;

namespace Cryptocash.Presentation.Api.OData;

public abstract partial class CountriesControllerBase
{
            
    [HttpDelete("Countries/{key}/Holidays")]
    public async Task<IActionResult> DeleteCountryOwnedHolidays([FromRoute] System.String key)
    {
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllHolidaysForCountryCommand(new CountryKeyDto(key), etag));
        return NoContent();
    }
}
