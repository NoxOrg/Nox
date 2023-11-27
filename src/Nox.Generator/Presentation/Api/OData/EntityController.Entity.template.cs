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
using {{codeGeneratorState.ApplicationNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.ApplicationNameSpace}}.Queries;
using {{codeGeneratorState.ApplicationNameSpace}}.Commands;
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.PersistenceNameSpace}};

namespace {{codeGeneratorState.ODataNameSpace}};

public partial class {{entity.PluralName}}Controller : {{entity.PluralName}}ControllerBase
{
    public {{entity.PluralName}}Controller(
            IMediator mediator,
            Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        ): base(mediator, httpLanguageProvider)
    {}
}

public abstract partial class {{entity.PluralName}}ControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The Culture Code from the HTTP request.
    /// </symmary>
    protected readonly Nox.Types.CultureCode _cultureCode;

    public {{entity.PluralName}}ControllerBase(
        IMediator mediator,
        Nox.Presentation.Api.IHttpLanguageProvider httpLanguageProvider
        {{- for query in entity.Queries }},
        {{ query.Name }}QueryBase {{ ToLowerFirstChar query.Name }}
        {{- end }}
    )
    {
        _mediator = mediator;
        _cultureCode = httpLanguageProvider.GetLanguage();

        {{- for query in entity.Queries }}
        _{{ ToLowerFirstChar query.Name}} = {{ ToLowerFirstChar query.Name }};
        {{- end }}
    }
    {{~ if entity.Persistence == null || entity.Persistence.Read.IsEnabled }}
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<{{entity.Name}}Dto>>> Get()
    {
        var result = await _mediator.Send(new Get{{entity.PluralName}}Query({{if entity.IsLocalized}}_cultureCode{{end}}));
        return Ok(result);
    }

    [EnableQuery]
    public virtual async Task<SingleResult<{{entity.Name}}Dto>> Get({{ primaryKeysRoute }})
    {
        var result = await _mediator.Send(new Get{{ entity.Name }}ByIdQuery({{if entity.IsLocalized || entity.HasLocalizedOwnedRelationships}}_cultureCode, {{end}}{{ primaryKeysQuery }}));
        return SingleResult.Create(result);
    }
    {{- end }}
    {{~ if entity.Persistence == null || entity.Persistence.Create.IsEnabled }}
    public virtual async Task<ActionResult<{{ entity.Name }}Dto>> Post([FromBody] {{entity.Name}}CreateDto {{ToLowerFirstChar entity.Name}})
    {
        if({{ToLowerFirstChar entity.Name}} is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var createdKey = await _mediator.Send(new Create{{entity.Name}}Command({{ToLowerFirstChar entity.Name}}, _cultureCode));

        var item = (await _mediator.Send(new Get{{entity.Name}}ByIdQuery({{if entity.IsLocalized || entity.HasLocalizedOwnedRelationships}}_cultureCode, {{end}}{{ createdKeyPrimaryKeysQuery }}))).SingleOrDefault();

        return Created(item);
    }
    {{- end}}
    {{~ if entity.Persistence == null || entity.Persistence.Update.IsEnabled }}
    public virtual async Task<ActionResult<{{entity.Name}}Dto>> Put({{ primaryKeysRoute }}, [FromBody] {{entity.Name}}UpdateDto {{ToLowerFirstChar entity.Name}})
    {
        if({{ToLowerFirstChar entity.Name}} is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }
        {{~ if !entity.IsOwnedEntity }}
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new Update{{ entity.Name }}Command({{ primaryKeysQuery }}, {{ToLowerFirstChar entity.Name}}, _cultureCode, etag));
        {{- else }}
        var updatedKey = await _mediator.Send(new Update{{ entity.Name }}Command({{ primaryKeysQuery }}, {{ToLowerFirstChar entity.Name}}, _cultureCode));
        {{- end}}

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new Get{{entity.Name}}ByIdQuery({{if entity.IsLocalized || entity.HasLocalizedOwnedRelationships}}_cultureCode, {{end}}{{ updatedKeyPrimaryKeysQuery }}))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<{{entity.Name}}Dto>> Patch({{ primaryKeysRoute }}, [FromBody] Delta<{{entity.Name}}PartialUpdateDto> {{ToLowerFirstChar entity.Name}})
    {
        if({{ToLowerFirstChar entity.Name}} is null)
        {
            throw new Nox.Exceptions.BadRequestInvalidFieldException();
        }
        if (!ModelState.IsValid)
        {
            throw new Nox.Exceptions.BadRequestException(ModelState);
        }

        var updatedProperties = new Dictionary<string, dynamic>();

        foreach (var propertyName in {{ToLowerFirstChar entity.Name}}.GetChangedPropertyNames())
        {
            if ({{ToLowerFirstChar entity.Name}}.TryGetPropertyValue(propertyName, out dynamic value))
            {
                updatedProperties[propertyName] = value;
            }
        }
        {{~ if !entity.IsOwnedEntity }}
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdate{{ entity.Name }}Command({{ primaryKeysQuery }}, updatedProperties, _cultureCode, etag));
        {{- else }}
        var updatedKey = await _mediator.Send(new PartialUpdate{{ entity.Name }}Command({{ primaryKeysQuery }}, updatedProperties, _cultureCode));
        {{- end}}

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new Get{{entity.Name}}ByIdQuery({{if entity.IsLocalized || entity.HasLocalizedOwnedRelationships}}_cultureCode, {{end}}{{ updatedKeyPrimaryKeysQuery }}))).SingleOrDefault();

        return Ok(item);
    }
    {{- end}}
    {{~ if entity.Persistence == null || entity.Persistence.Delete.IsEnabled }}
    public virtual async Task<ActionResult> Delete({{ primaryKeysRoute }})
    {
        {{- if !entity.IsOwnedEntity }}
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new Delete{{entity.Name}}ByIdCommand({{ primaryKeysQuery }}, etag));
        {{- else }}
        var result = await _mediator.Send(new Delete{{entity.Name}}ByIdCommand({{ primaryKeysQuery }}));
        {{- end }}

        if (!result)
        {
            return NotFound();
        }

        return NoContent();
    }
    {{- end }}
}