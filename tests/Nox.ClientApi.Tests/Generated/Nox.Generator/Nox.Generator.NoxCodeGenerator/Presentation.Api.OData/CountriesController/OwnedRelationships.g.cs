// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nox.Extensions;

using ClientApi.Application.Dto;

using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class CountriesControllerBase
{
            
    [HttpDelete("/api/v1/Countries/{key}/CountryLocalNames")]
    public virtual async Task<IActionResult> DeleteCountryOwnedCountryLocalNames([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllCountryLocalNamesForCountryCommand(new CountryKeyDto(key), etag));
        return NoContent();
    }
            
    [HttpDelete("/api/v1/Countries/{key}/CountryBarCode")]
    public virtual async Task<IActionResult> DeleteCountryOwnedCountryBarCode([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllCountryBarCodeForCountryCommand(new CountryKeyDto(key), etag));
        return NoContent();
    }
            
    [HttpDelete("/api/v1/Countries/{key}/CountryTimeZones")]
    public virtual async Task<IActionResult> DeleteCountryOwnedCountryTimeZones([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllCountryTimeZonesForCountryCommand(new CountryKeyDto(key), etag));
        return NoContent();
    }
            
    [HttpDelete("/api/v1/Countries/{key}/Holidays")]
    public virtual async Task<IActionResult> DeleteCountryOwnedHolidays([FromRoute] System.Int64 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllHolidaysForCountryCommand(new CountryKeyDto(key), etag));
        return NoContent();
    }
}
