// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using DtoNameSpace = {{codeGenConventions.DtoNameSpace}};
using PersistenceNameSpace = {{codeGenConventions.PersistenceNameSpace}};

namespace {{codeGenConventions.ApplicationQueriesNameSpace}};

{{- for enumAtt in enumerationAttributes }}
public partial record Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQuery() : IRequest<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForLocalizedEnumeration}}>>;

internal partial class Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQueryHandler: Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQueryHandlerBase
{
    public Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQueryHandler(PersistenceNameSpace.DtoDbContext dataDbContext): base(dataDbContext){}
}

internal abstract class Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForLocalizedEnumeration}}>>, IRequestHandler<Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQuery, IQueryable<DtoNameSpace.{{enumAtt.EntityNameForLocalizedEnumeration}}>>
{
    public  Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQueryHandlerBase(PersistenceNameSpace.DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public PersistenceNameSpace.DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForLocalizedEnumeration}}>> Handle(Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQuery request, CancellationToken cancellationToken)
    {
       
        var queryBuilder = DataDbContext.{{entity.PluralName}}{{ Pluralize(enumAtt.Attribute.Name)}}Localized
            .AsNoTracking<DtoNameSpace.{{enumAtt.EntityNameForLocalizedEnumeration}}>();
        return Task.FromResult(OnResponse(queryBuilder));
       
    }  
}
{{- end}}