// Generated#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.OData.Query;

using Microsoft.AspNetCore.Mvc;
using Nox.Application.Dto;

using DtoNameSpace = ClientApi.Application.Dto;
using ApplicationQueriesNameSpace = ClientApi.Application.Queries;
using ApplicationCommandsNameSpace = ClientApi.Application.Commands;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class TenantsControllerBase
{
    [HttpGet("/api/v1/Tenants/Statuses")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.TenantStatusDto>>> GetTenantStatusesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetTenantsStatusesQuery(_cultureCode));                        
        return Ok(result);        
    }
        
    [HttpPut("/api/v1/Tenants/TenantBrands/Statuses/{relatedKey}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult<DtoNameSpace.TenantBrandStatusLocalizedDto>> PutTenantBrandStatusesLocalizedNonConventional([FromRoute] System.Int32 relatedKey,[FromRoute] System.String cultureCode, [FromBody] DtoNameSpace.TenantBrandStatusLocalizedUpsertDto tenantBrandStatusLocalizedUpsertDto)
    {   
        if (tenantBrandStatusLocalizedUpsertDto is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var upsertedKeyDto = await _mediator.Send(new ApplicationCommandsNameSpace.UpsertTenantBrandsStatusesTranslationCommand(Nox.Types.Enumeration.FromDatabase(relatedKey), tenantBrandStatusLocalizedUpsertDto, Nox.Types.CultureCode.From(cultureCode)));                        
        var result = (await _mediator.Send(new ApplicationQueriesNameSpace.GetTenantBrandsStatusesTranslationsQuery())).SingleOrDefault(x => x.Id == upsertedKeyDto.Id && x.CultureCode == upsertedKeyDto.cultureCode);
        return Ok(result);       
    }

    [HttpDelete("/api/v1/Tenants/TenantBrands/Statuses/{relatedKey}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult> DeleteTenantBrandStatusesLocalizedNonConventional([FromRoute] System.Int32 relatedKey, [FromRoute] System.String cultureCode)
    {   
        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));

        var result = await _mediator.Send(new ApplicationCommandsNameSpace.DeleteTenantBrandsStatusesTranslationsCommand(Nox.Types.Enumeration.FromDatabase(relatedKey), cultureCodeValue!));                        
        return NoContent();     
    }
        
    [HttpPut("/api/v1/Tenants/TenantContact/Statuses/{relatedKey}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult<DtoNameSpace.TenantContactStatusLocalizedDto>> PutTenantContactStatusesLocalizedNonConventional([FromRoute] System.Int32 relatedKey,[FromRoute] System.String cultureCode, [FromBody] DtoNameSpace.TenantContactStatusLocalizedUpsertDto tenantContactStatusLocalizedUpsertDto)
    {   
        if (tenantContactStatusLocalizedUpsertDto is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var upsertedKeyDto = await _mediator.Send(new ApplicationCommandsNameSpace.UpsertTenantContactsStatusesTranslationCommand(Nox.Types.Enumeration.FromDatabase(relatedKey), tenantContactStatusLocalizedUpsertDto, Nox.Types.CultureCode.From(cultureCode)));                        
        var result = (await _mediator.Send(new ApplicationQueriesNameSpace.GetTenantContactsStatusesTranslationsQuery())).SingleOrDefault(x => x.Id == upsertedKeyDto.Id && x.CultureCode == upsertedKeyDto.cultureCode);
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