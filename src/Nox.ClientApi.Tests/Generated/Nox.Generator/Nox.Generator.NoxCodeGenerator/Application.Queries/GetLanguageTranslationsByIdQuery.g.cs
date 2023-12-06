// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;
using YamlDotNet.Core.Tokens;
using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public record  GetLanguageTranslationsByIdQuery(System.String keyId, Nox.Types.CultureCode CultureCode) : IRequest <IQueryable<LanguageLocalizedDto>>;

internal partial class GetLanguageTranslationsByIdQueryHandler:GetLanguageTranslationsByIdQueryHandlerBase
{
    public  GetLanguageTranslationsByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetLanguageTranslationsByIdQueryHandlerBase:  QueryBase<IQueryable<LanguageLocalizedDto>>, IRequestHandler<GetLanguageTranslationsByIdQuery, IQueryable<LanguageLocalizedDto>>
{
    public  GetLanguageTranslationsByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<LanguageLocalizedDto>> Handle(GetLanguageTranslationsByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.LanguagesLocalized
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId)
                && r.CultureCode == request.CultureCode.Value
            );
        return Task.FromResult(OnResponse(query));
    }
}