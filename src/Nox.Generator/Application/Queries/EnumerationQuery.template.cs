// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using DtoNameSpace = {{codeGeneratorState.DtoNameSpace}};
using PersistenceNameSpace = {{codeGeneratorState.PersistenceNameSpace}};

namespace {{codeGeneratorState.ApplicationQueriesNameSpace}};

{{- for enumAtt in enumerationAttributes }}

public record Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}Query() : IRequest<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>>;

internal partial class Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}QueryHandler: Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}QueryHandlerBase
{
    public Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}QueryHandler(PersistenceNameSpace.DtoDbContext dataDbContext): base(dataDbContext){}
}

internal abstract class Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}QueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>>, IRequestHandler<Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}Query, IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>>
{
    public  Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}QueryHandlerBase(PersistenceNameSpace.DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public PersistenceNameSpace.DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>> Handle(Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}Query request, CancellationToken cancellationToken)
    {
        var item = (IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>)DataDbContext.{{entity.PluralName}}{{ Pluralize(enumAtt.Attribute.Name)}}
            .AsNoTracking();
       return Task.FromResult(OnResponse(item));
    }
}
{{- end}}