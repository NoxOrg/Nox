// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class CountriesControllerBase
{
            
    [HttpDelete("Countries/{key}/CountryLocalNames")]
    public async Task<IActionResult> DeleteCountryOwnedCountryLocalNames([FromRoute] System.Int64 key)
    {
        await Task.CompletedTask;
        return NoContent();
    }
            
    [HttpDelete("Countries/{key}/CountryBarCode")]
    public async Task<IActionResult> DeleteCountryOwnedCountryBarCode([FromRoute] System.Int64 key)
    {
        await Task.CompletedTask;
        return NoContent();
    }
            
    [HttpDelete("Countries/{key}/CountryTimeZones")]
    public async Task<IActionResult> DeleteCountryOwnedCountryTimeZones([FromRoute] System.Int64 key)
    {
        await Task.CompletedTask;
        return NoContent();
    }
            
    [HttpDelete("Countries/{key}/Holidays")]
    public async Task<IActionResult> DeleteCountryOwnedHolidays([FromRoute] System.Int64 key)
    {
        await Task.CompletedTask;
        return NoContent();
    }
}
