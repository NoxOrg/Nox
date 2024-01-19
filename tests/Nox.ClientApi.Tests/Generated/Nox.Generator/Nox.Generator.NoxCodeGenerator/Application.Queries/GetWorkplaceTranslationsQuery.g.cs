// Generated

#nullable enable

using Microsoft.EntityFrameworkCore;
using MediatR;
using YamlDotNet.Core.Tokens;

using Nox.Application.Queries;
using ClientApi.Application.Dto;
using ClientApi.Infrastructure.Persistence;

namespace ClientApi.Application.Queries;

public partial record  GetWorkplaceTranslationsQuery(System.Int64 keyId) : IRequest <IQueryable<WorkplaceLocalizedDto>>;

internal partial class GetWorkplaceTranslationsQueryHandler:GetWorkplaceTranslationsQueryHandlerBase
{
    public  GetWorkplaceTranslationsQueryHandler(DtoDbContext dataDbContext): base(dataDbContext)
    {
    
    }
}

internal abstract class GetWorkplaceTranslationsQueryHandlerBase:  QueryBase<IQueryable<WorkplaceLocalizedDto>>, IRequestHandler<GetWorkplaceTranslationsQuery, IQueryable<WorkplaceLocalizedDto>>
{
    public  GetWorkplaceTranslationsQueryHandlerBase(DtoDbContext dataDbContext)
    {
        DataDbContext = dataDbContext;
    }

    public DtoDbContext DataDbContext { get; }

    public virtual Task<IQueryable<WorkplaceLocalizedDto>> Handle(GetWorkplaceTranslationsQuery request, CancellationToken cancellationToken)
    {    
        var query = DataDbContext.WorkplacesLocalized
            .AsNoTracking()
            .Where(r =>
                r.Id.Equals(request.keyId));
        return Task.FromResult(OnResponse(query));
    }
}