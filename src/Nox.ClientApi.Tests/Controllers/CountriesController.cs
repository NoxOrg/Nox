using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System;
using System.Net.Http.Headers;
using Nox.Application;
using Nox.Extensions;
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;
using Nox.Types;

namespace ClientApi.Presentation.Api.OData;

/// <summary>
/// Example of extending a Nox generated controller with additional end points
/// </summary>
public partial class CountriesController
{
    /// <summary>
    /// Example of extendiing a Commands with new properties, <seealso cref="CreateCountryLocalNameForCountryCommand"/>
    /// </summary>
    /// <param name="key"></param>
    /// <param name="countryLocalName"></param>
    /// <returns></returns>
    public override async Task<ActionResult> PostToCountryShortNames([FromRoute] long key, [FromBody] CountryLocalNameCreateDto countryLocalName)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var createdKey = await _mediator.Send(new CreateCountryLocalNameForCountryCommand(new CountryKeyDto(key), countryLocalName, etag) { CustomField = "Example"});
        if (createdKey == null)
        {
            return NotFound();
        }

        var child = await TryGetCountryShortNames(key, createdKey);
        if (child == null)
        {
            return NotFound();
        }

        return Created(child);
    }

    /// <summary>
    /// Example of a OData Function / end point with Query enable
    /// <seealso cref="ClientApi.Tests.StartupFixture"/> how to add nox and configure a OData End point
    /// </summary>
    /// <returns>Prefer using Nox Solution Entity Definition (yaml) to register custom function</returns>
    [EnableQuery]
    [HttpGet("api/CountriesWithDebt")]
    public ActionResult<IQueryable<Application.Dto.CountryDto>> CountriesWithDebt()
    {                
        return Ok(new List<Application.Dto.CountryDto>() {
            new Application.Dto.CountryDto()
            {
                Id = 1
            }
        });
    }

    /// <summary>
    /// Example of a non OData end point. Prefer using Odata EndPoints 
    /// And  Nox Solution Entity Definition (yaml) to register custom function
    /// </summary>
    /// <returns></returns>
    [HttpGet("api/[controller]/[action]")]
    public ActionResult<IQueryable<Application.Dto.CountryDto>> CountriesWithDebt2()
    {
        return Ok(new List<Application.Dto.CountryDto>() {
            new Application.Dto.CountryDto()
            {
                Id = 1
            }
        });
    }
}
