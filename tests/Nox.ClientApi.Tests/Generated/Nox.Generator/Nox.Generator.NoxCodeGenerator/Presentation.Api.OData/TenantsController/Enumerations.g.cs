// Generated#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Nox.Application.Dto;

using DtoNameSpace = ClientApi.Application.Dto;
using ApplicationQueriesNameSpace = ClientApi.Application.Queries;
using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class TenantsControllerBase
{
    [EnableQuery]
    [HttpGet("/api/v1/Tenants/Statuses")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.TenantStatusDto>>> GetTenantStatusesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetTenantsStatusesQuery(_cultureCode));                        
        return Ok(result);        
    }
        
    [EnableQuery]
    [HttpGet("/api/v1/Tenants/TenantBrands/Statuses")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.TenantBrandStatusDto>>> GetTenantBrandStatusesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetTenantBrandsStatusesQuery(_cultureCode));                        
        return Ok(result);        
    }
    [EnableQuery]
    [HttpGet("/api/v1/Tenants/TenantBrands/Statuses/Languages")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.TenantBrandStatusLocalizedDto>>> GetTenantBrandStatusesLanguagesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetTenantBrandsStatusesTranslationsQuery());                        
        return Ok(result);        
    } 
    [HttpDelete("/api/v1/Tenants/TenantBrands/Statuses/{relatedKey}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult> DeleteTenantBrandStatusesLocalizedNonConventional([FromRoute] System.Int32 relatedKey, [FromRoute] System.String cultureCode)
    {   
        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));

        var result = await _mediator.Send(new ApplicationCommandsNameSpace.DeleteTenantBrandsStatusesTranslationsCommand(Nox.Types.Enumeration.FromDatabase(relatedKey), cultureCodeValue!));                        
        return NoContent();     
    }
        
    [EnableQuery]
    [HttpGet("/api/v1/Tenants/TenantContact/Statuses")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.TenantContactStatusDto>>> GetTenantContactStatusesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetTenantContactsStatusesQuery(_cultureCode));                        
        return Ok(result);        
    }
    [EnableQuery]
    [HttpGet("/api/v1/Tenants/TenantContact/Statuses/Languages")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.TenantContactStatusLocalizedDto>>> GetTenantContactStatusesLanguagesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetTenantContactsStatusesTranslationsQuery());                        
        return Ok(result);        
    } 
    [HttpDelete("/api/v1/Tenants/TenantContact/Statuses/{relatedKey}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult> DeleteTenantContactStatusesLocalizedNonConventional([FromRoute] System.Int32 relatedKey, [FromRoute] System.String cultureCode)
    {   
        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));

        var result = await _mediator.Send(new ApplicationCommandsNameSpace.DeleteTenantContactsStatusesTranslationsCommand(Nox.Types.Enumeration.FromDatabase(relatedKey), cultureCodeValue!));                        
        return NoContent();     
    } 
}