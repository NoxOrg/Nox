﻿// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;
using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.ODataNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Queries;

public record Get{{entity.Name }}ByIdQuery({{entity.KeysFlattenComponentsTypeName[0]}} key) : IRequest<O{{entity.Name}}?>;

public class Get{{entity.Name}}ByIdQueryHandler: IRequestHandler<Get{{entity.Name}}ByIdQuery, O{{entity.Name}}?>
{
    public  Get{{entity.Name}}ByIdQueryHandler(ODataDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public ODataDbContext DataDbContext { get; }

    public Task<O{{entity.Name}}?> Handle(Get{{entity.Name}}ByIdQuery request, CancellationToken cancellationToken)
    {    
        var item = DataDbContext.{{entity.PluralName}}
            .AsNoTracking()
            .SingleOrDefault(r => {{if (entity.Persistence?.IsVersioned ?? true)}}!(r.Deleted == true) && {{end}}r.{{entity.Keys[0].Name}}.Equals(request.key));            
        return Task.FromResult(item);
    }
}