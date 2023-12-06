// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;
using YamlDotNet.Core.Tokens;
using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record  GetLanguageTranslationsQuery(System.String keyId) : IRequest <IQueryable<LanguageLocalizedDto>>;

internal partial class GetLanguageTranslationsQueryHandler:GetLanguageTranslationsQueryHandlerBase
{
    public  GetLanguageTranslationsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetLanguageTranslationsQueryHandlerBase:  QueryBase<IQueryable<LanguageLocalizedDto>>, IRequestHandler<GetLanguageTranslationsQuery, IQueryable<LanguageLocalizedDto>>
{
    public  GetLanguageTranslationsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<LanguageLocalizedDto>> Handle(GetLanguageTranslationsQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.LanguagesLocalized
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}