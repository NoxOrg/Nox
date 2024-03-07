﻿// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nox.Extensions;

using ClientApi.Application.Dto;

using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class TenantsControllerBase
{
            
    [HttpDelete("Tenants/{key}/TenantBrands")]
    public async Task<IActionResult> DeleteTenantOwnedTenantBrands([FromRoute] System.UInt32 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllTenantBrandsForTenantCommand(new TenantKeyDto(key), etag));
        return NoContent();
    }
            
    [HttpDelete("Tenants/{key}/TenantContact")]
    public async Task<IActionResult> DeleteTenantOwnedTenantContact([FromRoute] System.UInt32 key)
    {
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllTenantContactForTenantCommand(new TenantKeyDto(key), etag));
        return NoContent();
    }
}
