// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using DtoNameSpace = {{codeGenConventions.DtoNameSpace}};
using PersistenceNameSpace = {{codeGenConventions.PersistenceNameSpace}};

namespace {{codeGenConventions.ApplicationQueriesNameSpace}};

{{- for enumAtt in enumerationAttributes }}
public partial record Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQuery() : IRequest<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForLocalizedEnumeration}}>>;

internal partial class Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQueryHandler: Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQueryHandlerBase
{
    public Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForLocalizedEnumeration}}>>, IRequestHandler<Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQuery, IQueryable<DtoNameSpace.{{enumAtt.EntityNameForLocalizedEnumeration}}>>
{
    public  Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForLocalizedEnumeration}}>> Handle(Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}TranslationsQuery request, CancellationToken cancellationToken)
    {       
        var queryBuilder = ReadOnlyRepository.Query<DtoNameSpace.{{enumAtt.EntityNameForLocalizedEnumeration}}>();
        return Task.FromResult(OnResponse(queryBuilder));       
    }  
}
{{- end}}