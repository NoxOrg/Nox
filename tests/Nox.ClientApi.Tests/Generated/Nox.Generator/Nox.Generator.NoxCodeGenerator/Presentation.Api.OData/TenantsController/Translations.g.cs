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
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Presentation.Api.OData;
         


public abstract partial class TenantsControllerBase
{
    [HttpDelete("/api/v1/Tenants/{key}/TenantBrandsLocalized/{cultureCode}")]
    public virtual async Task<ActionResult<TenantBrandLocalizedDto>> DeleteTenantBrandLocalized( [FromRoute] System.UInt32 key, [FromRoute] System.String cultureCode)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));

        await _mediator.Send(new DeleteTenantBrandsLocalizationsForTenantCommand(key, Nox.Types.CultureCode.From(cultureCode)));

        return NoContent();
    }
    [HttpDelete("/api/v1/Tenants/{key}/TenantContactLocalized/{cultureCode}")]
    public virtual async Task<ActionResult<TenantContactLocalizedDto>> DeleteTenantContactLocalized( [FromRoute] System.UInt32 key, [FromRoute] System.String cultureCode)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));

        await _mediator.Send(new DeleteTenantContactLocalizationsForTenantCommand(key, Nox.Types.CultureCode.From(cultureCode)));

        return NoContent();
    }
}