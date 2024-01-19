// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;

using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public record  GetTestEntityLocalizationTranslationsByIdQuery(System.String keyId, Nox.Types.CultureCode CultureCode) : IRequest <IQueryable<TestEntityLocalizationLocalizedDto>>;

internal partial class GetTestEntityLocalizationTranslationsByIdQueryHandler:GetTestEntityLocalizationTranslationsByIdQueryHandlerBase
{
    public  GetTestEntityLocalizationTranslationsByIdQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityLocalizationTranslationsByIdQueryHandlerBase:  QueryBase<IQueryable<TestEntityLocalizationLocalizedDto>>, IRequestHandler<GetTestEntityLocalizationTranslationsByIdQuery, IQueryable<TestEntityLocalizationLocalizedDto>>
{
    public  GetTestEntityLocalizationTranslationsByIdQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityLocalizationLocalizedDto>> Handle(GetTestEntityLocalizationTranslationsByIdQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityLocalizationsLocalized
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId)
                && r.CultureCode == request.CultureCode.Value
            );
        return Task.FromResult(OnResponse(query));
    }
}