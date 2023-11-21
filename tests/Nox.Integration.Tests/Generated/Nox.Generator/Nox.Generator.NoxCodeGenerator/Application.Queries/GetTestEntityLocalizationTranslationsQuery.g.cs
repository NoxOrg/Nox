// Generated

#nullable enable

using MediatR;
using Microsoft.EntityFrameworkCore;

using Nox.Application.Commands;
using YamlDotNet.Core.Tokens;
using TestWebApp.Application.Dto;
using TestWebApp.Infrastructure.Persistence;

namespace TestWebApp.Application.Queries;

public partial record  GetTestEntityLocalizationTranslationsQuery(System.String keyId) : IRequest <IQueryable<TestEntityLocalizationLocalizedDto>>;

internal partial class GetTestEntityLocalizationTranslationsQueryHandler:GetTestEntityLocalizationTranslationsQueryHandlerBase
{
    public  GetTestEntityLocalizationTranslationsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetTestEntityLocalizationTranslationsQueryHandlerBase:  QueryBase<IQueryable<TestEntityLocalizationLocalizedDto>>, IRequestHandler<GetTestEntityLocalizationTranslationsQuery, IQueryable<TestEntityLocalizationLocalizedDto>>
{
    public  GetTestEntityLocalizationTranslationsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<TestEntityLocalizationLocalizedDto>> Handle(GetTestEntityLocalizationTranslationsQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.TestEntityLocalizationsLocalized
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}