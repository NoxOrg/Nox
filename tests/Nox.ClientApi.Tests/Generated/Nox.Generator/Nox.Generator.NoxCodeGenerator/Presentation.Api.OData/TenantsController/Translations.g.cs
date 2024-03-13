// Generated

#nullable enable

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Nox.Application;
using Nox.Extensions;
using Nox.Exceptions;

using System;
using System.ComponentModel.Design;
using System.Net.Http.Headers;
using ClientApi.Application;
using System.Threading.Tasks;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Presentation.Api.OData;
         


public abstract partial class TenantsControllerBase
{
    [HttpPut("/api/v1/Tenants/{key}/TenantBrandsLocalized/{cultureCode}")]
    public virtual async Task<ActionResult<TenantBrandLocalizedDto>> PutTenantBrandLocalized( [FromRoute] System.UInt32 key, [FromRoute] System.String cultureCode, [FromBody] TenantBrandLocalizedUpsertDto tenantBrandLocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = (await _mediator.Send(new GetTenantByIdQuery(key))).Select(e=>e.Etag).SingleOrDefault();
        
        if (etag == System.Guid.Empty)
        {
            throw new EntityNotFoundException("Tenant", $"{key.ToString()}");
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
        updatedProperties.Add(nameof(tenantBrandLocalizedUpsertDto.Description), tenantBrandLocalizedUpsertDto.Description.ToValueFromNonNull());
        var updatedKey = await _mediator.Send(new PartialUpdateTenantBrandsForTenantCommand(
            new TenantKeyDto(key),
            new TenantBrandKeyDto(tenantBrandLocalizedUpsertDto.Id!.Value),
            updatedProperties, Nox.Types.CultureCode.From(cultureCode), etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("Tenant", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetTenantBrandTranslationsByIdQuery( updatedKey.keyId, Nox.Types.CultureCode.From(cultureCode)))).SingleOrDefault();

        return Ok(item);
    }

    [HttpDelete("/api/v1/Tenants/{key}/TenantBrands/{relatedKey}/Languages/{cultureCode}")]
    public virtual async Task<ActionResult<TenantBrandLocalizedDto>> DeleteTenantBrandLocalized( [FromRoute] System.UInt32 key, [FromRoute] System.Int64 relatedKey, [FromRoute] System.String cultureCode)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));

        await _mediator.Send(new DeleteTenantBrandsTranslationsForTenantCommand(key, relatedKey, Nox.Types.CultureCode.From(cultureCode)));

        return NoContent();
    }
    [HttpPut("/api/v1/Tenants/{key}/TenantContactLocalized/{cultureCode}")]
    public virtual async Task<ActionResult<TenantContactLocalizedDto>> PutTenantContactLocalized( [FromRoute] System.UInt32 key, [FromRoute] System.String cultureCode, [FromBody] TenantContactLocalizedUpsertDto tenantContactLocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        
        var etag = (await _mediator.Send(new GetTenantByIdQuery(key))).Select(e=>e.Etag).SingleOrDefault();
        
        if (etag == System.Guid.Empty)
        {
            throw new EntityNotFoundException("Tenant", $"{key.ToString()}");
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
        updatedProperties.Add(nameof(tenantContactLocalizedUpsertDto.Description), tenantContactLocalizedUpsertDto.Description.ToValueFromNonNull());
        var updatedKey = await _mediator.Send(new PartialUpdateTenantContactForTenantCommand(
            new TenantKeyDto(key),
            updatedProperties, Nox.Types.CultureCode.From(cultureCode), etag));

        if (updatedKey is null)
        {
            throw new EntityNotFoundException("Tenant", $"{key.ToString()}");
        }

        var item = (await _mediator.Send(new GetTenantContactTranslationsByIdQuery( key, Nox.Types.CultureCode.From(cultureCode)))).SingleOrDefault();

        return Ok(item);
    }

    [HttpDelete("/api/v1/Tenants/{key}/TenantContact/Languages/{cultureCode}")]
    public virtual async Task<ActionResult<TenantContactLocalizedDto>> DeleteTenantContactLocalized( [FromRoute] System.UInt32 key, [FromRoute] System.String cultureCode)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));

        await _mediator.Send(new DeleteTenantContactTranslationsForTenantCommand(key, Nox.Types.CultureCode.From(cultureCode)));

        return NoContent();
    }
}