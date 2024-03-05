﻿// Generated
#nullable enable
using System.Collections.Generic;
using Microsoft.AspNetCore.OData.Query;

using Microsoft.AspNetCore.Mvc;
using Nox.Application.Dto;

using DtoNameSpace = TestWebApp.Application.Dto;
using ApplicationQueriesNameSpace = TestWebApp.Application.Queries;
using ApplicationCommandsNameSpace = TestWebApp.Application.Commands;

namespace TestWebApp.Presentation.Api.OData;

public abstract partial class TestEntityForTypesControllerBase
{
    [HttpGet("/api/v1/TestEntityForTypes/EnumerationTestFields")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldDto>>> GetEnumerationTestFieldsNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetTestEntityForTypesEnumerationTestFieldsQuery(_cultureCode));                        
        return Ok(result);        
    }
    [EnableQuery]
    [HttpGet("/api/v1/TestEntityForTypes/EnumerationTestFields/Languages")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldLocalizedDto>>> GetEnumerationTestFieldsLanguagesNonConventional()
    {            
        var result = await _mediator.Send(new ApplicationQueriesNameSpace.GetTestEntityForTypesEnumerationTestFieldsTranslationsQuery());                        
        return Ok(result);        
    }

    [HttpDelete("/api/v1/TestEntityForTypes/TestEntityForTypesEnumerationTestFieldsLocalized/{cultureCode}")]
    public virtual async Task<ActionResult> DeleteEnumerationTestFieldsLocalizedNonConventional([FromRoute] System.String cultureCode)
    {   
        Nox.Exceptions.BadRequestException.ThrowIfNotValid(Nox.Types.CultureCode.TryFrom(cultureCode, out var cultureCodeValue));

        var result = await _mediator.Send(new ApplicationCommandsNameSpace.DeleteTestEntityForTypesEnumerationTestFieldsTranslationsCommand(cultureCodeValue!));                        
        return NoContent();     
    }

    [HttpPut("/api/v1/TestEntityForTypes/TestEntityForTypesEnumerationTestFieldsLocalized")]
    public virtual async Task<ActionResult<IQueryable<DtoNameSpace.TestEntityForTypesEnumerationTestFieldLocalizedDto>>> PutEnumerationTestFieldsLocalizedNonConventional([FromBody] EnumerationLocalizedListDto<DtoNameSpace.TestEntityForTypesEnumerationTestFieldLocalizedDto> testEntityForTypesEnumerationTestFieldLocalizedDtos)
    {   
        
        if (testEntityForTypesEnumerationTestFieldLocalizedDtos is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        var result = await _mediator.Send(new ApplicationCommandsNameSpace.UpsertTestEntityForTypesEnumerationTestFieldsTranslationsCommand(testEntityForTypesEnumerationTestFieldLocalizedDtos.Items));                        
        return Ok(result);       
    } 
}
