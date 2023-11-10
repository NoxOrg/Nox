// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;

using {{codeGeneratorState.ApplicationNameSpace}}.Dto;
using {{codeGeneratorState.PersistenceNameSpace}};

namespace {{codeGeneratorState.ApplicationNameSpace}}.Queries;

public record Get{{entity.Name }}TranslationsByIdQuery({{primaryKeys}}, System.String {{codeGeneratorState.LocalizationCultureField}}) : IRequest <IQueryable<{{entity.Name}}LocalizedDto>>;

internal partial class Get{{entity.Name}}TranslationsByIdQueryHandler:Get{{entity.Name}}TranslationsByIdQueryHandlerBase
{
    public  Get{{entity.Name}}TranslationsByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class Get{{entity.Name}}TranslationsByIdQueryHandlerBase:  QueryBase<IQueryable<{{entity.Name}}LocalizedDto>>, IRequestHandler<Get{{entity.Name}}TranslationsByIdQuery, IQueryable<{{entity.Name}}LocalizedDto>>
{
    public  Get{{entity.Name}}TranslationsByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<{{entity.Name}}LocalizedDto>> Handle(Get{{entity.Name}}TranslationsByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.{{entity.PluralName}}Localized
            .AsNoTracking()
            .Where(r =>
            {{- for key in entity.Keys }}
                r.{{key.Name}}.Equals(request.key{{key.Name}}){{if !for.last}} &&{{end}}
            {{- end -}}
            {{-}}
                && r.CultureCode == request.{{codeGeneratorState.LocalizationCultureField}}
            );
        return Task.FromResult(OnResponse(query));
    }
}