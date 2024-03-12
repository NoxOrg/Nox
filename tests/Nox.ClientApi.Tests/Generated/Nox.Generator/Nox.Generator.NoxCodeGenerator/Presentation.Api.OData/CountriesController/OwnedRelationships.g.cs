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
    public virtual async Task<IActionResult> DeleteCountryAllOwnedCountryLocalNamesNonConventional([FromRoute] System.Int64 key)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllCountryLocalNamesForCountryCommand(new CountryKeyDto(key), etag));
        return NoContent();
    }
    [HttpDelete("/api/v1/Countries/{key}/CountryLocalNames/{relatedKey}")]
    public virtual async Task<IActionResult> DeleteCountryOwnedCountryLocalNameNonConventional([FromRoute] System.Int64 key, [FromRoute] System.Int64 relatedKey)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteCountryLocalNamesForCountryCommand(new CountryKeyDto(key), new CountryLocalNameKeyDto(relatedKey), etag));
        return NoContent();
    }
            
    [HttpDelete("/api/v1/Countries/{key}/CountryBarCode")]
    public virtual async Task<IActionResult> DeleteCountryAllOwnedCountryBarCodeNonConventional([FromRoute] System.Int64 key)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllCountryBarCodeForCountryCommand(new CountryKeyDto(key), etag));
        return NoContent();
    }
            
    [HttpDelete("/api/v1/Countries/{key}/CountryTimeZones")]
    public virtual async Task<IActionResult> DeleteCountryAllOwnedCountryTimeZonesNonConventional([FromRoute] System.Int64 key)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllCountryTimeZonesForCountryCommand(new CountryKeyDto(key), etag));
        return NoContent();
    }
    [HttpDelete("/api/v1/Countries/{key}/CountryTimeZones/{relatedKey}")]
    public virtual async Task<IActionResult> DeleteCountryOwnedCountryTimeZoneNonConventional([FromRoute] System.Int64 key, [FromRoute] System.String relatedKey)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteCountryTimeZonesForCountryCommand(new CountryKeyDto(key), new CountryTimeZoneKeyDto(relatedKey), etag));
        return NoContent();
    }
            
    [HttpDelete("/api/v1/Countries/{key}/Holidays")]
    public virtual async Task<IActionResult> DeleteCountryAllOwnedHolidaysNonConventional([FromRoute] System.Int64 key)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllHolidaysForCountryCommand(new CountryKeyDto(key), etag));
        return NoContent();
    }
    [HttpDelete("/api/v1/Countries/{key}/Holidays/{relatedKey}")]
    public virtual async Task<IActionResult> DeleteCountryOwnedHolidayNonConventional([FromRoute] System.Int64 key, [FromRoute] System.Guid relatedKey)
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
