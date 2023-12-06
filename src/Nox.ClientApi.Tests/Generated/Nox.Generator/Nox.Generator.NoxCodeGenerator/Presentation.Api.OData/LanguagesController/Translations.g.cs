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
         


public abstract partial class LanguagesControllerBase
{  
    
    [HttpPut("/api/v1/Languages/{key}/LanguagesLocalized/{cultureCode}")]
    public virtual async Task<ActionResult<LanguageLocalizedDto>> PutLanguageLocalized( [FromRoute] System.String key, [FromRoute] System.String cultureCode, [FromBody] LanguageLocalizedUpsertDto languageLocalizedUpsertDto)
    {
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var etag = (await _mediator.Send(new GetLanguageByIdQuery(key))).Select(e=>e.Etag).SingleOrDefault();
        
        if (etag == System.Guid.Empty)
        {
            return NotFound();
        }
        
        var updatedProperties = new Dictionary<string, dynamic>();
        updatedProperties.Add(nameof(languageLocalizedUpsertDto.Name), languageLocalizedUpsertDto.Name.ToValueFromNonNull());
        
        var updatedKey = await _mediator.Send(new PartialUpdateLanguageCommand(key, updatedProperties, Nox.Types.CultureCode.From(cultureCode) , etag));

        if (updatedKey is null)
        {
            return NotFound();
        }
        var item = (await _mediator.Send(new GetLanguageTranslationsByIdQuery( updatedKey.keyId, Nox.Types.CultureCode.From(cultureCode)))).SingleOrDefault();

        return Ok(item);
    }


    [HttpGet("/api/v1/Languages/{key}/LanguagesLocalized/")]
    public virtual async Task<ActionResult<IQueryable<LanguageLocalizedDto>>> GetLanguageLocalizedNonConventional( [FromRoute] System.String key)
    {
        var result = (await _mediator.Send(new GetLanguageTranslationsQuery(key)));
            
        return Ok(result);
    }
}