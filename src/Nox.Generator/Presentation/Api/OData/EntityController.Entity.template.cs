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

using Nox.Types;
using Nox.Presentation.Api;

namespace {{codeGeneratorState.ODataNameSpace}};

public abstract partial class {{entity.PluralName}}ControllerBase : ODataController
{
    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;

    /// <symmary>
    /// The HTTP language provider.
    /// </symmary>
    protected readonly IHttpLanguageProvider _languageProvider;

    protected {{entity.PluralName}}ControllerBase(
        IMediator mediator,
        IHttpLanguageProvider languageProvider
        {{- for query in entity.Queries }},
        {{ query.Name }}QueryBase {{ ToLowerFirstChar query.Name }}
        {{- end }}
    )
    {
        _mediator = mediator;
        _languageProvider = languageProvider;
    
        {{- for query in entity.Queries }}
        _{{ ToLowerFirstChar query.Name}} = {{ ToLowerFirstChar query.Name }};
        {{- end }}
    }
    {{~ if entity.Persistence == null || entity.Persistence.Read.IsEnabled }}
    [EnableQuery]
    public virtual async Task<ActionResult<IQueryable<{{entity.Name}}Dto>>> Get()
    {
        var result = await _mediator.Send(new Get{{entity.PluralName}}Query());
        return Ok(result);
    }

    [EnableQuery]
    public async Task<SingleResult<{{entity.Name}}Dto>> Get({{ primaryKeysRoute }})
    {
        var result = await _mediator.Send(new Get{{ entity.Name }}ByIdQuery({{ primaryKeysQuery }}));
        return SingleResult.Create(result);
    }
    {{- end }}
    {{~ if entity.Persistence == null || entity.Persistence.Create.IsEnabled }}
    public virtual async Task<ActionResult<{{ entity.Name }}Dto>> Post([FromBody] {{entity.Name}}CreateDto {{ToLowerFirstChar entity.Name}})
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var language = _languageProvider.GetLanguage();
        var createdKey = await _mediator.Send(new Create{{entity.Name}}Command({{ToLowerFirstChar entity.Name}}, language));

        var item = (await _mediator.Send(new Get{{entity.Name}}ByIdQuery({{ createdKeyPrimaryKeysQuery }}))).SingleOrDefault();

        return Created(item);
    }
    {{- end}}
    {{~ if entity.Persistence == null || entity.Persistence.Update.IsEnabled }}
    public virtual async Task<ActionResult<{{entity.Name}}Dto>> Put({{ primaryKeysRoute }}, [FromBody] {{entity.Name}}UpdateDto {{ToLowerFirstChar entity.Name}})
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        {{~ if !entity.IsOwnedEntity }}
        var etag = Request.GetDecodedEtagHeader();
        var updatedKey = await _mediator.Send(new Update{{ entity.Name }}Command({{ primaryKeysQuery }}, {{ToLowerFirstChar entity.Name}}, etag));
        {{- else }}
        var updatedKey = await _mediator.Send(new Update{{ entity.Name }}Command({{ primaryKeysQuery }}, {{ToLowerFirstChar entity.Name}}));
        {{- end}}

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new Get{{entity.Name}}ByIdQuery({{ updatedKeyPrimaryKeysQuery }}))).SingleOrDefault();

        return Ok(item);
    }

    public virtual async Task<ActionResult<{{entity.Name}}Dto>> Patch({{ primaryKeysRoute }}, [FromBody] Delta<{{entity.Name}}Dto> {{ToLowerFirstChar entity.Name}})
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
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
        var updatedKey = await _mediator.Send(new PartialUpdate{{ entity.Name }}Command({{ primaryKeysQuery }}, updatedProperties, etag));
        {{- else }}
        var updatedKey = await _mediator.Send(new PartialUpdate{{ entity.Name }}Command({{ primaryKeysQuery }}, updatedProperties));
        {{- end}}

        if (updatedKey is null)
        {
            return NotFound();
        }

        var item = (await _mediator.Send(new Get{{entity.Name}}ByIdQuery({{ updatedKeyPrimaryKeysQuery }}))).SingleOrDefault();

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

public partial class {{entity.PluralName}}Controller : {{entity.PluralName}}ControllerBase
{
    public {{entity.PluralName}}Controller(IMediator mediator, IHttpLanguageProvider languageProvider)
        : base(mediator, languageProvider)
    {}
}