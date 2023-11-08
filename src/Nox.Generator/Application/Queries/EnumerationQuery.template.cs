// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using DtoNameSpace = {{codeGeneratorState.DtoNameSpace}};
using PersistenceNameSpace = {{codeGeneratorState.PersistenceNameSpace}};

namespace {{codeGeneratorState.ApplicationQueriesNameSpace}};

{{- for enumAtt in enumerationAttributes }}

public partial record Get{{(entity.PluralName)}}{{Pluralize (enumAtt.Attribute.Name)}}Query() : IRequest<IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>>;

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
        {{- if enumAtt.Attribute.EnumerationTypeOptions.IsLocalized}}
        {
             //TODO Culture Code
            IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}> queryBuilder =
            from enumValues in DataDbContext.{{entity.PluralName}}{{ Pluralize(enumAtt.Attribute.Name)}}.AsNoTracking()
            from enumLocalized in DataDbContext.{{entity.PluralName}}{{ Pluralize(enumAtt.Attribute.Name)}}Localized.AsNoTracking()
                .Where(l => enumValues.Id == l.Id && l.CultureCode == "pt-PT").DefaultIfEmpty()
            select new DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}()
            {
                Id = enumValues.Id,
                Name = enumLocalized.Name ?? enumValues.Name,
            };
            return Task.FromResult(OnResponse(queryBuilder));
        }
        {{- else }}
        var queryBuilder = (IQueryable<DtoNameSpace.{{enumAtt.EntityNameForEnumeration}}>)DataDbContext.{{entity.PluralName}}{{ Pluralize(enumAtt.Attribute.Name)}}
            .AsNoTracking();
        return Task.FromResult(OnResponse(queryBuilder));
        {{- end }}
    }
}
{{- end}}