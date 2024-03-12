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
    [HttpDelete("/api/Countries/{key}/CountryTimeZones/{relatedKey}")]
    public virtual async Task<IActionResult> DeleteCountryOwnedCountryTimeZoneNonConventional([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteCountryTimeZonesForCountryCommand(new CountryKeyDto(key), new CountryTimeZoneKeyDto(relatedKey), etag));
        return NoContent();
    }
            
    [HttpDelete("/api/Countries/{key}/Holidays")]
    public virtual async Task<IActionResult> DeleteCountryAllOwnedHolidaysNonConventional([FromRoute] System.String key)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllHolidaysForCountryCommand(new CountryKeyDto(key), etag));
        return NoContent();
    }
    [HttpDelete("/api/Countries/{key}/Holidays/{relatedKey}")]
    public virtual async Task<IActionResult> DeleteCountryOwnedHolidayNonConventional([FromRoute] System.String key, [FromRoute] System.Int64 relatedKey)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteHolidaysForCountryCommand(new CountryKeyDto(key), new HolidayKeyDto(relatedKey), etag));
        return NoContent();
    }
}
