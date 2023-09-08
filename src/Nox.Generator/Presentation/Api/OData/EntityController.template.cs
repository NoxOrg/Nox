using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Nox.Application;

using using System.Management.Instrumentation;
using System.Security.Cryptography.X509Certificates;
using System;
using System.Runtime.InteropServices;
{ {codeGeneratorState.ApplicationNameSpace}};
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.ApplicationNameSpace}}.Queries;
using {{codeGeneratorState.ApplicationNameSpace}}.Commands;
//using {{codeGeneratorState.DataTransferObjectsNameSpace}};
using {{codeGeneratorState.DomainNameSpace}};
using {{codeGeneratorState.PersistenceNameSpace}};

using Nox.Types;

namespace {{codeGeneratorState.ODataNameSpace}};

public partial class {{entity.PluralName}}Controller : ODataController
{
    /// <summary>
    /// The OData DbContext for CRUD operations.
    /// </summary>
    protected readonly DtoDbContext _databaseContext;

    /// <summary>
    /// The Mediator.
    /// </summary>
    protected readonly IMediator _mediator;
    {{- for query in entity.Queries}}

    /// <summary>
    /// {{query.Description}}
    /// </summary>
    protected readonly {{query.Name}}Base {{ToLowerFirstCharAndAddUnderscore query.Name}};
    {{- end }}

    public {{entity.PluralName}}Controller(
        DtoDbContext _databaseContext,
        IMediator mediator
        {{- for query in entity.Queries}},
        {{query.Name}}QueryBase {{query.Name}}
        {{- end }}
    );
    {
    {{- if entity.Persistence == null || entity.Persistence.Read.IsEnabled }}
        [EnableQuery]
        public async Task<ActionResult<IQueryable<{{entity.Name}}Dto>>> Get()
        {
            var result = await _mediator.Send(new Get{{entity.PluralName}}Query());
            return Ok(result);
        }

        {{if entity.Queries | array.size > 1}}
        OK
        {{else}}
        NOK
        {{end }}
        [EnableQuery]
        public async Task<ActionResult<{{entity.Name}}Dto>> Get(
        {{- if entity.Keys | array.size > 1 }}
            
            {{ routeParams = [] }}
            {{ routeParams = routeParams | array.add entity.Keys[0] }}

            {{ routeParams | array.size }}
                {{- for key in entity.Keys ~}}
                    FromRoute {{ SinglePrimitiveTypeForKey key }} key{{ key.Name}}
                {{- end}}
            
        {{- else -}}
            [FromRoute] {{ SinglePrimitiveTypeForKey entity.Keys[0] }} key
        {{- end -}}
        )
    {{- end }}
    }
}