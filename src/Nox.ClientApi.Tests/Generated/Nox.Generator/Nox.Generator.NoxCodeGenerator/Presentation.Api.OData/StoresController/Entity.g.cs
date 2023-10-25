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
using System.Net.Http.Headers;
using ClientApi.Application;
using ClientApi.Application.Dto;
using ClientApi.Application.Queries;
using ClientApi.Application.Commands;
using ClientApi.Domain;
using ClientApi.Infrastructure.Persistence;

using Nox.Types;
using Nox.Presentation.Api;

namespace ClientApi.Presentation.Api.OData;

public abstract partial class StoresControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The HTTP language provider.
    /// </symmary>
    protected readonly IHttpLanguageProvider _languageProvider;

    protected StoresControllerBase(
        IMediator mediator,
        IHttpLanguageProvider languageProvider
    )
    {
        _mediator = mediator;
        _languageProvider = languageProvider;
    }

    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<StoreDto>>> Get()
    {
        var result = await _mediator.Send(new GetStoresQuery());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<StoreDto>> Get([FromRoute] System.Guid key)
    {
        var result = await _mediator.Send(new GetStoreByIdQuery(key));
        return SingleResult.Create(result);
    }

    public virtual async Task<ActionResult<StoreDto>> Post([FromBody] StoreCreateDto store)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var language = _languageProvider.GetLanguage();
        var createdKey = await _mediator.Send(new CreateStoreCommand(store, language));

        var item = (await _mediator.Send(new GetStoreByIdQuery(createdKey.keyId))).SingleOrDefault();

        return Created(item);
    }

    public virtual async Task<ActionResult<StoreDto>> Put([FromRoute] System.Guid key, [FromBody] StoreUpdateDto store)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new UpdateStoreCommand(key, store, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetStoreByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<StoreDto>> Patch([FromRoute] System.Guid key, [FromBody] Delta<StoreDto> store)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in store.GetChangedPropertyNames())
        {
            if (store.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }

        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdateStoreCommand(key, updatedProperties, etag));

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new GetStoreByIdQuery(updatedKey.keyId))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult> Delete([FromRoute] System.Guid key)
    {
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new DeleteStoreByIdCommand(key, etag));

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
}

public partial class StoresController : StoresControllerBase
{
    public StoresController(IMediator mediator, IHttpLanguageProvider languageProvider)
        : base(mediator, languageProvider)
    {}
}