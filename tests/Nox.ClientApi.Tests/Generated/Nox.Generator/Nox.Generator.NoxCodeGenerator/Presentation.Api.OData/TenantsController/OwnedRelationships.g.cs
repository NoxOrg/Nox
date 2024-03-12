// Generated

#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Nox.Extensions;

using ClientApi.Application.Dto;

using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class TenantsControllerBase
{
            
    [HttpDelete("/api/v1/Tenants/{key}/TenantBrands")]
    public virtual async Task<IActionResult> DeleteTenantAllOwnedTenantBrandsNonConventional([FromRoute] System.UInt32 key)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllTenantBrandsForTenantCommand(new TenantKeyDto(key), etag));
        return NoContent();
    }
    [HttpDelete("/api/v1/Tenants/{key}/TenantBrands/{relatedKey}")]
    public virtual async Task<IActionResult> DeleteTenantOwnedTenantBrandNonConventional([FromRoute] System.UInt32 key, [FromRoute] System.Int64 relatedKey)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteTenantBrandsForTenantCommand(new TenantKeyDto(key), new TenantBrandKeyDto(relatedKey), etag));
        return NoContent();
    }
            
    [HttpDelete("/api/v1/Tenants/{key}/TenantContact")]
    public virtual async Task<IActionResult> DeleteTenantAllOwnedTenantContactNonConventional([FromRoute] System.UInt32 key)
    {
        if(!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = Request.GetDecodedEtagHeader();
        await _mediator.Send(new ApplicationCommandsNameSpace.DeleteAllTenantContactForTenantCommand(new TenantKeyDto(key), etag));
        return NoContent();
    }
}
