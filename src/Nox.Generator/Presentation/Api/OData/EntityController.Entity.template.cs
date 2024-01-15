{{- func keyNameWithPrefix(name, prefix = "key")	
    ret ("{" + prefix + name + ".ToString()}")
end -}}
{{- func keysToString(keys)
    if keys.size > 1
	    ret (keys | array.map "Name" | array.each @keyNameWithPrefix | array.join ", ")
    else
        ret "{key.ToString()}"
    end
end -}}
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
using System.Net.Http.Headers;
using {{codeGenConventions.ApplicationNameSpace}};
using {{codeGenConventions.ApplicationNameSpace}}.Dto;
using {{codeGenConventions.ApplicationNameSpace}}.Queries;
using {{codeGenConventions.ApplicationNameSpace}}.Commands;
using {{codeGenConventions.DomainNameSpace}};
using {{codeGenConventions.PersistenceNameSpace}};

namespace {{codeGenConventions.ODataNameSpace}};

public partial class {{entity.PluralName}}Controller : {{entity.PluralName}}ControllerBase
{
    public {{entity.PluralName}}Controller(
            IMediator mediator,
            Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
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
        Nox.Presentation.Api.Providers.IHttpLanguageProvider httpLanguageProvider
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
    {{~ if entity.Persistence != null && !entity.Persistence.Read.IsEnabled }}
    [ApiExplorerSettings(IgnoreApi = true)]
    {{- end }}
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<{{entity.Name}}Dto>>> Get()
    {
        var result = await _mediator.Send(new Get{{entity.PluralName}}Query());
        return Ok(result);
    }
    {{~ if entity.Persistence != null && !entity.Persistence.Read.IsEnabled }}
    [ApiExplorerSettings(IgnoreApi = true)]
    {{- end }}
    [EnableQuery]
    public virtual async Task<SingleResult<{{entity.Name}}Dto>> Get({{ primaryKeysRoute }})
    {
        var result = await _mediator.Send(new Get{{ entity.Name }}ByIdQuery({{ primaryKeysQuery }}));
        return SingleResult.Create(result);
    }
    {{~ if entity.Persistence != null && !entity.Persistence.Create.IsEnabled }}
    [ApiExplorerSettings(IgnoreApi = true)]
    {{- end }}
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

        var item = (await _mediator.Send(new Get{{entity.Name}}ByIdQuery({{ createdKeyPrimaryKeysQuery }}))).SingleOrDefault();

        return Created(item);
    }
    {{~ if entity.Persistence != null && !entity.Persistence.Update.IsEnabled }}
    [ApiExplorerSettings(IgnoreApi = true)]
    {{- end }}
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

        var item = (await _mediator.Send(new Get{{entity.Name}}ByIdQuery({{ updatedKeyPrimaryKeysQuery }}))).SingleOrDefault();

        return Ok(item);
    }
    {{~ if entity.Persistence != null && !entity.Persistence.Update.IsEnabled }}
    [ApiExplorerSettings(IgnoreApi = true)]
    {{- end }}
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

        var updatedProperties = Nox.Presentation.Api.OData.ODataApi.GetDeltaUpdatedProperties<{{entity.Name}}PartialUpdateDto>({{ToLowerFirstChar entity.Name}});
        {{~ if !entity.IsOwnedEntity }}
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new PartialUpdate{{ entity.Name }}Command({{ primaryKeysQuery }}, updatedProperties, _cultureCode, etag));
        {{- else }}
        var updatedKey = await _mediator.Send(new PartialUpdate{{ entity.Name }}Command({{ primaryKeysQuery }}, updatedProperties, _cultureCode));
        {{- end}}

        var item = (await _mediator.Send(new Get{{entity.Name}}ByIdQuery({{ updatedKeyPrimaryKeysQuery }}))).SingleOrDefault();

        return Ok(item);
    }
    {{~ if entity.Persistence != null && !entity.Persistence.Delete.IsEnabled }}
    [ApiExplorerSettings(IgnoreApi = true)]
    {{- end }}
    public virtual async Task<ActionResult> Delete({{ primaryKeysRoute }})
    {
        {{- if !entity.IsOwnedEntity }}
        var etag = Request.GetDecodedEtagHeader();
        var result = await _mediator.Send(new Delete{{entity.Name}}ByIdCommand(new List<{{entity.Name}}KeyDto> { new {{entity.Name}}KeyDto({{ primaryKeysQuery }}) }, etag));
        {{- else }}
        var result = await _mediator.Send(new Delete{{entity.Name}}ByIdCommand(new List<{{entity.Name}}KeyDto> { new {{entity.Name}}KeyDto({{ primaryKeysQuery }}) }));
        {{- end }}

        return NoContent();
    }
}