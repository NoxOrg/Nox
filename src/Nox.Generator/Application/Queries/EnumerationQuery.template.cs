// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Queries;
using Nox.Application.Repositories;

using DtoNameSpace = {{codeGenConventions.DtoNameSpace}};

namespace {{codeGenConventions.ApplicationQueriesNameSpace}};

{{- for enumAtt in enumerationAttributes }}
public partial record Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}Query(Nox.Types.CultureCode cultureCode) : IRequest<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>>;

internal partial class Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}QueryHandler: Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}QueryHandlerBase
{
    public Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}QueryHandler(IReadOnlyRepository readOnlyRepository): base(readOnlyRepository){}
}

internal abstract class Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}QueryHandlerBase : QueryBase<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>>, IRequestHandler<Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}Query, IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>>
{
    public  Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}QueryHandlerBase(IReadOnlyRepository readOnlyRepository)
    {
        ReadOnlyRepository = readOnlyRepository;
    }

    public IReadOnlyRepository ReadOnlyRepository { get; }

    public virtual Task<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>> Handle(Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}Query request, CancellationToken cancellationToken)
    {
        {{- if enumAtt.Attribute.EnumerationTypeOptions.IsLocalized}}
        {
            var cultureCode = request.cultureCode.Value;
            IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}> queryBuilder =
            from enumValues in ReadOnlyRepository.Query<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>()
            from enumLocalized in ReadOnlyRepository.Query<DtoNameSpace.{{enumAtt.EntityNameForLocalizedEnumeration}}>()
                .Where(l => enumValues.Id == l.Id && l.CultureCode == cultureCode).DefaultIfEmpty()
            select new DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}()
            {
                Id = enumValues.Id,
                Name = enumLocalized.Name ?? "[" + enumValues.Name + "]",
            };
            return Task.FromResult(OnResponse(queryBuilder));
        }
        {{- else }}
        var queryBuilder = ReadOnlyRepository.Query<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>();
        return Task.FromResult(OnResponse(queryBuilder));
        {{- end }}
    }
}
{{- end}}